using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Articulos
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public float Precio { get; set; }
        public int IdProveedor { get; set; }
        public int UnidadesExistentes { get; set; }
        public bool Activo { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}