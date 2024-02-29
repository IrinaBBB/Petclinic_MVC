using System.ComponentModel.DataAnnotations;

namespace Petclinic.Entities
{
    public class AppointmentBooking
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

        public bool Pending { get; set; } = true;

        public bool Processed { get; set; } = false;
    }
}
