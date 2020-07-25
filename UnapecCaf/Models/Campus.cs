using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Campus
    {
        public Campus ()
        {
            this.Cafeterias = new HashSet<Cafeterias>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        [Display(Name ="Descripcion del campus")]
        public string DescripcionCampus { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Estado { get; set; }

        public virtual ICollection<Cafeterias>Cafeterias { get; set; }
    }
}