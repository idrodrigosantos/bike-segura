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
            /*
            if (ModelState.IsValid)
            {
                db.NumerosSeries.Add(numerosSeries);
                db.SaveChanges();
                return RedirectToAction("CreateAdicional", "NumerosSeries", new { id = numerosSeries.BicicletasId });
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
            */
        }

        [Authorize]
        // GET: NumerosSeries/CreateAdicional
        //public ActionResult Create()
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
            //ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0 && w.Pessoas.Id == idlogado), "Id", "Modelo");            
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo");
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
            /*
            if (ModelState.IsValid)
            {
                db.NumerosSeries.Add(numerosSeries);
                db.SaveChanges();
                return RedirectToAction("ListaNumerosSeries", "NumerosSeries");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", numerosSeries.BicicletasId);
            return View(numerosSeries);
            */
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
                //db.NumerosSeries.Remove(numerosSeries);
                //Antes excluia do banco, agora altera o status
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
        public ActionResult BuscarPublico(string id)
        {
            if (id != null)
            {
                //var numeroserie = db.NumerosSeries.Where(w => w.Numero == id).FirstOrDefault();
                // Busca parte no número digitado, sql like
                var numeroserie = db.NumerosSeries.Where(w => w.Numero.Contains(id)).FirstOrDefault();
                if (numeroserie != null)
                {
                    return RedirectToAction("DetalhesBuscaPublicoSegura", "NumerosSeries", new { id = numeroserie.Id });
                    //if (numeroserie.Bicicletas.AlertaRoubo == 0)
                    //{
                    //    return RedirectToAction("DetalhesBuscaPublicoSegura", "NumerosSeries", new { id = numeroserie.Id });
                    //}
                    //else
                    //{
                    //    return RedirectToAction("DetalhesBuscaPublicoRoubada", "NumerosSeries", new { id = numeroserie.Id });
                    //}
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
                //var numeroserie = db.NumerosSeries.Where(w => w.Numero == id).FirstOrDefault();
                // Busca parte no número digitado, sql like
                var numeroserie = db.NumerosSeries.Where(w => w.Numero.Contains(id)).FirstOrDefault();
                if (numeroserie != null)
                {
                    if (numeroserie.Bicicletas.AlertaRoubo == 0)
                    {
                        return RedirectToAction("DetalhesBuscaUsuarioSegura", "NumerosSeries", new { id = numeroserie.Id });
                    }
                    else
                    {
                        return RedirectToAction("DetalhesBuscaUsuarioRoubada", "NumerosSeries", new { id = numeroserie.Id });
                    }
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

        // GET: NumerosSeries/DetalhesBuscaPublicoSegura
        public ActionResult DetalhesBuscaPublicoSegura(int? id)
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

        // GET: NumerosSeries/DetalhesBuscaPublicoRoubada
        public ActionResult DetalhesBuscaPublicoRoubada(int? id)
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
        // GET: NumerosSeries/DetalhesBuscaUsuarioSegura
        public ActionResult DetalhesBuscaUsuarioSegura(int? id)
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
        // GET: NumerosSeries/DetalhesBuscaUsuarioRoubada
        public ActionResult DetalhesBuscaUsuarioRoubada(int? id)
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
            //return View(numerosSeries.Where(w => w.Ativo == 0 && w.Bicicletas.Pessoas.Id == idlogado).ToList());
            //var a = from h in db.Historicos
            //        join b in db.Bicicletas on h.BicicletasId equals b.Id
            //        join n in db.NumerosSeries on b.Id equals n.BicicletasId
            //        select new
            //        {
            //            h,
            //            b,
            //            n
            //        };

            var resultado = db.NumerosSeries
                .Join(db.Bicicletas, num => num.BicicletasId, bic => bic.Id, (num, bic) => new { num, bic })
                .Join(db.Historicos, num => num.bic.Id, his => his.BicicletasId, (num, his) => new { num, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.num.num.Numero,
                    x.num.bic.Modelo
                }).Where(w=> w.CompradorId == idlogado).ToList();

            string p = "";
            foreach (var i in resultado)
            {
                p += "<p>"+i.Modelo+" - "+i.Numero+"</p>";
            }

            ViewData["DADOS"] = p;
            ViewBag.ConsultaNum = resultado;

            //var resultadoToList = resultado.ToList();
            //ViewData["DADOS"] = resultadoToList;
            //ViewBag.ConsultaNum = resultadoToList;

            //return View(numerosSeries.Where(w => w.Ativo == 0).ToList());
            //return View(resultadoToList);
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
