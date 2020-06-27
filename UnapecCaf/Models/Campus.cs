using System;
using System.Collections.Generic;
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
        public string DescripcionCampus { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Cafeterias>Cafeterias { get; set; }
    }
}