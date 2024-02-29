using Microsoft.AspNetCore.Mvc;
using Petclinic.Models;
using System.Diagnostics;
using Petclinic.Entities;
using Petclinic.Data;
using Petclinic.ViewModels;

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

        [HttpPost]
        public IActionResult Index(AppointmentOrder model)
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return Redirect(Url.Action("Index", "Home") + "#location");
        }

        public IActionResult Blog()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
