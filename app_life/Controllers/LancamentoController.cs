using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Life.Models;
using System.Net;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Facebook;
namespace APP_Life.Controllers
{
    public class LancamentoController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();
        // GET: Lancamento

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null || ViewBag.usuarioFacebookID != null)
            {
                int mes = DateTime.Now.Month;

                


                ViewBag.listaReceita2 = contexto.receitas.ToList().Where(x =>
                x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));


                ViewBag.listaDespesa2 = contexto.despesas.ToList().Where(x =>
                x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));


                ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );


                if (Session["messReceita"] == null)
                {
                    Session["messReceita"] = "nada";
                }

                if (Session["messDespesa"] == null)
                {
                    Session["messDespesa"] = "nada";
                }


                return View();
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }
        }
        [HttpPost]
        public ActionResult Receitas(int? mes)
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {
                string mesA = "";
                if (mes < 10)
                {
                    mesA = "0" + Convert.ToString(mes);
                }
                else
                {
                    mesA = Convert.ToString(mes);
                }

                ViewBag.listaReceita = contexto.receitas.ToList().Where(x =>

           x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]) &&
           x.Data.Split('/')[1] == (mesA)

           );



               // ViewBag.listaReceita = contexto.receitas.ToList();
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
                Session["messReceita"] = "Incluido";


                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "erro locao");
                return PartialView("_CadastrarReceita");
            }

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
            Session["messReceita"] = "Deletado";

            return RedirectToAction("Index");
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

            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );



            return PartialView("_ReceitaUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ReceitaUpdate(receita rece)
        {

            rece.UpdateReceita(rece);
            Session["messReceita"] = "Atualizado";

            return RedirectToAction("Index");
        }

        public ActionResult Despesas(int? mes)
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {
                string mesA = "";
                if (mes < 10)
                {
                    mesA = "0" + Convert.ToString(mes);
                }
                else
                {
                    mesA = Convert.ToString(mes);
                }

                ViewBag.listaDespesa = contexto.despesas.ToList().Where(x =>

           x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]) &&
           x.Data.Split('/')[1] == (mesA)

           );


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
                Session["messDespesa"] = "Incluido";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "erro locao");
                return PartialView("_CadastrarDespesa");
            }
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
            Session["messDespesa"] = "Deletado";
            return RedirectToAction("Index");
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

            ViewBag.CategoriaID = new SelectList
                            (
                                contexto.categorias.ToList(),
                                "CategoriaID",
                                "nome"
                            );


            return PartialView("_DespesaUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult DespesaUpdate(despesa rece)
        {

            rece.UpdateDespesa(rece);
            Session["messDespesa"] = "Atualizado";
            return RedirectToAction("Index");
        }

        public ActionResult Geral(Int64? idf)
        {

            //se login com face sucesso
            var queryface = from u in contexto.usuarios where u.idfacebook == idf select u;
            foreach (var item in queryface)
            {

                try
                {
                    if (item.idfacebook == idf && item.idfacebook != null)
                    {
                        Session["usuarioLogadoID"] = item.usuarioID;
                    }
                }
                catch
                {

                    //deslogar do face

                    //mandar para pagina de inicio
                    return RedirectToAction("Inicio", "Login");
                }


            }



            if (Session["usuarioLogadoID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["usuarioFacebookID"] = idf;
            }


            //se nao retorna erro

            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {
                int mes = DateTime.Now.Month;
               
                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
                ViewBag.listaObjetivo = contexto.objetivos.ToList().Where(x => x.UsuarioID == id);
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

                return View(contexto.despesas.ToList().Where(x =>
                x.UsuarioID == id &&
                x.Data.Split('/')[1] == Convert.ToString(mes)


                ));



            }
            else
            {

                return RedirectToAction("Inicio", "Login");
            }

        }



    }
}