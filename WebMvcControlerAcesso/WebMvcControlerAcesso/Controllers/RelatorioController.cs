using System;
using System.Collections.Generic;
using PagedList;
using Rotativa.MVC;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcControlerAcesso.Models;

namespace WebMvcControlerAcesso.Controllers
{
    public class RelatorioController : Controller
    {
        private DB_CONTROLEACESSOEntities db = new DB_CONTROLEACESSOEntities();

        // GET: Relatorio
        public ActionResult RelatorioAlunos(int? pagina, Boolean? pdf)
        {
            var listaAlunos = db.TB_ALUNO.OrderBy(c => c.COD_ALUNO).ToList();
            if (pdf != true)
            {
                int numeroRegistros = 3;
                int numeroPagina = (pagina ?? 1);
                return View(listaAlunos.ToPagedList(numeroPagina, numeroRegistros));
            }
            else
            {
                int pagNumero = 1;

                var relatorioPDF = new ViewAsPdf
                {
                    ViewName = "RelatorioAlunos",
                    //IsGrayScale = true,
                    Model = listaAlunos.ToPagedList(pagNumero, listaAlunos.Count)
                };
                return relatorioPDF;
            }
        }

    }
}