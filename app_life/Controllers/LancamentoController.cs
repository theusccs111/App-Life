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

        //
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
            return View(main);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ReceitaDeleteConfirmed(int id)
        {
            receita rece = new receita();
            rece.RemoverReceita(id);
          
            return RedirectToAction("Index");
        }
        //
        /* public ActionResult ReceitaUpdate(int? id)
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
             return View(main);
         }
         [HttpPost, ActionName("ReceitaUpdate")]
         public ActionResult ReceitaUpdateConfirmed(int id)
         {
            // receita rece = new receita();
            // rece.RemoverReceita(id);

             //
             var query = from u in contexto.receitas where u.ReceitaID == id select u;
             foreach (var item in query)
             {
                // item.Descricao = "descricao Nova";

             }
             contexto.SaveChanges();

             //

             return RedirectToAction("Index");
         }*/
         //
         // this action result returns the partial containing the modal
        public ActionResult ReceitaUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receita gradeModelo = contexto.receitas.Find(id);
            if (gradeModelo == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ReceitaUpdate",gradeModelo);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ReceitaUpdate([Bind(Include = "ReceitaId,Descricao,Valor,Data")] receita gradeModelo)
        {

            if (ModelState.IsValid)
            {
                contexto.Entry(gradeModelo).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("receitas");
            }
            return View(gradeModelo);
        }
        /*
        // GET: GradeModeloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receita gradeModelo = contexto.receitas.Find(id);
            if (gradeModelo == null)
            {
                return HttpNotFound();
            }
            return PartialView(gradeModelo);
        }

        // POST: GradeModeloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Descricao,Data")] receita gradeModelo)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(gradeModelo).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("receitas");
            }
            return View(gradeModelo);
        }
        */




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