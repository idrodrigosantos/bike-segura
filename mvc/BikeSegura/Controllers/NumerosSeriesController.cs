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
    public class NumerosSeriesController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: NumerosSeries
        public ActionResult Index()
        {
            var numerosSeries = db.NumerosSeries.Include(n => n.Bicicletas);
            return View(numerosSeries.ToList());
        }

        // GET: NumerosSeries/Details/5
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
            //ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            if (id == null)
                ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            else
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Id == id), "Id", "Modelo");
            return View();
        }

        // POST: NumerosSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,BicicletasId")] NumerosSeries numerosSeries)
        {
            if (ModelState.IsValid)
            {
                db.NumerosSeries.Add(numerosSeries);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Create", "NumerosSeries", new { id = numerosSeries.BicicletasId });                
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Edit/5
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
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        // POST: NumerosSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,BicicletasId")] NumerosSeries numerosSeries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numerosSeries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Delete/5
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

        // POST: NumerosSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumerosSeries numerosSeries = db.NumerosSeries.Find(id);
            db.NumerosSeries.Remove(numerosSeries);
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

        // Método buscar número de série
        public ActionResult Buscar(string id)
        {
            if (id != null)
            {
                var numeroserie = db.NumerosSeries.Where(w => w.Numero == id).FirstOrDefault();
                if (numeroserie != null)
                {
                    return RedirectToAction("DetalhesBusca", "NumerosSeries", new { id = numeroserie.Id });
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

        // GET: NumerosSeries/DetalhesBusca/5
        public ActionResult DetalhesBusca(int? id)
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

        // Alerta de sucesso do número de série cadastrado
        //[HttpPost]
        //public string alertaCadastro(string Numero)
        //{
        //    if (!String.IsNullOrEmpty(Numero))                
        //        return "O número de série: " + Numero + " foi salvo com suscesso.";
        //    else
        //        return "Número de série é obrigatório.";
        //}
    }
}
