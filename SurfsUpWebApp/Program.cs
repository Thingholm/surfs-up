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
