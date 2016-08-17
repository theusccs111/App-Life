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

        public ActionResult teste()
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
                    if (item.email == user.email)
                    {
                        Session["usuarioLogadoID"] = item.usuarioID.ToString();
                        Session["nomeUsuarioLogado"] = item.nome.ToString();
                        return RedirectToAction("Lancamento");
                  //      return View("Lancamento");
                    }
                    else
                    {
                       // return View(user);
                    }
                }
            }
            return View(user);
        }


        public ActionResult Inicio()
        {
            Session["usuarioLogadoID"] = null;
            Session["nomeUsuarioLogado"] = null;
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

        public ActionResult Receitas()
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

        public ActionResult Despesas()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(contexto.despesas.ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Geral()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
                var query = from u in contexto.receitas
                            where u.UsuarioID == id
                            select new
                            {

                                valor = u.Valor,

                            };
                Double total = 0;
              foreach(var u in query)
                {
                    total += Convert.ToDouble(u.valor);
                }
                Session["total"] = total;


                return View(contexto.despesas.ToList());
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
                contexto.usuarios.Add(user);
                contexto.SaveChanges();
                return RedirectToAction("Geral");
            }
            return View();
        }

      

    }

}