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
    public class FreiosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Freios
        public ActionResult Index()
        {
            return View(db.Freio.ToList());
        }

        // GET: Freios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freio freio = db.Freio.Find(id);
            if (freio == null)
            {
                return HttpNotFound();
            }
            return View(freio);
        }

        // GET: Freios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Freio freio)
        {
            if (ModelState.IsValid)
            {
                db.Freio.Add(freio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freio);
        }

        // GET: Freios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freio freio = db.Freio.Find(id);
            if (freio == null)
            {
                return HttpNotFound();
            }
            return View(freio);
        }

        // POST: Freios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Freio freio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freio);
        }

        // GET: Freios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freio freio = db.Freio.Find(id);
            if (freio == null)
            {
                return HttpNotFound();
            }
            return View(freio);
        }

        // POST: Freios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Freio freio = db.Freio.Find(id);
            db.Freio.Remove(freio);
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
