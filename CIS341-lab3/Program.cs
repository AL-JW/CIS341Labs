using System.Diagnostics;

namespace CIS341_lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                //This writes the current time and request url 
                Debug.WriteLine($"Time: {DateTime.Now}, URL: {context.Request.Path}");


                //go to the next delegate in the pipeline

                await next.Invoke();
            });

         

            app.UseStatusCodePagesWithReExecute("/StatusCode", "?code={0}");


            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}