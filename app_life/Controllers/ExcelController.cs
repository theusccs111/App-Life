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

            // excel bolado
            var despesaExcel = contexto.despesas.ToList();
            GridView gv = new GridView();
            gv.DataSource = despesaExcel;
            gv.DataBind();
            Session["ExcelDespesa"] = gv;

            var receitaExcel = contexto.receitas.ToList();
            GridView gv2 = new GridView();
            gv2.DataSource = receitaExcel;
            gv2.DataBind();
            Session["ExcelDespesa"] = gv2;

            return View();
        }



        public class DownloadResult : ActionResult
        {
            public GridView excelGridView { get; set; }
            public string nomeArquivo { get; set; }
            //public object HttpContext { get; private set; }
            HttpContext curContext;

            public DownloadResult(GridView gv, string nomearquivo)
            {
                excelGridView = gv;
                nomeArquivo = nomearquivo;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                //Criar um fluxo para gravar o arquivo do Excel

                HttpContext curContext = System.Web.HttpContext.Current;
                curContext.Response.Clear();
                curContext.Response.AddHeader("nome do arquivo", nomeArquivo);
                curContext.Response.Charset = "UTF-8";
                curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                curContext.Response.ContentType = "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet";

                //Renderiza o GridView
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                excelGridView.RenderControl(htw);

                byte[] byteArray = Encoding.ASCII.GetBytes(sw.ToString());
                MemoryStream s = new MemoryStream(byteArray);
                StreamReader sr = new StreamReader(s, Encoding.ASCII);

                curContext.Response.Write(sr.ReadToEnd());
                curContext.Response.End();
            }
        }

        public ActionResult Download(string nomeArquivo)
        {
            if (Session["ExcelDespesa"] != null)
            {
                return new DownloadResult((GridView)Session["ExcelDespesa"], nomeArquivo);

            }
            else
                return RedirectToAction("Geral");
        }


    }
}