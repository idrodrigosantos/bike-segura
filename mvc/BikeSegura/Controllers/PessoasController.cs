using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BikeSegura.Models;

namespace BikeSegura.Controllers
{
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        [Authorize]
        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Administrador"))
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
            else
            {
                Pessoas pessoas = db.Pessoas.Find(Convert.ToInt32(usu));
                if (pessoas == null)
                {
                    return HttpNotFound();
                }
                return View(pessoas);
            }
        }

        //[Authorize]
        //// GET: Pessoas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pessoas pessoas = db.Pessoas.Find(id);
        //    if (pessoas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pessoas);
        //}

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
        public ActionResult Create([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,Telefone,Celular,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContato,CelularContato,TipoUsuario")] Pessoas pessoas)
        {
            if (pessoas != null)
            {
                // Verifica se o e-mail já está cadastrado no banco
                var verificaemail = db.Pessoas.Where(w => w.Email == pessoas.Email).FirstOrDefault();
                if (verificaemail == null)
                {
                    // Verifica se o CPF já está cadastrado no banco
                    var verificacpf = db.Pessoas.Where(w => w.Cpf == pessoas.Cpf).FirstOrDefault();
                    if (verificacpf == null)
                    {
                        // Se não estiver cadastrado e-mail ou CPF, salva no banco
                        pessoas.Senha = Funcoes.SHA512(pessoas.Senha); //Criptografia
                        pessoas.ConfirmaSenha = Funcoes.SHA512(pessoas.ConfirmaSenha); //Criptografia
                        db.Pessoas.Add(pessoas);
                        db.SaveChanges();
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        // Se CPF estiver cadastrado no banco, retorna mensagem de erro
                        ModelState.AddModelError("", "O CPF informado está em uso");
                        return View();
                    }
                }
                else
                {
                    // Se e-mail estiver cadastrado no banco, retorna mensagem de erro
                    ModelState.AddModelError("", "O e-mail informado está em uso");
                    return View();
                }
            }
            else
            {
                return View(pessoas);
            }
        }

        [Authorize]
        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Administrador"))
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
            else
            {
                Pessoas pessoas = db.Pessoas.Find(Convert.ToInt32(usu));
                if (pessoas == null)
                {
                    return HttpNotFound();
                }
                return View(pessoas);
            }
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,Telefone,Celular,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContato,CelularContato,TipoUsuario")] Pessoas pessoas, HttpPostedFileBase arquivoimg)
        {
            string valor = ""; // Faz parte do upload
            if (ModelState.IsValid)
            {
                // Método upload imagem do perfil
                if (arquivoimg != null)
                {
                    Upload.CriarDiretorio();
                    string nomearquivo = "perfil" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(arquivoimg.FileName);
                    valor = Upload.UploadArquivo(arquivoimg, nomearquivo);
                    if (valor == "sucesso")
                    {
                        Upload.ExcluirArquivo(Request.PhysicalApplicationPath + "Uploads\\" + pessoas.Imagem);
                        pessoas.Imagem = nomearquivo;
                        pessoas.Senha = Funcoes.SHA512(pessoas.Senha); //Criptografia
                        pessoas.ConfirmaSenha = Funcoes.SHA512(pessoas.ConfirmaSenha); //Criptografia
                        db.Entry(pessoas).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                // Fim método upload imagem do perfil
                else
                {
                    pessoas.Senha = Funcoes.SHA512(pessoas.Senha); //Criptografia
                    pessoas.ConfirmaSenha = Funcoes.SHA512(pessoas.ConfirmaSenha); //Criptografia
                    db.Entry(pessoas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("DashboardUsuario", "Pessoas");
            }
            return View(pessoas);
        }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Comum")]
        // GET: DashboardUsuario
        public ActionResult DashboardUsuario()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int id = Convert.ToInt32(usu);
            //var historicos = db.Historicos.Include(h => h.Bicicletas).Include(h => h.Comprador).Include(h => h.Vendedor).Where(x => x.CompradorId == id);
            var historicos = db.Historicos.Include(h => h.Bicicletas).Include(h => h.Comprador).Include(h => h.Vendedor).Where(x => x.CompradorId == id && (int)x.TipoTransferencia == 2);
            return View(historicos.ToList());
        }

        [Authorize(Roles = "Administrador")]
        // GET: DashboardAdm
        public ActionResult DashboardAdm()
        {
            //var pessoas = db.Pessoas.Count();
            return View(db.Pessoas.ToList());
        }

        // Alerta de sucesso do cadastro do usuário
        //[HttpPost]
        //public string alertaCadastro(string Nome, string Email, string ConfirmaEmail, 
        //    string Senha, string ConfirmaSenha, string Telefone, string Cpf)
        //{
        //    if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(ConfirmaEmail) && 
        //        !String.IsNullOrEmpty(Senha) && !String.IsNullOrEmpty(ConfirmaSenha) && !String.IsNullOrEmpty(Telefone) && 
        //        !String.IsNullOrEmpty(Cpf))
        //        return "Cadastro realizado com sucesso.";
        //    else
        //        return "Campo(s) obrigatório(s).";
        //}
    }
}
