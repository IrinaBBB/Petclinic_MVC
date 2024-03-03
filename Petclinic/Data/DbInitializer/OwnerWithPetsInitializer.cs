using Microsoft.AspNetCore.Identity;
using Petclinic.Entities;

namespace Petclinic.Data.DbInitializer
{
    public static class OwnerWithPetsInitializer
    {
        public static async Task InitializeOwnersWithPets(DataContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Owners.Any())
            {
                var anna = new ApplicationUser
                {
                    UserName = "anna@uit.no",
                    Email = "anna@uit.no"
                };

                await userManager.CreateAsync(anna, "Pa$$w0rd");
                await userManager.AddToRoleAsync(anna, "User");

                var ownerAnna = new Owner
                {
                    FirstName = "Anna",
                    LastName = "Larsen",
                    Address = "123 Maple St",
                    City = "Anytown",
                    Telephone = "555-1234",
                    ImageUrl = "",
                    ApplicationUser = anna,
                };
                var annasPet = new Pet
                {
                    Name = "Lucky", 
                    BirthDate = new DateTime(2020, 11, 12),
                    PetType = "Cat"
                };

                ownerAnna.Pets.Add(annasPet);
                context.Owners.Add(ownerAnna);

                var bob = new ApplicationUser
                {
                    UserName = "bob@uit.no",
                    Email = "bob@uit.no"
                };

                await userManager.CreateAsync(bob, "Pa$$w0rd");
                await userManager.AddToRoleAsync(bob, "User");

                var ownerBob = new Owner
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    Address = "3192 Matthews Street",
                    City = "Chicago",
                    Telephone = "815-600-1710",
                    ImageUrl = "",
                    ApplicationUser = bob,
                };
                var bobsPet = new Pet
                {
                    Name = "Max",
                    BirthDate = new DateTime(2019, 09, 11),
                    PetType = "dog"
         
                };

                ownerAnna.Pets.Add(bobsPet);
                context.Owners.Add(ownerBob);

                var charlie = new ApplicationUser
                {
                    UserName = "charlie@uit.no",
                    Email = "charlie@uit.no"
                };

                await userManager.CreateAsync(charlie, "Pa$$w0rd");
                await userManager.AddToRoleAsync(charlie, "User");

                var ownerCharlie = new Owner
                {
                    FirstName = "Charlie ",
                    LastName = "Brown",
                    Address = "78 Nuzum Court",
                    City = "New York",
                    Telephone = "815-600-1710",
                    ImageUrl = "",
                    ApplicationUser = charlie,
                };
                var charliesPet = new Pet
                {
                    Name = "Buddy",
                    BirthDate = new DateTime(2019, 09, 11),
                    PetType = "bird"
                };

                ownerCharlie.Pets.Add(charliesPet);
                context.Owners.Add(ownerCharlie);

                await context.SaveChangesAsync();
            }
        }
    }
}
