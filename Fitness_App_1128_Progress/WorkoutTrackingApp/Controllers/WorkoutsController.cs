using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WorkoutTrackingApp.Models;
using WorkoutTrackingApp.ViewModels;
using WorkoutTrackingApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WorkoutTrackingApp.Controllers
{
    [AllowAnonymous]
    public class WorkoutsController : Controller
    {
        private readonly WorkoutTrackingAppContext _context; // Define your database context

        public WorkoutsController(WorkoutTrackingAppContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //This is the main workouts page
            //Has list of all of the workouts
            var workouts = _context.Workouts.ToList(); // Fetch workouts from the database
            return View(workouts);
        }

        //[Authorize]
        public IActionResult Create()
        {
            ViewBag.ExerciseList = _context.Exercises.ToList();

            return View("ManageWorkouts", new Workout());
        }

        [HttpPost]
        public IActionResult Create(Workout workout, List<int> SelectedExercises)
        {
            if (ModelState.IsValid)
            {
                // Manually populate properties
                //  workout.WorkoutExercises = new List<WorkoutExercise>(); // Initialize the collection
                // workout.Exercises = new List<Exercise>(); // Initialize the collection
                // Create a list of WorkoutExercise objects to associate exercises with the workout
                //workout.WorkoutExercises = new List<WorkoutExercise>();
                // Retrieve the list of exercises from the database and store them in ViewBag
                // Associate selected exercises with the workout
                if (SelectedExercises != null)
                {
                    workout.Exercises = _context.Exercises.Where(e => SelectedExercises.Contains(e.ExerciseId)).ToList();
                }

                // Logic to save workout to database

                _context.Workouts.Add(workout);
                _context.SaveChanges(); // Save the changes to the database

                return RedirectToAction("Index");
            }

            // Retrieve the list of exercises to populate the checkboxes again if there are validation errors
            ViewBag.ExerciseList = _context.Exercises.ToList();

            return View("ManageWorkouts",  workout);

        }

       // [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workout = _context.Workouts
                          .Include(w => w.Exercises) // Include related data if necessary
                          .FirstOrDefault(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            ViewBag.ExerciseList = _context.Exercises.ToList();
            return View("ManageWorkouts", workout);
        }

       // [Authorize]
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

            // Repopulate ViewBag.ExerciseList if returning the view after a failed validation
            ViewBag.ExerciseList = _context.Exercises.ToList();
            return View("ManageWorkouts", workout);
        }



      //  [Authorize]
        public IActionResult Delete()
        {
            return View();
        }

      //  [Authorize]
        public IActionResult History()
        {
            return View();
        }

    }
}
