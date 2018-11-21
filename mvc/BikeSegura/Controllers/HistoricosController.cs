using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Historicos;

namespace BikeSegura.Controllers
{
    public class HistoricosController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: Historicos
        public ActionResult Index()
        {
            var historicos = db.Historicos.Include(h => h.Bicicletas).Include(h => h.Comprador).Include(h => h.Vendedor);
            //return View(historicos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(historicos.Where(w => w.Ativo == 0).ToList());
        }

        [Authorize]
        // GET: Historicos/Details
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

        [Authorize]
        // GET: Historicos/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
            ViewBag.CompradorId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome");
            ViewBag.VendedorId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome");
            return View();
        }

        // POST: Historicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoTransferencia,DataAquisicao,DataTransferencia,BicicletasId,VendedorId,CompradorId,Ativo")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Historicos.Add(historicos);
                db.SaveChanges();
                return RedirectToAction("ListaBicicletas", "Historicos");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historicos.BicicletasId);
            ViewBag.CompradorId = new SelectList(db.Pessoas, "Id", "Nome", historicos.CompradorId);
            ViewBag.VendedorId = new SelectList(db.Pessoas, "Id", "Nome", historicos.VendedorId);
            return View(historicos);
        }

        [Authorize]
        // GET: Historicos/Edit
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
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo", historicos.BicicletasId);
            ViewBag.CompradorId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome", historicos.CompradorId);
            ViewBag.VendedorId = new SelectList(db.Pessoas.Where(w => w.Ativo == 0), "Id", "Nome", historicos.VendedorId);
            return View(historicos);
        }

        // POST: Historicos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoTransferencia,DataAquisicao,DataTransferencia,BicicletasId,VendedorId,CompradorId,Ativo")] Historicos historicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaBicicletas", "Historicos");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", historicos.BicicletasId);
            ViewBag.CompradorId = new SelectList(db.Pessoas, "Id", "Nome", historicos.CompradorId);
            ViewBag.VendedorId = new SelectList(db.Pessoas, "Id", "Nome", historicos.VendedorId);
            return View(historicos);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Historicos/Delete
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

        // POST: Historicos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historicos historicos = db.Historicos.Find(id);
            //db.Historicos.Remove(historicos);
            //Antes excluia do banco, agora altera o status
            historicos.Ativo = (OpcaoStatusHistoricos)1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        // Lista de Bicicletas do Usuário
        public ActionResult ListaBicicletas()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int id = Convert.ToInt32(usu);
            var historicos = db.Historicos.Include(h => h.Bicicletas).Include(h => h.Comprador).Include(h => h.Vendedor).Where(x => x.CompradorId == id && (int)x.TipoTransferencia == 2);
            return View(historicos.ToList());
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
