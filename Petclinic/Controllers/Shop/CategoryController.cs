using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Petclinic.Data;
using Petclinic.Models;

namespace Petclinic.Controllers.Shop
{
    public class CategoryController : Controller
    {
        private readonly ShopDbContext _db;

        public CategoryController(ShopDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
    }
}
