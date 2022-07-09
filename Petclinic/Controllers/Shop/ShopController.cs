using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petclinic.Data;

namespace Petclinic.Controllers.Shop
{
    public class ShopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _db;

        public ShopController(ILogger<HomeController> logger, ShopDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}