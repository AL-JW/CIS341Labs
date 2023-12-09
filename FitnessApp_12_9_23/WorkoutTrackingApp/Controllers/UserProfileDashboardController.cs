using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WorkoutTrackingApp.ViewModels;
using System;
using System.Collections.Generic; // this is for List<T>
using Microsoft.AspNetCore.Authorization;
// Central hub for user dashboard
// Here I can incorporate latest workout/ or workouts, don't need a profile picture i don't think, profile view was completly unneccesary since the index is the profile
// Don't need to manage subscription as a user so that view was deleted
// Basic Settings view can be integrated here into the index I think, possibly. 
namespace WorkoutTrackingApp.Controllers
{
    // [Authorize]
    [AllowAnonymous]
    public class UserProfileDashboardController : Controller
    {
        public IActionResult Index()
        {
            // Putting dummy data in here just so I can try and visualize this better

            var viewModel = new UserDashboardViewModel
            {
                UserName = "JohnSmith",
                Email = "john.smith@gmail.com",
                IsSubscribed = true,
                SubscriptionEndDate = DateTime.Now.AddDays(30),
                RecentWorkouts = new List<WorkoutViewModel> // Comes from the data source
                {
                    new WorkoutViewModel
                    {
                        WorkoutID = 1,
                        Name = "Cardio Crusher",
                        Description = "Very unenjoyable timed intervals of cardio that no one wants to do but " +
                        "they need to do it anyway.",
                        Difficulty = "Difficult/Not fun"

                    },
                    new WorkoutViewModel 
                    { 
                        WorkoutID = 2,
                        Name = "Warrior Workout",
                        Description  = "A series of freeweight exercises that makes people feel like they " +
                        "are warriors when they are done",
                        Difficulty = "Moderate"

                    }
                },
                Messages = new List<MessageViewModel> // also data source
                {
                    new MessageViewModel { SenderName = "Larry", Content = "Hi! Nice to meet you, I am your virtual fitness trainer. I am here to help!" },
                    new MessageViewModel { SenderName = "Larry", Content = "Also, don't 'forget' leg day and do chest again!" },
                    new MessageViewModel { SenderName = "Larry", Content = "This is awesome. "}
                }

        };
            return View(viewModel);
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
