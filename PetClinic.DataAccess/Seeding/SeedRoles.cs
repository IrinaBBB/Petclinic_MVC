using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PetClinic.Utility;

namespace PetClinic.DataAccess.Seeding
{
    public class SeedRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            try
            {
                if (! await roleManager.RoleExistsAsync(Constants.RoleAdmin))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.RoleAdmin));
                }

                if (!await roleManager.RoleExistsAsync(Constants.RoleUser))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.RoleUser));
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedRoles>();
                logger.LogError(ex.Message);
            }
        }
    }
}