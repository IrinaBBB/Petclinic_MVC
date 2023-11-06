using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Petclinic.Areas.Customer.ViewModels;
using Petclinic.Repository.IRepository;

namespace Petclinic.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            //var productList = _db.Product.GetAll("Category");
            //var viewModel = new IndexShopViewModel
            //{
            //    Products = productList,
            //};
            //return View(viewModel);
            return View();
        }

        //public IActionResult Details(int? productId)
        //{
        //    var product = _db.Product.GetFirstOrDefault(u => u.Id == productId, "Category");
        //    var viewModel = new ShoppingCartViewModel
        //    {
        //        Product = product,
        //        Count = 1
        //    };
        //    return View(viewModel);
        //}
    }
}