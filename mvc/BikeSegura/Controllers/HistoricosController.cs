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
    public class HistoricosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Historicos
        public ActionResult Index()
        {
            var historicos = db.Historicos.Include(h => h.Bicicletas).Include(h => h.Pessoas);
            return View(historicos.ToList());
        }

        // GET: Historicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // GET: Historicos/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome");
            return View();
        }

        // POST: Historicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SituacaoAtual,DataAquisicao,DataTransferencia,BicicletasId,PessoasId")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Historicos.Add(historicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historicos.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historicos.PessoasId);
            return View(historicos);
        }

        // GET: Historicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historicos.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historicos.PessoasId);
            return View(historicos);
        }

        // POST: Historicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SituacaoAtual,DataAquisicao,DataTransferencia,BicicletasId,PessoasId")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historicos.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historicos.PessoasId);
            return View(historicos);
        }

        // GET: Historicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historicos historicos = db.Historicos.Find(id);
            if (historicos == null)
            {
                return HttpNotFound();
            }
            return View(historicos);
        }

        // POST: Historicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historicos historicos = db.Historicos.Find(id);
            db.Historicos.Remove(historicos);
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
