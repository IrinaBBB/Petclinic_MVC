using System.ComponentModel.DataAnnotations;
using System;
using PetClinic.DataAccess.Entities.Identity;

namespace PetClinic.ViewModel.Blog
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        [StringLength(450)]
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}
