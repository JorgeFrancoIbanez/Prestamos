using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProyecto.Models;

namespace MvcProyecto.Controllers
{
    public class SalaController : Controller
    {
        private Db db = new Db();

        //
        // GET: /Sala/

        public ActionResult Index()
        {
            return View(db.Salas.ToList());
        }


        //
        // GET: /Sala/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sala/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Salas.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sala);
        }

        //
        // GET: /Sala/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        //
        // POST: /Sala/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sala);
        }

        //
        // GET: /Sala/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        //
        // POST: /Sala/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sala sala = db.Salas.Find(id);
            db.Salas.Remove(sala);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}