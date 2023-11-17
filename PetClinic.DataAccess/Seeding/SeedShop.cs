using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinic.DataAccess.Entities.Shop;
using System.Linq;
using System;

namespace PetClinic.DataAccess.Seeding
{
    public class SeedShop
    {
        public static async Task SeedAsync(ShopDbContext context, ILoggerFactory loggerFactory)
        {
            var categories = new List<Category>
            {
                new()
                {
                    Name = "Pet Food",
                    Description = "High-quality pet food is essential for your furry friends' health and well-being. Find a wide selection of dry, wet, and raw pet food options to suit your pet's dietary needs.",
                    DisplayOrder = 1
                },
                new()
                {
                    Name = "Pet Treats",
                    Description = "Reward your pets with a variety of delicious and nutritious treats. These snacks can be used for training or simply to show your pets some love.",
                    DisplayOrder = 2
                },
                new()
                {
                    Name = "Toys and Enrichment",
                    Description = "Keep your pets mentally and physically stimulated with a range of toys, from squeaky toys for dogs to feather wands for cats. Enrichment items like puzzle feeders are also available to engage their minds.",
                    DisplayOrder = 3
                },
                new()
                {
                    Name = "Pet Grooming Supplies",
                    Description = "Maintain your pet's hygiene with grooming products such as brushes, shampoos, nail clippers, and pet-safe cleaning solutions. Your pet will look and feel their best.",
                    DisplayOrder = 4
                },
                new()
                {
                    Name = "Health and Wellness Products",
                    Description = "Promote your pet's well-being with supplements, vitamins, and health-related products. You can find flea and tick treatments, dental care items, and first-aid supplies.",
                    DisplayOrder = 5
                },
                new()
                {
                    Name = "Aquarium and Fish Supplies",
                    Description = "If you have aquatic pets, we offer a wide range of aquariums, fish food, water conditioners, and accessories to create a thriving underwater environment.",
                    DisplayOrder = 6
                },
                new()
                {
                    Name = "Bird Supplies",
                    Description = "From birdcages and perches to birdseed and toys, our selection of avian products caters to the needs of your feathered friends.",
                    DisplayOrder = 7
                },
                new()
                {
                    Name = "Reptile and Exotic Pet Accessories",
                    Description = "Find heating lamps, terrariums, substrates, and other essentials for reptiles and exotic pets, ensuring their habitats mimic their natural environment.",
                    DisplayOrder = 8
                },
                new()
                {
                    Name = "Small Animal Supplies",
                    Description = "For hamsters, guinea pigs, rabbits, and other small pets, we offer cages, bedding, hay, and toys to keep them happy and healthy.",
                    DisplayOrder = 9
                },
            };

            try
            {
                if (!context.Categories.Any())
                {
                    foreach (var category in categories)
                    {
                        context.Categories.Add(category);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedBlog>();
                logger.LogError(ex.Message);
            }
        }
    }
}