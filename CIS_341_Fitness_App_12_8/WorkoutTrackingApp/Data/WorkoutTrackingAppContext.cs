using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackingApp.Models;

namespace WorkoutTrackingApp.Data
{
    // Here is where Entity framework core is interacting with the database
    public class WorkoutTrackingAppContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TrackedWorkout> TrackedWorkouts { get; set;}
        public DbSet<WorkoutExercise> WorkoutExercises { get;set; }
        
        public WorkoutTrackingAppContext(DbContextOptions<WorkoutTrackingAppContext> options)
            : base(options)
        {

        }

    }
}
