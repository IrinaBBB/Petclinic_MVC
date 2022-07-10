using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Clinic
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
    }
}