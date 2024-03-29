using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Petclinic.DataAccess;
using PetClinic.DataAccess.Seeding;
using System;
using System.Threading.Tasks;
using PetClinic.DataAccess;

namespace Petclinic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var blogContext = services.GetRequiredService<BlogDbContext>();
                var shopContext = services.GetRequiredService<ShopDbContext>();
                await SeedRoles.SeedRolesAsync(roleManager, loggerFactory);
                await SeedBlog.SeedAsync(blogContext, loggerFactory);
                await SeedShop.SeedAsync(shopContext, loggerFactory);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migration");
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
