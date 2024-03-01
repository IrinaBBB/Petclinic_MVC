using Microsoft.AspNetCore.Mvc;
using Petclinic.Models;
using System.Diagnostics;
using Petclinic.Entities;
using Petclinic.Data;
using Petclinic.ViewModels;
using Petclinic.Extensions;

namespace Petclinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var homePageViewModel = new HomePageViewModel
            {
                Vets = _context.Vets.ToList()
            };
            return View(homePageViewModel);
        }

        public IActionResult Services()
        {
            var services = _context.Services.ToList();
            return View(services);
        }



        [HttpPost]
        public IActionResult Book(HomePageViewModel model)
        {
            var appointment = new AppointmentBooking 
            { 
                Name = model.AppointmentBookingViewModel.Name,
                Email = model.AppointmentBookingViewModel.Email,
                PhoneNumber = model.AppointmentBookingViewModel.PhoneNumber,
                Description = model.AppointmentBookingViewModel.Description,
            };

            _context.AppointmentBookings.Add(appointment);
            _context.SaveChanges();
         
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
