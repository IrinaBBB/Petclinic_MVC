using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Petclinic.Areas.Identity.IdentityHostingStartup))]
namespace Petclinic.Areas.Identity
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