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
    public class CityController : Controller
    {
        private urlredEntities db = new urlredEntities();

        //
        // GET: /city/

        public ActionResult Index()
        {
            return View(db.cities.ToList());
        }

        //
        // GET: /city/Details/5

        public ActionResult Details(int id = 0)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // GET: /city/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /city/Create

        [HttpPost]
        public ActionResult Create(city city)
        {
            if (ModelState.IsValid)
            {
                db.cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        //
        // GET: /city/Edit/5

        public ActionResult Edit(int id = 0)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // POST: /city/Edit/5

        [HttpPost]
        public ActionResult Edit(city city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        //
        // GET: /city/Delete/5

        public ActionResult Delete(int id = 0)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // POST: /city/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            city city = db.cities.Find(id);
            db.cities.Remove(city);
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