using System.Collections.Generic;

namespace Week8PicknPay.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int CategoryId { get; set; }
        public bool IsTopDeal { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
