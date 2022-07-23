using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(string userId);
        Task<bool> SaveOrder(Order order);
    }
}