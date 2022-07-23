using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private static string UserId { get; set; }

        public AddressService(IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        public async Task<bool> AddAddressAsync(Address address)
        {
            address.Id = Guid.NewGuid().ToString();
            address.UserId = UserId;
            var success = await _unitOfWork.Addresses.AddAddressAsync(address);
            if (success)
            {
                _orderService.OrderAddress(address);
            }
            return success;
        }

        public IEnumerable<Address> GetUserAddresses(string userId)
        {
            UserId = userId;
            return _unitOfWork.Addresses.GetUserAddresses(userId);
        }

        public async Task<bool> RemoveAddressAsync(Address address)
        {
            return await _unitOfWork.Addresses.RemoveAddressAsync(address);
        }
    }
}