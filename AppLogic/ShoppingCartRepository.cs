using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Returns a specific shopping cart using shopping cart id
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        /// <summary>
        ///  Adds a product from a specific shopping cart using product id and shopping cart id
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public bool AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = amount
                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            return _appDbContext.SaveChanges() > 0;
        }


        /// <summary>
        /// Increases the quantity of a product in a shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        public void IncreaseQty(int productId)
        {
            var shoppingCartItem =
                   _appDbContext.ShoppingCartItems.SingleOrDefault(
                       s => s.Product.ProductId == productId && s.ShoppingCartId == ShoppingCartId);
            shoppingCartItem.Amount++;
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Decreases the quantity of a product in a shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        public void DecreaseQty(int productId)
        {
            var shoppingCartItem =
                   _appDbContext.ShoppingCartItems.SingleOrDefault(
                       s => s.Product.ProductId == productId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem.Amount-1 >=1)
            {
                shoppingCartItem.Amount--;
                _appDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a product from a specific shopping cart using product id and shopping cart id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int RemoveFromCart(int productId)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == productId && s.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            return _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Returns all products in a specific shopping cart using the shopping cart id.
        /// </summary>
        /// <returns></returns>
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            var list =  _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList();
            return list;
        }

        /// <summary>
        /// Clears all products from a specific shopping cart using shopping cart id
        /// </summary>
        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Returns the total sum of the prices of all the products in a shopping cart
        /// </summary>
        /// <returns></returns>
        public double GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
    }
}
