using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Services;

namespace Week8PicknPay.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;

        public ProfileController(UserManager<User> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var orders = _orderService.GetUserOrders(userId);

            return View(user);
        }

        public ActionResult Edit(User user)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }
    }
}
