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
    public class AroesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Aroes
        public ActionResult Index()
        {
            return View(db.Aro.ToList());
        }

        // GET: Aroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aro.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // GET: Aroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Medida")] Aro aro)
        {
            if (ModelState.IsValid)
            {
                db.Aro.Add(aro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aro);
        }

        // GET: Aroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aro.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // POST: Aroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Medida")] Aro aro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aro);
        }

        // GET: Aroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aro aro = db.Aro.Find(id);
            if (aro == null)
            {
                return HttpNotFound();
            }
            return View(aro);
        }

        // POST: Aroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aro aro = db.Aro.Find(id);
            db.Aro.Remove(aro);
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
