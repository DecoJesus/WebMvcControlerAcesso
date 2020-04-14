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
    public class UsuarioController : Controller
    {
        private DB_CONTROLEACESSOEntities db = new DB_CONTROLEACESSOEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var tB_USUARIO = db.TB_USUARIO.Include(t => t.TB_CARGO);
            return View(tB_USUARIO.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.COD_CARGO = new SelectList(db.TB_CARGO, "COD_CARGO", "CARGO");
            return View();
        }

        // POST: Usuario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_USUARIO,NOME,SOBRENOME,EMAIL,SENHA,COD_CARGO")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TB_USUARIO.Add(tB_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CARGO = new SelectList(db.TB_CARGO, "COD_CARGO", "CARGO", tB_USUARIO.COD_CARGO);
            return View(tB_USUARIO);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CARGO = new SelectList(db.TB_CARGO, "COD_CARGO", "CARGO", tB_USUARIO.COD_CARGO);
            return View(tB_USUARIO);
        }

        // POST: Usuario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_USUARIO,NOME,SOBRENOME,EMAIL,SENHA,COD_CARGO")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CARGO = new SelectList(db.TB_CARGO, "COD_CARGO", "CARGO", tB_USUARIO.COD_CARGO);
            return View(tB_USUARIO);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            db.TB_USUARIO.Remove(tB_USUARIO);
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
