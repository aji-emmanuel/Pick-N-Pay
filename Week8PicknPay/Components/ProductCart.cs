using Microsoft.AspNetCore.Components;

namespace Week8PicknPay.Components
{
    public class ProductCart : ComponentBase
    {
        public bool show = false;

        public int productQty = 1;

        public void IncreaseQty()
        {
            productQty++;
        }

        public void DecreaseQty()
        {
            if (productQty - 1 > 0)
            {
                productQty--;
            }
        }

        public void CloseNotification()
        {
            show = false;
        }
    }
}
