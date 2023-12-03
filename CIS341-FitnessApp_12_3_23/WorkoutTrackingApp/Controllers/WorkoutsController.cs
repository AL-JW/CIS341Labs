using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WorkoutTrackingApp.Models;
using WorkoutTrackingApp.ViewModels;
using WorkoutTrackingApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WorkoutTrackingApp.Controllers
{
    [AllowAnonymous]
    public class WorkoutsController : Controller
    {
        private readonly WorkoutTrackingAppContext _context; // Defining the database context

        private readonly UserManager<IdentityUser> _userManager; // UserManager

        public WorkoutsController(WorkoutTrackingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // This is the main workouts page
            // Has list of all of the logged in user workouts
            // Get the current user's ID
            var userId = _userManager.GetUserId(User);

            // Get workouts from the database that belong to the logged-in user
            var workouts = _context.Workouts.Where(w => w.UserId == userId).ToList();

            // var workouts = _context.Workouts.ToList(); // This gets all the workouts from the database
            return View(workouts);
        }

        //[Authorize]
        public IActionResult Create()
        {
            ViewBag.ExerciseList = _context.Exercises.ToList();
            return View("ManageWorkouts", new Workout());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Workout workout, List<int> SelectedExercises)
        {
            // Get the logged in users ID
            var userId = _userManager.GetUserId(User);

            // Assign the user ID to the workout
            workout.UserId = userId;

            if (ModelState.IsValid)
            {

                _context.Workouts.Add(workout);
                _context.SaveChanges(); // Save workout first to make a WorkoutId
                if (SelectedExercises != null)
                {
                    foreach (var exerciseId in SelectedExercises)
                    {
                        _context.WorkoutExercises.Add(new WorkoutExercise { WorkoutId = workout.WorkoutId, ExerciseId = exerciseId });
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Retrieve the list of exercises again
            ViewBag.ExerciseList = _context.Exercises.ToList();

            return View("ManageWorkouts", workout);

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
                          .Include(w => w.WorkoutExercises)
                          .ThenInclude(we => we.Exercise)
                          .FirstOrDefault(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            ViewBag.ExerciseList = _context.Exercises.ToList();
            ViewBag.SelectedExercises = workout.WorkoutExercises.Select(we => we.ExerciseId).ToList();
            return View("ManageWorkouts", workout);
        }

       // [Authorize]
        [HttpPost]
        public IActionResult Edit(Workout workout, List<int> SelectedExercises)
        {
            if (ModelState.IsValid)
            {
                var existingWorkout = _context.Workouts
                                        .Include(w => w.WorkoutExercises)
                                        .FirstOrDefault(w => w.WorkoutId == workout.WorkoutId);

                if (existingWorkout != null)
                {
                    existingWorkout.Name = workout.Name;
                    existingWorkout.Author = workout.Author;

                    // Update WorkoutExercises
                    existingWorkout.WorkoutExercises.Clear();
                    foreach (var exerciseId in SelectedExercises)
                    {
                        existingWorkout.WorkoutExercises.Add(new WorkoutExercise { WorkoutId = workout.WorkoutId, ExerciseId = exerciseId });
                    }

                    _context.Update(existingWorkout);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

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
