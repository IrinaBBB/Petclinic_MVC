using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetClinic.DataAccess;
using Microsoft.AspNetCore.Identity;
using PetClinic.Models.Clinic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Petclinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IdentityContext _db;
        private readonly UserManager<IdentityAppUser> _userManager;

        public UserController(IdentityContext db, UserManager<IdentityAppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userList = _db.IdentityUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                user.Role = role == null ? "None" : roles.FirstOrDefault(u => u.Id == role.RoleId)!.Name;
            }

            return View(userList);
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var userFromDb = _db.IdentityUsers.FirstOrDefault(u => u.Id == userId);
            if (userFromDb == null)
            {
                return NotFound();
            }

            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            var role = userRole.FirstOrDefault(u => u.UserId == userFromDb.Id);
            if (role != null)
            {
                userFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId)!.Id;
            }

            userFromDb.RoleList = _db.Roles.ToList();

            return View(userFromDb);
        }

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}