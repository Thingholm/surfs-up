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
            var connecionString = builder.Configuration.GetConnectionString("SurfsUpDatabase") ?? "Data Source = AppDataContext.db";
            
            
            //builder.Services.AddDbContext<CartItemDb>(options => options.UseInMemoryDatabase("items"));
            builder.Services.AddSqlite<AppDataContext>(connecionString);
            

            builder.Services.AddEndpointsApiExplorer();
            

            //builder.Services.AddSingleton<CartItemRepository>();
            builder.Services.AddScoped<CartItemRepository>();
            

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            // app.MapGet("/addexample", async (AppDataContext db ) => {
            //     var examples = ProductRepository.GetAllProducts();
            //     examples.ForEach((s) => { db.Products.Add(s);
            //     });
                
            //     await db.SaveChangesAsync();
            //  });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
