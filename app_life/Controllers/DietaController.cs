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
    public class DietaController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();

        // GET: Dieta
        public ActionResult Index(int? pagina)
        {
            if (Session["usuarioLogadoID"] != null)
            {

                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);


                ViewBag.listaDieta = (contexto.dietas.ToList().Where(x => x.UsuarioID == 
                Convert.ToInt32(Session["usuarioLogadoID"]))).ToPagedList(paginaNumero,paginaTamanho);

                if (Session["messDieta"] == null)
                {
                    Session["messDieta"] = "nada";
                }

                if (Session["messDietaitens"] == null)
                {
                    Session["messDietaitens"] = "nada";
                }


                return View();
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }
        }

        public ActionResult ListarDieta(int? id)
        {

            ViewBag.ListaAlimentos = contexto.lista_alimentos.ToList().Where(x => x.IDDieta == id);


            return PartialView("_ListarDieta");
        }


        public ActionResult CadastrarItens(int? id)
        {

            ViewBag.IDDieta = new SelectList
               (
                   contexto.dietas.ToList().Where(x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]) && x.DietaID == id),
                   "DietaID",
                   "Nome"
               );


            ViewBag.IDAlimento = new SelectList
    (
        contexto.alimentos.ToList(),
        "ID",
        "Nome"
    );


            return PartialView("_CadastrarItens");
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult CadastrarItens(lista_alimentos rece)
        {
            if (ModelState.IsValid)
            {

                lista_alimentos x = new lista_alimentos();
                x.CadastrarItens(rece);
                Session["messDietaitens"] = "Incluido";


                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public ActionResult CadastrarDieta()
        {


            return PartialView("_CadastrarDieta");


        }



        [HttpPost]
        public ActionResult CadastrarDieta(dieta rece)
        {

            if (ModelState.IsValid)
            {
                dieta x = new dieta();
                x.CadastrarDieta(rece, Convert.ToInt32(Session["usuarioLogadoID"]));
                Session["messDieta"] = "Incluido";

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "erro locao");
                return PartialView("_CadastrarDieta");
            }

        }

        public ActionResult DeleteDieta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dieta main = contexto.dietas.Find(id);
            if (main == null)
            {
                return HttpNotFound();
            }

            dieta rece = new dieta();
            rece.RemoverDieta(main.DietaID);
            Session["messDieta"] = "Deletado";

            return RedirectToAction("Index");
        }



        public ActionResult DietaUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dieta rece = contexto.dietas.Find(id);
            if (rece == null)
            {
                return HttpNotFound();
            }


            return PartialView("_DietaUpdate", rece);
        }

        [HttpPost] // this action takes the viewModel from the modal
        public ActionResult DietaUpdate(dieta rece)
        {

            rece.UpdateDieta(rece);

            Session["messDieta"] = "Atualizado";

            return RedirectToAction("Index");
        }

        public ActionResult ConsultarNutrientesDieta(int? pagina)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                int paginaTamanho = 4;
                int paginaNumero = (pagina ?? 1);


                ViewBag.listaDieta = (contexto.dietas.ToList().Where(x => x.UsuarioID == 
                Convert.ToInt32(Session["usuarioLogadoID"]))).ToPagedList(paginaNumero, paginaTamanho);


                return View();
            }
            else
            {
                return RedirectToAction("Inicio", "Login");
            }

        }
        public ActionResult ConsultarNutrientes(int? id)
        {

            ViewBag.listaAlimentosDetalhes = contexto.lista_alimentos.ToList().
                Where(x => x.IDDieta == id);
               
            
            return PartialView("_ConsultarNutrientes");
        }

        public ActionResult dicas()
        {
            return View();
        }



    }
}