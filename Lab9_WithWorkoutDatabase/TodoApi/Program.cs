using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);
// Replaced with actual DbContext and connection string
builder.Services.AddDbContext<ExerciseDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ExerciseContextConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Exercise API",
    }); 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Need this to add existing data to the datbase
// Create a scope to get scoped services
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Seed the database with initial data
        
        ExerciseDbInitializer.Initialize(services);
    }
    catch (Exception ex)
    {
        // Handle exceptions, for example: log them
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}
// GET ALL EXERCISES
app.MapGet("/exercises", async (ExerciseDbContext db) =>
    await db.Exercises.ToListAsync());

// GET ONE EXERCISE
app.MapGet("/exercises/{id}", async (int id, ExerciseDbContext db) =>
    await db.Exercises.FindAsync(id)
        is Exercise exercise
            ? Results.Ok(exercise)
            : Results.NotFound());

// CREATE AN EXERCISE
app.MapPost("/exercises", async (Exercise exercise, ExerciseDbContext db) =>
{
    db.Exercises.Add(exercise);
    await db.SaveChangesAsync();

    return Results.Created($"/exercises/{exercise.ExerciseId}", exercise);
});

// ENPOINT TO UPDATE EXERCISE
app.MapPut("/exercises/{id}", async (int id, Exercise inputExercise, ExerciseDbContext db) =>
{
    var exercise = await db.Exercises.FindAsync(id);

    if (exercise is null) return Results.NotFound();

    exercise.Name = inputExercise.Name;
    exercise.Description = inputExercise.Description;
    exercise.Author = inputExercise.Author;
    exercise.Length = inputExercise.Length;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// ENDPOINT TO DELETE EXERCISE
app.MapDelete("/exercises/{id}", async (int id, ExerciseDbContext db) =>
{
    if (await db.Exercises.FindAsync(id) is Exercise exercise)
    {
        db.Exercises.Remove(exercise);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise API V1");
    c.RoutePrefix = string.Empty; // Serves the Swagger UI at the app's root
});

app.Run();
