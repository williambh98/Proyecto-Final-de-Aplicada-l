using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class TipoArticulo
    {
        [Key]
        public int TiposId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoArticulo()
        {
            TiposId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
