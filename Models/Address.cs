namespace Week8PicknPay.Models
{
    public class Address
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string LGA { get; set; }
        public string State { get; set; }
    }
}
