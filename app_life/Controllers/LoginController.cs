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

        public ActionResult LoginFacebook()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Index(usuario user)
        {
            if (ModelState.IsValid)
            {
             
                    var query = from u in contexto.usuarios select u;
                    foreach (var item in query)
                    {
                        if ((item.email == user.email) && (item.senha == user.senha))
                        {
                            Session["usuarioLogadoID"] = item.usuarioID.ToString();
                            Session["nomeUsuarioLogado"] = item.nome.ToString();
                        return RedirectToAction("Geral","Lancamento");
                       

                    }
                  

                }
          
              
            }
            return RedirectToAction("Inicio", "Login");
        }

  


        public ActionResult Inicio()
        {
            Session["usuarioLogadoID"] = null;
            Session["nomeUsuarioLogado"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(usuario user)
        {
            if (ModelState.IsValid)
            {
                usuario x = new usuario();
                x.CadastrarUsuario(user);
                Session["usuarioLogadoID"] = user.usuarioID.ToString();
                //Session["nomeUsuarioLogado"] = user.nome.ToString();
                return RedirectToAction("Geral", "Lancamento");
            }
            return RedirectToAction("Inicio");

        }




    }

}