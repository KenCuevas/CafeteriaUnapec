﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnapecCaf.Models
{
    public class Cafeterias
    {
        public static object IdCampus { get; internal set; }
        public static object idEncargado { get; internal set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public string Descripcion { get; set; }
        public  int IDCampus { get; set; }
        public int IdEncargado { get; set; }
        [Required(ErrorMessage = "El campo es obligatario")]
        public bool Estado { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual Empleados Empleados { get; set; }
    }
}