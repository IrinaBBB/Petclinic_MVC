using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Clinic
{
    public class Visit
    {
        public int Id { get; set; }

        public Pet Pet { get; set; }

        public DateTime VisitDate { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}