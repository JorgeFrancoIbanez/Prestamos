using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProyecto.Models;

namespace MvcProyecto.Controllers
{
    public class HomeController : Controller
    {
        Db _db = new Db();
        public ActionResult Index(string search = null)
        {
            var model = 
                _db.Salas
                .OrderByDescending(r=>r.Computadores.Count())
                .Where(r => search == null || r.Nombre.StartsWith(search))
                .Select(r =>new SalaListViewModel {
                       Id = r.Id,
                       Nombre = r.Nombre,
                       Aula = r.Aula,
                       Salon= r.Salon,
                       CountComputadores= r.Computadores.Count()
            });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
