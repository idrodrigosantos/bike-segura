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
    public class SuspensaosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Suspensaos
        public ActionResult Index()
        {
            return View(db.Suspensao.ToList());
        }

        // GET: Suspensaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensao suspensao = db.Suspensao.Find(id);
            if (suspensao == null)
            {
                return HttpNotFound();
            }
            return View(suspensao);
        }

        // GET: Suspensaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suspensaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Suspensao suspensao)
        {
            if (ModelState.IsValid)
            {
                db.Suspensao.Add(suspensao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspensao);
        }

        // GET: Suspensaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensao suspensao = db.Suspensao.Find(id);
            if (suspensao == null)
            {
                return HttpNotFound();
            }
            return View(suspensao);
        }

        // POST: Suspensaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Suspensao suspensao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspensao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspensao);
        }

        // GET: Suspensaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspensao suspensao = db.Suspensao.Find(id);
            if (suspensao == null)
            {
                return HttpNotFound();
            }
            return View(suspensao);
        }

        // POST: Suspensaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspensao suspensao = db.Suspensao.Find(id);
            db.Suspensao.Remove(suspensao);
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
