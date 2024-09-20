using System;
using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;
using EntityFramework.Infrastructure;
using EntityFramework.Members;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

	

    [HttpPost]
    public IActionResult Registration(CreateAdmin model)
    {
        if (ModelState.IsValid)
        {
            Admin admin = new Admin();
            admin.Email = model.Email;
            admin.Password = model.Password;
            try
            {
                _context.Admins.Add(admin);
             _context.SaveChanges();
             ModelState.Clear();

            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError("", "skriv email og kode");

            }
            

        }
        return View(model);

    }
   // public IActionResult Login()
    
}
