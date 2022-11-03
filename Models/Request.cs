using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Request
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Subject { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Description { get; set; }
    }
}
