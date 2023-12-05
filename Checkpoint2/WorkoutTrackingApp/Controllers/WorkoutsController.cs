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
    // [AllowAnonymous]
    public class WorkoutsController : Controller
    {
        private readonly WorkoutTrackingAppContext _context; // Defining the database context

        private readonly UserManager<IdentityUser> _userManager; // UserManager

        // Here is where the Contexts are being injected into the controller so it can use them
        public WorkoutsController(WorkoutTrackingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // [AllowAnonymous]
        public IActionResult Index()
        {
            // Get the current user's ID, Has list of all of the logged in user workouts
            var userId = _userManager.GetUserId(User);

            // Get workouts from the database that belong to the logged-in user using LINQ to query the database, also using the Dbcontext here
            var workouts = _context.Workouts.Where(w => w.UserId == userId).ToList();
            return View(workouts);
        }

        // [Authorize]
        public IActionResult Create()
        {
            ViewBag.ExerciseList = _context.Exercises.ToList();
            return View("ManageWorkouts", new WorkoutViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutViewModel workoutVM, List<int> SelectedExercises)
        {
            // This is to relate the ViewModel to Entity Model
            var workout = new Workout
            {
                Name = workoutVM.Name,
                Author = workoutVM.Author,
                UserId = _userManager.GetUserId(User)
            };

            if (SelectedExercises != null)
            {
                workout.WorkoutExercises = SelectedExercises.Select(id => new WorkoutExercise { ExerciseId = id }).ToList();
            }

            // The ModelState doesn't need to be checked for UserId anymore since
            // the viewmodel I think should be handling the validation 
            // WorkoutTrackingAppContext is being used here as well with _context
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }

        // [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Using LINQ here to filter workouts by the logged in user Id, also using the
            // _context to get a specific work out and its related data
            var workout = _context.Workouts
                          .Include(w => w.WorkoutExercises)
                          .ThenInclude(we => we.Exercise)
                          .FirstOrDefault(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            ViewBag.ExerciseList = _context.Exercises.ToList();

            // Map the entity model to the view wmodel 
            var workoutViewModel = new WorkoutViewModel
            {
                WorkoutID = workout.WorkoutId,
                Name = workout.Name,
                Author = workout.Author,
                SelectedExercises = workout.WorkoutExercises.Select(we => we.ExerciseId).ToList()
            };
            return View("ManageWorkouts", workoutViewModel);
        }

       // [Authorize]
        [HttpPost]
        public IActionResult Edit(WorkoutViewModel workoutVM, List<int> SelectedExercises)
        {
                var existingWorkout = _context.Workouts
                                        .Include(w => w.WorkoutExercises)
                                        .FirstOrDefault(w => w.WorkoutId == workoutVM.WorkoutID);

                if (existingWorkout != null)
                {
                    existingWorkout.Name = workoutVM.Name;
                    existingWorkout.Author = workoutVM.Author;

                    // Update WorkoutExercises
                    existingWorkout.WorkoutExercises.Clear();
                    if (SelectedExercises != null)
                    {
                        foreach (var exerciseId in SelectedExercises)
                        {
                            existingWorkout.WorkoutExercises.Add(new WorkoutExercise { WorkoutId = workoutVM.WorkoutID, ExerciseId = exerciseId });
                        }
                    }
                    _context.Update(existingWorkout);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");

            ViewBag.ExerciseList = _context.Exercises.ToList();
            return View("ManageWorkouts", workoutVM);
        }

        // [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // WorkoutTrackingAppContext _context being used here to delete a workout with LINQ
            var workout = _context.Workouts
                          .Where(w => w.WorkoutId == id)
                          .Select(w => new WorkoutViewModel
                          {
                              WorkoutID = w.WorkoutId,
                              Name = w.Name,
                              Author = w.Author,
                              // Other properties...
                          })
                          .FirstOrDefault();

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(WorkoutViewModel workoutVM)
        {
            // First, delete related WorkoutExercises. This is using LINQ to load the related data.
            var relatedExercises = _context.WorkoutExercises.Where(we => we.WorkoutId == workoutVM.WorkoutID).ToList();
            if (relatedExercises.Any())
            {
                _context.WorkoutExercises.RemoveRange(relatedExercises);
            }


            var workoutToDelete = _context.Workouts.Find(workoutVM.WorkoutID);
            if (workoutToDelete == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workoutToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // [Authorize]
        public IActionResult History()
        {
            return View();
        }
    }
}
