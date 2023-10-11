using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCWebApplication2.Data;
namespace MVCWebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MVCWebApplication2Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MVCWebApplication2Context") ?? throw new InvalidOperationException("Connection string 'MVCWebApplication2Context' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=TodoItems}/{action=Index}/{id?}");

            app.Run();
        }
    }
}