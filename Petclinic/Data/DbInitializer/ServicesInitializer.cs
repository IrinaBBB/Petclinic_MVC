using Microsoft.AspNetCore.Identity;
using Petclinic.Entities;

namespace Petclinic.Data.DbInitializer
{
    public static class ServicesInitializer
    {
        public static async Task InitializeServices(DataContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Services.Any())
            {
                List<Service> services = new List<Service>
                {
                    // Services for cats
                    new Service { Name = "Cat Wellness Exam", Description = "Comprehensive health check-up for cats", Price = 50.00m, Type = "cats" },
                    new Service { Name = "Spaying", Description = "Surgical procedure for female cats", Price = 120.00m, Type = "cats" },
                    new Service { Name = "Dental Cleaning", Description = "Professional dental cleaning for cats", Price = 80.00m, Type = "cats" },
                    new Service { Name = "Cat Vaccination", Description = "Vaccination for common cat diseases", Price = 40.00m, Type = "cats" },
                    new Service { Name = "Cat Neutering", Description = "Surgical procedure for male cats", Price = 100.00m, Type = "cats" },
                    new Service { Name = "Feline Grooming", Description = "Professional grooming services for cats", Price = 60.00m, Type = "cats" },
                    new Service { Name = "Cat Behavioral Consultation", Description = "Consultation for cat behavioral issues", Price = 70.00m, Type = "cats" },
                    new Service { Name = "Feline Boarding", Description = "Boarding services for cats", Price = 25.00m, Type = "cats" },

                    // Services for dogs
                    new Service { Name = "Dog Wellness Exam", Description = "Comprehensive health check-up for dogs", Price = 60.00m, Type = "dogs" },
                    new Service { Name = "Dog Vaccination", Description = "Vaccination for common dog diseases", Price = 45.00m, Type = "dogs" },
                    new Service { Name = "Dog Neutering", Description = "Surgical procedure for male dogs", Price = 110.00m, Type = "dogs" },
                    new Service { Name = "Canine Dental Cleaning", Description = "Professional dental cleaning for dogs", Price = 90.00m, Type = "dogs" },
                    new Service { Name = "Dog Grooming", Description = "Professional grooming services for dogs", Price = 70.00m, Type = "dogs" },
                    new Service { Name = "Dog Behavioral Consultation", Description = "Consultation for dog behavioral issues", Price = 80.00m, Type = "dogs" },
                    new Service { Name = "Canine Boarding", Description = "Boarding services for dogs", Price = 30.00m, Type = "dogs" },

                    // Services for exotic animals
                    new Service { Name = "Exotic Animal Consultation", Description = "Specialized consultation for exotic pets", Price = 80.00m, Type = "exotic animals" },
                    new Service { Name = "Reptile Health Check-up", Description = "Health check-up for reptiles", Price = 55.00m, Type = "exotic animals" },
                    new Service { Name = "Avian Wing Clipping", Description = "Trimming bird's wings to prevent flight", Price = 35.00m, Type = "exotic animals" },

                    // Services for rodents
                    new Service { Name = "Rodent Dental Care", Description = "Dental care for rodents", Price = 50.00m, Type = "rodents" },
                    new Service { Name = "Rodent Parasite Treatment", Description = "Treatment for common parasites in rodents", Price = 40.00m, Type = "rodents" },

                    // Services for birds
                    new Service { Name = "Avian Wellness Exam", Description = "Comprehensive health check-up for birds", Price = 55.00m, Type = "birds" },
                    new Service { Name = "Avian Vaccination", Description = "Vaccination for common bird diseases", Price = 35.00m, Type = "birds" },
                    new Service { Name = "Avian Grooming", Description = "Professional grooming services for birds", Price = 45.00m, Type = "birds" },
                    new Service { Name = "Avian Behavioral Consultation", Description = "Consultation for bird behavioral issues", Price = 60.00m, Type = "birds" },
                    new Service { Name = "Avian Boarding", Description = "Boarding services for birds", Price = 20.00m, Type = "birds" }
                };
                context.AddRange(services);
                await context.SaveChangesAsync();
            }
        }
    }
}
