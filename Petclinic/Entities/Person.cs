using System;
using System.ComponentModel.DataAnnotations;

namespace Petclinic.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(128)]
        public string City { get; set; }

        [Required]
        [MaxLength(128)]
        public string Telephone { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}