using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name length must be greater than 1 and less than 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name length must be greater than 1 and less than 30 characters.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression("[0-9]", ErrorMessage = "Not a valid number")]
        public string HouseNo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage ="Street length must be less than 50 characters.")]
        public string Street { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "City length must be less than 50 characters.")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LGA { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string State { get; set; }
    }
}
