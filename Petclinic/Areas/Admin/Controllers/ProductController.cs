using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petclinic.Areas.Admin.ViewModels;
using PetClinic.Models.Shop;
using Petclinic.Repository.IRepository;

namespace Petclinic.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;

        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objProductList = _db.Product.GetAll();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProductViewModel
            {
                Categories = _db.Category.GetAll().Select(
                    u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    })
            };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                _db.Product.Add(product);
                _db.Save();
                ReturnTempMessage("success", $"Product '{product.Name}' has been created.");
                return RedirectToAction("Index");
            }

            ReturnTempMessage("danger", "Something went wrong! We could not create new product :(");
            return View("Create");
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.GetFirstOrDefault(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Update(product);
                _db.Save();
                return RedirectToAction("Index");
            }

            ReturnTempMessage("danger", "Something went wrong! We could not create new product :(");
            return View("Create");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.GetFirstOrDefault(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj is null) return NotFound();
            _db.Product.Remove(obj);
            _db.Save();
            ReturnTempMessage("danger", $"Product '{obj.Name}' is deleted.");
            return RedirectToAction("Index");
        }

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}