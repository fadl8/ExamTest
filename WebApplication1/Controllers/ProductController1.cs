using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController1 : Controller
    {
        private ApplicationDbContext db;
        public ProductController1(ApplicationDbContext _context)
        {
            db = _context;
        }
        public IActionResult Index()
        {

            var data = db.Product.ToList();
            return View(data);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Product input)
        {
            db.Product.Add(input);
            

            db.LogFile.Add(new LogFile { Action = "Insert" , SystemUserId = 1 });
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Update(long id)
        {
            var product = db.Product.FirstOrDefault(user => user.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product input)
        {
            var productfromdb = db.Product.FirstOrDefault(product => product.Id == input.Id);
            productfromdb.name = input.name;
            db.LogFile.Add(new LogFile { Action = "Update", SystemUserId = 1 });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var productfromdb = db.Product.FirstOrDefault(user => user.Id == id);
            db.Remove(productfromdb);
            db.LogFile.Add(new LogFile { Action = "Delete", SystemUserId = 1 });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
