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
    public class RedirectController : Controller
    {
        private urlredEntities db = new urlredEntities();

        //
        // GET: /Redirect/

        public ActionResult Index()
        {
            return View(db.redirects.ToList());
        }

        //
        // GET: /[prm: Page to Redirect according to key value in DB]

        public ActionResult Rdct(string prm = "")
        {
            try
            {
                // Looking for the view, according to "prm" (i.e. www.mywebsite.com/prm) parameter passed 
                redirect redirect = db.redirects.Where(s => s.Key == prm).FirstOrDefault();

                if (redirect == null)
                {
                    // No db parameter was passed so will have to look for a controller with that name
                    if (!string.IsNullOrEmpty(prm))
                        return Redirect("/" + prm + "/Index");
                    else
                    //If no paramater was passed let's go to theHome page
                        return Redirect("/Home/Index");
                }

                //If a redirect view was found in the DB, let's go there!
                return Redirect("/" + redirect.View);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error:" + ex);
            }
        }

        //
        // GET: /Redirect/Details/5

        public ActionResult Details(int id = 0)
        {
            redirect redirect = db.redirects.Find(id);
            if (redirect == null)
            {
                return HttpNotFound();
            }
            return View(redirect);
        }

        //
        // GET: /Redirect/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Redirect/Create

        [HttpPost]
        public ActionResult Create(redirect redirect)
        {
            if (ModelState.IsValid)
            {
                db.redirects.Add(redirect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redirect);
        }

        //
        // GET: /Redirect/Edit/5

        public ActionResult Edit(int id = 0)
        {
            redirect redirect = db.redirects.Find(id);
            if (redirect == null)
            {
                return HttpNotFound();
            }
            return View(redirect);
        }

        //
        // POST: /Redirect/Edit/5

        [HttpPost]
        public ActionResult Edit(redirect redirect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redirect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redirect);
        }

        //
        // GET: /Redirect/Delete/5

        public ActionResult Delete(int id = 0)
        {
            redirect redirect = db.redirects.Find(id);
            if (redirect == null)
            {
                return HttpNotFound();
            }
            return View(redirect);
        }

        //
        // POST: /Redirect/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            redirect redirect = db.redirects.Find(id);
            db.redirects.Remove(redirect);
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