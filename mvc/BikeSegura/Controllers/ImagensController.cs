using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;

namespace BikeSegura.Controllers
{
    public class ImagensController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: Imagens
        public ActionResult Index()
        {
            var imagens = db.Imagens.Include(i => i.Bicicletas);
            return View(imagens.ToList());
        }

        [Authorize]
        // GET: Imagens/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagens.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            return View(imagens);
        }

        [Authorize]
        // GET: Imagens/Create
        public ActionResult Create()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);

            var resultado = db.Bicicletas
                .Join(db.Historicos, inf => inf.Id, his => his.BicicletasId, (inf, his) => new { inf, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.inf.Id,
                    x.inf.Modelo
                }).Where(w => w.CompradorId == idlogado).ToList();

            ViewBag.BicicletasId = new SelectList(resultado, "Id", "Modelo");
            return View();
        }

        // POST: Imagens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imagem,BicicletasId")] Imagens imagens, IEnumerable<HttpPostedFileBase> arquivoimg)
        {
            if (ModelState.IsValid)
            {
                // Método upload imagem da bicicleta
                string valor = "";
                string nomearquivo = "";
                if (arquivoimg != null)
                {
                    Upload.CriarDiretorio();
                    foreach (HttpPostedFileBase a in arquivoimg) //a de arquivo
                    {
                        nomearquivo = "bicicleta" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(a.FileName);
                        valor = Upload.UploadArquivo(a, nomearquivo);
                        if (valor == "sucesso")
                        {
                            imagens.Imagem = nomearquivo;
                            db.Imagens.Add(imagens);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("ListaUsuario", "Imagens");
                }
                // Fim método upload imagem da bicicleta
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        [Authorize]
        // GET: Imagens/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagens.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas.Where(w => w.Ativo == 0), "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        // POST: Imagens/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imagem,BicicletasId")] Imagens imagens, HttpPostedFileBase arquivoimg)
        {
            string valor = ""; // Faz parte do upload
            if (ModelState.IsValid)
            {
                // Método upload imagem do perfil
                if (arquivoimg != null)
                {
                    Upload.CriarDiretorio();
                    string nomearquivo = "bicicleta" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arquivoimg.FileName);
                    valor = Upload.UploadArquivo(arquivoimg, nomearquivo);
                    if (valor == "sucesso")
                    {
                        Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + imagens.Imagem);
                        imagens.Imagem = nomearquivo;
                        db.Entry(imagens).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                // Fim método upload imagem do perfil
                else
                {
                    db.Entry(imagens).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ListaUsuario", "Imagens");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        [Authorize]
        // GET: Imagens/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagens imagens = db.Imagens.Find(id);
            if (imagens == null)
            {
                return HttpNotFound();
            }
            return View(imagens);
        }

        // POST: Imagens/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagens imagens = db.Imagens.Find(id);
            db.Imagens.Remove(imagens);
            db.SaveChanges();
            return RedirectToAction("ListaUsuario");
        }

        [Authorize]
        // GET: ListaImagens
        public ActionResult ListaUsuario()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int idlogado = Convert.ToInt32(usu);

            var resultado = db.Imagens
                .Join(db.Bicicletas, ima => ima.BicicletasId, bic => bic.Id, (ima, bic) => new { ima, bic })
                .Join(db.Historicos, ima => ima.bic.Id, his => his.BicicletasId, (ima, his) => new { ima, his })
                .Select(x => new
                {
                    x.his.CompradorId,
                    x.ima.bic.Marcas.Nome,
                    x.ima.bic.Modelo,
                    //x.ima.ima.Imagem,
                    x.ima.ima.Id
                }).Where(w => w.CompradorId == idlogado).ToList();

            string resultImagem = "";
            foreach (var i in resultado)
            {
                resultImagem += "<tr><td>" + i.Nome + "</td>";
                resultImagem += "<td>" + i.Modelo + "</td>";
                //resultImagem += @"<td><img src='~/Uploads/" + i.Imagem + @"' style='max-width:70px;' /></td>";
                resultImagem += @"<td><a class='btn btn-success' href='/Imagens/Details/" + i.Id + @"' role='button'>
                                    <i class='fas fa-list'></i>
                                    Detalhes
                                </a></td>";
                resultImagem += @"<td><a class='btn btn-primary' href='/Imagens/Edit/" + i.Id + @"' role='button'>
                                    <i class='fas fa-pen'></i>
                                    Editar
                                </a></td>";
                resultImagem += @"<td><a class='btn btn-danger' href='/Imagens/Delete/" + i.Id + @"' role='button'>
                                    <i class='fas fa-times'></i>
                                    Excluir
                                </a></td></tr>";
            }
            ViewData["IMAGEM"] = resultImagem;
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
