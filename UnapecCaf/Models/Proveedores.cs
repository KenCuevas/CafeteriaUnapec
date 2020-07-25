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
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Nombre de la empresa")]
        public string NombreComercial { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string RNC { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Fecha de registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
     "{0:yyyy-MM-dd}",
      ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Estado { get; set; }

        public virtual ICollection<Articulos>Articulos { get; set; }
    }
}