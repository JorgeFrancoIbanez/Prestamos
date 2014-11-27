namespace MvcProyecto.Migrations
{
    using MvcProyecto.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcProyecto.Models.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcProyecto.Models.Db context)
        {
            context.Salas.AddOrUpdate(a => a.Nombre,
               new Sala { Id = 1, Nombre = "ing1", Aula = "A1-", Salon = 401 },
               new Sala { Id = 2, Nombre = "ing2", Aula = "A1-", Salon = 402 },
               new Sala
               {
                   Id = 3,
                   Nombre = "REDES",
                   Aula = "A1-",
                   Salon = 406,
                   Computadores =
                   new List<Computador>
                   {
                       new Computador{ Id=1, SalaId = 1, Serial="A123", Estado="Disponible"} 
                   }
               }
            );

        }
    }
}