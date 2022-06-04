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

        private static Order Order;

        /// <summary>
        /// Creates and saves a new Order to the database
        /// </summary>
        /// <param name="order"></param>
        public Order CreateOrderCheckout(User user)
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if(Order == null)
            {
                Order = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    User = user,
                    UserId = user.Id,
                    Email = user.Email,
                    OrderItems = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<OrderDetail>>(shoppingCartItems),
                    OrderTotal = _shoppingCart.GetShoppingCartTotal(),
                    OrderTime = DateTime.Now
                };
            }

            // _appDbContext.Orders.Add(order);
            //  _appDbContext.SaveChanges();
            return Order;
        }

        public bool OrderAddress(Address address)
        {
            Order.Address = address;
            return Order.Address != null;
        }
    }
}
