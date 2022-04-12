using System.Collections.Generic;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        bool AddToCart(Product product, int amount);
        void ClearCart();
        List<ShoppingCartItem> GetShoppingCartItems();
        double GetShoppingCartTotal();
        void IncreaseQty(int productId);
        void DecreaseQty(int productId);
        int RemoveFromCart(int productId);
    }
}