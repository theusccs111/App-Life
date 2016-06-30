using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Life.Models;
using System.Collections.ObjectModel;

namespace APP_Life.Controllers
{
    public class LoginController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();

        // GET: Login
        public ActionResult Index()
        {//view tipada
            var user = new usuario();
            return View(user);
        }

        public void lerUsuario()
        {


        }

        [HttpPost]
        public ActionResult Index(usuario user)
        {
            if (ModelState.IsValid)
            {
                var query = from u in contexto.usuarios select u;
                foreach (var item in query)
                {
                    if (item.email == user.email)
                    {
                        Session["usuarioLogadoID"] = item.usuarioID.ToString();
                        Session["nomeUsuarioLogado"] = item.nome.ToString();
                        return RedirectToAction("Lancamento");
                  //      return View("Lancamento");
                    }
                    else
                    {
                        return View(user);
                    }
                }
            }
            return View(user);
        }


        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Lancamento()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(contexto.receitas.ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


        public ActionResult Resultado(usuario user)
        {
            return View(user);
        }

        public ActionResult CadastrarUsuario()
        {
            var user = new usuario();
            return View(user);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(usuario user)
        {
            if (ModelState.IsValid)
            {
                return View("Resultado", user);
            }
            return View(user);
        }

        public ActionResult EmailUnico(string email)
        {
            var loginsDeExemplo = new Collection<string>
            {
                "theus@gmail.com","fael@gmail.com","ivo@gmail.com","lili@gmail.com"
            };
            return Json(loginsDeExemplo.All(x => x.ToLower() != email.ToLower()), JsonRequestBehavior.AllowGet);
        }

    }

}