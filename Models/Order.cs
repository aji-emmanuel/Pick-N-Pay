using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public double OrderTotal { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime OrderTime { get => DateTime.Now; }
    }
}
