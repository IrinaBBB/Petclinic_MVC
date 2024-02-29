using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Petclinic.Entities;
using System.Net;

namespace Petclinic.Data.DbInitializer
{
    public static class VetInitializer
    {
        public static async Task InitializeVets(DataContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Vets.Any())
            {
                var alex = new ApplicationUser
                {
                    UserName = "alex@uit.no",
                    Email = "alex@uit.no"
                };

                await userManager.CreateAsync(alex, "Pa$$w0rd");
                await userManager.AddToRoleAsync(alex, "Vet");

                var vetAlex = new Vet
                {
                    FirstName = "Alex",
                    LastName = "Johnson",
                    Address = "123 Main St",
                    City = "Anytown",
                    Telephone = "555-1234",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1709134731/nvjcogmnhj3gpvnpoiom.jpg",
                    ApplicationUser = alex,
                    About = "Dr. Alex Johnson is a highly skilled veterinarian specializing in surgical veterinary medicine. With a gentle touch and precise expertise, he ensures the best possible outcomes for his patients. Dr. Alex Johnson is dedicated to providing comprehensive care and support to both animals and their owners."
                };

                context.Vets.Add(vetAlex);

                var michael = new ApplicationUser
                {
                    UserName = "michael@uit.no",
                    Email = "michael@uit.no"
                };

                await userManager.CreateAsync(michael, "Pa$$w0rd");
                await userManager.AddToRoleAsync(michael, "Vet");

                var vetMichael = new Vet
                {
                    FirstName = "Michael",
                    LastName = "Brown",
                    Address = "789 Oak St",
                    City = "Somewhere",
                    Telephone = "555-9012",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1709135181/mb9spasmfaqivi21devv.jpg",
                    ApplicationUser = michael,
                    About = "Dr. Michael Brown is an expert in orthopedic veterinary medicine, specializing in diagnosing and treating musculoskeletal conditions in animals. With advanced training and cutting-edge techniques, he restores mobility and improves the quality of life for his patients. Dr. Brown is dedicated to providing compassionate care and innovative solutions for orthopedic issues in pets."
                };

                context.Vets.Add(vetMichael);

                var sophia = new ApplicationUser
                {
                    UserName = "sophia@uit.no",
                    Email = "sophia@uit.no"
                };

                await userManager.CreateAsync(sophia, "Pa$$w0rd");
                await userManager.AddToRoleAsync(sophia, "Vet");

                var vetSophia = new Vet
                {
                    FirstName = "Sophia",
                    LastName = "Martinez",
                    Address = "654 Cedar St",
                    City = "Anywhere",
                    Telephone = "555-7890",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1709135181/brkqfbkdsnjgcyljkpzm.jpg",
                    ApplicationUser = sophia,
                    About = "Dr. Sophia Martinez specializes in emergency veterinary medicine, providing urgent care to pets in critical situations. With quick thinking and expert medical skills, she stabilizes patients and ensures they receive immediate attention. Dr. Martinez is dedicated to being a reliable source of support for pet owners during stressful and challenging times."
                };

                context.Vets.Add(vetSophia);


                var emma = new ApplicationUser
                {
                    UserName = "emma@uit.no",
                    Email = "emma@uit.no"
                };

                await userManager.CreateAsync(emma, "Pa$$w0rd");
                await userManager.AddToRoleAsync(emma, "Vet");

                var vetEmma = new Vet
                {
                    FirstName = "Emma",
                    LastName = "Wilson",
                    Address = "789 Oak St",
                    City = "Somewhere",
                    Telephone = "555-9012",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1709135188/rskbunmqbuazkh5argsa.jpg",
                    ApplicationUser = emma,
                    About = "Dr. Emma Wilson specializes in dental veterinary medicine, ensuring that pets have healthy teeth and gums. With a focus on preventive care and advanced dental procedures, she helps pets maintain optimal oral health. Dr. Wilson is committed to educating pet owners on the importance of dental hygiene for their furry companions."
                };

                context.Vets.Add(vetEmma);

                var olivia = new ApplicationUser
                {
                    UserName = "olivia@uit.no",
                    Email = "olivia@uit.no"
                };

                await userManager.CreateAsync(olivia, "Pa$$w0rd");
                await userManager.AddToRoleAsync(olivia, "Vet");

                var vetOlivia = new Vet
                {
                    FirstName = "Olivia",
                    LastName = "Taylor",
                    Address = "987 Birch St",
                    City = "Somewhere",
                    Telephone = "555-2345",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1623190215/xqbteybvqkt8cyyurzya.jpg",
                    ApplicationUser = olivia,
                    About = "Dr. Olivia Taylor specializes in oncology veterinary medicine, focusing on the diagnosis and treatment of cancer in animals. With compassion and expertise, he develops personalized treatment plans to improve outcomes and enhance the quality of life for his patients. Dr. Taylor is committed to supporting pet owners through every step of their pet's cancer journey."
                };

                context.Vets.Add(vetOlivia);

                var isabella = new ApplicationUser
                {
                    UserName = "isabella@uit.no",
                    Email = "isabella@uit.no"
                };

                await userManager.CreateAsync(isabella, "Pa$$w0rd");
                await userManager.AddToRoleAsync(isabella, "Vet");

                var vetIsabella = new Vet
                {
                    FirstName = "Isabella",
                    LastName = "Garcia",
                    Address = "789 Maple St",
                    City = "Somewhere",
                    Telephone = "555-6789",
                    ImageUrl = "https://res.cloudinary.com/dhjmbyt4n/image/upload/v1620632084/s6rswnywhw6erelye27e.jpg",
                    ApplicationUser = isabella,
                    About = "Dr. Isabella Garcia specializes in exotic animal medicine, catering to the unique needs of non-traditional pets. With a deep understanding of exotic species and their specific health requirements, she provides comprehensive care and guidance to exotic pet owners. Dr. Garcia is passionate about promoting the well-being of all creatures, no matter how rare or unusual."
                };

                context.Vets.Add(vetIsabella);

                await context.SaveChangesAsync();
            }
        }      
    }
}
