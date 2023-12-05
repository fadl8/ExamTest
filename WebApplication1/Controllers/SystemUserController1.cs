using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SystemUserController1 : Controller
    { 
        private ApplicationDbContext db;
        public SystemUserController1(ApplicationDbContext _context)
        {
            db = _context;
        }
        public IActionResult Index()
        {
            
            var data = db.SystemUser.ToList();
            return View(data);
        }

        public IActionResult Save()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Save(SystemUser input)
        {
            db.SystemUser.Add(input);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(long id)
        {
            var user = db.SystemUser.FirstOrDefault(user => user.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(SystemUser input)
        {
            var userfromdb = db.SystemUser.FirstOrDefault(user => user.Id == input.Id);
            userfromdb.Name = input.Name;
            userfromdb.Email = input.Email;
            userfromdb.Password = input.Password; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var userfromdb = db.SystemUser.FirstOrDefault(user => user.Id == id);
            db.Remove(userfromdb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
