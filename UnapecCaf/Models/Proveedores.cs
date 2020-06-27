using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Proveedores
    {
        public Proveedores()
        {
            this.Articulos = new HashSet<Articulos>();
        }
        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public string RNC { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
     "{0:yyyy-MM-dd}",
      ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Articulos>Articulos { get; set; }
    }
}