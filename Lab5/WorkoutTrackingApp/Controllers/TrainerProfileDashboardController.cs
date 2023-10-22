using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    public class TrainerProfileDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult ManageWorkouts()
        {
            return View();
        }

        public IActionResult ManageExercises()
        {

            return View();
        }

        public IActionResult Subscribers()
        {
            return View();
        }

        public IActionResult PopularWorkouts()
        {
            return View();
        }

    }
}
