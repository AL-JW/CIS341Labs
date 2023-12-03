using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    public class ExercisesController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize]
        public IActionResult Delete() 
        {
            return View();
        }
    }
}
