﻿using APP_Life.Models;
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


        public ActionResult Index()
        {
            int mes = DateTime.Now.Month;

            int id = Convert.ToInt32(Session["usuarioLogadoID"].ToString());
            ViewBag.listaProjetadoR = contexto.projetadoes.ToList().Where(x =>
            x.categoria.tipo == true && x.UsuarioID == id
            &&
                x.Data.Split('/')[1] == Convert.ToString(mes)

            );

            ViewBag.listaProjetadoD = contexto.projetadoes.ToList().Where(x =>
            x.categoria.tipo == false && x.UsuarioID == id &&
                x.Data.Split('/')[1] == Convert.ToString(mes)
);

            ViewBag.listaObjetivo = contexto.objetivos.ToList().Where(x => x.UsuarioID == id);


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


            return View();

        }



        public ActionResult ProjetadoR()
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {

                return PartialView("_ProjetadoR");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }

        public ActionResult ProjetadoD()
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {
                //ViewBag.listaProjetado = contexto.projetadoes.ToList();

                return PartialView("_ProjetadoD");
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }


        public ActionResult CadastrarProjetado()
        {
            ViewBag.CategoriaID = new SelectList
                (
                    contexto.categorias.ToList(),
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

            return RedirectToAction("Index");
        }



        public ActionResult ProjetadoUpdate(int? id)
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
            return PartialView("_ProjetadoUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult ProjetadoUpdate(projetado rece)
        {

            rece.UpdateProjetado(rece);
            Session["messProjetadoR"] = "Atualizado";
            Session["messProjetadoD"] = "Atualizado";

            return RedirectToAction("Index");
        }



        //objetivo
        public ActionResult Objetivo()
        {
            if (Session["usuarioLogadoID"] != null || Session["usuarioFacebookID"] != null)
            {


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

            rece.UpdateObjetivo(rece);

            Session["messObjetivo"] = "Atualizado";
            return RedirectToAction("Index");
        }




    }
}