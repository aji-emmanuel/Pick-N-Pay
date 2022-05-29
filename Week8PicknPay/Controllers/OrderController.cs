using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IAddressRepository _addressRepository;

        public OrderController(UserManager<User> userManager, IOrderRepository orderRepository, IShoppingCart shoppingCart, IAddressRepository addressRepository)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Returns the checkout view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var order = _orderRepository.CreateOrder(user);
            var addresses = _addressRepository.GetUserAddresses(userId);
            return View(new OrderCheckout() {Order = order, Addresses = addresses});
        }
        
        public IActionResult CheckoutComplete()
        {
            _shoppingCart.ClearCart();
            ViewBag.CheckoutCompleteMessage = "Thanks for patronizing PicknPay!";
            return View();
        }
    }
}
