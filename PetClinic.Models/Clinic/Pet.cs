using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Clinic
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public PetType PetType { get; set; }

        public Owner Owner { get; set; }
    }
}