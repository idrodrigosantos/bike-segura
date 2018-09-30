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
    public class RelatoRouboesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: RelatoRouboes
        public ActionResult Index()
        {
            var relatoRoubo = db.RelatoRoubo.Include(r => r.InformacoesRoubo).Include(r => r.Pessoas);
            return View(relatoRoubo.ToList());
        }

        // GET: RelatoRouboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatoRoubo relatoRoubo = db.RelatoRoubo.Find(id);
            if (relatoRoubo == null)
            {
                return HttpNotFound();
            }
            return View(relatoRoubo);
        }

        // GET: RelatoRouboes/Create
        public ActionResult Create()
        {
            ViewBag.InformacoesRouboId = new SelectList(db.InformacoesRoubo, "Id", "Relato");
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome");
            return View();
        }

        // POST: RelatoRouboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Relato,Local,Data,PessoasId,InformacoesRouboId")] RelatoRoubo relatoRoubo)
        {
            if (ModelState.IsValid)
            {
                db.RelatoRoubo.Add(relatoRoubo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InformacoesRouboId = new SelectList(db.InformacoesRoubo, "Id", "Relato", relatoRoubo.InformacoesRouboId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatoRoubo.PessoasId);
            return View(relatoRoubo);
        }

        // GET: RelatoRouboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatoRoubo relatoRoubo = db.RelatoRoubo.Find(id);
            if (relatoRoubo == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformacoesRouboId = new SelectList(db.InformacoesRoubo, "Id", "Relato", relatoRoubo.InformacoesRouboId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatoRoubo.PessoasId);
            return View(relatoRoubo);
        }

        // POST: RelatoRouboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Relato,Local,Data,PessoasId,InformacoesRouboId")] RelatoRoubo relatoRoubo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatoRoubo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InformacoesRouboId = new SelectList(db.InformacoesRoubo, "Id", "Relato", relatoRoubo.InformacoesRouboId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatoRoubo.PessoasId);
            return View(relatoRoubo);
        }

        // GET: RelatoRouboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatoRoubo relatoRoubo = db.RelatoRoubo.Find(id);
            if (relatoRoubo == null)
            {
                return HttpNotFound();
            }
            return View(relatoRoubo);
        }

        // POST: RelatoRouboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelatoRoubo relatoRoubo = db.RelatoRoubo.Find(id);
            db.RelatoRoubo.Remove(relatoRoubo);
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
