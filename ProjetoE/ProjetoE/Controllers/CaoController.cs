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
    public class CaoController : Controller
    {
        private contexto db = new contexto();

        // GET: Cao
        public ActionResult Index()
        {
            List<cao> ListaCaesComRacas = db.Caes.ToList();
            foreach (var item in ListaCaesComRacas)
            {
                item.Nome_Raca = db.Racas.Where(x => x.ID_raca == item.ID_raca).ToList().FirstOrDefault().Nome;
            }
            return View(ListaCaesComRacas);
        }

        // GET: Cao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao cao = db.Caes.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            else
            {
                cao.Nome_Raca = db.Racas.Where(x => x.ID_raca == cao.ID_raca).ToList().FirstOrDefault().Nome;
            }
            return View(cao);
        }

        // GET: Cao/Create
        public ActionResult Create()
        {
            ViewBag.Racas = db.Racas.ToList().OrderBy(x => x.Nome);

            return View();
        }

        // POST: Cao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_cao,Nome,ID_raca")] cao cao)
        {
            if (ModelState.IsValid)
            {
                db.Caes.Add(cao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cao);
        }

        // GET: Cao/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Racas = db.Racas.ToList().OrderBy(x => x.Nome);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao cao = db.Caes.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            else
            {
                cao.Nome_Raca = db.Racas.Where(x => x.ID_raca == cao.ID_raca).ToList().FirstOrDefault().Nome;
            }
            return View(cao);
        }

        // POST: Cao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_cao,Nome,ID_raca")] cao cao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cao);
        }

        // GET: Cao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cao cao = db.Caes.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            else
            {
                cao.Nome_Raca = db.Racas.Where(x => x.ID_raca == cao.ID_raca).ToList().FirstOrDefault().Nome;
            }
            return View(cao);
        }

        // POST: Cao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cao cao = db.Caes.Find(id);
            db.Caes.Remove(cao);
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
