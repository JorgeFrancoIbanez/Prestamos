using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProyecto.Models
{
    public class SalaListViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Aula { get; set; }

        public int Salon { get; set; }

        public int CountComputadores { get; set; }
    }
}