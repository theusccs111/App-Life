﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Life.Models;

namespace APP_Life.Controllers
{
    public class UsuarioController : Controller
    {
        app_lifeContext contexto = new app_lifeContext();
        // GET: Usuario
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
                usuario cd = new usuario();
                cd.CadastrarUsuario(user);

                return RedirectToAction("Geral");
            }
            return View();
        }

        public ActionResult InfoUsuario()
        {
            int id = Convert.ToInt32(Session["usuarioLogadoID"]);
            var query = from u in contexto.usuarios where id == u.usuarioID select u;
            var user = new usuario();


            foreach (var item in query)
            {
                user = item;
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult InfoUsuario(usuario rece)
        {
            rece.UpdateUsuario(rece);

            return RedirectToAction("InfoUsuario","Usuario");
        }

        public ActionResult Sincronizar()
        {

            int id = Convert.ToInt32(Session["usuarioLogadoID"]);

            Int64 idFacebook = Convert.ToInt64(Session["usuarioFacebookID"]);


            var queryU = from u in contexto.usuarios where id == u.usuarioID select u;
            foreach (var item in queryU)
            {
                item.idfacebook = idFacebook;
            }
            contexto.SaveChanges();


            return RedirectToAction("Geral","Lancamento");

        }



    }
}