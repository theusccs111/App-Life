using APP_Life.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APP_Life.Controllers
{
    public class ProjetadoController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();
        // GET: Projetado


        public ActionResult Index(int? pagina)
        {
            if (Session["usuarioLogadoID"] != null || ViewBag.usuarioFacebookID != null)
            {

                int mes = DateTime.Now.Month;

                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());



                ViewBag.listaProjetadoR2 = contexto.projetadoes.ToList().Where(x =>
            x.categoria.tipo == true && x.UsuarioID == id && x.categoria.tipo == true);



                ViewBag.listaProjetadoD2 = contexto.projetadoes.ToList().Where(x =>
                x.categoria.tipo == false && x.UsuarioID == id && x.categoria.tipo == false);

                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);


                ViewBag.listaObjetivo = contexto.objetivos.ToList().Where(x => x.UsuarioID == id).ToPagedList(paginaNumero, paginaTamanho);

                ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
                    "CategoriaID",
                    "nome"
                );

                if (Session["messProjetadoR"] == null)
                {
                    Session["messProjetadoR"] = "nada";
                }

                if (Session["messProjetadoD"] == null)
                {
                    Session["messProjetadoD"] = "nada";
                }

                if (Session["messObjetivo"] == null)
                {
                    Session["messObjetivo"] = "nada";

                }


                if (Session["menuPro"] == null)
                {
                    Session["menuPro"] = "nada";
                }

                return View();
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }
        }



        public ActionResult ProjetadoR(int? mes, int? pagina)
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {

                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());

                string mesA = "";
                if (mes < 10)
                {
                    mesA = "0" + Convert.ToString(mes);
                }
                else
                {
                    mesA = Convert.ToString(mes);
                }

                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);



                ViewBag.listaProjetadoR = contexto.projetadoes.ToList().Where(x =>
            x.categoria.tipo == true && x.UsuarioID == id
            && 
                x.Data.Split('/')[1] == (mesA) && x.categoria.tipo == true

            ).ToPagedList(paginaNumero, paginaTamanho); 

                return PartialView("_ProjetadoR");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }

        public ActionResult ProjetadoD(int? mes, int? pagina)
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {

                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());

                string mesA = "";
                if (mes < 10)
                {
                    mesA = "0" + Convert.ToString(mes);
                }
                else
                {
                    mesA = Convert.ToString(mes);
                }

                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);


                ViewBag.listaProjetadoD = contexto.projetadoes.ToList().Where(x =>
                x.categoria.tipo == false && x.UsuarioID == id &&
                    x.Data.Split('/')[1] == (mesA) && x.categoria.tipo == false

                                ).ToPagedList(paginaNumero, paginaTamanho); 

                return PartialView("_ProjetadoD");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }


        public ActionResult CadastrarProjetado(bool? cod)
        {
            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList().Where(x => x.tipo == cod),
                    "CategoriaID",
                    "nome"
                );

            return PartialView("_CadastrarProjetado");


        }


        [HttpPost]
        public ActionResult CadastrarProjetado(projetado rece)
        {
            if (ModelState.IsValid)
            {
                projetado x = new projetado();
                x.CadastrarProjetado(rece, Convert.ToInt32(Session["usuarioLogadoID"]));
                Session["messProjetadoR"] = "Incluido";
                Session["messProjetadoD"] = "Incluido";

                Session["menuPro"] = "Projeto";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Geral");
        }


        public ActionResult ProjetadoDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projetado main = contexto.projetadoes.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }

            projetado rece = new projetado();
            rece.RemoverProjetado(main.ProjetadoID);
            Session["messProjetadoR"] = "Deletado";
            Session["messProjetadoD"] = "Deletado";
            Session["menuPro"] = "Projeto";
            return RedirectToAction("Index");
        }



        public ActionResult ProjetadoUpdate(int? id, bool? cod)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projetado rece = contexto.projetadoes.Find(id);
            if (rece == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList().Where(x => x.tipo == cod),
                    "CategoriaID",
                    "nome"
                );


            return PartialView("_ProjetadoUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ProjetadoUpdate(projetado rece)
        {

            rece.UpdateProjetado(rece);
            Session["messProjetadoR"] = "Atualizado";
            Session["messProjetadoD"] = "Atualizado";
            Session["menuPro"] = "Projeto";
            return RedirectToAction("Index");
        }



        //objetivo
        public ActionResult Objetivo(int? pagina)
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {
                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);

                int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());

                ViewBag.listaObjetivo = contexto.objetivos.ToList().Where(x => x.UsuarioID == id).ToPagedList(paginaNumero, paginaTamanho); ;


                return PartialView("_Objetivo");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }
        public ActionResult CadastrarObjetivo()
        {


            return PartialView("_CadastrarObjetivo");


        }


        [HttpPost]
        public ActionResult CadastrarObjetivo(objetivo rece)
        {
            if (ModelState.IsValid)
            {
                objetivo x = new objetivo();
                x.CadastrarObjetivo(rece, Convert.ToInt32(Session["usuarioLogadoID"]));

                Session["messObjetivo"] = "Incluido";
                Session["menuPro"] = "Objeto";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Geral");
        }


        public ActionResult ObjetivoDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objetivo main = contexto.objetivos.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }

            objetivo rece = new objetivo();
            rece.RemoverObjetivo(main.ObjetivoID);

            Session["messObjetivo"] = "Deletado";
            Session["menuPro"] = "Objeto";
            return RedirectToAction("Index");
        }



        public ActionResult ObjetivoUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            objetivo rece = contexto.objetivos.Find(id);
            if (rece == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ObjetivoUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ObjetivoUpdate(objetivo rece)
        {
            if (ModelState.IsValid)
            {
                objetivo x = new objetivo();
                rece.ValorAtual = rece.ValorAtual + rece.valorADD;

                rece.UpdateObjetivo(rece);

                despesa dp = new despesa();
                dp.CategoriaID = 9;
                dp.UsuarioID = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
                dp.Valor = rece.valorADD;
                dp.Descricao = "Despesa do objetivo: " + rece.Nome;
                dp.Data = Convert.ToString(DateTime.Now.Day) + "/" + Convert.ToString(DateTime.Now.Month) + "/" + Convert.ToString(DateTime.Now.Year);

                dp.CadastrarDespesa(dp, Convert.ToInt32(Session["usuarioLogadoID"].ToString()));
                Session["messObjetivo"] = "Incluido";
                Session["menuPro"] = "Objeto";
                return RedirectToAction("Index");

            }
         

            Session["messObjetivo"] = "Atualizado";
            Session["menuPro"] = "Objeto";
            return RedirectToAction("Index");
        }




    }
}