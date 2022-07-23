using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Services
{
    public interface IOrderService
    {
        Order CreateOrderCheckout(User user);
        void OrderAddress(Address address);
        IEnumerable<Order> GetUserOrders(string userId);
        Task<bool> SaveOrder();
    }
}