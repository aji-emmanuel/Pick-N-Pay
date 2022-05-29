using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Address
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string HouseNo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Street length must be less than 50 characters.")]
        public string Street { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "City length must be less than 50 characters.")]
        public string City { get; set; }

        [Required]
        public string LGA { get; set; }

        [Required]
        public string State { get; set; }
    }
}
