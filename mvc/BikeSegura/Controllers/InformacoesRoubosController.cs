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
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);
            //ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0 && w.PessoasId == idlogado), "Id", "Modelo");

            //var resultado = db.InformacoesRoubos
            //    .Join(db.Bicicletas, inf => inf.BicicletasId, bic => bic.Id, (inf, bic) => new { inf, bic })
            //    .Join(db.Historicos, inf => inf.bic.Id, his => his.BicicletasId, (inf, his) => new { inf, his })
            //    .Select(x => new
            //    {
            //        x.his.CompradorId,
            //        //x.inf.inf.Cidade,
            //        //x.inf.inf.Estado,
            //        //x.inf.inf.LocalAdicional,
            //        //x.inf.inf.DataRoubo,
            //        //x.inf.bic.Modelo,
            //        //x.inf.bic.Marcas.Nome,
            //        //x.inf.inf.Id
            //        x.inf.bic.Id
            //    }).Where(w => w.CompradorId == idlogado).ToList();
            //foreach(var x in resultado)
            //{
            //    x.Id;
            //}
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Id == 0), "Id", "Modelo");
            return View();
        }

        // POST: InformacoesRoubos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cidade,Estado,Relato,LocalAdicional,DataRoubo,BicicletasId,Ativo")] InformacoesRoubos informacoesRoubos)
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
        public ActionResult Edit([Bind(Include = "Id,Cidade,Estado,Relato,LocalAdicional,DataRoubo,BicicletasId,Ativo")] InformacoesRoubos informacoesRoubos)
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
        // GET: ListaNumerosSeries
        public ActionResult ListaUsuario()
        {
            //var numerosSeries = db.NumerosSeries.Include(n => n.Bicicletas);
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);

            var resultado = db.InformacoesRoubos
                .Join(db.Bicicletas, inf => inf.BicicletasId, bic => bic.Id, (inf, bic) => new { inf, bic })
                .Join(db.Historicos, inf => inf.bic.Id, his => his.BicicletasId, (inf, his) => new { inf, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.inf.inf.Cidade,
                    x.inf.inf.Estado,
                    x.inf.inf.LocalAdicional,
                    x.inf.inf.DataRoubo,
                    x.inf.bic.Modelo,
                    x.inf.bic.Marcas.Nome,
                    x.inf.inf.Id
                }).Where(w => w.CompradorId == idlogado).ToList();

            string resulNumero = "", resulMarca = "", resulModelo = "", resulTipo = "";
            foreach (var i in resultado)
            {
                resulNumero += "<tr><td>" + i.Cidade + "</td>";
                resulNumero += "<td>" + i.Estado + "</td>";
                resulNumero += "<td>" + i.LocalAdicional + "</td>";
                resulNumero += "<td>" + i.Nome + "</td>";
                resulNumero += "<td>" + i.Modelo + "</td>";
                resulNumero += "<td>" + i.DataRoubo.ToString("dd/MM/yyyy") + "</td>";
                resulNumero += @"<td><a class='btn btn-success' href='/InformacoesRoubos/Details/" + i.Id + @"' role='button'>
                                    <i class='fas fa-list'></i>
                                    Detalhes
                                </a></td>";
                resulNumero += @"<td><a class='btn btn-primary' href='/InformacoesRoubos/Edit/" + i.Id + @"' role='button'>
                                    <i class='fas fa-pen'></i>
                                    Editar
                                </a></td>";
                resulNumero += @"<td><a class='btn btn-danger' href='/InformacoesRoubos/Delete/" + i.Id + @"' role='button'>
                                    <i class='fas fa-times'></i>
                                    Excluir
                                </a></td></tr>";
            }

            ViewData["NUMERO"] = resulNumero;
            ViewData["MARCA"] = resulMarca;
            ViewData["MODELO"] = resulModelo;
            ViewData["TIPO"] = resulTipo;

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
