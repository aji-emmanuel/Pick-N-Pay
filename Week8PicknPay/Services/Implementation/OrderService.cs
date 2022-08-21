using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Models.Enums;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCart _shoppingCart;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IShoppingCart shoppingCart, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
        }

        private static Order Order;

        /// <summary>
        /// Creates and saves a new Order to the database
        /// </summary>
        /// <param name="order"></param>
        public Order CreateOrderCheckout(User user = null)
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (Order == null)
            {
                Order = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    User = user,
                    UserId = user?.Id,
                    Email = user?.Email,
                    OrderItems = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<OrderDetail>>(shoppingCartItems),
                    OrderTotal = _shoppingCart.GetShoppingCartTotal(),
                    OrderTime = DateTime.Now
                };
            }
            return Order;
        }

        public void OrderAddress(Address address)
        {
            if (address != null)
            {
                Order.Address = address;
                Order.AddressId = address.Id;
            }
        }

        public void UpdateOrderPayment(string status, string method)
        {
            Order.PaymentMethod = method;
            Order.PaymentStatus = status;
        }

        public async Task<bool> SaveOrder()
        {
            Order.User = null;
            Order.Address = null;
            foreach (var item in Order.OrderItems)
            {
                item.ProductId = item.Product.ProductId;
                item.Product = null;
            }

            var result = await _unitOfWork.Orders.SaveOrder(Order);
            if (result)
            {
                Order = null;
                _shoppingCart.ClearCart();
            }
            return result;
        }

        public IEnumerable<Order> GetUserOrders(string userId)
        {
            return _unitOfWork.Orders.GetUserOrders(userId);
        }
    }
}
