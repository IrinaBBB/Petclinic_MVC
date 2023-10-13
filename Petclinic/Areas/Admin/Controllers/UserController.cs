using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Models.Shop;
using Petclinic.Repository.IRepository;

namespace Petclinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _db;

        public UserController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}