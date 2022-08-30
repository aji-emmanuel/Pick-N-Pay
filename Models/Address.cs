using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d{0,3}?[a-zA-Z]?$", ErrorMessage = "Not a valid house number (e.g 20, 20a, 20A)")]
        public string HouseNo { get; set; }

        [Required]
        [RegularExpression(@"^(?:[A-Z]\d|[^\W\d_]{2,}\.?)(?:[- '’][^\W\d_]+\.?)*$", ErrorMessage = "Street can only contain alphabets")]
        [StringLength(50, ErrorMessage = "Street length must be less than 50 characters.")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^(?:[A-Z]\d|[^\W\d_]{2,}\.?)(?:[- '’][^\W\d_]+\.?)*$", ErrorMessage = "City can only contain alphabets")]
        [StringLength(50, ErrorMessage = "City length must be less than 50 characters.")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^(?:[A-Z]\d|[^\W\d_]{2,}\.?)(?:[- '’][^\W\d_]+\.?)*$", ErrorMessage = "LGA can only contain alphabets")]
        public string LGA { get; set; }

        [Required]
        [RegularExpression(@"^(?:[A-Z]\d|[^\W\d_]{2,}\.?)(?:[- '’][^\W\d_]+\.?)*$", ErrorMessage = "State can only contain alphabets")]
        public string State { get; set; }
    }
}
