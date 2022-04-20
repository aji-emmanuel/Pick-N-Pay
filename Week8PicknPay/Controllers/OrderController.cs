using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week8PicknPay.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Returns the checkout view
        /// </summary>
        /// <returns></returns>
        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// Displays all products in the shopping cart
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //var items = _shoppingCart.GetShoppingCartItems();
            //if (items.Count == 0)
            //{
            //    ModelState.AddModelError("", "Your cart is empty, add some products first!");
            //    return RedirectToAction("Index", "ShoppingCart");
            //}
            _orderRepository.CreateOrder(order);
            _shoppingCart.ClearCart();
            return RedirectToAction("CheckoutComplete");
        }

        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for patronizing PicknPay!";
            return View();
        }
    }
}
