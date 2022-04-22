using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Week8PicknPay.Areas.Identity.IdentityHostingStartup))]
namespace Week8PicknPay.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}