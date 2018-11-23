using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;
using static BikeSegura.Models.Bicicletas;

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
            //return View(bicicletas.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(bicicletas.Where(w => w.Ativo == 0).ToList());
        }

        [Authorize]
        // GET: Bicicletas/Details
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
            ViewBag.ArosId = new SelectList(db.Aros.Where(w => w.Ativo == 0), "Id", "Medida");
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros.Where(w => w.Ativo == 0), "Id", "Velocidade");
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros.Where(w => w.Ativo == 0), "Id", "Velocidade");
            ViewBag.FreiosId = new SelectList(db.Freios.Where(w => w.Ativo == 0), "Id", "Nome");
            ViewBag.MarcasId = new SelectList(db.Marcas.Where(w => w.Ativo == 0), "Id", "Nome");
            ViewBag.QuadrosId = new SelectList(db.Quadros.Where(w => w.Ativo == 0), "Id", "Material");
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes.Where(w => w.Ativo == 0), "Id", "Nome");
            ViewBag.TiposId = new SelectList(db.Tipos.Where(w => w.Ativo == 0), "Id", "Nome");
            //Mostrar apenas o usuário logado
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            ViewBag.PessoasId = new SelectList(db.Pessoas.Where(w => w.Id == idlogado), "Id", "Nome");
            return View();
        }

        // POST: Bicicletas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MarcasId,Modelo,TiposId,Cor,Imagem,CambiosDianteirosId,CambiosTraseirosId,FreiosId,SuspensoesId,ArosId,QuadrosId,Informacoes,Tamanho,AlertaRoubo,Vendendo,Ativo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Bicicletas.Add(bicicletas);
                db.SaveChanges();
                string modelo = bicicletas.Modelo;
                var bike = db.Bicicletas.Where(t => t.Modelo == modelo).ToList().Last();
                // Salva na tabela Históricos - início
                Historicos hist = new Historicos();
                var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
                int idlogado = Convert.ToInt32(usu);
                hist.CompradorId = idlogado;
                hist.BicicletasId = bike.Id;
                db.Historicos.Add(hist);
                db.SaveChanges();
                // Salva na tabela Históricos - fim
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
        // GET: Bicicletas/Edit
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
            ViewBag.ArosId = new SelectList(db.Aros.Where(w => w.Ativo == 0), "Id", "Medida", bicicletas.ArosId);
            ViewBag.CambiosDianteirosId = new SelectList(db.CambiosDianteiros.Where(w => w.Ativo == 0), "Id", "Velocidade", bicicletas.CambiosDianteirosId);
            ViewBag.CambiosTraseirosId = new SelectList(db.CambiosTraseiros.Where(w => w.Ativo == 0), "Id", "Velocidade", bicicletas.CambiosTraseirosId);
            ViewBag.FreiosId = new SelectList(db.Freios.Where(w => w.Ativo == 0), "Id", "Nome", bicicletas.FreiosId);
            ViewBag.MarcasId = new SelectList(db.Marcas.Where(w => w.Ativo == 0), "Id", "Nome", bicicletas.MarcasId);
            ViewBag.QuadrosId = new SelectList(db.Quadros.Where(w => w.Ativo == 0), "Id", "Material", bicicletas.QuadrosId);
            ViewBag.SuspensoesId = new SelectList(db.Suspensoes.Where(w => w.Ativo == 0), "Id", "Nome", bicicletas.SuspensoesId);
            ViewBag.TiposId = new SelectList(db.Tipos.Where(w => w.Ativo == 0), "Id", "Nome", bicicletas.TiposId);
            //Mostrar apenas o usuário logado
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            ViewBag.PessoasId = new SelectList(db.Pessoas.Where(w => w.Id == idlogado), "Id", "Nome");
            return View(bicicletas);
        }

        // POST: Bicicletas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MarcasId,Modelo,TiposId,Cor,Imagem,CambiosDianteirosId,CambiosTraseirosId,FreiosId,SuspensoesId,ArosId,QuadrosId,Informacoes,Tamanho,AlertaRoubo,Vendendo,Ativo")] Bicicletas bicicletas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicicletas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DashboardUsuario", "Pessoas");
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

        [Authorize(Roles = "Administrador")]
        // GET: Bicicletas/Delete
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

        // POST: Bicicletas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicicletas bicicletas = db.Bicicletas.Find(id);
            //db.Bicicletas.Remove(bicicletas);
            //Antes excluia do banco, agora altera o status
            bicicletas.Ativo = (OpcaoStatusBicicletas)1;
            db.SaveChanges();
            return RedirectToAction("DashboardUsuario", "Pessoas");
        }

        // GET: Bicicletas/DetalhesBicicletaPublico
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

        [Authorize]
        // GET: Bicicletas/DetalhesBicicletaUsuario
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
