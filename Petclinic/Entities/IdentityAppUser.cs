using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Petclinic.Entities
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