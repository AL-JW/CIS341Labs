using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    public class UserProfileDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile() 
        {

            return View();  
            
        }

        public IActionResult Subscription()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }


        public IActionResult Picture()
        {
            return View();
        }

        public IActionResult LatestWorkout() 
        {
            return View();
        }
    }
}
