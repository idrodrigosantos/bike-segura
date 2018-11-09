using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.CambiosTraseiros;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CambiosTraseirosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CambiosTraseiros
        public ActionResult Index()
        {
            //return View(db.CambiosTraseiros.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(db.CambiosTraseiros.Where(w => w.Ativo == 0).ToList());
        }

        // GET: CambiosTraseiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CambiosTraseiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Velocidade,Ativo")] CambiosTraseiros cambiosTraseiros)
        {
            if (ModelState.IsValid)
            {
                db.CambiosTraseiros.Add(cambiosTraseiros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // POST: CambiosTraseiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Velocidade,Ativo")] CambiosTraseiros cambiosTraseiros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambiosTraseiros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cambiosTraseiros);
        }

        // GET: CambiosTraseiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            if (cambiosTraseiros == null)
            {
                return HttpNotFound();
            }
            return View(cambiosTraseiros);
        }

        // POST: CambiosTraseiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CambiosTraseiros cambiosTraseiros = db.CambiosTraseiros.Find(id);
            //db.CambiosTraseiros.Remove(cambiosTraseiros);
            //Antes excluia do banco, agora altera o status
            cambiosTraseiros.Ativo = (OpcaoStatusCambiosTraseiros)1;
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
