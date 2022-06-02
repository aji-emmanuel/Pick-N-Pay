using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week8PicknPay.Models
{
    public class OrderCheckout
    {
        public Order Order { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
