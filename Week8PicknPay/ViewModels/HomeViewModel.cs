using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Models;

namespace Week8PicknPay.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> TopDealProducts { get; set; }
    }
}
