using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Shop
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 200)]
        public int? DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}