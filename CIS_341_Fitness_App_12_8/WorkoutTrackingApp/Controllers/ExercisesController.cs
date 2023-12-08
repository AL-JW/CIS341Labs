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

        //[Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            
            return View("ManageExercises", new ExerciseViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExerciseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exercise = new Exercise 
                {
                    Name = model.Name,
                    Description = model.Description,
                    Intensity = model.Intensity,
                    
                };

                _context.Exercises.Add(exercise);
                _context.SaveChanges();

                
                return RedirectToAction("Index");
            }

            return View(model);
        }

       // [Authorize]
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
