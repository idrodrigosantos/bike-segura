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
using static BikeSegura.Models.Pessoas;

namespace BikeSegura.Controllers
{
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas
        public ActionResult Index()
        {
            //return View(db.Pessoas.ToList());
            //Antes listava todos registro, agora lista apenas os com status 0 (ativado)
            return View(db.Pessoas.Where(w => w.Ativo == (OpcaoStatusPessoas)1).ToList());
        }

        [Authorize]
        // GET: Pessoas/Details
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

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,TelefoneUm,TelefoneDois,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContatoUm,TelefoneContatoDois,TipoUsuario,Ativo,DataCadastro")] Pessoas pessoas, string mensagem, string assunto)
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
                        // Salva data e hora do cadastro
                        pessoas.DataCadastro = DateTime.Now;
                        // Gera um código aleatório
                        var codigoValidacao = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Funcoes.CodigoAleatorio(8);
                        pessoas.CodigoValidarEmail = codigoValidacao;
                        // Adiciona uma imagem padrão
                        pessoas.Imagem = "user02.jpg";
                        db.Pessoas.Add(pessoas);
                        db.SaveChanges();
                        //Enviar e-mail para o e-mail cadastrado
                        assunto = "Bike Segura - Cadastro";
                        mensagem = "Seu cadastro foi efetuado com sucesso. Código de validação: " + codigoValidacao;
                        Funcoes.EnviarEmail(pessoas.Email, assunto, mensagem);
                        return RedirectToAction("ValidarEmail", "Pessoas");
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
        // GET: Pessoas/Edit
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

        // POST: Pessoas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,TelefoneUm,TelefoneDois,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContatoUm,TelefoneContatoDois,TipoUsuario,Ativo")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                if (pessoas != null)
                {
                    // Verifica se o e-mail já está cadastrado no banco
                    var verificaemail = db.Pessoas.Where(w => w.Email == pessoas.Email && w.Id != pessoas.Id).FirstOrDefault();
                    if (verificaemail == null)
                    {
                        // Verifica se o CPF já está cadastrado no banco
                        var verificacpf = db.Pessoas.Where(w => w.Cpf == pessoas.Cpf && w.Id != pessoas.Id).FirstOrDefault();
                        if (verificacpf == null)
                        {
                            pessoas.Ativo = (OpcaoStatusPessoas)1;
                            db.Entry(pessoas).State = EntityState.Modified;
                            db.Entry(pessoas).Property(p => p.Imagem).IsModified = false; // Não altera o campo imagem
                            db.Entry(pessoas).Property(p => p.DataCadastro).IsModified = false; // Não altera o campo data de cadastro
                            db.SaveChanges();
                            return RedirectToAction("DashboardUsuario", "Pessoas");
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
            }
            return View(pessoas);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas/Delete
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

        // POST: Pessoas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            //db.Pessoas.Remove(pessoas);
            //Antes excluia do banco, agora altera o status
            pessoas.Ativo = (OpcaoStatusPessoas)0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: Pessoas/EditarSenha
        public ActionResult EditarSenha(int? id)
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

        // POST: Pessoas/EditarSenha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSenha([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,TelefoneUm,TelefoneDois,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContatoUm,TelefoneContatoDois,TipoUsuario,Ativo")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                pessoas.Senha = Funcoes.SHA512(pessoas.Senha); //Criptografia
                pessoas.ConfirmaSenha = Funcoes.SHA512(pessoas.ConfirmaSenha); //Criptografia
                pessoas.Ativo = (OpcaoStatusPessoas)1;
                db.Entry(pessoas).State = EntityState.Modified;
                db.Entry(pessoas).Property(p => p.Imagem).IsModified = false; // Não altera o campo imagem
                db.Entry(pessoas).Property(p => p.DataCadastro).IsModified = false; // Não altera o campo data de cadastro
                db.SaveChanges();
                return RedirectToAction("DashboardUsuario", "Pessoas");
            }
            return View(pessoas);
        }

