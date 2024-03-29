﻿using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Clinic
{
    public class PetType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}