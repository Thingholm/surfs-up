using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.AspNetCore.Authentication.Cookies;


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
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

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
