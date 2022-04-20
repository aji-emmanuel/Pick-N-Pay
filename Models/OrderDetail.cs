using System;

namespace Week8PicknPay.Models
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
