using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetClinic.Models.Clinic;

namespace Petclinic.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppointmentOrder model)
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return Redirect(Url.Action("Index", "Home") + "#location");
        }

        [Authorize]
        public IActionResult Blog()
        {
            return View();
        }
    }
}
