using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoE.Models;

namespace ProjetoE.Controllers
{
    public class RelacionamentoController : Controller
    {
        private contexto db = new contexto();

        // GET: Relacionamento
        public ActionResult Index()
        {
            List<cao_dono> ListaRelacioinamento = db.Relacionamento.ToList();

            foreach (var item in ListaRelacioinamento)
            {
                item.Nome_Dono = db.Donos.Where(x => x.ID_Dono == item.ID_dono).ToList().FirstOrDefault().Nome;
                item.Nome_Cao = db.Caes.Where(x => x.ID_cao == item.ID_cao).ToList().FirstOrDefault().Nome;
            }

            return View(ListaRelacioinamento);
        }

        // GET: Relacionamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao_dono cao_dono = db.Relacionamento.Find(id);
            if (cao_dono == null)
            {
                return HttpNotFound();
            }
            return View(cao_dono);
        }

        // GET: Relacionamento/Create
        public ActionResult Create()
        {
            ViewBag.Donos = db.Donos.ToList().OrderBy(x => x.Nome);
            ViewBag.Caes = db.Caes.ToList().OrderBy(x => x.Nome);
            return View();
        }

        // POST: Relacionamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_cao_dono,ID_dono,ID_cao")] cao_dono cao_dono)
        {
            if (ModelState.IsValid)
            {
                db.Relacionamento.Add(cao_dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cao_dono);
        }

        // GET: Relacionamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao_dono cao_dono = db.Relacionamento.Find(id);
            if (cao_dono == null)
            {
                return HttpNotFound();
            }
            return View(cao_dono);
        }

        // POST: Relacionamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_cao_dono,ID_dono,ID_cao")] cao_dono cao_dono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cao_dono).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cao_dono);
        }

        // GET: Relacionamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao_dono cao_dono = db.Relacionamento.Find(id);
            if (cao_dono == null)
            {
                return HttpNotFound();
            }
            else
            {
                cao_dono.Nome_Dono = db.Donos.Where(x => x.ID_Dono == cao_dono.ID_dono).ToList().FirstOrDefault().Nome;
                cao_dono.Nome_Cao = db.Caes.Where(x => x.ID_cao == cao_dono.ID_cao).ToList().FirstOrDefault().Nome;
            }
            return View(cao_dono);
        }

        // POST: Relacionamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cao_dono cao_dono = db.Relacionamento.Find(id);
            db.Relacionamento.Remove(cao_dono);
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
