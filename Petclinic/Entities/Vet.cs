using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petclinic.Entities
{
    public class Vet : Person
    {
        public List<Specialty> Specialties { get; set; }
    }
}