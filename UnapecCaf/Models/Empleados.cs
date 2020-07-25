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
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Horario de trabajo")]
        public string TandaLabor { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public int comision { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Estado { get; set; }

        public virtual ICollection<Cafeterias>Cafeterias{get;set;}
    }
}