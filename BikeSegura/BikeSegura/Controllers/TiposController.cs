using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Tipos;

namespace BikeSegura.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TiposController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Tipos
        public ActionResult Index()
        {
            //return View(db.Tipos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(db.Tipos.Where(w => w.Ativo == 0).ToList());
        }

        // GET: Tipos/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        // GET: Tipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] Tipos tipos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos);
        }

        // GET: Tipos/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        // POST: Tipos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] Tipos tipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos);
        }

        // GET: Tipos/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        // POST: Tipos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos tipos = db.Tipos.Find(id);
            //db.Tipos.Remove(tipos);
            //Antes excluia do banco, agora altera o status
            tipos.Ativo = (OpcaoStatusTipos)1;
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
