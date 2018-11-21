using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.NumerosSeries;

namespace BikeSegura.Controllers
{
    public class NumerosSeriesController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: NumerosSeries
        public ActionResult Index()
        {
            var numerosSeries = db.NumerosSeries.Include(n => n.Bicicletas);
            //return View(numerosSeries.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(numerosSeries.Where(w => w.Ativo == 0).ToList());
        }

        [Authorize]
        // GET: NumerosSeries/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            if (numerosSeries == null)
            {
                return HttpNotFound();
            }
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Create
        //public ActionResult Create()
        public ActionResult Create(int? id)
        {
            var consultanumero = db.NumerosSeries.Where(w => w.BicicletasId == id).Select(s => s.Numero).FirstOrDefault();
            ViewData["CONSULTANUMERO"] = consultanumero;
            //ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");            
            if (id == null)
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
            else
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Id == id), "Id", "Modelo");
            return View();
        }

        // POST: NumerosSeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,BicicletasId,Ativo")] NumerosSeries numerosSeries)
        {
            if (ModelState.IsValid)
            {
                db.NumerosSeries.Add(numerosSeries);
                db.SaveChanges();
                return RedirectToAction("Create", "NumerosSeries", new { id = numerosSeries.BicicletasId });
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            if (numerosSeries == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        // POST: NumerosSeries/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,BicicletasId,Ativo")] NumerosSeries numerosSeries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numerosSeries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaNumerosSeries");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            if (numerosSeries == null)
            {
                return HttpNotFound();
            }
            return View(numerosSeries);
        }

        // POST: NumerosSeries/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            //db.NumerosSeries.Remove(numerosSeries);
            //Antes excluia do banco, agora altera o status
            numerosSeries.Ativo = (OpcaoStatusNumerosSeries)1;
            db.SaveChanges();
            return RedirectToAction("ListaNumerosSeries");
        }

        // Método buscar número de série - usuário público
        public ActionResult BuscarPublico(string id)
        {
            if (id != null)
            {
                var numeroserie = db.NumerosSeries.Where(w => w.Numero == id).FirstOrDefault();
                if (numeroserie != null)
                {
                    return RedirectToAction("DetalhesBuscaPublico", "NumerosSeries", new { id = numeroserie.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Número de série não foi encontrado");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        // Método buscar número de série - usuário logado
        public ActionResult BuscarUsuario(string id)
        {
            if (id != null)
            {
                var numeroserie = db.NumerosSeries.Where(w => w.Numero == id).FirstOrDefault();
                if (numeroserie != null)
                {
                    return RedirectToAction("DetalhesBuscaUsuario", "NumerosSeries", new { id = numeroserie.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Número de série não foi encontrado");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: NumerosSeries/DetalhesBusca
        public ActionResult DetalhesBuscaPublico(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            if (numerosSeries == null)
            {
                return HttpNotFound();
            }
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/DetalhesBuscaUsuario
        public ActionResult DetalhesBuscaUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            if (numerosSeries == null)
            {
                return HttpNotFound();
            }
            return View(numerosSeries);
        }

        [Authorize]
        // GET: ListaNumerosSeries
        public ActionResult ListaNumerosSeries()
        {
            var numerosSeries = db.NumerosSeries.Include(n => n.Bicicletas);
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            return View(numerosSeries.Where(w => w.Ativo == 0 && w.Bicicletas.Pessoas.Id == idlogado).ToList());
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
