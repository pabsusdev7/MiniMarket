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
    public class FruitController : Controller
    {
        private urlredEntities db = new urlredEntities();

        //
        // GET: /fruit/

        public ActionResult Index()
        {
            return View(db.fruits.ToList());
        }

        //
        // GET: /fruit/Details/5

        public ActionResult Details(int id = 0)
        {
            fruit fruit = db.fruits.Find(id);
            if (fruit == null)
            {
                return HttpNotFound();
            }
            return View(fruit);
        }

        //
        // GET: /fruit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /fruit/Create

        [HttpPost]
        public ActionResult Create(fruit fruit)
        {
            if (ModelState.IsValid)
            {
                db.fruits.Add(fruit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fruit);
        }

        //
        // GET: /fruit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fruit fruit = db.fruits.Find(id);
            if (fruit == null)
            {
                return HttpNotFound();
            }
            return View(fruit);
        }

        //
        // POST: /fruit/Edit/5

        [HttpPost]
        public ActionResult Edit(fruit fruit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fruit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fruit);
        }

        //
        // GET: /fruit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fruit fruit = db.fruits.Find(id);
            if (fruit == null)
            {
                return HttpNotFound();
            }
            return View(fruit);
        }

        //
        // POST: /fruit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fruit fruit = db.fruits.Find(id);
            db.fruits.Remove(fruit);
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