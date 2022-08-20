namespace Week8PicknPay.Models
{
    public class FlutterResponse<T> where T : class
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class FlutterResponseData
    {
        public string Link { get; set; }
    }
}