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
    public class RelatosRoubosController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: RelatosRoubos
        public ActionResult Index()
        {
            var relatosRoubos = db.RelatosRoubos.Include(r => r.InformacoesRoubos).Include(r => r.Pessoas);
            //return View(relatosRoubos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(relatosRoubos.Where(w => w.Ativo == 0).ToList());
        }

        [Authorize]
        // GET: RelatosRoubos/Details
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

        [Authorize]
        // GET: RelatosRoubos/Create
        public ActionResult Create()
        {
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos.Where(w => w.Ativo == 0), "Id", "Relato");
            //Mostrar apenas o usuário logado
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            ViewBag.PessoasId = new SelectList(db.Pessoas.Where(w => w.Id == idlogado), "Id", "Nome");
            return View();
        }

        // POST: RelatosRoubos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cidade,Estado,Relato,LocalAdicional,DataRelato,PessoasId,InformacoesRoubosId,Ativo")] RelatosRoubos relatosRoubos)
        {
            if (ModelState.IsValid)
            {
                db.RelatosRoubos.Add(relatosRoubos);
                db.SaveChanges();
                return RedirectToAction("ListaUsuario", "RelatosRoubos");
            }
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos, "Id", "Relato", relatosRoubos.InformacoesRoubosId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatosRoubos.PessoasId);
            return View(relatosRoubos);
        }

        [Authorize]
        // GET: RelatosRoubos/Edit
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

        // POST: RelatosRoubos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cidade,Estado,Relato,LocalAdicional,DataRelato,PessoasId,InformacoesRoubosId,Ativo")] RelatosRoubos relatosRoubos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatosRoubos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaUsuario", "RelatosRoubos");
            }
            ViewBag.InformacoesRoubosId = new SelectList(db.InformacoesRoubos, "Id", "Relato", relatosRoubos.InformacoesRoubosId);
            ViewBag.PessoasId = new SelectList(db.Pessoas, "Id", "Nome", relatosRoubos.PessoasId);
            return View(relatosRoubos);
        }

        [Authorize]
        // GET: RelatosRoubos/Delete
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

        // POST: RelatosRoubos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelatosRoubos relatosRoubos = db.RelatosRoubos.Find(id);
            //db.RelatosRoubos.Remove(relatosRoubos);
            //Antes excluia do banco, agora altera o status
            relatosRoubos.Ativo = (OpcaoStatusRelatosRoubos)1;
            db.SaveChanges();
            return RedirectToAction("ListaUsuario", "RelatosRoubos");
        }

        [Authorize]
        // GET: RelatosRoubos
        public ActionResult ListaUsuario()
        {
            var relatosRoubos = db.RelatosRoubos.Include(r => r.InformacoesRoubos).Include(r => r.Pessoas);
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            //return View(relatosRoubos.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(relatosRoubos.Where(w => w.Ativo == 0 && w.Pessoas.Id == idlogado).ToList());
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
