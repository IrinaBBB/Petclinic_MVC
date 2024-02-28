using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Petclinic.Entities;

namespace Petclinic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}