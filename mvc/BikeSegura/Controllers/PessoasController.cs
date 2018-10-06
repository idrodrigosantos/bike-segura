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
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,Telefone,Celular,Cpf,DataNascimento,Genero,ImagemPerfil,NomeContato,TelefoneContato,TipoUsuario")] Pessoas pessoas, HttpPostedFileBase arquivoimg)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arquivoimg != null)
                {
                    Upload.CriarDiretorio();
                    string nomearquivo = "perfil" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arquivoimg.FileName);
                    valor = Upload.UploadArquivo(arquivoimg, nomearquivo);
                    if (valor == "sucesso")
                    {
                        pessoas.Imagem = nomearquivo;
                        db.Pessoas.Add(pessoas);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                    }
                }
            }
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,Telefone,Celular,Cpf,DataNascimento,Genero,ImagemPerfil,NomeContato,TelefoneContato,TipoUsuario")] Pessoas pessoas, HttpPostedFileBase arquivoimg)
        {
            string valor = "";
            if (ModelState.IsValid)
            {
                if (arquivoimg != null)
                {
                    Upload.CriarDiretorio();
                    string nomearquivo = "perfil" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arquivoimg.FileName);
                    valor = Upload.UploadArquivo(arquivoimg, nomearquivo);
                    if (valor == "sucesso")
                    {
                        Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + pessoas.Imagem);
                        pessoas.Imagem = nomearquivo;
                        db.Entry(pessoas).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.Entry(pessoas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + pessoas.Imagem);
            db.Pessoas.Remove(pessoas);
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
    }
}