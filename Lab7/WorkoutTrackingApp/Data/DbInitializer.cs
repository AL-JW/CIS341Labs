using System.ComponentModel.DataAnnotations;
using WorkoutTrackingApp.Models;

namespace WorkoutTrackingApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(WorkoutTrackingAppContext context)
        {
            //Create database and use Entity Framework model to create tables
            context.Database.EnsureCreated();


            //Content already exists, then exit
            if (context.Accounts.Any())
            {
                return;
            }

            //Seed in and create entity instances
            var account = new Account
            {
                AccountId = 1,
                Email = "JohnRingo@gmail.com",
                Password = "password",
                Role = "User"
            };

            // Add to Dbset
            context.Accounts.Add(account);

            var workout = new Workout
            {
                WorkoutId = 1,
                AccountId = 1,
                Name = "Cycling",
                Author = "Larry Trainer",
            };

            context.Workouts.Add(workout);


            var exercise = new Exercise
            {
                Author = "Unknown",
                Name = "Bench Press",
                Description = "Freeweight pushing motion with a bar with weights and a bench which you lay on",
                Length = "5 sets of 5 reps"

            };

            context.Exercises.Add(exercise);

            var message = new Message
            {
                Sender = "Larry Trainer",
                Recipient = "Chris Doe",
                Content = "Hi there did you check out the new workout I uploaded?"
            };

            context.Messages.Add(message);


                var trackedWorkout = new TrackedWorkout
                {
                    TrackedWorkoutId = 1,
                    AccountId = 1,
                    WorkoutId = 1,
                    DateCompleted = DateTime.Now
                };

            context.TrackedWorkouts.Add(trackedWorkout);


            var workoutexercise = new WorkoutExercise
            {

                WorkoutId = 1,
                ExerciseId = 1,

            };
            context.WorkoutExercises.Add(workoutexercise);

            context.SaveChanges();
        }
    }
}
