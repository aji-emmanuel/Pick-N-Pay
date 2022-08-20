using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Services
{
    public interface IPaymentService
    {
        Task<FlutterResponse<FlutterResponseData>> InitiatePaymentAsync(Order order);
        Task<FlutterResponse<VerifyResponse>> VerifyPaymentAsync(string transactionRef);
    }
}