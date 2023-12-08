using Microsoft.EntityFrameworkCore;
using WorkoutTrackingApp.Data;
using Microsoft.AspNetCore.Identity;
using WorkoutTrackingApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace WorkoutTrackingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

           
            // Adding DbContext to the service container, indicating that WorkoutTrackingAppContext is registered
            builder.Services.AddDbContext<WorkoutTrackingAppContext>(options =>
                                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;  // Changed to false, changed back
                options.Password.RequiredLength = 10; // Changed from 6 to 10
                options.Password.RequiredUniqueChars = 2;  // Require 2 unique chars instead of 1 
                
            });

            // Adding DbContext to the service container
            builder.Services.AddDbContext<AltercationContext>(options =>
                                            options.UseSqlServer(builder.Configuration.GetConnectionString("AltercationContextConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AltercationContext>();

            var app = builder.Build();

            // Since the DbContext is a "scoped service", need to create a scope to retrieve the service
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
                app.UseExceptionHandler("/Error"); // Points to the Razor page now instead of controller
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Top-level route registrations
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.MapFallbackToFile("Index");

            app.Run();
        }
    }
}