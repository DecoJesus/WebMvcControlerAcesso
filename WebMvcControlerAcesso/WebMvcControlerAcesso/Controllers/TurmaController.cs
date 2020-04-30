using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMvcControlerAcesso.Models;

namespace WebMvcControlerAcesso.Controllers
{
    public class TurmaController : Controller
    {
        private DB_CONTROLEACESSOEntities db = new DB_CONTROLEACESSOEntities();

        // GET: Turma
        public ActionResult Index()
        {
            var tB_TURMA = db.TB_TURMA.Include(t => t.TB_CURSO);
            return View(tB_TURMA.ToList());
        }

        // GET: Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TURMA tB_TURMA = db.TB_TURMA.Find(id);
            if (tB_TURMA == null)
            {
                return HttpNotFound();
            }
            return View(tB_TURMA);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            ViewBag.COD_CURSO = new SelectList(db.TB_CURSO, "COD_CURSO", "NOME_CURSO");
            return View();
        }

        // POST: Turma/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TURMA,SERIE,PERIODO,HORA_ENTRADA,HORA_SAIDA,COD_CURSO")] TB_TURMA tB_TURMA)
        {
            if (ModelState.IsValid)
            {
                db.TB_TURMA.Add(tB_TURMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CURSO = new SelectList(db.TB_CURSO, "COD_CURSO", "NOME_CURSO", tB_TURMA.COD_CURSO);
            return View(tB_TURMA);
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TURMA tB_TURMA = db.TB_TURMA.Find(id);
            if (tB_TURMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CURSO = new SelectList(db.TB_CURSO, "COD_CURSO", "NOME_CURSO", tB_TURMA.COD_CURSO);
            return View(tB_TURMA);
        }

        // POST: Turma/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TURMA,SERIE,PERIODO,HORA_ENTRADA,HORA_SAIDA,COD_CURSO")] TB_TURMA tB_TURMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_TURMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CURSO = new SelectList(db.TB_CURSO, "COD_CURSO", "NOME_CURSO", tB_TURMA.COD_CURSO);
            return View(tB_TURMA);
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TURMA tB_TURMA = db.TB_TURMA.Find(id);
            if (tB_TURMA == null)
            {
                return HttpNotFound();
            }
            return View(tB_TURMA);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_TURMA tB_TURMA = db.TB_TURMA.Find(id);
            db.TB_TURMA.Remove(tB_TURMA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
