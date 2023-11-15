using Microsoft.EntityFrameworkCore;
using WorkoutTrackingApp.Data;

namespace WorkoutTrackingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Adding DbContext to the service container
            builder.Services.AddDbContext<WorkoutTrackingAppContext>(options =>
                                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Since the DbContext is a "scoped service", we need to create a scope to retrieve the service.
            using (var scope = app.Services.CreateScope())
            {
                // Service provider for the scope
                var services = scope.ServiceProvider;
                try
                {
                    // Get the DbContext from the service provider
                    var context = services.GetRequiredService<WorkoutTrackingAppContext>();
                    // Initialize the db
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}