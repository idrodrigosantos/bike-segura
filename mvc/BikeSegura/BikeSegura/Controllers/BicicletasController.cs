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
    public class BicicletasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Bicicletas
        public ActionResult Index()
        {
            var bicicletas = db.Bicicletas.Include(b => b.Aro).Include(b => b.CambioDianteiro).Include(b => b.CambioTraseiro).Include(b => b.Freio).Include(b => b.Marcas).Include(b => b.Quadro).Include(b => b.Suspensao).Include(b => b.Tipo);
            return View(bicicletas.ToList());
        }

        // GET: Bicicletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicletas bicicletas = db.Bicicletas.Find(id);
            if (bicicletas == null)
            {
                return HttpNotFound();
            }
            return View(bicicletas);
        }

        // GET: Bicicletas/Create
        public ActionResult Create()
        {
            ViewBag.AroId = new SelectList(db.Aro, "Id", "Nome");
            ViewBag.CambioDianteiroId = new SelectList(db.CambioDianteiro, "Id", "Nome");
            ViewBag.CambioTraseiroId = new SelectList(db.CambioTraseiro, "Id", "Nome");
            ViewBag.FreioId = new SelectList(db.Freio, "Id", "Nome");
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome");
            ViewBag.QuadroId = new SelectList(db.Quadro, "Id", "Nome");
            ViewBag.SuspensaoId = new SelectList(db.Suspensao, "Id", "Nome");
            ViewBag.TipoId = new SelectList(db.Tipo, "Id", "Nome");
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroSerie,MarcasId,Modelo,TipoId,Cor,Imagem,CambioDianteiroId,CambioTraseiroId,FreioId,SuspensaoId,AroId,QuadroId,Informacoes,AlertaRoubo,Vendendo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Bicicletas.Add(bicicletas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AroId = new SelectList(db.Aro, "Id", "Nome", bicicletas.AroId);
            ViewBag.CambioDianteiroId = new SelectList(db.CambioDianteiro, "Id", "Nome", bicicletas.CambioDianteiroId);
            ViewBag.CambioTraseiroId = new SelectList(db.CambioTraseiro, "Id", "Nome", bicicletas.CambioTraseiroId);
            ViewBag.FreioId = new SelectList(db.Freio, "Id", "Nome", bicicletas.FreioId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadroId = new SelectList(db.Quadro, "Id", "Nome", bicicletas.QuadroId);
            ViewBag.SuspensaoId = new SelectList(db.Suspensao, "Id", "Nome", bicicletas.SuspensaoId);
            ViewBag.TipoId = new SelectList(db.Tipo, "Id", "Nome", bicicletas.TipoId);
            return View(bicicletas);
        }

        // GET: Bicicletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicletas bicicletas = db.Bicicletas.Find(id);
            if (bicicletas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AroId = new SelectList(db.Aro, "Id", "Nome", bicicletas.AroId);
            ViewBag.CambioDianteiroId = new SelectList(db.CambioDianteiro, "Id", "Nome", bicicletas.CambioDianteiroId);
            ViewBag.CambioTraseiroId = new SelectList(db.CambioTraseiro, "Id", "Nome", bicicletas.CambioTraseiroId);
            ViewBag.FreioId = new SelectList(db.Freio, "Id", "Nome", bicicletas.FreioId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadroId = new SelectList(db.Quadro, "Id", "Nome", bicicletas.QuadroId);
            ViewBag.SuspensaoId = new SelectList(db.Suspensao, "Id", "Nome", bicicletas.SuspensaoId);
            ViewBag.TipoId = new SelectList(db.Tipo, "Id", "Nome", bicicletas.TipoId);
            return View(bicicletas);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroSerie,MarcasId,Modelo,TipoId,Cor,Imagem,CambioDianteiroId,CambioTraseiroId,FreioId,SuspensaoId,AroId,QuadroId,Informacoes,AlertaRoubo,Vendendo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicletas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AroId = new SelectList(db.Aro, "Id", "Nome", bicicletas.AroId);
            ViewBag.CambioDianteiroId = new SelectList(db.CambioDianteiro, "Id", "Nome", bicicletas.CambioDianteiroId);
            ViewBag.CambioTraseiroId = new SelectList(db.CambioTraseiro, "Id", "Nome", bicicletas.CambioTraseiroId);
            ViewBag.FreioId = new SelectList(db.Freio, "Id", "Nome", bicicletas.FreioId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadroId = new SelectList(db.Quadro, "Id", "Nome", bicicletas.QuadroId);
            ViewBag.SuspensaoId = new SelectList(db.Suspensao, "Id", "Nome", bicicletas.SuspensaoId);
            ViewBag.TipoId = new SelectList(db.Tipo, "Id", "Nome", bicicletas.TipoId);
            return View(bicicletas);
        }

        // GET: Bicicletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicicletas bicicletas = db.Bicicletas.Find(id);
            if (bicicletas == null)
            {
                return HttpNotFound();
            }
            return View(bicicletas);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicicletas bicicletas = db.Bicicletas.Find(id);
            db.Bicicletas.Remove(bicicletas);
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
