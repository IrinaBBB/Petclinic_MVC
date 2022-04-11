using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Petclinic.Entities;


namespace Petclinic.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions options) : base(options) { }

        public DbSet<IdentityAppUser> IdentityUsers { get; set; }
    }
}