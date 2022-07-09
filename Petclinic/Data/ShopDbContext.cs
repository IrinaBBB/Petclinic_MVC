using Microsoft.EntityFrameworkCore;
using Petclinic.Models;

namespace Petclinic.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}