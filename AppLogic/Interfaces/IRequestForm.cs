using System.Collections.Generic;
using Week8PicknPay.Models;

namespace Week8PicknPay.Repository
{
    public interface IRequestForm
    {
        void SaveRequest(Request request);
    }
}