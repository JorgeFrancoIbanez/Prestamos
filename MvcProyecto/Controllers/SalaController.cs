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
        private Db _db = new Db();

        //
        // GET: /Sala/

        public ActionResult Index()
        {
            var model = from r in _db.Salas
                        where r.Estado == "Disponible"
                        select new SalaListViewModel
                        {
                            Id = r.Id,
                            Nombre = r.Nombre,
                            Aula = r.Aula,
                            Salon = r.Salon,
                            Estado =r.Estado,
                            CountComputadores = r.Computadores.Count()
                        };
            return View(model);
        }




        //
        // GET: /Sala/Create
//        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sala/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin")]
        public ActionResult Create(Sala sala)
        {
            if (ModelState.IsValid)
            {
                _db.Salas.Add(sala);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sala);
        }

        //
        // GET: /Sala/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sala sala = _db.Salas.Find(id);
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
                _db.Entry(sala).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sala);
        }

        //
        // GET: /Sala/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sala sala = _db.Salas.Find(id);
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
            Sala sala = _db.Salas.Find(id);
            _db.Salas.Remove(sala);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}