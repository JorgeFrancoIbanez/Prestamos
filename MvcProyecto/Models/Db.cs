using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcProyecto.Models
{

    public class Db:DbContext
    {
        public Db() : base("name=DefaultConnection")
        {

        }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<PrestamoSala> PrestamosSalas { get; set; }
        public DbSet<PrestamoCompu> PrestamosComputadores { get; set; }
        public DbSet<Computador> Computadores{ get; set; }
    }
}