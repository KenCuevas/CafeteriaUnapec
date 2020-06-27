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
    public class TipoUsuariosController : Controller
    {
        private CafetDB db = new CafetDB();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            return View(db.TipoUsuarios.ToList());
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado")] TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuarios.Add(tipoUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // POST: TipoUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado")] TipoUsuarios tipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUsuarios);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            if (tipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuarios);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuarios tipoUsuarios = db.TipoUsuarios.Find(id);
            db.TipoUsuarios.Remove(tipoUsuarios);
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
