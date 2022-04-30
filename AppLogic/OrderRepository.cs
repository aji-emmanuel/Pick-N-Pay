using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrderRepository(AppDbContext appDbContext, IShoppingCart shoppingCart, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates and saves a new Order to the database
        /// </summary>
        /// <param name="order"></param>
        public Order CreateOrder(User user)
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            //foreach (var item in shoppingCartItems)
            //{
            //    orderItems.Add(new OrderDetail()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        OrderId = Guid.NewGuid().ToString(),
            //        Product = item.Product,
            //        Quantity = item.Quantity
            //    });
            //}


            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                OrderItems = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<OrderDetail>>(shoppingCartItems),
                OrderTotal = _shoppingCart.GetShoppingCartTotal(),
                OrderTime = DateTime.Now
            };
           // _appDbContext.Orders.Add(order);
          //  _appDbContext.SaveChanges();
            return order;
        }
    }
}
