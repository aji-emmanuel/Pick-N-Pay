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

       
        public IActionResult Reply(Request request)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }

            _requestForm.SaveRequest(request);
            return RedirectToAction("Index", "Home");
        }
    }
}
