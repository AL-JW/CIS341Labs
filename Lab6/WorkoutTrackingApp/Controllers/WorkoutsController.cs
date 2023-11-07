using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackingApp.Controllers
{
    public class WorkoutsController : Controller
    {
        public IActionResult Index()
        {
            //This is the main workouts page
            //Has list of all of the workouts
            return View();
        }

        public IActionResult Create()
        {

            return View();

        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit() 
        { 
        
            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }


        public IActionResult History()
        {
            return View();
        }

    }
}
