using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week8PicknPay.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestForm _requestForm;

        public RequestController(IRequestForm requestForm)
        {
            _requestForm = requestForm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reply(Request request)
        {
            _requestForm.SaveRequest(request);
            ViewBag.RequestMessage = "Thanks for submitting your request! We will get back to you as soon as possible.";
            return RedirectToAction("Index", "Home");
        }
    }
}
