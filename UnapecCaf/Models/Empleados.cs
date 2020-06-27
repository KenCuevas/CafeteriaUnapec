using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Empleados
    {
        public Empleados()
        {
            this.Cafeterias = new HashSet<Cafeterias>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string TandaLabor { get; set; }
        public int comision { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Cafeterias>Cafeterias{get;set;}
    }
}