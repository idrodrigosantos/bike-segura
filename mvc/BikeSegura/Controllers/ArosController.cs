using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ArosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Aros
        public ActionResult Index()
        {
            return View(db.Aros.ToList());
        }

        // GET: Aros/Details/5
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Medida")] Aros aros)
        {
            if (ModelState.IsValid)
            {
                db.Aros.Add(aros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aros);
        }

        // GET: Aros/Edit/5
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

        // POST: Aros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Medida")] Aros aros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aros);
        }

        // GET: Aros/Delete/5
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

        // POST: Aros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aros aros = db.Aros.Find(id);
            db.Aros.Remove(aros);
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
