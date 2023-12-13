﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WorkoutTrackingApp.Models;

namespace WorkoutTrackingApp.Data
{
    public class DbInitializer
    {
        public static void ClearData(WorkoutTrackingAppContext context)
        {
            // Clearing all workout exercises first because was having trouble with foreign key restraints
            context.WorkoutExercises.RemoveRange(context.WorkoutExercises);
            context.SaveChanges(); 

            // Clearing the tracked workouts, workouts, and exercises
            context.TrackedWorkouts.RemoveRange(context.TrackedWorkouts);
            context.Workouts.RemoveRange(context.Workouts);
            context.Exercises.RemoveRange(context.Exercises);
            context.SaveChanges();

            // Clearing out the messages and accounts
            context.Messages.RemoveRange(context.Messages);
            context.Accounts.RemoveRange(context.Accounts);
            context.SaveChanges();
        }

        public static async Task InitializeAsync(WorkoutTrackingAppContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Clear data to re initialize
            // ClearData(context);
            
            // Create database and use Entity Framework model to create tables
            context.Database.EnsureCreated();

            // Check to see if trainer role exists
            if (!await roleManager.RoleExistsAsync("Trainer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Trainer"));
            }

            // Create a trainer user if it doesn't exist
            var trainerEmail = "JackTheTrainer@gmail.com";
            var trainerUser = await userManager.FindByEmailAsync(trainerEmail);
            if (trainerUser == null)
            {
                trainerUser = new IdentityUser { UserName = trainerEmail, Email = trainerEmail };
                var createUserResult = await userManager.CreateAsync(trainerUser, "$Tr@in3rsOnly#!%"); 
                if (createUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(trainerUser, "Trainer");
                }
          
            }

            // Content already exists, then exit
            if (context.Accounts.Any())
            {
                return;
            }

            // Seed in and create entity instances
            var account = new Account
            {
                //Email = "JohnRingo@gmail.com",
               // Password = "password",
               // Role = "User"
            };

            // Add to Dbset
            context.Accounts.Add(account);

            context.SaveChanges();


            var workout = new Workout
            {        
                Name = "Cycling",
                Author = "Larry Trainer",
            };

            context.Workouts.Add(workout);

            context.SaveChanges();

            var exercise1 = new Exercise
            {
                Author = "Unknown",
                Name = "Bench Press",
                Description = "Freeweight pushing motion with a bar with weights and a bench which you lay on",
                Intensity = ExerciseIntensity.High

            };

            context.Exercises.Add(exercise1);
            context.SaveChanges();

            var exercise2 = new Exercise
            {
                Author = "Johnny",
                Name = "Squats",
                Description = "Lower body exercise using barbell for added weight if necessary, body weight works too",
                Intensity = ExerciseIntensity.High
            };
            context.Exercises.Add(exercise2);
            context.SaveChanges();

            var exercise3 = new Exercise
            {
                Author = "Johnny",
                Name = "Overhead Press",
                Description = "Compound exercise that involces lifting a weighted barbell or dumbells from shoulder height to overhead. Builds upper body strength and shoulder muscles.",
                Intensity= ExerciseIntensity.High
                
            };
            context.Exercises.Add(exercise3);
            context.SaveChanges();

            var exercise4 = new Exercise
            {
                Author = "Johnny",
                Name = "Deadlift",
                Description = "Classic strength training exercise that involves lifting a loaded barbell from the ground to fully upright position. Excellent for building strength, power, and muscle mass.",
                Intensity = ExerciseIntensity.High
            };
            context.Exercises.Add(exercise4);
            context.SaveChanges();

            var message = new Message
            {
                Sender = "Larry Trainer",
                Recipient = "Chris Doe",
                Content = "Hi there did you check out the new workout I uploaded?"
            };

            context.Messages.Add(message);
            context.SaveChanges();

            var trackedWorkout = new TrackedWorkout
            {
                WorkoutId = 1,
                DateCompleted = DateTime.Now
            };

            context.TrackedWorkouts.Add(trackedWorkout);
            context.SaveChanges();

            var workoutexercise = new WorkoutExercise
            {

            };
            context.WorkoutExercises.Add(workoutexercise);

            context.SaveChanges();
        }
    }
}
