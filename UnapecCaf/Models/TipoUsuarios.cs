using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class TipoUsuarios
    {
        public TipoUsuarios()
        {
            this.Usuarios = new HashSet<Usuarios>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Estado { get; set; }
       

        public virtual ICollection<Usuarios> Usuarios { get; set; }

    }
}