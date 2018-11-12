using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.RelatosRoubos;

namespace BikeSegura.Controllers
{
    [Authorize]
    public class RelatosRoubosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: RelatosRoubos
        public ActionResult Index()
        {
            var relatosRoubos = db.RelatosRoubos.Include(r => r.InformacoesRoubos).Include(r => r.Pessoas);
            //return View(relatosRoubos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(relatosRoubos.Where(w => w.Ativo == 0).ToList());
        }

        // GET: RelatosRoubos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatosRoubos relatosRoubos = db.RelatosRoubos.Find(id);
            if (relatosRoubos == null)
            {
                return HttpNotFound();
            }
            return View(relatosRoubos);
        }

        // GET: RelatosRoubos/Create
        public ActionResult Create()
        {
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos.Where(w => w.Ativo == 0), "Id", "Relato");
            ViewBag.PessoasId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome");
            return View();
        }

        // POST: RelatosRoubos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Relato,Local,Data,PessoasId,InformacoesRoubosId,Ativo")] RelatosRoubos relatosRoubos)
        {
            if (ModelState.IsValid)
            {
                db.RelatosRoubos.Add(relatosRoubos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos, "Id", "Relato", relatosRoubos.InformacoesRoubosId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatosRoubos.PessoasId);
            return View(relatosRoubos);
        }

        // GET: RelatosRoubos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatosRoubos relatosRoubos = db.RelatosRoubos.Find(id);
            if (relatosRoubos == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos.Where(w => w.Ativo == 0), "Id", "Relato", relatosRoubos.InformacoesRoubosId);
            ViewBag.PessoasId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome", relatosRoubos.PessoasId);
            return View(relatosRoubos);
        }

        // POST: RelatosRoubos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Relato,Local,Data,PessoasId,InformacoesRoubosId,Ativo")] RelatosRoubos relatosRoubos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatosRoubos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos, "Id", "Relato", relatosRoubos.InformacoesRoubosId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatosRoubos.PessoasId);
            return View(relatosRoubos);
        }

        // GET: RelatosRoubos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelatosRoubos relatosRoubos = db.RelatosRoubos.Find(id);
            if (relatosRoubos == null)
            {
                return HttpNotFound();
            }
            return View(relatosRoubos);
        }

        // POST: RelatosRoubos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelatosRoubos relatosRoubos = db.RelatosRoubos.Find(id);
            //db.RelatosRoubos.Remove(relatosRoubos);
            //Antes excluia do banco, agora altera o status
            relatosRoubos.Ativo = (OpcaoStatusRelatosRoubos)1;
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
