﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Services;

namespace Week8PicknPay.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> InitiatePayment()
        {
            var response = await _paymentService.InitiatePaymentAsync();
            if(response.Data != null)
            {
                return Redirect(response.Data.Link);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Verify([FromQuery]string tx_ref)
        {
            await _paymentService.VerifyPaymentAsync(tx_ref);
            return RedirectToAction("Checkout", "Order");
        }
    }
}