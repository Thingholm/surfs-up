using SurfsUpWebApp.Repositories;
using Microsoft.OpenApi.Models;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connecionString = builder.Configuration.GetConnectionString("Products") ?? "Data Source = Products.db";
            var connecionString2 = builder.Configuration.GetConnectionString("CartItems") ?? "Data Source = CartItems.db";
            
            //builder.Services.AddDbContext<CartItemDb>(options => options.UseInMemoryDatabase("items"));
            builder.Services.AddSqlite<ProductDb>(connecionString);
            builder.Services.AddSqlite<CartItemDb>(connecionString2);

            builder.Services.AddEndpointsApiExplorer();
            

            builder.Services.AddSingleton<CartItemRepository>();

            builder.Services.AddControllersWithViews();

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
