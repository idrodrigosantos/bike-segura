using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.InformacoesRoubos;

namespace BikeSegura.Controllers
{
    public class InformacoesRoubosController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: InformacoesRoubos
        public ActionResult Index()
        {
            var informacoesRoubos = db.InformacoesRoubos.Include(i => i.Bicicletas);
            //return View(informacoesRoubos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(informacoesRoubos.Where(w => w.Ativo == 0).ToList());
        }

        [Authorize]
        // GET: InformacoesRoubos/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubos informacoesRoubos = db.InformacoesRoubos.Find(id);
            if (informacoesRoubos == null)
            {
                return HttpNotFound();
            }
            return View(informacoesRoubos);
        }

        [Authorize]
        // GET: InformacoesRoubos/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
            return View();
        }

        // POST: InformacoesRoubos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Relato,Local,Data,BicicletasId,Ativo")] InformacoesRoubos informacoesRoubos)
        {
            if (ModelState.IsValid)
            {
                db.InformacoesRoubos.Add(informacoesRoubos);
                db.SaveChanges();
                return RedirectToAction("ListaUsuario", "InformacoesRoubos");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", informacoesRoubos.BicicletasId);
            return View(informacoesRoubos);
        }

        [Authorize]
        // GET: InformacoesRoubos/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubos informacoesRoubos = db.InformacoesRoubos.Find(id);
            if (informacoesRoubos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo", informacoesRoubos.BicicletasId);
            return View(informacoesRoubos);
        }

        // POST: InformacoesRoubos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Relato,Local,Data,BicicletasId,Ativo")] InformacoesRoubos informacoesRoubos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacoesRoubos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaUsuario", "InformacoesRoubos");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", informacoesRoubos.BicicletasId);
            return View(informacoesRoubos);
        }

        [Authorize]
        // GET: InformacoesRoubos/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacoesRoubos informacoesRoubos = db.InformacoesRoubos.Find(id);
            if (informacoesRoubos == null)
            {
                return HttpNotFound();
            }
            return View(informacoesRoubos);
        }

        // POST: InformacoesRoubos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacoesRoubos informacoesRoubos = db.InformacoesRoubos.Find(id);
            //db.InformacoesRoubos.Remove(informacoesRoubos);
            //Antes excluia do banco, agora altera o status
            informacoesRoubos.Ativo = (OpcaoStatusInformacoesRoubos)1;
            db.SaveChanges();
            return RedirectToAction("ListaUsuario", "InformacoesRoubos");
        }

        [Authorize]
        // GET: InformacoesRoubos
        public ActionResult ListaUsuario()
        {
            var informacoesRoubos = db.InformacoesRoubos.Include(i => i.Bicicletas);
            //return View(informacoesRoubos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(informacoesRoubos.Where(w => w.Ativo == 0).ToList());
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
