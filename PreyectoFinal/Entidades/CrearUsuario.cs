using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
   public class CrearUsuario
    {
        [Key]
        public int CodigoUsuario { get; set;}
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public int Contrasena { get; set; }


    }
}
