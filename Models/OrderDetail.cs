namespace Week8PicknPay.Models
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public double SubTotal { get; set; }
        public Order Order { get; set; }
    }
}
