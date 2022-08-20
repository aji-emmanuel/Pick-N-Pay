using Newtonsoft.Json;

namespace Week8PicknPay.Models
{
    public class FlutterRequest
    {
        [JsonProperty("customer")]
        public FlutterCustomer Customer { get; set; }

        [JsonProperty("tx_ref")]
        public string Tx_Ref { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("redirect_url")]
        public string Redirect_Url { get; set; }
    }

    public class FlutterCustomer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
