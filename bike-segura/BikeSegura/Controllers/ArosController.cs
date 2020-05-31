using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Aros;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ArosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Aros
        public ActionResult Index()
        {
            return View(db.Aros.Where(w => w.Ativo == 0).ToList());
        }

        // GET: Aros/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aros aros = db.Aros.Find(id);
            if (aros == null)
            {
                return HttpNotFound();
            }
            return View(aros);
        }

        // GET: Aros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Medida,Ativo")] Aros aros)
        {
            if (ModelState.IsValid)
            {
                db.Aros.Add(aros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aros);
        }

        // GET: Aros/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aros aros = db.Aros.Find(id);
            if (aros == null)
            {
                return HttpNotFound();
            }
            return View(aros);
        }

        // POST: Aros/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Medida,Ativo")] Aros aros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aros);
        }

        // GET: Aros/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aros aros = db.Aros.Find(id);
            if (aros == null)
            {
                return HttpNotFound();
            }
            return View(aros);
        }

        // POST: Aros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aros aros = db.Aros.Find(id);
            aros.Ativo = (OpcaoStatusAros)1;
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
