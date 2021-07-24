using Microsoft.AspNetCore.Mvc;
using OderApplication.Data;
using OderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DriverController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Driver> objectList = _db.drivers;
            return View(objectList);
        }
        //Get Create
        public IActionResult Create()
        {

            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Driver ob)
        {
            if (ModelState.IsValid)
            {
                _db.drivers.Add(ob);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ob);




        }


        //Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var objec = _db.drivers.Find(Id);
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
            var obj = _db.drivers.Find(Id);
            if (Id == null)
            {
                return NotFound();
            }
            _db.drivers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var objec = _db.drivers.Find(Id);
            if (objec == null)
            {
                return NotFound();
            }

            return View(objec);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Driver obj)
        {


            _db.drivers.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");



        }

    }
}
