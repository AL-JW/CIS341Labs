using Microsoft.EntityFrameworkCore;


namespace TodoApi
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
            : base(options) { }
        public DbSet<Exercise> Exercises { get; set; }

    }
}
