using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackingApp.Data;
using WorkoutTrackingApp.Models;
using WorkoutTrackingApp.ViewModels;

namespace WorkoutTrackingApp.Controllers
{
    
    public class ExercisesController : Controller
    {

        private readonly WorkoutTrackingAppContext _context; // Defining the database context

        public ExercisesController(WorkoutTrackingAppContext context)
        {
            _context = context;
        }

        // [AllowAnonymous]
        public IActionResult Index()
        {
            var exercises = _context.Exercises
                                  .Select(e => new ExerciseViewModel
                                  {
                                      Id = e.ExerciseId,
                                      Name = e.Name,
                                      Description = e.Description,
                                      
                                  })
                                  .ToList();

            return View(exercises);
        }

       // [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }

        [Authorize(Roles = "Trainer")]
        [HttpGet]
        public IActionResult Create()
        {
            
            return View("ManageExercises", new ExerciseViewModel());
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExerciseViewModel model)
        {
            // if (ModelState.IsValid)
            // {
                var exercise = new Exercise 
                {
                    Name = model.Name,
                    Author = model.Author,
                    Description = model.Description,
                    Intensity = model.Intensity,
                    
                };

                _context.Exercises.Add(exercise);
                _context.SaveChanges();
               
                return RedirectToAction("Index");
            // }

            return View("ManageExercises", model);
        }

        [Authorize(Roles = "Trainer")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == id);

            if (exercise == null)
            {
                return NotFound();
            }

            var exerciseViewModel = new ExerciseViewModel
            {
                Id = exercise.ExerciseId,
                Name = exercise.Name,
                Description = exercise.Description,
                Author = exercise.Author, 
                Intensity = exercise.Intensity
            };

            return View("ManageExercises", exerciseViewModel);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExerciseViewModel model)
        {
            // if (ModelState.IsValid)
            // {
                var existingExercise = _context.Exercises.Find(model.Id);

                if (existingExercise == null)
                {
                    return NotFound();
                }

                existingExercise.Name = model.Name;
                existingExercise.Author = model.Author;
                existingExercise.Description = model.Description;
                existingExercise.Intensity = model.Intensity;
                // Update other properties as necessary

                _context.Update(existingExercise);
                _context.SaveChanges();

                return RedirectToAction("Index");
            // }

            return View("ManageExercises", model);
        }

        [Authorize(Roles = "Trainer")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exercise = _context.Exercises
                                   .Where(e => e.ExerciseId == id)
                                   .Select(e => new ExerciseViewModel
                                   {
                                       Id = e.ExerciseId,
                                       Name = e.Name,
                                       Author = e.Author,
                                       Description = e.Description,
                                       
                                   })
                                   .FirstOrDefault();

            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise); // Make sure you have a corresponding Delete view for ExerciseViewModel
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var exerciseToDelete = _context.Exercises.Find(id);
            if (exerciseToDelete == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exerciseToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
