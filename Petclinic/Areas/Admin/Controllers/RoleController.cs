using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetClinic.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using PetClinic.DataAccess.Entities.Identity;

namespace Petclinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IdentityContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(IdentityContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                var role = _db.Roles.FirstOrDefault(x => x.Id == id);
                return View(role);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole role)
        {
            if (await _roleManager.RoleExistsAsync(role.Name))
            {
                ReturnTempMessage("danger", "Role already exists");
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrEmpty(role.Id))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.Name });
                ReturnTempMessage("warning", $"Role '{role.Name}' has been created.");
            }
            else
            {
                var roleFromDb = _db.Roles.FirstOrDefault(u => u.Id == role.Id);
                roleFromDb!.Name = role.Name;
                roleFromDb.NormalizedName = role.Name.ToUpper();
                var result = await _roleManager.UpdateAsync(roleFromDb);
                ReturnTempMessage("warning", "Role has been updated.");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var role = _db.Roles.FirstOrDefault(u => u.Id == id);
            if (role != null) return View(role);
            ReturnTempMessage("danger", "Error");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole role)
        {
            var roleFromDb = _db.Roles.FirstOrDefault(u => u.Id == role.Id);
            if (roleFromDb != null)
            {
                _db.Roles.Remove(roleFromDb);
                await _db.SaveChangesAsync();
                ReturnTempMessage("warning", $"Role '{roleFromDb.Name}' has been removed.");
            }
            return RedirectToAction(nameof(Index));
        }

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}