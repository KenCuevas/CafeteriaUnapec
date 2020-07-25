using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Nombre de la empresa")]
        public string NombreEmpresa { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Activo { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}