using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Models.Shop;
using Petclinic.Repository.IRepository;

namespace Petclinic.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Category.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            category.DisplayOrder ??= 100;

            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.Save();
                ReturnTempMessage("success", $"Category '{category.Name}' has been created.");
                return RedirectToAction("Index");
            }

            ReturnTempMessage("danger", "Something went wrong! We could not create new category :(");
            return View("Create");
        }

        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category category)
        {
            category.DisplayOrder ??= 100;

            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.Save();
                return RedirectToAction("Index");
            }

            ReturnTempMessage("danger", "Something went wrong! We could not create new category :(");
            return View("Create");
        }

        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj is null) return NotFound();
            _db.Category.Remove(obj);
            _db.Save();
            ReturnTempMessage("danger", $"Category '{obj.Name}' is deleted.");
            return RedirectToAction("Index");
        }

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}