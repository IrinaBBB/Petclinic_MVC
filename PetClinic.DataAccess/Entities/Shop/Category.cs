using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataAccess.Entities.Shop
{
    public class Category
    {
        public int Id { get; set; }


        [DisplayName("Category Name")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 250 characters")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }


        [DisplayName("Description")] public string Description { get; set; }


        [DisplayName("Display Order")]
        [Required(ErrorMessage = "Display Order is required")]
        [Range(1, 200, ErrorMessage = "Display Order cannot be greater than 200 and less than 1")]
        public int? DisplayOrder { get; set; }


        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}