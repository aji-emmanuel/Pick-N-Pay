using System.Collections.Generic;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Services
{
    public interface IOrderService
    {
        Order CreateOrderCheckout(User user = null);
        void OrderAddress(Address address);
        void UpdateOrderPayment(string status, string method);
        IEnumerable<Order> GetUserOrders(string userId);
        Task<bool> SaveOrder();
    }
}