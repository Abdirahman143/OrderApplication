using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OderApplication.Data;
using OderApplication.Models;
using OderApplication.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OderApplication.Controllers
{
    public class AmbulanceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AmbulanceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ambulance> objectList = _db.Ambulances;
            foreach(var obj in objectList)
            {
                obj.Driver = _db.drivers.FirstOrDefault(u => u.Id == obj.DriverId); 

            }
            return View(objectList);
        }
        //Get Create
        public IActionResult Create()
        {
            DriverVM DriverVM = new DriverVM()
            {
                Ambulance = new Ambulance(),

                TypeDropDown = _db.drivers.Select(i=> new SelectListItem{
                    Text = i.Name,
                    Value = i.Id.ToString()

                })


        };

          /*  IEnumerable<SelectListItem> TypeDropDown = _db.drivers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropDwon = TypeDropDown;*/
            
            return View(DriverVM);


    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DriverVM ob)
        {
            if (ModelState.IsValid)
            {
                _db.Ambulances.Add(ob.Ambulance);
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
            var objec = _db.Ambulances.Find(Id);
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
            var obj = _db.Ambulances.Find(Id);
            if (Id == null)
            {
                return NotFound();
            }
            _db.Ambulances.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }



        public IActionResult Edit(int? Id)
        {


            DriverVM DriverVM = new DriverVM()
            {
                Ambulance = new Ambulance(),

                TypeDropDown = _db.drivers.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                })


            };

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
          DriverVM.Ambulance= _db.Ambulances.Find(Id);
            if (DriverVM.Ambulance == null)
            {
                return NotFound();
            }

            return View(DriverVM);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DriverVM obj)
        {

            
                _db.Ambulances.Update(obj.Ambulance);
                _db.SaveChanges();
                return RedirectToAction("Index");
            


        }




    }
}
