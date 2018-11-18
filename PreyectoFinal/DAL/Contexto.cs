using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulo> _Articulo { get; set; }
        public DbSet<Departamento> Almacen { get; set; }
        public DbSet<Proveedores> provedores { get; set; }
        public DbSet<TipoArticulo> Tipo { get; set; }
        public DbSet<CrearUsuario> Usuario { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public Contexto() : base("ConStr")
        {

        }
    }
}
