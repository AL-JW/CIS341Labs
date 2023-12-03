using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return RedirectToAction("Index", "UserProfileDashboard");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
