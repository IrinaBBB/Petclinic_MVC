using Microsoft.AspNetCore.Identity;
using Petclinic.Entities;

namespace Petclinic.Data.DbInitializer
{
    public static class DbInitializer
    {
        public static async Task Initialize(DataContext context, UserManager<ApplicationUser> userManager)
        {
            await VetInitializer.InitializeVets(context, userManager);
        }
    }
}
