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
        private readonly IAddressRepository _addressRepository;

        public OrderRepository(AppDbContext appDbContext, IShoppingCart shoppingCart, IMapper mapper, IAddressRepository addressRepository)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Creates and saves a new Order to the database
        /// </summary>
        /// <param name="order"></param>
        public OrderCheckout CreateOrderCheckout(User user)
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                User = user,
                UserId = user.Id,
                Email = user.Email,
                OrderItems = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<OrderDetail>>(shoppingCartItems),
                OrderTotal = _shoppingCart.GetShoppingCartTotal(),
                OrderTime = DateTime.Now
            };
            var addresses = _addressRepository.GetUserAddresses(user.Id);

            // _appDbContext.Orders.Add(order);
            //  _appDbContext.SaveChanges();
            return new OrderCheckout() { Order = order, Addresses = addresses };
        }
    }
}
