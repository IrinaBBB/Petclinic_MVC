using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetClinic.DataAccess;
using Microsoft.AspNetCore.Identity;
using PetClinic.Models.Clinic;
using System.Linq;

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

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}