        [Authorize]
        // GET: Pessoas/EditarImagem
        public ActionResult EditarImagem(int? id)
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

        // POST: Pessoas/EditarImagem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarImagem([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Cpf,Imagem,TipoUsuario,Ativo")] Pessoas pessoas, HttpPostedFileBase arquivoimg)
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
                        pessoas.Ativo = (OpcaoStatusPessoas)1;
                        pessoas.Imagem = nomearquivo;
                        db.Entry(pessoas).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DashboardUsuario", "Pessoas");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                    }
                }
            }
            return View(pessoas);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas/DetailsAdm
        public ActionResult DetailsAdm(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Comum"))
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

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas/EditAdm
        public ActionResult EditAdm(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Comum"))
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

        // POST: Pessoas/EditAdm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdm([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,TelefoneUm,TelefoneDois,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContatoUm,TelefoneContatoDois,TipoUsuario,Ativo")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                if (pessoas != null)
                {
                    // Verifica se o e-mail já está cadastrado no banco
                    var verificaemail = db.Pessoas.Where(w => w.Email == pessoas.Email && w.Id != pessoas.Id).FirstOrDefault();
                    if (verificaemail == null)
                    {
                        // Verifica se o CPF já está cadastrado no banco
                        var verificacpf = db.Pessoas.Where(w => w.Cpf == pessoas.Cpf && w.Id != pessoas.Id).FirstOrDefault();
                        if (verificacpf == null)
                        {
                            db.Entry(pessoas).State = EntityState.Modified;
                            db.Entry(pessoas).Property(p => p.Imagem).IsModified = false; // Não altera o campo imagem
                            db.SaveChanges();
                            return RedirectToAction("DashboardAdm", "Pessoas");
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
            }
            return View(pessoas);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas/EditarSenhaAdm
        public ActionResult EditarSenhaAdm(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Comum"))
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

        // POST: Pessoas/EditarSenhaAdm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSenhaAdm([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Endereco,Numero,Complemento,Cep,Bairro,Cidade,Estado,TelefoneUm,TelefoneDois,Cpf,DataNascimento,Genero,Imagem,NomeContato,TelefoneContato,CelularContatoUm,CelularContatoDois,Ativo")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                pessoas.Senha = Funcoes.SHA512(pessoas.Senha); //Criptografia
                pessoas.ConfirmaSenha = Funcoes.SHA512(pessoas.ConfirmaSenha); //Criptografia
                db.Entry(pessoas).State = EntityState.Modified;
                db.Entry(pessoas).Property(p => p.Imagem).IsModified = false; // Não altera o campo imagem
                db.SaveChanges();
                return RedirectToAction("DashboardAdm", "Pessoas");
            }
            return View(pessoas);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Pessoas/EditarImagemAdm
        public ActionResult EditarImagemAdm(int? id)
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            if (System.Web.HttpContext.Current.User.IsInRole("Comum"))
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

        // POST: Pessoas/EditarImagemAdm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarImagemAdm([Bind(Include = "Id,Nome,Email,ConfirmaEmail,Senha,ConfirmaSenha,Cpf,Imagem,TipoUsuario,Ativo")] Pessoas pessoas, HttpPostedFileBase arquivoimg)
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
                        db.Entry(pessoas).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("DashboardAdm", "Pessoas");
                    }
                    else
                    {
                        ModelState.AddModelError("", valor);
                    }
                }
            }
            return View(pessoas);
        }

        // ValidarEmail início
        public ActionResult ValidarEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarEmail(string email, string codigo)
        {
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.CodigoValidarEmail == codigo).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                usuarios.Ativo = (OpcaoStatusPessoas)1;
                usuarios.CodigoValidarEmail = null;
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PrimeiroAcesso", "Home");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou Código de Validação estão incorretos");
                return View();
            }
        }
        // ValidarEmail fim

        // EsqueceuSenha início
        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EsqueceuSenha(string email, string cpf, string mensagem, string assunto)
        {
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.Cpf == cpf).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                // Gera um código aleatório
                var codigoEsqueceuSenha = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Funcoes.CodigoAleatorio(8);
                usuarios.CodigoEsqueceuSenha = codigoEsqueceuSenha;
                //Enviar e-mail para o e-mail cadastrado
                mensagem = "Para alterar sua senha use esse código de validação: " + codigoEsqueceuSenha;
                assunto = "Bike Segura - Esqueceu Senha";
                Funcoes.EnviarEmail(usuarios.Email, assunto, mensagem);
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ValidarEsqueceuSenha", "Pessoas");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou CPF estão incorretos");
                return View();
            }
        }
        // EsqueceuSenha fim

        // ValidarEsqueceuSenha início
        public ActionResult ValidarEsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarEsqueceuSenha(string email, string codigo, string mensagem, string assunto)
        {
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.CodigoEsqueceuSenha == codigo).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                // Gera um código aleatório
                var novaSenha = Funcoes.CodigoAleatorio(16);
                //Enviar e-mail para o e-mail cadastrado
                mensagem = "Sua nova senha: " + novaSenha;
                assunto = "Bike Segura - Nova Senha";
                Funcoes.EnviarEmail(usuarios.Email, assunto, mensagem);
                usuarios.Senha = Funcoes.SHA512(novaSenha); //Criptografia
                usuarios.ConfirmaSenha = Funcoes.SHA512(novaSenha); //Criptografia
                usuarios.CodigoEsqueceuSenha = null;
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoginRecuperarSenha", "Home");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou Código de Validação estão incorretos");
                return View();
            }
        }
        // ValidarEsqueceuSenha fim

        [Authorize]
        // GET: DashboardUsuario
        public ActionResult DashboardUsuario()
        {
            var usu = System.Web.HttpContext.Current.User.Identity.Name.Split('|')[0];
            int id = Convert.ToInt32(usu);
            var historicos = db.Historicos.Where(x => x.CompradorId == id && x.TipoTransferencia == 0);
            // Consulta banco, número de bicicletas seguras 
            var totalBikeSegura = db.Bicicletas.Where(w => (int)w.AlertaRoubo == 0).Count();
            ViewData["TOTALBIKESEGURA"] = totalBikeSegura;
            // Consulta banco, número de bicicletas roubadas
            var totalBikeRoubada = db.Bicicletas.Where(w => (int)w.AlertaRoubo == 1).Count();
            ViewData["TOTALBIKEROUBADA"] = totalBikeRoubada;
            // Consulta banco, número de bicicletas que não está a venda 
            var totalBikeSemVender = db.Bicicletas.Where(w => (int)w.Vendendo == 0).Count();
            ViewData["TOTALBIKESEMVENDER"] = totalBikeSemVender;
            // Consulta banco, número de bicicletas que estão a venda
            var totalBikeVendendo = db.Bicicletas.Where(w => (int)w.Vendendo == 1).Count();
            ViewData["TOTALBIKEVENDENDO"] = totalBikeVendendo;
            // Consuta banco, número de bicicletas por estado
            var totalBikeAC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 0).Count();
            ViewData["BIKEAC"] = totalBikeAC;
            var totalBikeAL = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 1).Count();
            ViewData["BIKEAL"] = totalBikeAL;
            var totalBikeAP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 2).Count();
            ViewData["BIKEAP"] = totalBikeAP;
            var totalBikeAM = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 3).Count();
            ViewData["BIKEAM"] = totalBikeAM;
            var totalBikeBA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 4).Count();
            ViewData["BIKEBA"] = totalBikeBA;
            var totalBikeCE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 5).Count();
            ViewData["BIKECE"] = totalBikeCE;
            var totalBikeDF = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 6).Count();
            ViewData["BIKEDF"] = totalBikeDF;
            var totalBikeES = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 7).Count();
            ViewData["BIKEES"] = totalBikeES;
            var totalBikeGO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 8).Count();
            ViewData["BIKEGO"] = totalBikeGO;
            var totalBikeMA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 9).Count();
            ViewData["BIKEMA"] = totalBikeMA;
            var totalBikeMT = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 10).Count();
            ViewData["BIKEMT"] = totalBikeMT;
            var totalBikeMS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 11).Count();
            ViewData["BIKEMS"] = totalBikeMS;
            var totalBikeMG = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 12).Count();
            ViewData["BIKEMG"] = totalBikeMG;
            var totalBikePA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 13).Count();
            ViewData["BIKEPA"] = totalBikePA;
            var totalBikePB = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 14).Count();
            ViewData["BIKEPB"] = totalBikePB;
            var totalBikePR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 15).Count();
            ViewData["BIKEPR"] = totalBikePR;
            var totalBikePE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 16).Count();
            ViewData["BIKEPE"] = totalBikePE;
            var totalBikePI = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 17).Count();
            ViewData["BIKEPI"] = totalBikePI;
            var totalBikeRJ = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 18).Count();
            ViewData["BIKERJ"] = totalBikeRJ;
            var totalBikeRN = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 19).Count();
            ViewData["BIKERN"] = totalBikeRN;
            var totalBikeRS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 20).Count();
            ViewData["BIKERS"] = totalBikeRS;
            var totalBikeRO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 21).Count();
            ViewData["BIKERO"] = totalBikeRO;
            var totalBikeRR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 22).Count();
            ViewData["BIKERR"] = totalBikeRR;
            var totalBikeSC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 23).Count();
            ViewData["BIKESC"] = totalBikeSC;
            var totalBikeSP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 24).Count();
            ViewData["BIKESP"] = totalBikeSP;
            var totalBikeSE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 25).Count();
            ViewData["BIKESE"] = totalBikeSE;
            var totalBikeTO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 26).Count();
            ViewData["BIKETO"] = totalBikeTO;
            // Consuta banco, número de bicicletas roubadas por estado
            var totalBikeRoubadaAC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 0).Count();
            ViewData["BIKEROUBADAAC"] = totalBikeRoubadaAC;
            var totalBikeRoubadaAL = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 1).Count();
            ViewData["BIKEROUBADAAL"] = totalBikeRoubadaAL;
            var totalBikeRoubadaAP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 2).Count();
            ViewData["BIKEROUBADAAP"] = totalBikeRoubadaAP;
            var totalBikeRoubadaAM = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 3).Count();
            ViewData["BIKEROUBADAAM"] = totalBikeRoubadaAM;
            var totalBikeRoubadaBA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 4).Count();
            ViewData["BIKEROUBADABA"] = totalBikeRoubadaBA;
            var totalBikeRoubadaCE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 5).Count();
            ViewData["BIKEROUBADACE"] = totalBikeRoubadaCE;
            var totalBikeRoubadaDF = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 6).Count();
            ViewData["BIKEROUBADADF"] = totalBikeRoubadaDF;
            var totalBikeRoubadaES = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 7).Count();
            ViewData["BIKEROUBADAES"] = totalBikeRoubadaES;
            var totalBikeRoubadaGO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 8).Count();
            ViewData["BIKEROUBADAGO"] = totalBikeRoubadaGO;
            var totalBikeRoubadaMA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 9).Count();
            ViewData["BIKEROUBADAMA"] = totalBikeRoubadaMA;
            var totalBikeRoubadaMT = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 10).Count();
            ViewData["BIKEROUBADAMT"] = totalBikeRoubadaMT;
            var totalBikeRoubadaMS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 11).Count();
            ViewData["BIKEROUBADAMS"] = totalBikeRoubadaMS;
            var totalBikeRoubadaMG = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 12).Count();
            ViewData["BIKEROUBADAMG"] = totalBikeRoubadaMG;
            var totalBikeRoubadaPA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 13).Count();
            ViewData["BIKEROUBADAPA"] = totalBikeRoubadaPA;
            var totalBikeRoubadaPB = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 14).Count();
            ViewData["BIKEROUBADAPB"] = totalBikeRoubadaPB;
            var totalBikeRoubadaPR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 15).Count();
            ViewData["BIKEROUBADAPR"] = totalBikeRoubadaPR;
            var totalBikeRoubadaPE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 16).Count();
            ViewData["BIKEROUBADAPE"] = totalBikeRoubadaPE;
            var totalBikeRoubadaPI = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 17).Count();
            ViewData["BIKEROUBADAPI"] = totalBikeRoubadaPI;
            var totalBikeRoubadaRJ = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 18).Count();
            ViewData["BIKEROUBADARJ"] = totalBikeRoubadaRJ;
            var totalBikeRoubadaRN = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 19).Count();
            ViewData["BIKEROUBADARN"] = totalBikeRoubadaRN;
            var totalBikeRoubadaRS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 20).Count();
            ViewData["BIKEROUBADARS"] = totalBikeRoubadaRS;
            var totalBikeRoubadaRO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 21).Count();
            ViewData["BIKEROUBADARO"] = totalBikeRoubadaRO;
            var totalBikeRoubadaRR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 22).Count();
            ViewData["BIKEROUBADARR"] = totalBikeRoubadaRR;
            var totalBikeRoubadaSC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 23).Count();
            ViewData["BIKEROUBADASC"] = totalBikeRoubadaSC;
            var totalBikeRoubadaSP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 24).Count();
            ViewData["BIKEROUBADASP"] = totalBikeRoubadaSP;
            var totalBikeRoubadaSE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 25).Count();
            ViewData["BIKEROUBADASE"] = totalBikeRoubadaSE;
            var totalBikeRoubadaTO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 26).Count();
            ViewData["BIKEROUBADATO"] = totalBikeRoubadaTO;
            return View(historicos.ToList());
        }

        [Authorize(Roles = "Administrador")]
        // GET: DashboardAdm
        public ActionResult DashboardAdm()
        {
            // Consulta banco, número de bicicletas seguras 
            var totalBikeSegura = db.Bicicletas.Where(w => (int)w.AlertaRoubo == 0).Count();
            ViewData["TOTALBIKESEGURA"] = totalBikeSegura;
            // Consulta banco, número de bicicletas roubadas
            var totalBikeRoubada = db.Bicicletas.Where(w => (int)w.AlertaRoubo == 1).Count();
            ViewData["TOTALBIKEROUBADA"] = totalBikeRoubada;
            // Consulta banco, número de bicicletas que não está a venda 
            var totalBikeSemVender = db.Bicicletas.Where(w => (int)w.Vendendo == 0).Count();
            ViewData["TOTALBIKESEMVENDER"] = totalBikeSemVender;
            // Consulta banco, número de bicicletas que estão a venda
            var totalBikeVendendo = db.Bicicletas.Where(w => (int)w.Vendendo == 1).Count();
            ViewData["TOTALBIKEVENDENDO"] = totalBikeVendendo;
            // Consuta banco, número de bicicletas por estado
            var totalBikeAC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 0).Count();
            ViewData["BIKEAC"] = totalBikeAC;
            var totalBikeAL = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 1).Count();
            ViewData["BIKEAL"] = totalBikeAL;
            var totalBikeAP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 2).Count();
            ViewData["BIKEAP"] = totalBikeAP;
            var totalBikeAM = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 3).Count();
            ViewData["BIKEAM"] = totalBikeAM;
            var totalBikeBA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 4).Count();
            ViewData["BIKEBA"] = totalBikeBA;
            var totalBikeCE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 5).Count();
            ViewData["BIKECE"] = totalBikeCE;
            var totalBikeDF = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 6).Count();
            ViewData["BIKEDF"] = totalBikeDF;
            var totalBikeES = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 7).Count();
            ViewData["BIKEES"] = totalBikeES;
            var totalBikeGO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 8).Count();
            ViewData["BIKEGO"] = totalBikeGO;
            var totalBikeMA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 9).Count();
            ViewData["BIKEMA"] = totalBikeMA;
            var totalBikeMT = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 10).Count();
            ViewData["BIKEMT"] = totalBikeMT;
            var totalBikeMS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 11).Count();
            ViewData["BIKEMS"] = totalBikeMS;
            var totalBikeMG = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 12).Count();
            ViewData["BIKEMG"] = totalBikeMG;
            var totalBikePA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 13).Count();
            ViewData["BIKEPA"] = totalBikePA;
            var totalBikePB = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 14).Count();
            ViewData["BIKEPB"] = totalBikePB;
            var totalBikePR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 15).Count();
            ViewData["BIKEPR"] = totalBikePR;
            var totalBikePE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 16).Count();
            ViewData["BIKEPE"] = totalBikePE;
            var totalBikePI = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 17).Count();
            ViewData["BIKEPI"] = totalBikePI;
            var totalBikeRJ = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 18).Count();
            ViewData["BIKERJ"] = totalBikeRJ;
            var totalBikeRN = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 19).Count();
            ViewData["BIKERN"] = totalBikeRN;
            var totalBikeRS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 20).Count();
            ViewData["BIKERS"] = totalBikeRS;
            var totalBikeRO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 21).Count();
            ViewData["BIKERO"] = totalBikeRO;
            var totalBikeRR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 22).Count();
            ViewData["BIKERR"] = totalBikeRR;
            var totalBikeSC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 23).Count();
            ViewData["BIKESC"] = totalBikeSC;
            var totalBikeSP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 24).Count();
            ViewData["BIKESP"] = totalBikeSP;
            var totalBikeSE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 25).Count();
            ViewData["BIKESE"] = totalBikeSE;
            var totalBikeTO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Comprador.Estado == 26).Count();
            ViewData["BIKETO"] = totalBikeTO;
            // Consuta banco, número de bicicletas roubadas por estado
            var totalBikeRoubadaAC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 0).Count();
            ViewData["BIKEROUBADAAC"] = totalBikeRoubadaAC;
            var totalBikeRoubadaAL = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 1).Count();
            ViewData["BIKEROUBADAAL"] = totalBikeRoubadaAL;
            var totalBikeRoubadaAP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 2).Count();
            ViewData["BIKEROUBADAAP"] = totalBikeRoubadaAP;
            var totalBikeRoubadaAM = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 3).Count();
            ViewData["BIKEROUBADAAM"] = totalBikeRoubadaAM;
            var totalBikeRoubadaBA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 4).Count();
            ViewData["BIKEROUBADABA"] = totalBikeRoubadaBA;
            var totalBikeRoubadaCE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 5).Count();
            ViewData["BIKEROUBADACE"] = totalBikeRoubadaCE;
            var totalBikeRoubadaDF = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 6).Count();
            ViewData["BIKEROUBADADF"] = totalBikeRoubadaDF;
            var totalBikeRoubadaES = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 7).Count();
            ViewData["BIKEROUBADAES"] = totalBikeRoubadaES;
            var totalBikeRoubadaGO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 8).Count();
            ViewData["BIKEROUBADAGO"] = totalBikeRoubadaGO;
            var totalBikeRoubadaMA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 9).Count();
            ViewData["BIKEROUBADAMA"] = totalBikeRoubadaMA;
            var totalBikeRoubadaMT = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 10).Count();
            ViewData["BIKEROUBADAMT"] = totalBikeRoubadaMT;
            var totalBikeRoubadaMS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 11).Count();
            ViewData["BIKEROUBADAMS"] = totalBikeRoubadaMS;
            var totalBikeRoubadaMG = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 12).Count();
            ViewData["BIKEROUBADAMG"] = totalBikeRoubadaMG;
            var totalBikeRoubadaPA = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 13).Count();
            ViewData["BIKEROUBADAPA"] = totalBikeRoubadaPA;
            var totalBikeRoubadaPB = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 14).Count();
            ViewData["BIKEROUBADAPB"] = totalBikeRoubadaPB;
            var totalBikeRoubadaPR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 15).Count();
            ViewData["BIKEROUBADAPR"] = totalBikeRoubadaPR;
            var totalBikeRoubadaPE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 16).Count();
            ViewData["BIKEROUBADAPE"] = totalBikeRoubadaPE;
            var totalBikeRoubadaPI = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 17).Count();
            ViewData["BIKEROUBADAPI"] = totalBikeRoubadaPI;
            var totalBikeRoubadaRJ = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 18).Count();
            ViewData["BIKEROUBADARJ"] = totalBikeRoubadaRJ;
            var totalBikeRoubadaRN = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 19).Count();
            ViewData["BIKEROUBADARN"] = totalBikeRoubadaRN;
            var totalBikeRoubadaRS = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 20).Count();
            ViewData["BIKEROUBADARS"] = totalBikeRoubadaRS;
            var totalBikeRoubadaRO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 21).Count();
            ViewData["BIKEROUBADARO"] = totalBikeRoubadaRO;
            var totalBikeRoubadaRR = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 22).Count();
            ViewData["BIKEROUBADARR"] = totalBikeRoubadaRR;
            var totalBikeRoubadaSC = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 23).Count();
            ViewData["BIKEROUBADASC"] = totalBikeRoubadaSC;
            var totalBikeRoubadaSP = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 24).Count();
            ViewData["BIKEROUBADASP"] = totalBikeRoubadaSP;
            var totalBikeRoubadaSE = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 25).Count();
            ViewData["BIKEROUBADASE"] = totalBikeRoubadaSE;
            var totalBikeRoubadaTO = db.Historicos.Where(w => w.Ativo == 0 && w.TipoTransferencia == 0 && (int)w.Bicicletas.AlertaRoubo == 1 && (int)w.Comprador.Estado == 26).Count();
            ViewData["BIKEROUBADATO"] = totalBikeRoubadaTO;
            // Consulta banco, número de pessoas cadastradas por mês           
            var dataCadastro1 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 1);
            ViewData["DATACADASTRO1"] = dataCadastro1;
            var dataCadastro2 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 2);
            ViewData["DATACADASTRO2"] = dataCadastro2;
            var dataCadastro3 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 3);
            ViewData["DATACADASTRO3"] = dataCadastro3;
            var dataCadastro4 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 4);
            ViewData["DATACADASTRO4"] = dataCadastro4;
            var dataCadastro5 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 5);
            ViewData["DATACADASTRO5"] = dataCadastro5;
            var dataCadastro6 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 6);
            ViewData["DATACADASTRO6"] = dataCadastro6;
            var dataCadastro7 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 7);
            ViewData["DATACADASTRO7"] = dataCadastro7;
            var dataCadastro8 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 8);
            ViewData["DATACADASTRO8"] = dataCadastro8;
            var dataCadastro9 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 9);
            ViewData["DATACADASTRO9"] = dataCadastro9;
            var dataCadastro10 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 10);
            ViewData["DATACADASTRO10"] = dataCadastro10;
            var dataCadastro11 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 11);
            ViewData["DATACADASTRO11"] = dataCadastro11;
            var dataCadastro12 = db.Pessoas.Count(w => w.DataCadastro.Value.Month == 12);
            ViewData["DATACADASTRO12"] = dataCadastro12;
            // Consulta banco, número de bicicletas cadastradas por mês           
            var dataBike1 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 1 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE1"] = dataBike1;
            var dataBike2 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 2 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE2"] = dataBike2;
            var dataBike3 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 3 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE3"] = dataBike3;
            var dataBike4 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 4 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE4"] = dataBike4;
            var dataBike5 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 5 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE5"] = dataBike5;
            var dataBike6 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 6 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE6"] = dataBike6;
            var dataBike7 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 7 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE7"] = dataBike7;
            var dataBike8 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 8 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE8"] = dataBike8;
            var dataBike9 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 9 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE9"] = dataBike9;
            var dataBike10 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 10 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE10"] = dataBike10;
            var dataBike11 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 11 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE11"] = dataBike11;
            var dataBike12 = db.Historicos.Count(w => w.DataAquisicao.Value.Month == 12 && w.DataAquisicao.Value.Year == 2018);
            ViewData["DATABIKE12"] = dataBike12;
            return View(db.Pessoas.ToList());
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
