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

        // GET: Imagens
        public ActionResult Index()
        {
            var imagens = db.Imagens.Include(i => i.Bicicletas);
            return View(imagens.ToList());
        }

        // GET: Imagens/Details/5
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

        // GET: Imagens/Create
        public ActionResult Create()
        {
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo");
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imagem,BicicletasId")] Imagens imagens, IEnumerable<HttpPostedFileBase> arquivoimg)
        {
            if (ModelState.IsValid)
            {
                // Método upload imagem do perfil
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
                    return RedirectToAction("Index");
                }
                // Fim método upload imagem do perfil
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        // GET: Imagens/Edit/5
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
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("Index");
            }
            ViewBag.BicicletasId = new SelectList(db.Bicicletas, "Id", "Modelo", imagens.BicicletasId);
            return View(imagens);
        }

        // GET: Imagens/Delete/5
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

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagens imagens = db.Imagens.Find(id);
            db.Imagens.Remove(imagens);
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

        // Ação para apagar a imagem sem atualizar a página
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public JsonResult ExcluirFoto(string id)
        {
            Imagens f = db.Imagens.Find(Convert.ToInt32(id));
            if (f != null)
            {
                db.Imagens.Remove(f);
                db.SaveChanges();
                return Json("s");
            }
            else
            {
                return Json("n");
            }
        }
    }
}
