using MvcProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProyecto.Controllers
{
    public class ComputadorController : Controller
    {
        //
        // GET: /Computador/
        Db _db = new Db();
        public ActionResult Index([Bind(Prefix="id")]int SalaId)
        {
            var sala = _db.Salas.Find(SalaId);
            if (sala != null)
            {
                return View(sala);
            }
            return HttpNotFound();
        }


        [HttpGet]
        public ActionResult Prestar(int id)
        {
            var model = _db.Computadores.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Prestar(Computador computador)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(computador).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = computador.SalaId });
            }
            return View(computador);
        }


        [HttpGet]
        public ActionResult Create(int SalaID)
        {
            var model = _db.Computadores.Find(SalaID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Computador computador)
        {
            if (ModelState.IsValid)
            {
                _db.Computadores.Add(computador);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = computador.SalaId });
            }
            return View(computador);
        }
        
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Computadores.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Computador computador)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(computador).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = computador.SalaId });
            }
            return View(computador);
        }

        public ActionResult Delete(int id = 0)
        {
            Computador computador = _db.Computadores.Find(id);
            if (computador== null)
            {
                return HttpNotFound();
            }
            return View(computador);
        }

        //
        // POST: /Sala/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computador computador = _db.Computadores.Find(id);
            _db.Computadores.Remove(computador);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = computador.SalaId });
        }
        
        protected override void Dispose(bool disposing)
        {
                _db.Dispose();
 	            base.Dispose(disposing);
        }
    }
}
