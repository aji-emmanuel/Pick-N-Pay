using System;
using System.Collections.Generic;
using System.Text;
using Week8PicknPay.Database;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public class RequestForm : IRequestForm
    {
        private readonly AppDbContext _appDbContext;

        public RequestForm(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Saves Request details from customers
        /// </summary>
        /// <param name="request"></param>
        public void SaveRequest(Request request)
        {
            request.Id = Guid.NewGuid().ToString();
            _appDbContext.UserRequests.Add(request);
            if(request.Subject!=null && request.Description!=null)
            {
                _appDbContext.SaveChanges();
            }
        }
    }
}
