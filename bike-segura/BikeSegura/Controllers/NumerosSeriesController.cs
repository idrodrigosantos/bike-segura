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
        public ActionResult Create(int? id)
        {
            var consultanumero = db.NumerosSeries.Where(w => w.BicicletasId == id).Select(s => s.Numero).ToList();
            ViewBag.ConsultaNumero = consultanumero;
            var consultatipo = db.NumerosSeries.Where(w => w.BicicletasId == id).Select(s => s.Tipo).ToList();
            ViewBag.ConsultaTipo = consultatipo;
            if (id == null)
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
            else
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Id == id), "Id", "Modelo");
            return View();
        }

        // POST: NumerosSeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,BicicletasId,Ativo,Tipo")] NumerosSeries numerosSeries)
        {
            if (numerosSeries != null)
            {
                var verificanumero = db.NumerosSeries.Where(w => w.Numero == numerosSeries.Numero && w.Tipo == 0).FirstOrDefault();
                if (verificanumero == null)
                {
                    db.NumerosSeries.Add(numerosSeries);
                    db.SaveChanges();
                    return RedirectToAction("CreateAdicional", "NumerosSeries", new { id = numerosSeries.BicicletasId });
                }
                else
                {
                    // Se CPF estiver cadastrado no banco, retorna mensagem de erro                
                    ModelState.AddModelError("", "O número de série informado está em uso");
                    ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
                    return View();
                }
            }
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/CreateAdicional
        public ActionResult CreateAdicional(int? id)
        {
            var consultanumero = db.NumerosSeries.Where(w => w.BicicletasId == id).Select(s => s.Numero).ToList();
            ViewBag.ConsultaNumero = consultanumero;
            var consultatipo = db.NumerosSeries.Where(w => w.BicicletasId == id).Select(s => s.Tipo).ToList();
            ViewBag.ConsultaTipo = consultatipo;
            if (id == null)
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
            else
                ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Id == id), "Id", "Modelo");
            return View();
        }

        // POST: NumerosSeries/CreateAdicional
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdicional([Bind(Include = "Id,Numero,BicicletasId,Ativo,Tipo")] NumerosSeries numerosSeries)
        {
            if (ModelState.IsValid)
            {
                db.NumerosSeries.Add(numerosSeries);
                db.SaveChanges();
                return RedirectToAction("CreateAdicional", "NumerosSeries", new { id = numerosSeries.BicicletasId });
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
        }

        [Authorize]
        // GET: NumerosSeries/Create        
        public ActionResult CreateNumeros()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);

            var resultado = db.Bicicletas
                .Join(db.Historicos, inf => inf.Id, his => his.BicicletasId, (inf, his) => new { inf, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.his.Ativo,
                    x.inf.Id,
                    x.inf.Modelo
                }).Where(w => w.CompradorId == idlogado && w.Ativo == 0).ToList();

            ViewBag.BicicletasId = new SelectList(resultado, "Id", "Modelo");
            return View();
        }

        // POST: NumerosSeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNumeros([Bind(Include = "Id,Numero,BicicletasId,Ativo,Tipo")] NumerosSeries numerosSeries)
        {
            if (numerosSeries != null)
            {
                var verificanumero = db.NumerosSeries.Where(w => w.Numero == numerosSeries.Numero && w.Tipo == 0).FirstOrDefault();
                if (verificanumero == null)
                {
                    db.NumerosSeries.Add(numerosSeries);
                    db.SaveChanges();
                    return RedirectToAction("ListaNumerosSeries", "NumerosSeries");
                }
                else
                {
                    // Se CPF estiver cadastrado no banco, retorna mensagem de erro                
                    ModelState.AddModelError("", "O número de série informado está em uso");
                    ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
                    return View();
                }
            }
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
        public ActionResult Edit([Bind(Include = "Id,Numero,BicicletasId,Ativo,Tipo")] NumerosSeries numerosSeries)
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
            if (numerosSeries.Tipo != 0)
            {
                numerosSeries.Ativo = (OpcaoStatusNumerosSeries)1;
                db.SaveChanges();
                return RedirectToAction("ListaNumerosSeries");
            }
            else
            {
                ModelState.AddModelError("", "Número de série do quadro não pode ser excluído.");
                return View(numerosSeries);
            }
        }

        // Método buscar número de série - usuário público
        public ActionResult BuscarPublico()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPublico(string nome)
        {
            if (!String.IsNullOrEmpty(nome))
            {
                // Busca parte no número digitado, sql like
                var numeroserie = db.NumerosSeries.Where(w => w.Numero.Contains(nome)).ToList();
                if (numeroserie != null)
                {
                    return View(numeroserie);
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
        public ActionResult BuscarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarUsuario(string nome)
        {
            if (!String.IsNullOrEmpty(nome))
            {
                // Busca parte no número digitado, sql like
                var numeroserie = db.NumerosSeries.Where(w => w.Numero.Contains(nome)).ToList();
                if (numeroserie != null)
                {
                    return View(numeroserie);
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
        // GET: ListaNumerosSeries
        public ActionResult ListaNumerosSeries()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);

            var resultado = db.NumerosSeries
                .Join(db.Bicicletas, num => num.BicicletasId, bic => bic.Id, (num, bic) => new { num, bic })
                .Join(db.Historicos, num => num.bic.Id, his => his.BicicletasId, (num, his) => new { num, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.num.num.Numero,
                    x.his.Ativo,
                    x.num.bic.Marcas.Nome,
                    x.num.bic.Modelo,
                    x.num.num.Tipo,
                    x.num.num.Id
                }).Where(w => w.CompradorId == idlogado && w.Ativo == 0).ToList();

            string resultNumero = "";
            foreach (var i in resultado)
            {
                resultNumero += "<tr><td>" + i.Numero + "</td>";
                resultNumero += "<td>" + i.Nome + "</td>";
                resultNumero += "<td>" + i.Modelo + "</td>";
                resultNumero += "<td>" + i.Tipo + "</td>";
                resultNumero += @"<td><a class='btn btn-success' href='/NumerosSeries/Details/" + i.Id + @"' role='button'>
                                    <i class='fas fa-list'></i>
                                    Detalhes
                                </a></td>";
                resultNumero += @"<td><a class='btn btn-primary' href='/NumerosSeries/Edit/" + i.Id + @"' role='button'>
                                    <i class='fas fa-pen'></i>
                                    Editar
                                </a></td>";
                resultNumero += @"<td><a class='btn btn-danger' href='/NumerosSeries/Delete/" + i.Id + @"' role='button'>
                                    <i class='fas fa-times'></i>
                                    Excluir
                                </a></td></tr>";
            }
            ViewData["NUMERO"] = resultNumero;
            return View();
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
