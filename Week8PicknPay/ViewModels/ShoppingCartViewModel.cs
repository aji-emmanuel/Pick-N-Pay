
using Week8PicknPay.Repository;

namespace Week8PicknPay.ViewModels
{
    /// <summary>
    /// Model for displaying the shopping cart page
    /// </summary>
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
