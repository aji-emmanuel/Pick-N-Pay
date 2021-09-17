using System.Collections.Generic;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        void AddToCart(Product product, int amount);
        void ClearCart();
        List<ShoppingCartItem> GetShoppingCartItems();
        double GetShoppingCartTotal();
        int RemoveFromCart(Product product);
    }
}