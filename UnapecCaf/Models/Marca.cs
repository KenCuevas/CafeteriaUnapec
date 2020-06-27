using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Marca
    {
        public Marca()
        {
            this.Articulos = new HashSet<Articulos>();
        }

        public int ID { get; set; }
        public string NombreEmpresa { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}