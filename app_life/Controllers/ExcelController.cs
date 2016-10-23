using APP_Life.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APP_Life.Controllers
{
    public class ExcelController : Controller
    {

        app_lifeContext contexto = new app_lifeContext();

        // GET: Excel
        public ActionResult Index()
        {
            return View();

        }



        //controller Action
        public void Excel()
        {
            var model = contexto.receitas.ToList().Where(x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));
            var model2 = contexto.despesas.ToList().Where(x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));



            Export export = new Export();

            Export export2 = new Export();
            export.ToExcel(Response, model);

            export2.ToExcel(Response, model2);

        }

        public void Excel2()
        {
            var model2 = contexto.despesas.ToList().Where(
                x => x.UsuarioID == Convert.ToInt32(Session["usuarioLogadoID"]));
            
            
            Export export2 = new Export();
           
            export2.ToExcel(Response, model2);

        }

        //helper class
        public class Export
        {
            public void ToExcel(HttpResponseBase Response, object clientsList)
            {
                var grid = new System.Web.UI.WebControls.GridView();
                grid.DataSource = clientsList;
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=Relatório_AppLife.xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                grid.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }


    }
}