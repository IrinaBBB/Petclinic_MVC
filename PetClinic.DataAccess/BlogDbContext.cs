using Microsoft.EntityFrameworkCore;
using PetClinic.DataAccess.Entities.Blog;

namespace Petclinic.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}


