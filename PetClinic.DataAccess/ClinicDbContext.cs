using Microsoft.EntityFrameworkCore;
using PetClinic.Models.Clinic;

namespace PetClinic.DataAccess
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Visit> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}