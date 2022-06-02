using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Week8PicknPay.Models
{
    public class Order
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        public string UserId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public Address Address { get; set; }

        public IEnumerable<OrderDetail> OrderItems { get; set; }

        public double OrderTotal { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
