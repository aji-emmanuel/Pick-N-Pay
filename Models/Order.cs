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

        public User User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public IEnumerable<OrderDetail> OrderItems { get; set; }

        [Required]
        public double OrderTotal { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public string PaymentMethod { get; set; }

        public bool PayOnDelivery { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }
    }
}
