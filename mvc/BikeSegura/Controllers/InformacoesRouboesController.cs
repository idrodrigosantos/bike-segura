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
    public class InformacoesRouboesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: InformacoesRouboes
        public ActionResult Index()
        {
            var informacoesRoubo = db.InformacoesRoubo.Include(i => i.Bicicletas);
            return View(informacoesRoubo.ToList());
        }

        // GET: InformacoesRouboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubo informacoesRoubo = db.InformacoesRoubo.Find(id);
            if (informacoesRoubo == null)
            {
                return HttpNotFound();
            }
            return View(informacoesRoubo);
        }

        // GET: InformacoesRouboes/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            return View();
        }

        // POST: InformacoesRouboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Relato,Local,Data,BicicletasId")] InformacoesRoubo informacoesRoubo)
        {
            if (ModelState.IsValid)
            {
                db.InformacoesRoubo.Add(informacoesRoubo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", informacoesRoubo.BicicletasId);
            return View(informacoesRoubo);
        }

        // GET: InformacoesRouboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubo informacoesRoubo = db.InformacoesRoubo.Find(id);
            if (informacoesRoubo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", informacoesRoubo.BicicletasId);
            return View(informacoesRoubo);
        }

        // POST: InformacoesRouboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Relato,Local,Data,BicicletasId")] InformacoesRoubo informacoesRoubo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacoesRoubo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", informacoesRoubo.BicicletasId);
            return View(informacoesRoubo);
        }

        // GET: InformacoesRouboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubo informacoesRoubo = db.InformacoesRoubo.Find(id);
            if (informacoesRoubo == null)
            {
                return HttpNotFound();
            }
            return View(informacoesRoubo);
        }

        // POST: InformacoesRouboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacoesRoubo informacoesRoubo = db.InformacoesRoubo.Find(id);
            db.InformacoesRoubo.Remove(informacoesRoubo);
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
