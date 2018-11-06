using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class Articulo
    {
        [Key]

        public int CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public float ITS { get; set; }
        public int Precio { get; set; }
        public string Garantia { get; set; }

        public Articulo()
        {
            CodigoArticulo = 0;
            Descripcion = string.Empty;
            Precio = 0;
            ITS = 0;
            Garantia = string.Empty;
        }


    }
}
