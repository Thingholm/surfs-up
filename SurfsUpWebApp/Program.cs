using EntityFramework.Data;
using EntityFramework.Infrastructure;
using EntityFramework.Models;

//using SurfsUpWebApp.Models;
using SurfsUpWebApp.Repositories;
using System;

namespace SurfsUpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<CartItemRepository>();




            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    if (context.Database.EnsureCreated())
                    {
                        Seeddata.Initialize(context);
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
