using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SurfsUpWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AdminController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() 
        {
            List<RentedBoard>? rentedBoards;
            try 
            {
                rentedBoards = _dbContext.RentedBoards.Include(p => p.Product).ToList();
            }
            catch (Exception ex) 
            {
                rentedBoards = null;
            }

            return View(rentedBoards);
        }
    }
}