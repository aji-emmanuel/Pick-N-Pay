using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

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


        public void NewsLetter(string email)
        {
            var result = _requestForm.SaveNewsLetterMail(email);
            ViewBag["Subscribe"] = result;
        }
    }
}
