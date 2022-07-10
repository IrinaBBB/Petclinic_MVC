using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PetClinic.Models.Clinic
{
    public class IdentityAppUser : IdentityUser
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
    }
}