namespace Week8PicknPay.Models
{
    public class VerifyResponse
    {
            public int Id { get; set; }
            public string Tx_Ref { get; set; }
            public int Amount { get; set; }
            public string Currency { get; set; }
            public string Status { get; set; }
    }
}