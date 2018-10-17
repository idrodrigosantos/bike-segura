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
    //[Authorize(Roles = "Administrador")]
    public class QuadrosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Quadros
        public ActionResult Index()
        {
            return View(db.Quadros.ToList());
        }

        // GET: Quadros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // GET: Quadros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quadros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material")] Quadros quadros)
        {
            if (ModelState.IsValid)
            {
                db.Quadros.Add(quadros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quadros);
        }

        // GET: Quadros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // POST: Quadros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material")] Quadros quadros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quadros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quadros);
        }

        // GET: Quadros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // POST: Quadros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quadros quadros = db.Quadros.Find(id);
            db.Quadros.Remove(quadros);
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
