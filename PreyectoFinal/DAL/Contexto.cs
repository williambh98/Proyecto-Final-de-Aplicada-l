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
        public DbSet<Articulo>_Articulo { get; set; }
        public DbSet<Proveedores> Clientes { get; set; }
       // public DbSet<Cotizacion> Cotizacion { get; set; }
        public DbSet<CrearUsuario> Usuario { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
