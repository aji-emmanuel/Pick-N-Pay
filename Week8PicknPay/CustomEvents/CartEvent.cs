using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week8PicknPay.CustomEvents
{
    public class CartEvent
    {
        public static event EventHandler UpdateCartSummary;

        public static void OnCartChange(EventArgs e) //protected virtual method
        {
            //if UpdateCartSummary is not null then call delegate
            UpdateCartSummary?.Invoke(new CartEvent(), e);
        }
    }
}
