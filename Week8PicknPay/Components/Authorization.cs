using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Threading.Tasks;

namespace Week8PicknPay.Components
{
    public class Authorization : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode("/shoppingcart");
                NavigationManager.NavigateTo($"/Identity/Account/Login?returnUrl={returnUrl}");
            }
        }
    }
}
