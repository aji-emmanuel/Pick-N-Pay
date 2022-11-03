using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Services;

namespace Week8PicknPay.Components
{
    public class AddAddressModalBase : ComponentBase
    {
        [Inject] IAddressService _addressService { get; set; }

        protected CustomFormValidator customFormValidator;

        protected bool show = false;

        protected Address AddressModel = new Address();

        protected async Task HandleSubmit()
        {
            show = await _addressService.AddAddressAsync(AddressModel);
        }

        protected void Dismiss()
        {
            show = false;
            AddressModel = new Address();
        }
    }
}
