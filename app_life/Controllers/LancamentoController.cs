using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Life.Models;

namespace APP_Life.Controllers
{
    public class LancamentoController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();
        // GET: Lancamento

            public ActionResult Index()
        {
            return View();
        }
        public ActionResult Receitas()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.listaReceita = contexto.receitas.ToList();
                ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );
                return View();
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }

        public ActionResult CadastrarReceita()
        {
           
            var rece = new receita();
            return View(rece);


        }

        [HttpPost]
        public ActionResult CadastrarReceita(receita rece)
        {
            if (ModelState.IsValid)
            {
                receita x = new receita();
                x.CadastrarReceita(rece, Convert.ToInt32(Session["usuarioLogadoID"]));
                //return RedirectToAction("Geral");
            }
            return RedirectToAction("Receitas");
        }

        public ActionResult Despesas()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(contexto.despesas.ToList());
            }
            else
            {

                return RedirectToAction("Inicio", "Login");
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
                foreach (var u in query)
                {
                    total += Convert.ToDouble(u.valor);
                }
                Session["receitaTotal"] = total;

                var query2 = from u in contexto.despesas
                             where u.UsuarioID == id
                             select new
                             {

                                 valor = u.Valor,

                             };
                Double total2 = 0;
                foreach (var u2 in query2)
                {
                    total2 += Convert.ToDouble(u2.valor);
                }
                Session["despesaTotal"] = total2;

                var query3 = from u in contexto.despesas orderby u.Data select u;
                return View(query3);
            }
            else
            {

                return RedirectToAction("Inicio", "Login");
            }

        }


    }
}