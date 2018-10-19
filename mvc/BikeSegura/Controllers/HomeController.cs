//using BikeSegura.Models;
using BikeSegura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using System.Web.Security;

namespace BikeSegura.Controllers
{
    public class HomeController : Controller
    {
        Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Login Início
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string ReturnUrl)
        {
            Pessoas usuarios = db.Pessoas.Where(t => t.Email == email && t.Senha == senha).ToList().FirstOrDefault();
            if (usuarios != null)
            {
                string permissoes = "";
                permissoes += usuarios.TipoUsuario + ",";
                permissoes = permissoes.Substring(0, permissoes.Length - 1);
                FormsAuthentication.SetAuthCookie(usuarios.Nome, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuarios.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
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
        // Login Fim
    }
}
