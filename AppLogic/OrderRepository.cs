using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Order> GetUserOrders(string userId)
        {
            return _appDbContext.Orders
                .Include(order => order.Address)
                .Include(order => order.OrderItems)
                .Where(order => order.UserId == userId);
        }

        public async Task<bool> SaveOrder(Order order)
        {
            _appDbContext.Orders.Add(order);
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}