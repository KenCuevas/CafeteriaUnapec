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
    public class ProveedoresController : Controller
    {
        private CafetDB db = new CafetDB();

        // GET: Proveedores
        public ActionResult Index(string Busqueda = null)
        {
            return View(db.Proveedores.Where(p => Busqueda == null ||
                              p.NombreComercial.Contains(Busqueda)).ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreComercial,RNC,FechaRegistro,Estado")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedores);
        }
        [Authorize(Roles = "Administrador, Consulta")]
        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreComercial,RNC,FechaRegistro,Estado")] Proveedores proveedores)
        {
            if (!esUnRNCValido(proveedores.RNC))
                ModelState.AddModelError("RNC", "RCN invalido");
            if (ModelState.IsValid)
            { 
                db.Entry(proveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedores);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return HttpNotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedores proveedores = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedores);
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

        private bool esUnRNCValido(string pRNC)
        {
            int vnTotal = 0;
            int[] digitoMult = new int[8] { 7, 9, 8, 6, 5, 4, 3, 2 };
            string vcRNC = pRNC.Replace("-", "").Replace(" ", "");
            string vDigito = vcRNC.Substring(8, 1);
            if (vcRNC.Length.Equals(9))
                if (!"145".Contains(vcRNC.Substring(0, 1)))
                    return false;

            for (int vDig = 1; vDig <= 8; vDig++)
            {
                int vCalculo = Int32.Parse(vcRNC.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                vnTotal += vCalculo;
            }

            if (vnTotal % 11 == 0 && vDigito == "1" || vnTotal % 11 == 1 && vDigito == "1" ||
                (11 - (vnTotal % 11)).Equals(vDigito))
                return true;
            else
                return false;
        }
    }
}
