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
    public class CambioDianteiroesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CambioDianteiroes
        public ActionResult Index()
        {
            return View(db.CambioDianteiro.ToList());
        }

        // GET: CambioDianteiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioDianteiro cambioDianteiro = db.CambioDianteiro.Find(id);
            if (cambioDianteiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioDianteiro);
        }

        // GET: CambioDianteiroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CambioDianteiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Velocidade")] CambioDianteiro cambioDianteiro)
        {
            if (ModelState.IsValid)
            {
                db.CambioDianteiro.Add(cambioDianteiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cambioDianteiro);
        }

        // GET: CambioDianteiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioDianteiro cambioDianteiro = db.CambioDianteiro.Find(id);
            if (cambioDianteiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioDianteiro);
        }

        // POST: CambioDianteiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Velocidade")] CambioDianteiro cambioDianteiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambioDianteiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambioDianteiro);
        }

        // GET: CambioDianteiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioDianteiro cambioDianteiro = db.CambioDianteiro.Find(id);
            if (cambioDianteiro == null)
            {
                return HttpNotFound();
            }
            return View(cambioDianteiro);
        }

        // POST: CambioDianteiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CambioDianteiro cambioDianteiro = db.CambioDianteiro.Find(id);
            db.CambioDianteiro.Remove(cambioDianteiro);
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
