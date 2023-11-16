using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WorkoutTrackingApp.Models;
using WorkoutTrackingApp.Data;

namespace WorkoutTrackingApp.Controllers
{

    public class WorkoutsController : Controller
    {
        private readonly WorkoutTrackingAppContext _context; // Define your database context

        public WorkoutsController(WorkoutTrackingAppContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public IActionResult Create(Workout workout)
        {
            if (ModelState.IsValid)
            {
                // Logic to save workout to database
                return RedirectToAction("Index");
            }

            return View(workout);

        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workout = _context.Workouts.First(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        [HttpPost]
        public IActionResult Edit(Workout workout)
        {
            if (ModelState.IsValid)
            {
                // Update the workout in the database
                _context.Update(workout);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(workout);
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
