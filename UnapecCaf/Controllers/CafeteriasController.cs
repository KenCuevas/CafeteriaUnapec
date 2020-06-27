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
    public class CafeteriasController : Controller
    {
        private CafetDB db = new CafetDB();

        // GET: Cafeterias
        public ActionResult Index()
        {
            return View(db.Cafeterias.ToList());
        }

        // GET: Cafeterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeterias cafeterias = db.Cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            return View(cafeterias);
        }

        // GET: Cafeterias/Create
        public ActionResult Create()
        {
            ViewBag.IdCampus = new SelectList(db.Campus, "Id", "DescripcionCampus");
            ViewBag.IdEncargado = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: Cafeterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,IDCampus,IdEncargado,Estado")] Cafeterias cafeterias)
        {
            if (ModelState.IsValid)
            {
                db.Cafeterias.Add(cafeterias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cafeterias);
        }

        // GET: Cafeterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeterias cafeterias = db.Cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCampus = new SelectList(db.Campus, "IdCampus", "DescripcionCampus", Cafeterias.IdCampus);
            ViewBag.IdEmpleados = new SelectList(db.Empleados, "Id", "Nombre", Cafeterias.idEncargado);
            return View(cafeterias);
        }

        // POST: Cafeterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,IDCampus,IdEncargado,Estado")] Cafeterias cafeterias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafeterias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cafeterias);
        }

        // GET: Cafeterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafeterias cafeterias = db.Cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            return View(cafeterias);
        }

        // POST: Cafeterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cafeterias cafeterias = db.Cafeterias.Find(id);
            db.Cafeterias.Remove(cafeterias);
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
