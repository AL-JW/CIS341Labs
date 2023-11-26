using Microsoft.EntityFrameworkCore;

namespace TodoApi
{
    public class ExerciseDbInitializer
    {
        public static void ClearData(ExerciseDbContext context)
        {
            // Delete all records from specific tables
            context.Exercises.RemoveRange(context.Exercises);
            context.SaveChanges();
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExerciseDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ExerciseDbContext>>()))
            {
                //ClearData(context);
                // Look for any exercises.
                if (context.Exercises.Any())
                {
                    return;   // DB has been seeded
                }
                context.Exercises.AddRange(
                    new Exercise
                    {
                        Name = "Push-ups",
                        Description = "A basic push-up exercise",
                        Author = "Bob",
                        Length = "10 reps"
                    },
                    new Exercise
                    {
                        Name = "Sit-ups",
                        Description = "A basic sit-up exercise",
                        Author = "Luke",
                        Length = "15 reps"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
