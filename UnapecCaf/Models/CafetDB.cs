using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace UnapecCaf.Models
{
    public class CafetDB:DbContext
    {
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Cafeterias> Cafeterias { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}