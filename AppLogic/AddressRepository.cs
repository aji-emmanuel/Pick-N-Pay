using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Address> _addresses;
        private static string UserId { get; set; }
        public AddressRepository(AppDbContext context)
        {
            _context = context;
            _addresses = _context.Set<Address>();
        }

        public async Task<bool> AddAddressAsync(Address address)
        {
            address.Id = Guid.NewGuid().ToString();
            address.UserId = UserId;
            _addresses.Add(address);
            return await _context.SaveChangesAsync() > 0;
        }

        public IEnumerable<Address> GetUserAddresses(string userId)
        {
            UserId = userId;
            return _addresses.Where(x => x.UserId == userId);
        }

        public async Task<bool> RemoveAddressAsync(Address address)
        {
            _addresses.Remove(address);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
