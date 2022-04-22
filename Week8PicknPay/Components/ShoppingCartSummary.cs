using Microsoft.AspNetCore.Mvc;

namespace Week8PicknPay.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
