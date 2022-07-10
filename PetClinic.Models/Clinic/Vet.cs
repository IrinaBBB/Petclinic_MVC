using System.Collections.Generic;

namespace PetClinic.Models.Clinic
{
    public class Vet : Person
    {
        public List<Specialty> Specialties { get; set; }
    }
}