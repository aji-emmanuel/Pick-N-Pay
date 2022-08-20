using System.Threading.Tasks;

namespace Week8PicknPay.Services
{
    public interface IHttpClientService
    {
        Task<TRes> GetRequestAsync<TRes>(string baseUrl, string url, string token = null) where TRes : class;
        Task<TRes> PostRequestAsync<TReq, TRes>(string baseUrl, string url, TReq requestModel, string token = null)
            where TReq : class
            where TRes : class;
    }
}