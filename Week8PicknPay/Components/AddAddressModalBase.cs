using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Week8PicknPay.Models;
using Week8PicknPay.Repository;

namespace Week8PicknPay.Components
{
    public class AddAddressModalBase : ComponentBase
    {
        [Inject] IAddressRepository _addressRepo { get; set; }

        protected CustomFormValidator customFormValidator;

        protected bool show = false;

        protected Address AddressModel = new Address();

        protected async Task HandleSubmit()
        {
            show = await _addressRepo.AddAddressAsync(AddressModel);
        }
    }
}
