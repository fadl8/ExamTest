using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LogFileController1 : Controller
    {
        private ApplicationDbContext db;

        public LogFileController1(ApplicationDbContext _context)
        {
            db = _context;
        }
        public IActionResult Index()
        { 
            var data = db.LogFile.Include(user => user.SystemUser).ToList();
            return View(data);
        }
         
    }
}
