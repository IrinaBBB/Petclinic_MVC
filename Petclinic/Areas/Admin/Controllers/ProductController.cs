//using System;
//using System.IO;
//using System.Linq;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Petclinic.Areas.Admin.ViewModels;
//using Petclinic.Repository.IRepository;

//namespace Petclinic.Areas.Admin.Controllers
//{
//    [Area("Admin")]

//    public class ProductController : Controller
//    {
//        private readonly IUnitOfWork _db;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
//        {
//            _db = db;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public IActionResult Index()
//        {
//            var objProductList = _db.Product.GetAll("Category");
//            return View(objProductList);
//        }

//        public IActionResult Create()
//        {
//            var viewModel = new CreateProductViewModel
//            {
//                Categories = _db.Category.GetAll().Select(
//                    u => new SelectListItem
//                    {
//                        Text = u.Name,
//                        Value = u.Id.ToString()
//                    })
//            };
//            return View(viewModel);
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult Create(CreateProductViewModel viewModel, IFormFile? file)
//        {

//            if (ModelState.IsValid)
//            {
//                if (file != null)
//                {
//                    var wwwRootPath = _webHostEnvironment.WebRootPath;
//                    var fileName = Guid.NewGuid().ToString();
//                    var uploads = Path.Combine(wwwRootPath, @"app_images\products");
//                    var extension = Path.GetExtension(file.FileName);

//                    using (var fileStream =
//                           new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
//                    {
//                        file.CopyTo(fileStream);
//                    };
//                    viewModel.Product.ImageUrl = @"app_images\products\" + fileName + extension;
//                }

//                _db.Product.Add(viewModel.Product);
//                _db.Save();
//                ReturnTempMessage("success", $"Product '{viewModel.Product.Name}' has been created.");
//                return RedirectToAction("Index");
//            }

//            ReturnTempMessage("danger", "Something went wrong! We could not create new product :(");
//            return View("Create");
//        }

//        public IActionResult Edit(int? id)
//        {
//            if (id is null or 0)
//            {
//                return NotFound();
//            }

//            var productFromDb = _db.Product.GetFirstOrDefault(u => u.Id == id);
//            if (productFromDb == null)
//            {
//                return NotFound();
//            }

//            var viewModel = new EditProductViewModel
//            {
//                Product = productFromDb,
//                Categories = _db.Category.GetAll().Select(
//                    u => new SelectListItem
//                    {
//                        Text = u.Name,
//                        Value = u.Id.ToString()
//                    })
//            };

//            return View(viewModel);
//        }

//        [HttpPost]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult Edit(EditProductViewModel viewModel, IFormFile? file)
//        {
//            if (ModelState.IsValid)
//            {
//                if (file != null)
//                {
//                    var wwwRootPath = _webHostEnvironment.WebRootPath;
//                    var fileName = Guid.NewGuid().ToString();
//                    var uploads = Path.Combine(wwwRootPath, @"app_images\products");
//                    var extension = Path.GetExtension(file.FileName);

//                    using (var fileStream =
//                           new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
//                    {
//                        file.CopyTo(fileStream);
//                    };
//                    viewModel.Product.ImageUrl = @"app_images\products\" + fileName + extension;
//                    var productFromDb = _db.Product.GetFirstOrDefault(u => u.Id == viewModel.Product.Id);
//                    if (productFromDb != null && productFromDb.ImageUrl != null)
//                    {
//                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productFromDb.ImageUrl.TrimStart('\\'));
//                        DeleteImage(oldImagePath);
//                    }
//                }

//                _db.Product.Update(viewModel.Product);
//                _db.Save();
//                ReturnTempMessage("success", $"Product '{viewModel.Product.Name}' has been updated.");
//                return RedirectToAction("Index");
//            }

//            ReturnTempMessage("danger", "Something went wrong! We could not update product :(");
//            return View("Create");
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id is null or 0)
//            {
//                return NotFound();
//            }

//            var productFromDb = _db.Product.GetFirstOrDefault(u => u.Id == id);
//            if (productFromDb == null)
//            {
//                return NotFound();
//            }

//            var viewModel = new DeleteProductViewModel
//            {
//                Product = productFromDb,
//                Categories = _db.Category.GetAll().Select(
//                    u => new SelectListItem
//                    {
//                        Text = u.Name,
//                        Value = u.Id.ToString()
//                    })
//            };

//            return View(viewModel);
//        }

//        [HttpPost, ActionName("Delete")]
//        [AutoValidateAntiforgeryToken]
//        public IActionResult DeletePost(int? id)
//        {
//            var obj = _db.Product.GetFirstOrDefault(u => u.Id == id);
//            if (obj is null) return NotFound();

//            if (obj.ImageUrl != null)
//            {
//                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
//                DeleteImage(oldImagePath);
//            }
            
//            _db.Product.Remove(obj);
//            _db.Save();
//            ReturnTempMessage("danger", $"Product '{obj.Name}' is deleted.");
//            return RedirectToAction("Index");
//        }

//        private void ReturnTempMessage(string type, string message)
//        {
//            TempData["Message"] = message;
//            TempData["Type"] = type;
//        }
//        private static void DeleteImage(string imagePath)
//        {
//            if (System.IO.File.Exists(imagePath))
//            {
//                System.IO.File.Delete(imagePath);
//            }
//        }
//    }

    
//}