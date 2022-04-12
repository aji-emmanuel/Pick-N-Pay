using Microsoft.AspNetCore.Mvc;

namespace Week8PicknPay.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
