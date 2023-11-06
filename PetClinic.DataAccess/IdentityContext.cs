using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.DataAccess.Entities.Identity;


namespace PetClinic.DataAccess
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        public DbSet<ApplicationUser> IdentityUsers { get; set; }
    }
}