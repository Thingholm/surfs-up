using SurfsUpWebApp.Models;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Data;
using Microsoft.Extensions.DependencyInjection;

namespace SurfsUpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Retrieve connection string from the configuration
            var connectionString = builder.Configuration.GetConnectionString("SurfsUpContext");

            // Pass the connection string to the DbContext
            builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlite(connectionString));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDataContext>();
                    if (context.Database.EnsureCreated())
                    {
                        Seeddata.Initialize(context); // Ensure seeding if database was just created
                    }
                }
                catch (System.Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();

        }
    }
}
