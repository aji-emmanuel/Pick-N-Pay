using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string userId);
    }
}