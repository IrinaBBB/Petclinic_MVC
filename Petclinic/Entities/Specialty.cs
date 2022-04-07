using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Petclinic.Entities
{
    public class Specialty
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Vet> Vets { get; set; }

    }
}