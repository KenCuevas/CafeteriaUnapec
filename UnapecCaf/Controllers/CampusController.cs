using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnapecCaf.Models;

namespace UnapecCaf.Controllers
{
    public class CampusController : Controller
    {
        private CafetDB db = new CafetDB();

        // GET: Campus
        public ActionResult Index()
        {
            return View(db.Campus.ToList());
        }

        // GET: Campus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Campus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescripcionCampus,Estado")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campus.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        // GET: Campus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescripcionCampus,Estado")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campus);
        }

        // GET: Campus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campus.Find(id);
            db.Campus.Remove(campus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
