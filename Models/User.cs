using Microsoft.AspNetCore.Identity;

namespace Week8PicknPay.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
