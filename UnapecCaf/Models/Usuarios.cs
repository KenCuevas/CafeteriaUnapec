using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Usuarios
    {
        public static object IdTipoUsuarios { get; internal set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Cedula { get; set; }
        public string IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Limite de credito")]
        public int LimiteCredito { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Fecha de registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
       "{0:yyyy-MM-dd}",
       ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }


        public virtual TipoUsuarios TipoUsuarios { get; set; }

    }
}