using Microsoft.AspNetCore.Mvc;
using OderApplication.Data;
using OderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;


        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _db.Categories;
            return View(objlist);
        }

        //GET  Create
        public IActionResult Create()
        {
            
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(obj);
            
        }
        // Get Edit
        public IActionResult Edit(int? Id)
        {
            if(Id==null||Id==0)
            {
                return NotFound();
            }
            var objec = _db.Categories.Find(Id);
            if (objec == null)
            {
                return NotFound();
            }

            return View(objec);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


        //Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var objec = _db.Categories.Find(Id);
            if (objec == null)
            {
                return NotFound();
            }

            return View(objec);
        }

        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Categories.Find(Id);
            if (Id == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

      

      


    }
}
