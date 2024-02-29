using Petclinic.Entities;

namespace Petclinic.ViewModels
{
    public class HomePageViewModel
    {
        public List<Vet> Vets { get; set; }

        public AppointmentBookingViewModel AppointmentBookingViewModel { get; set; } 
            = new AppointmentBookingViewModel();
    }
}

