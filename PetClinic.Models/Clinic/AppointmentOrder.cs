using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Clinic
{
    public class AppointmentOrder
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Processed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}