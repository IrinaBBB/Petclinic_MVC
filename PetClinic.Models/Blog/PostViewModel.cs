using System.ComponentModel.DataAnnotations;
using System;
using PetClinic.Models.Clinic;

namespace PetClinic.Models.Blog
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
        public IdentityAppUser Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}
