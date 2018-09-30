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
    public class NumeroSeriesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: NumeroSeries
        public ActionResult Index()
        {
            var numeroSerie = db.NumeroSerie.Include(n => n.Bicicletas);
            return View(numeroSerie.ToList());
        }

        // GET: NumeroSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroSerie numeroSerie = db.NumeroSerie.Find(id);
            if (numeroSerie == null)
            {
                return HttpNotFound();
            }
            return View(numeroSerie);
        }

        // GET: NumeroSeries/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            return View();
        }

        // POST: NumeroSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,BicicletasId")] NumeroSerie numeroSerie)
        {
            if (ModelState.IsValid)
            {
                db.NumeroSerie.Add(numeroSerie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numeroSerie.BicicletasId);
            return View(numeroSerie);
        }

        // GET: NumeroSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroSerie numeroSerie = db.NumeroSerie.Find(id);
            if (numeroSerie == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numeroSerie.BicicletasId);
            return View(numeroSerie);
        }

        // POST: NumeroSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,BicicletasId")] NumeroSerie numeroSerie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numeroSerie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numeroSerie.BicicletasId);
            return View(numeroSerie);
        }

        // GET: NumeroSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumeroSerie numeroSerie = db.NumeroSerie.Find(id);
            if (numeroSerie == null)
            {
                return HttpNotFound();
            }
            return View(numeroSerie);
        }

        // POST: NumeroSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumeroSerie numeroSerie = db.NumeroSerie.Find(id);
            db.NumeroSerie.Remove(numeroSerie);
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
