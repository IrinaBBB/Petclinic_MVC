#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PetClinic.Models.Clinic
{
    public class IdentityAppUser : IdentityUser
    {
        [Required] [StringLength(128)] public string? FirstName { get; set; }
        [Required] [StringLength(128)] public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        [NotMapped] public string? RoleId { get; set; }
        [NotMapped] public string? Role { get; set; }
        [NotMapped] public IEnumerable<IdentityRole>? RoleList { get; set; }
    }
}

