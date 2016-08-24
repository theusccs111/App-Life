using System;
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

    }
}