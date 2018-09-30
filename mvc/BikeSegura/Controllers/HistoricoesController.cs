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
    public class HistoricoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Historicoes
        public ActionResult Index()
        {
            var historico = db.Historico.Include(h => h.Bicicletas).Include(h => h.Pessoas);
            return View(historico.ToList());
        }

        // GET: Historicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historico.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
        }

        // GET: Historicoes/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome");
            return View();
        }

        // POST: Historicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SituacaoAtual,DataAquisicao,DataTransferencia,BicicletasId,PessoasId")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Historico.Add(historico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historico.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historico.PessoasId);
            return View(historico);
        }

        // GET: Historicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historico.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historico.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historico.PessoasId);
            return View(historico);
        }

        // POST: Historicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SituacaoAtual,DataAquisicao,DataTransferencia,BicicletasId,PessoasId")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historico.BicicletasId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", historico.PessoasId);
            return View(historico);
        }

        // GET: Historicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico historico = db.Historico.Find(id);
            if (historico == null)
            {
                return HttpNotFound();
            }
            return View(historico);
        }

        // POST: Historicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historico historico = db.Historico.Find(id);
            db.Historico.Remove(historico);
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
