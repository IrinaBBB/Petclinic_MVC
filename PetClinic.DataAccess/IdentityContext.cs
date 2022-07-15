using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.Models.Clinic;

namespace PetClinic.DataAccess
{
    public class IdentityContext : IdentityDbContext<IdentityAppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        public DbSet<IdentityAppUser> IdentityUsers { get; set; }
    }
}