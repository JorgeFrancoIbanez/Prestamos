using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProyecto.Models
{
    public class Computador
    {

        public int Id { get; set; }
        [Required] //validation/Data annotation
        public int SalaId{ get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Serial{ get; set; }
        public string Estado{ get; set; }
    
    }
}