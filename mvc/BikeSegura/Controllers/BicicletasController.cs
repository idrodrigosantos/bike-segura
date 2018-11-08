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

        [Authorize(Roles = "Administrador")]
        // GET: Bicicletas
        public ActionResult Index()
        {
            var bicicletas = db.Bicicletas.Include(b => b.Aros).Include(b => b.CambiosDianteiros).Include(b => b.CambiosTraseiros).Include(b => b.Freios).Include(b => b.Marcas).Include(b => b.Quadros).Include(b => b.Suspensoes).Include(b => b.Tipos);
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

        [Authorize]
        // GET: Bicicletas/Create
        public ActionResult Create()
        {
            ViewBag.ArosId = new SelectList(db.Aros, "Id", "Medida");
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros, "Id", "Velocidade");
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros, "Id", "Velocidade");
            ViewBag.FreiosId = new SelectList(db.Freios, "Id", "Nome");
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome");
            ViewBag.QuadrosId = new SelectList(db.Quadros, "Id", "Material");
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes, "Id", "Nome");
            ViewBag.TiposId = new SelectList(db.Tipos, "Id", "Nome");
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MarcasId,Modelo,TiposId,Cor,Imagem,CambiosDianteirosId,CambiosTraseirosId,FreiosId,SuspensoesId,ArosId,QuadrosId,Informacoes,Tamanho,AlertaRoubo,Vendendo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Bicicletas.Add(bicicletas);
                db.SaveChanges();
                // Antes, após cadastrar a bicicleta a página era redirecionada para a index,
                //  agora a página é redirecionada para a página de cadastro de número de série
                //return RedirectToAction("Index");
                return RedirectToAction("Create", "NumerosSeries", new { id = bicicletas.Id });
            }

            ViewBag.ArosId = new SelectList(db.Aros, "Id", "Medida", bicicletas.ArosId);
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros, "Id", "Velocidade", bicicletas.CambiosDianteirosId);
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros, "Id", "Velocidade", bicicletas.CambiosTraseirosId);
            ViewBag.FreiosId = new SelectList(db.Freios, "Id", "Nome", bicicletas.FreiosId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadrosId = new SelectList(db.Quadros, "Id", "Material", bicicletas.QuadrosId);
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes, "Id", "Nome", bicicletas.SuspensoesId);
            ViewBag.TiposId = new SelectList(db.Tipos, "Id", "Nome", bicicletas.TiposId);
            return View(bicicletas);
        }

        [Authorize]
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
            ViewBag.ArosId = new SelectList(db.Aros, "Id", "Medida", bicicletas.ArosId);
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros, "Id", "Velocidade", bicicletas.CambiosDianteirosId);
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros, "Id", "Velocidade", bicicletas.CambiosTraseirosId);
            ViewBag.FreiosId = new SelectList(db.Freios, "Id", "Nome", bicicletas.FreiosId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadrosId = new SelectList(db.Quadros, "Id", "Material", bicicletas.QuadrosId);
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes, "Id", "Nome", bicicletas.SuspensoesId);
            ViewBag.TiposId = new SelectList(db.Tipos, "Id", "Nome", bicicletas.TiposId);
            return View(bicicletas);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MarcasId,Modelo,TiposId,Cor,Imagem,CambiosDianteirosId,CambiosTraseirosId,FreiosId,SuspensoesId,ArosId,QuadrosId,Informacoes,Tamanho,AlertaRoubo,Vendendo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicletas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArosId = new SelectList(db.Aros, "Id", "Medida", bicicletas.ArosId);
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros, "Id", "Velocidade", bicicletas.CambiosDianteirosId);
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros, "Id", "Velocidade", bicicletas.CambiosTraseirosId);
            ViewBag.FreiosId = new SelectList(db.Freios, "Id", "Nome", bicicletas.FreiosId);
            ViewBag.MarcasId = new SelectList(db.Marcas, "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadrosId = new SelectList(db.Quadros, "Id", "Material", bicicletas.QuadrosId);
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes, "Id", "Nome", bicicletas.SuspensoesId);
            ViewBag.TiposId = new SelectList(db.Tipos, "Id", "Nome", bicicletas.TiposId);
            return View(bicicletas);
        }

        [Authorize]
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

        // GET: Bicicletas/DetalhesBicicletaPublico/5
        public ActionResult DetalhesBicicletaPublico(int? id)
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

        // GET: Bicicletas/DetalhesBicicletaUsuario/5
        public ActionResult DetalhesBicicletaUsuario(int? id)
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
    }
}
