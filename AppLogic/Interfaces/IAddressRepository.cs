﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IAddressRepository
    {
        Task<bool> AddAddressAsync(Address address);
        IEnumerable<Address> GetUserAddresses(string userId);
        Task<bool> RemoveAddressAsync(Address address);
    }
}
