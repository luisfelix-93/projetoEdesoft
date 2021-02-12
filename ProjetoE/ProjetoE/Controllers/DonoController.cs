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
    public class DonoController : Controller
    {
        private contexto db = new contexto();

        // GET: Dono
        public ActionResult Index()
        {
            return View(db.Donos.ToList());
        }

        // GET: Dono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dono dono = db.Donos.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // GET: Dono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Dono,Nome")] dono dono)
        {
            if (ModelState.IsValid)
            {
                db.Donos.Add(dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dono);
        }

        // GET: Dono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dono dono = db.Donos.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // POST: Dono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Dono,Nome")] dono dono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dono).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dono);
        }

        // GET: Dono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dono dono = db.Donos.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // POST: Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dono dono = db.Donos.Find(id);
            db.Donos.Remove(dono);
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
