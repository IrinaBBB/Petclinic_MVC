using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petclinic.Repository.IRepository;

namespace Petclinic.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Blog.GetBlogMainViewModelAsync());
        }
    }
}
