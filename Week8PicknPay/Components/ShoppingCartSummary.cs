using Microsoft.AspNetCore.Mvc;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetShoppingCartItems();
            //_shoppingCart.ShoppingCartItems = items;

            //var shoppingCartViewModel = new ShoppingCartViewModel
            //{
            //    ShoppingCart = _shoppingCart,
            //    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            //};
            return View();
        }
    }
}
