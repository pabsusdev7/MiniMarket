using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLRedirect.DAL;

namespace URLRedirect.Controllers
{
    public class CarController : Controller
    {
        private urlredEntities db = new urlredEntities();

        //
        // GET: /Car/

        public ActionResult Index()
        {
            return View(db.cars.ToList());
        }

        //
        // GET: /car/Details/5

        public ActionResult Details(int id = 0)
        {
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // GET: /car/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /car/Create

        [HttpPost]
        public ActionResult Create(car car)
        {
            if (ModelState.IsValid)
            {
                db.cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        //
        // GET: /car/Edit/5

        public ActionResult Edit(int id = 0)
        {
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /car/Edit/5

        [HttpPost]
        public ActionResult Edit(car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        //
        // GET: /car/Delete/5

        public ActionResult Delete(int id = 0)
        {
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /car/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            car car = db.cars.Find(id);
            db.cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}