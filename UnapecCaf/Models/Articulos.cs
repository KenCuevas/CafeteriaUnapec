using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Articulos
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public float Precio { get; set; }
        public int IdProveedor { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name = "Unidades existentes")]
        public int UnidadesExistentes { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Activo { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}