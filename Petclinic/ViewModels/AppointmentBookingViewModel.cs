using System.ComponentModel.DataAnnotations;

namespace Petclinic.ViewModels
{
    public class AppointmentBookingViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
