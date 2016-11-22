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


            if (Session["messUsuario"] == null)
            {
                Session["messUsuario"] = "nada";
            }

            return View(user);
        }

        public ActionResult LoginFacebook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginFacebook(usuario user)
        {
            app_lifeContext contexto = new app_lifeContext();
            int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
            var query = from u in contexto.usuarios where u.usuarioID == id select u;
            foreach (var item in query)
            {
                              item.idfacebook = user.idfacebook;
            
             
            }
            contexto.SaveChanges();
        
            return RedirectToAction("Geral","Lancamento");
        }

        [HttpPost]
        public ActionResult Index(usuario user)
        {
         
            
            if (ModelState.IsValid)
            {
                int erro = 0;
                var query = from u in contexto.usuarios select u;
                    foreach (var item in query)
                    {

                        if ((item.email == user.email) && (item.senha == user.senha))
                        {
                       erro = 1;
                        Session["usuarioLogadoID"] = item.usuarioID.ToString();
                            Session["nomeUsuarioLogado"] = item.nome.ToString();
                        Session["messUsuario"] = "nada";
                        return RedirectToAction("Geral","Lancamento");
                       

                    }
                    Session["messUsuario"] = "Erro";
                  

                }
          
              
            }
            return RedirectToAction("Index", "Login");
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