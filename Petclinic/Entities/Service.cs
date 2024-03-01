using System.ComponentModel.DataAnnotations;

namespace Petclinic.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
