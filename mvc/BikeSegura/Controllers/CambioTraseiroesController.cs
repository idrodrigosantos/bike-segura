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
    public class CambioTraseiroesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CambioTraseiroes
        public ActionResult Index()
        {
            return View(db.CambioTraseiro.ToList());
        }

        // GET: CambioTraseiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTraseiro cambioTraseiro = db.CambioTraseiro.Find(id);
            if (cambioTraseiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioTraseiro);
        }

        // GET: CambioTraseiroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CambioTraseiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Velocidade")] CambioTraseiro cambioTraseiro)
        {
            if (ModelState.IsValid)
            {
                db.CambioTraseiro.Add(cambioTraseiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cambioTraseiro);
        }

        // GET: CambioTraseiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTraseiro cambioTraseiro = db.CambioTraseiro.Find(id);
            if (cambioTraseiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioTraseiro);
        }

        // POST: CambioTraseiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Velocidade")] CambioTraseiro cambioTraseiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambioTraseiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambioTraseiro);
        }

        // GET: CambioTraseiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTraseiro cambioTraseiro = db.CambioTraseiro.Find(id);
            if (cambioTraseiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioTraseiro);
        }

        // POST: CambioTraseiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CambioTraseiro cambioTraseiro = db.CambioTraseiro.Find(id);
            db.CambioTraseiro.Remove(cambioTraseiro);
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
