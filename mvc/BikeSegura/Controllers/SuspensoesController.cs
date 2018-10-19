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
    public class SuspensoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Suspensoes
        public ActionResult Index()
        {
            return View(db.Suspensoes.ToList());
        }

        // GET: Suspensoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensoes suspensoes = db.Suspensoes.Find(id);
            if (suspensoes == null)
            {
                return HttpNotFound();
            }
            return View(suspensoes);
        }

        // GET: Suspensoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suspensoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Suspensoes suspensoes)
        {
            if (ModelState.IsValid)
            {
                db.Suspensoes.Add(suspensoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspensoes);
        }

        // GET: Suspensoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensoes suspensoes = db.Suspensoes.Find(id);
            if (suspensoes == null)
            {
                return HttpNotFound();
            }
            return View(suspensoes);
        }

        // POST: Suspensoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Suspensoes suspensoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspensoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspensoes);
        }

        // GET: Suspensoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensoes suspensoes = db.Suspensoes.Find(id);
            if (suspensoes == null)
            {
                return HttpNotFound();
            }
            return View(suspensoes);
        }

        // POST: Suspensoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspensoes suspensoes = db.Suspensoes.Find(id);
            db.Suspensoes.Remove(suspensoes);
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
