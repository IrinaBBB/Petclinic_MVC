//using System;
//using System.IO;
//using System.Linq;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Petclinic.Areas.Admin.ViewModels;
//using PetClinic.Models.Shop;
//using Petclinic.Repository.IRepository;

//namespace Petclinic.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class CompanyController : Controller
//    {
//        private readonly IUnitOfWork _db;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public CompanyController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
//        {
//            _db = db;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public IActionResult Index()
//        {
//            var objProductList = _db.Company.GetAll();
//            return View(objProductList);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult Create(Company company)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Company.Add(company);
//                _db.Save();
//                ReturnTempMessage("success", $"Company '{company.Name}' has been created.");
//                return RedirectToAction("Index");
//            }

//            ReturnTempMessage("danger", "Something went wrong! We could not create new company :(");
//            return View("Create");
//        }

//        public IActionResult Edit(int? id)
//        {
//            if (id is null or 0)
//            {
//                return NotFound();
//            }

//            var companyFromDb = _db.Company.GetFirstOrDefault(u => u.Id == id);
//            if (companyFromDb == null)
//            {
//                return NotFound();
//            }

//            return View(companyFromDb);
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult Edit(Company company)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Company.Update(company);
//                _db.Save();
//                ReturnTempMessage("success", $"Product '{company.Name}' has been updated.");
//                return RedirectToAction("Index");
//            }

//            ReturnTempMessage("danger", "Something went wrong! We could not update company :(");
//            return View("Edit");
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id is null or 0)
//            {
//                return NotFound();
//            }

//            var companyFromDb = _db.Company.GetFirstOrDefault(u => u.Id == id);
//            if (companyFromDb == null)
//            {
//                return NotFound();
//            }

//            return View(companyFromDb);
//        }

//        [HttpPost, ActionName("Delete")]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult DeletePost(int? id)
//        {
//            var obj = _db.Company.GetFirstOrDefault(u => u.Id == id);
//            if (obj is null) return NotFound();

//            _db.Company.Remove(obj);
//            _db.Save();
//            ReturnTempMessage("danger", $"Company '{obj.Name}' is deleted.");
//            return RedirectToAction("Index");
//        }

//        private void ReturnTempMessage(string type, string message)
//        {
//            TempData["Message"] = message;
//            TempData["Type"] = type;
//        }
//    }
//}