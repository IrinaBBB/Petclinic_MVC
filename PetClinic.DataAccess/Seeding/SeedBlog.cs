using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using PetClinic.DataAccess.Entities.Blog;
using Petclinic.DataAccess;

namespace PetClinic.DataAccess.Seeding
{
    public class SeedBlog
    {
        public static async Task SeedAsync(BlogContext context, ILoggerFactory loggerFactory)
        {
            var posts = new List<Post>
            {
                new()
                {
                    Title = "The Importance of Regular Vet Visits for Your Furry Friend",
                    Body =
                        "Regular Vet Visits: A Key to Your Pet's Long and Healthy Life\r\n\r\nAs a loving pet owner, you want the best for your furry friend. One of the most important ways to ensure their well-being is through regular vet visits. These check-ups are not just for when your pet is sick; they play a vital role in maintaining their overall health and happiness.\r\n\r\nEarly Detection of Health Issues: Just like humans, pets can develop a variety of health conditions. Many of these issues, if detected early, can be effectively managed or even cured. Regular vet visits allow your veterinarian to identify potential health concerns before they become serious. This early detection can make a huge difference in your pet's quality of life.\r\n\r\nPreventive Care: An ounce of prevention is worth a pound of cure. Through routine vet visits, your pet can receive essential vaccinations and preventative treatments for issues like parasites and dental problems. Preventive care is often more cost-effective and less stressful for both you and your pet compared to dealing with illnesses or conditions that could have been prevented.\r\n\r\nTailored Wellness Plans: Every pet is unique, and their healthcare needs can vary. Your veterinarian can create a personalized wellness plan that takes into account your pet's age, breed, and lifestyle. Whether it's nutrition, exercise, or other aspects of their care, these plans can help your pet thrive.\r\n\r\nThe Human-Animal Bond: Regular vet visits also serve as an opportunity to strengthen the bond between you and your pet. These visits can be a positive and stress-free experience for your pet, helping them feel more comfortable around the vet and reducing anxiety during future visits.\r\n\r\nIn conclusion, regular vet visits are a cornerstone of responsible pet ownership. By staying proactive in your pet's healthcare, you're giving them the best chance for a longer, healthier life filled with love and happiness.\r\n\r\nPost 2: \"Top 5 Common Pet Allergies and How to Manage Them\"\r\n\r\nTop 5 Common Pet Allergies: Understanding and Managing Your Pet's Health\r\n\r\nJust like people, pets can develop allergies that affect their well-being. Allergies in pets can manifest in various ways, from sneezing and itching to digestive problems. In this blog post, we'll explore the top 5 common pet allergies and provide insights into how to manage and alleviate their effects.\r\n\r\nEnvironmental Allergies: Pollen, dust mites, and mold can trigger allergies in pets, leading to symptoms like sneezing, itching, and skin rashes. These allergies are often seasonal. To manage them, your vet may recommend antihistamines, allergy shots, or lifestyle changes to reduce exposure to allergens.\r\n\r\nFlea Allergies: Fleas are a common annoyance for pets, and some animals are allergic to flea saliva. Even a single flea bite can cause severe itching and discomfort. Regular flea prevention is key to managing this allergy, along with treating your pet and their environment if an infestation occurs.\r\n\r\nFood Allergies: Pets can be allergic to certain ingredients in their food, such as proteins like chicken, beef, or grains. Common signs of food allergies include skin issues and digestive problems. Your vet can perform food trials to identify the allergen and recommend an appropriate diet.\r\n\r\nContact Allergies: Your pet may develop skin reactions to various substances they come into contact with, such as cleaning products, plants, or fabrics. Identifying and removing the irritant is the primary solution to these allergies.\r\n\r\nInhalant Allergies: Pets can be sensitive to inhaled allergens like smoke, perfumes, or household cleaners. Reducing exposure to these irritants and providing good ventilation in your home can help manage inhalant allergies.\r\n\r\nManaging your pet's allergies involves working closely with your veterinarian to identify the allergen and develop a tailored treatment plan. Allergies can significantly impact your pet's quality of life, so it's essential to address them proactively.",
                    AuthorId = "4c90a058-9904-44f9-86c2-3f58ff5d7687",
                    Created = new DateTime(2022, 08, 09, 12, 30, 00)
                },
                new()
                {
                    Title = "Top 5 Common Pet Allergies and How to Manage Them",
                    Body =
                        "Top 5 Common Pet Allergies: Understanding and Managing Your Pet's Health\r\n\r\nJust like people, pets can develop allergies that affect their well-being. Allergies in pets can manifest in various ways, from sneezing and itching to digestive problems. In this blog post, we'll explore the top 5 common pet allergies and provide insights into how to manage and alleviate their effects.\r\n\r\nEnvironmental Allergies: Pollen, dust mites, and mold can trigger allergies in pets, leading to symptoms like sneezing, itching, and skin rashes. These allergies are often seasonal. To manage them, your vet may recommend antihistamines, allergy shots, or lifestyle changes to reduce exposure to allergens.\r\n\r\nFlea Allergies: Fleas are a common annoyance for pets, and some animals are allergic to flea saliva. Even a single flea bite can cause severe itching and discomfort. Regular flea prevention is key to managing this allergy, along with treating your pet and their environment if an infestation occurs.\r\n\r\nFood Allergies: Pets can be allergic to certain ingredients in their food, such as proteins like chicken, beef, or grains. Common signs of food allergies include skin issues and digestive problems. Your vet can perform food trials to identify the allergen and recommend an appropriate diet.\r\n\r\nContact Allergies: Your pet may develop skin reactions to various substances they come into contact with, such as cleaning products, plants, or fabrics. Identifying and removing the irritant is the primary solution to these allergies.\r\n\r\nInhalant Allergies: Pets can be sensitive to inhaled allergens like smoke, perfumes, or household cleaners. Reducing exposure to these irritants and providing good ventilation in your home can help manage inhalant allergies.\r\n\r\nManaging your pet's allergies involves working closely with your veterinarian to identify the allergen and develop a tailored treatment plan. Allergies can significantly impact your pet's quality of life, so it's essential to address them proactively.",
                    AuthorId = "4c90a058-9904-44f9-86c2-3f58ff5d7687",
                    Created = new DateTime(2023, 01, 04, 20, 34, 00)
                },
                new()
                {
                    Title = "How to Keep Your Pet's Teeth Healthy and Strong",
                    Body =
                        "Smile Bright: The Key to Your Pet's Overall Health\r\n\r\nOral health is a critical but often overlooked aspect of your pet's overall well-being. Just like humans, pets can suffer from dental problems that impact their quality of life. In this post, we'll explore the importance of dental care for your furry friend and provide tips for maintaining their dental hygiene.\r\n\r\nThe Importance of Dental Health: Dental issues can cause pain, discomfort, and even lead to more severe health problems if left untreated. Common dental problems in pets include gum disease, tartar buildup, and tooth decay. By prioritizing dental health, you can ensure your pet's comfort and well-being.\r\n\r\nSigns of Dental Problems: It's essential to be aware of the signs of dental issues in your pet. These may include bad breath, drooling, difficulty eating, pawing at the mouth, and inflamed or bleeding gums. If you notice any of these signs, it's time to consult your vet for a dental check-up.\r\n\r\nRegular Teeth Cleaning: Brushing your pet's teeth regularly is one of the most effective ways to maintain their dental health. Use a pet-specific toothbrush and toothpaste, and introduce this routine gradually to make it a positive experience for your pet. Dental chews and toys can also help reduce plaque and tartar.\r\n\r\nProfessional Dental Care: Your veterinarian can perform professional dental cleanings to remove tartar and address more serious dental problems. These cleanings often require anesthesia to ensure a thorough examination and cleaning.\r\n\r\nDiet and Dental Health: Feeding your pet a balanced diet that promotes dental health can make a difference. There are specially formulated foods designed to reduce tartar and promote oral hygiene.\r\n\r\nIn conclusion, a healthy smile leads to a happy pet. Prioritizing your pet's dental health not only ensures their comfort but also contributes to their overall well-being. Consult with your veterinarian to create a dental care plan tailored to your pet's needs.",
                    AuthorId = "4c90a058-9904-44f9-86c2-3f58ff5d7687",
                    Created = new DateTime(2023, 02, 12, 13, 12, 00)
                },
                new()
                {
                    Title = "Adopt, Don't Shop: The Benefits of Rescuing a Shelter Pet",
                    Body =
                        "Adopting a Shelter Pet: A Win-Win for You and Your Furry Friend\r\n\r\nWhen it comes to bringing a new pet into your home, the choice to adopt from a shelter is a decision that benefits both you and the pet in need. In this blog post, we'll explore the advantages of adopting a shelter pet and share heartwarming stories that highlight the rewards of giving a shelter animal a forever home.\r\n\r\nSave a Life: By choosing to adopt a shelter pet, you're literally saving a life. Shelters are often overcrowded, and many pets face the risk of euthanasia if they don't find a loving home. Your decision to adopt can be a life-changing act of kindness.\r\n\r\nTemperament Assessment: Many shelter pets undergo temperament assessments, which help match you with a pet that suits your lifestyle and personality. This ensures a better chance of a harmonious and lasting bond.\r\n\r\nHealth and Behavioral Support: Shelter pets often receive medical and behavioral care while in the shelter. This means you're adopting a pet that has been assessed, vaccinated, and spayed or neutered. Some shelters even offer post-adoption support and training resources.\r\n\r\nCost-Effective: Adopting from a shelter is typically more cost-effective than purchasing from a breeder or pet store. The adoption fee often covers initial vaccinations, spaying/neutering, and sometimes even microchipping",
                    AuthorId = "4c90a058-9904-44f9-86c2-3f58ff5d7687",
                    Created = new DateTime(2023, 06, 13, 13, 13, 00)
                },
            };


            try
            {
                if (!context.Posts.Any())
                {
                    foreach (var post in posts)
                    {
                        context.Posts.Add(post);
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