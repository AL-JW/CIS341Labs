using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackingApp.Data;
using WorkoutTrackingApp.ViewModels;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic; // this is for List<T>
using System.Linq;
using WorkoutTrackingApp.Models;

namespace WorkoutTrackingApp.Controllers
{
    // [Authorize]
    [AllowAnonymous]
    public class TrainerProfileDashboardController : Controller
    {
        private readonly WorkoutTrackingAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TrainerProfileDashboardController(WorkoutTrackingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Implementing Messaging feature action methods now
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var usersList = await GetUsersList();
            var workoutsList = await GetWorkoutsList();
            var exercisesList = await GetExercisesList();
            var viewModel = new MessageViewModel
            {
                Users = usersList,
                Workouts = workoutsList,
                Exercises = exercisesList
                               
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageViewModel model)
        {
            var errors = ModelState
           .Where(x => x.Value.Errors.Count > 0)
           .Select(x => new { x.Key, x.Value.Errors })
           .ToArray();
            if (ModelState.IsValid)
            {
                var senderAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.IdentityUserId == _userManager.GetUserId(User));

                if (senderAccount == null)
                {
                    
                    return NotFound("Sender account not found.");
                }
                var message = new Message
                {
                    SenderId = senderAccount.AccountId,
                    RecipientId = model.RecipientId,
                    Content = model.Content,
                    SelectedWorkoutId = model.SelectedWorkoutId, 
                    SelectedExerciseId = model.SelectedExerciseId 
                };
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            model.Users = await GetUsersList();
            return View(model);
        }

        private async Task<List<SelectListItem>> GetUsersList()
        {
            // Getting all the users 
            var usersList = new List<SelectListItem>();

                
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.IdentityUserId == user.Id);
                if (account != null)
                {                  
                    usersList.Add(new SelectListItem { Value = account.AccountId.ToString(), Text = user.UserName });
                }
            }
            return usersList;
        }

        private async Task<List<SelectListItem>> GetWorkoutsList()
        {
            return await _context.Workouts.Select(w => new SelectListItem
            {
                Value = w.WorkoutId.ToString(),
                Text = w.Name
            }).ToListAsync();
        }

        private async Task<List<SelectListItem>> GetExercisesList()
        {
            return await _context.Exercises.Select(e => new SelectListItem
            {
                Value = e.ExerciseId.ToString(),
                Text = e.Name
            }).ToListAsync();
        }

        public async Task<IActionResult> ViewMessages()
        {
            var userId = _userManager.GetUserId(User); // Logged in users Id

            var userAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.IdentityUserId == userId);
            if (userAccount == null)
            {
                return NotFound("User account not found.");
            }
            var accountId = userAccount.AccountId;
            // Getting all the messages
            var messages = await _context.Messages
                                        .Where(m => m.SenderId == accountId || m.RecipientId == accountId)
                                        .Include(m => m.Sender)
                                        .Include(m => m.Recipient)
                                        .Include(m => m.SelectedWorkout)
                                        .Include(m => m.SelectedExercise)
                                        .ToListAsync();

            // Createing this to help display the emails
            var userInfos = new Dictionary<int, string>();
            foreach (var message in messages)
            {
                if (!userInfos.ContainsKey(message.SenderId))
                {
                    var senderUser = await _userManager.FindByIdAsync(message.Sender.IdentityUserId);
                    userInfos[message.SenderId] = senderUser?.Email;
                }

                if (!userInfos.ContainsKey(message.RecipientId))
                {
                    var recipientUser = await _userManager.FindByIdAsync(message.Recipient.IdentityUserId);
                    userInfos[message.RecipientId] = recipientUser?.Email;
                }
            }
            ViewBag.UserInfos = userInfos;
            return View(messages); 
        }
    }
}
