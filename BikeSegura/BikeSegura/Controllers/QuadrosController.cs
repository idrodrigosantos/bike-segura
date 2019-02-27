using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Quadros;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class QuadrosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Quadros
        public ActionResult Index()
        {
            //return View(db.Quadros.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(db.Quadros.Where(w => w.Ativo == 0).ToList());
        }

        // GET: Quadros/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // GET: Quadros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quadros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Ativo")] Quadros quadros)
        {
            if (ModelState.IsValid)
            {
                db.Quadros.Add(quadros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quadros);
        }

        // GET: Quadros/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // POST: Quadros/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Ativo")] Quadros quadros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quadros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quadros);
        }

        // GET: Quadros/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quadros quadros = db.Quadros.Find(id);
            if (quadros == null)
            {
                return HttpNotFound();
            }
            return View(quadros);
        }

        // POST: Quadros/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quadros quadros = db.Quadros.Find(id);
            //db.Quadros.Remove(quadros);
            //Antes excluia do banco, agora altera o status
            quadros.Ativo = (OpcaoStatusQuadros)1;
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
