using System;
using System.Collections.Generic;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, IShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Creates and saves a new Order to the database
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail               //adding the order with its details
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}
