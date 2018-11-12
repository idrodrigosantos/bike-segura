using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Suspensoes;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class SuspensoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Suspensoes
        public ActionResult Index()
        {
            //return View(db.Suspensoes.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(db.Suspensoes.Where(w => w.Ativo == 0).ToList());
        }

        // GET: Suspensoes/Details
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] Suspensoes suspensoes)
        {
            if (ModelState.IsValid)
            {
                db.Suspensoes.Add(suspensoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspensoes);
        }

        // GET: Suspensoes/Edit
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

        // POST: Suspensoes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] Suspensoes suspensoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspensoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspensoes);
        }

        // GET: Suspensoes/Delete
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

        // POST: Suspensoes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspensoes suspensoes = db.Suspensoes.Find(id);
            //db.Suspensoes.Remove(suspensoes);
            //Antes excluia do banco, agora altera o status
            suspensoes.Ativo = (OpcaoStatusSuspensoes)1;
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
