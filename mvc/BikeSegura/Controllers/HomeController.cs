using BikeSegura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static BikeSegura.Models.Pessoas;

namespace BikeSegura.Controllers
{
    public class HomeController : Controller
    {
        Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAdm()
        {
            return View();
        }

        public ActionResult IndexUsuario()
        {
            return View();
        }

        // Login início
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string ReturnUrl)
        {
            string senhacriptografada = Funcoes.SHA512(senha); //Compara a senha criptografada com a senha digitada
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.Senha == senhacriptografada && t.Ativo == (OpcaoStatusPessoas)1).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                string permissoes = "";
                permissoes += usuarios.TipoUsuario + ",";
                permissoes = permissoes.Substring(0, permissoes.Length - 1);
                FormsAuthentication.SetAuthCookie(usuarios.Nome, false);
                string nome = usuarios.Nome.Contains(' ') ? usuarios.Nome.Split(' ')[0] : usuarios.Nome;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuarios.Id.ToString() + "|" + nome + "|" + usuarios.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    if (usuarios.TipoUsuario == 0)
                    {
                        // Se for usuário comum
                        return RedirectToAction("DashboardUsuario", "Pessoas");
                    }
                    else
                    {
                        // Se for administrador
                        return RedirectToAction("DashboardAdm", "Pessoas");
                    }
                }
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou Senha estão incorretos");
                return View();
            }
        }
        // Login fim

        // PrimeiroAcesso início
        public ActionResult PrimeiroAcesso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrimeiroAcesso(string email, string senha, string ReturnUrl)
        {
            string senhacriptografada = Funcoes.SHA512(senha); //Compara a senha criptografada com a senha digitada
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.Senha == senhacriptografada && t.Ativo == (OpcaoStatusPessoas)1).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                string permissoes = "";
                permissoes += usuarios.TipoUsuario + ",";
                permissoes = permissoes.Substring(0, permissoes.Length - 1);
                FormsAuthentication.SetAuthCookie(usuarios.Nome, false);
                string nome = usuarios.Nome.Contains(' ') ? usuarios.Nome.Split(' ')[0] : usuarios.Nome;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuarios.Id.ToString() + "|" + nome + "|" + usuarios.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    if (usuarios.TipoUsuario == 0)
                    {
                        // Se for usuário comum
                        return RedirectToAction("DashboardUsuario", "Pessoas");
                    }
                    else
                    {
                        // Se for administrador
                        return RedirectToAction("DashboardAdm", "Pessoas");
                    }
                }
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou Senha estão incorretos");
                return View();
            }
        }
        // PrimeiroAcesso fim

        // LoginRecuperarSenha início
        public ActionResult LoginRecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginRecuperarSenha(string email, string senha, string ReturnUrl)
        {
            string senhacriptografada = Funcoes.SHA512(senha); //Compara a senha criptografada com a senha digitada
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.Senha == senhacriptografada && t.Ativo == (OpcaoStatusPessoas)1).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                string permissoes = "";
                permissoes += usuarios.TipoUsuario + ",";
                permissoes = permissoes.Substring(0, permissoes.Length - 1);
                FormsAuthentication.SetAuthCookie(usuarios.Nome, false);
                string nome = usuarios.Nome.Contains(' ') ? usuarios.Nome.Split(' ')[0] : usuarios.Nome;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuarios.Id.ToString() + "|" + nome + "|" + usuarios.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    if (usuarios.TipoUsuario == 0)
                    {
                        // Se for usuário comum
                        return RedirectToAction("EditarSenha", "Pessoas");
                    }
                    else
                    {
                        // Se for administrador
                        return RedirectToAction("DashboardAdm", "Pessoas");
                    }
                }
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou Senha estão incorretos");
                return View();
            }
        }
        // LoginRecuperarSenha fim
    }
}
