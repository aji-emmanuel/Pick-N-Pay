using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Services;


namespace Week8PicknPay.Components
{
    public class ProfileBase : ComponentBase
    {
        [Inject] UserManager<User> UserManager { get; set; }
        [Inject] IOrderService OrderService { get; set; }
        [Inject] IAddressService AddressService { get; set; }

        protected CustomFormValidator customFormValidator;

        [Parameter] public string Id { get; set; }

        protected IEnumerable<Order> orders;
        protected List<Address> addresses;
        protected Address delete;

        protected bool showAccountInfo = true;
        protected bool showOrderHistory = false;
        protected bool showAddress = false;
        protected bool showPendingRating = false;

        protected User user = new User();

        protected IdentityResult result;

        protected async override void OnInitialized()
        {
            user = await UserManager.FindByIdAsync(Id);
            orders = OrderService.GetUserOrders(Id);
        }

        protected void LoadAddress()
        {
            ShowAddress();
            addresses = AddressService.GetUserAddresses(Id).ToList();

        }

        protected async Task HandleSubmit()
        {
            result = await UserManager.UpdateAsync(user);
        }

        protected void SetDelete(Address address)
        {
            delete = address;
        }
        protected async Task DeleteAddress(Address address)
        {
            var result = await AddressService.RemoveAddressAsync(address);
            if (result)
            {
                addresses.Remove(address);
                SetDelete(null);
            }
        }


        private void ShowAddress()
        {
            showAccountInfo = false;
            showOrderHistory = false;
            showPendingRating = false;
            showAddress = true;
        }
    }
}