using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _httpClient;
        private readonly string BaseUrl;
        private readonly string Token;

        public PaymentService(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseUrl = configuration.GetSection("Flutter:BaseUrl").Value;
            Token = configuration.GetSection("Flutter:Token").Value;
        }

        public async Task<FlutterResponse<FlutterResponseData>> InitiatePaymentAsync(Order order)
        {
            try
            {
                var request = new FlutterRequest()
                {
                    Amount = order.OrderTotal,
                    Customer = new FlutterCustomer { Name = order?.User?.FirstName + order?.User?.LastName, Email = order?.Email },
                    Tx_Ref = order?.Id,
                    Redirect_Url = _configuration.GetSection("Flutter:Redirect").Value
                };
                var requestUrl = _configuration.GetSection("Flutter:PaymentLink").Value;
                if (!string.IsNullOrWhiteSpace(requestUrl))
                {
                    var response = await _httpClient.PostRequestAsync<FlutterRequest, FlutterResponse<FlutterResponseData>>(BaseUrl, requestUrl, request, Token);
                    return response;
                }
                return new FlutterResponse<FlutterResponseData>() { Status = "Failed", Message = "Payment link was not found!" };
            }
            catch (Exception ex)
            {
                return new FlutterResponse<FlutterResponseData>() { Status = "Failed", Message = ex.Message };
            }
        }

        public async Task<FlutterResponse<VerifyResponse>> VerifyPaymentAsync(string transactionRef)
        {
            try
            {
                var requestUrl = _configuration.GetSection("Flutter:VerifyLink").Value + transactionRef;
                if (!string.IsNullOrWhiteSpace(requestUrl))
                {
                    var response = await _httpClient.GetRequestAsync<FlutterResponse<VerifyResponse>>(BaseUrl, requestUrl, Token);
                    return response;
                }
                return new FlutterResponse<VerifyResponse>() { Status = "Failed", Message = "Verification link was not found!" };
            }
            catch (Exception ex)
            {
                return new FlutterResponse<VerifyResponse>() { Status = "Failed", Message = ex.Message };
            }
        }
    }
}