using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Life.Models;
using System.Net;
using System.Data.Entity;

namespace APP_Life.Controllers
{
    public class LancamentoController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();
        // GET: Lancamento

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.listaReceita = contexto.receitas.ToList().Where(x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));
                ViewBag.listaDespesa = contexto.despesas.ToList().Where(x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"])); ;
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
                return PartialView("_Receitas");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }


        public ActionResult CadastrarReceita()
        {
            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );

            return PartialView("_CadastrarReceita");


        }


        [HttpPost]
        public ActionResult CadastrarReceita(receita rece)
        {
            if (ModelState.IsValid)
            {
                receita x = new receita();
                x.CadastrarReceita(rece, Convert.ToInt32(Session["usuarioLogadoID"]));
                return RedirectToAction("Receitas");
            }
            return RedirectToAction("Geral");
        }


        public ActionResult ReceitaDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receita main = contexto.receitas.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }

            receita rece = new receita();
            rece.RemoverReceita(main.ReceitaID);

            return RedirectToAction("Receitas");
        }



        public ActionResult ReceitaUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receita rece = contexto.receitas.Find(id);
            if (rece == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ReceitaUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ReceitaUpdate(receita rece)
        {

            rece.UpdateReceita(rece);
            return RedirectToAction("Receitas");
        }

        public ActionResult Despesas()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.listaDespesa = contexto.despesas.ToList();
                ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );
                return PartialView("_Despesas");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }

        public ActionResult CadastrarDespesa()
        {
            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );

            return PartialView("_CadastrarDespesa");


        }


        [HttpPost]
        public ActionResult CadastrarDespesa(despesa rece)
        {
            if (ModelState.IsValid)
            {
                despesa x = new despesa();
                x.CadastrarDespesa(rece, Convert.ToInt32(Session["usuarioLogadoID"]));
                return RedirectToAction("Despesas");
            }
            return RedirectToAction("Geral");
        }


        public ActionResult DespesaDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            despesa main = contexto.despesas.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }

            despesa rece = new despesa();
            rece.RemoverDespesa(main.DespesaID);

            return RedirectToAction("Despesas");
        }

        public ActionResult DespesaUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            despesa rece = contexto.despesas.Find(id);
            if (rece == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DespesaUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult DespesaUpdate(despesa rece)
        {

            rece.UpdateDespesa(rece);

            return RedirectToAction("Despesas");
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
                return View(contexto.despesas.ToList());
            }
            else
            {

                return RedirectToAction("Inicio", "Login");
            }

        }




    }
}