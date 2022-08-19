using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Services;

namespace Week8PicknPay.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;

        public OrderController(UserManager<User> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var orderCheckout = _orderService.CreateOrderCheckout(user);
            
            return View(orderCheckout);
        }
    }
}
