using Microsoft.AspNetCore.Mvc;
using Petclinic.Data;
using Petclinic.ViewModels;

namespace Petclinic.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public OwnerController(ILogger<HomeController> logger, DataContext context)
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
    }
}

