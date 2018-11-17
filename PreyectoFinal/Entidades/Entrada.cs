using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class Entrada
    {
        [Key]

        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProvedorID { get; set; }
        public int ArticuloID { get; set; }
        public double Cantidad { get; set; }
        public virtual List<ArticuloDetalle> Detalle { get; set; }
        public Entrada()
        {
            /*  EntradaId = 0;
              Fecha = DateTime.Now;
              ArticuloID = 0;
              Cantidad = 0;
              ProvedorID = 0;*/

            this.Detalle = new List<ArticuloDetalle>();
        }

        public void ArticuloDetalle(int id, DateTime fecha, int articuloid, double cantidad, double precio, double importe, DateTime vencimiento)
        {
            this.Detalle.Add(new ArticuloDetalle(id, fecha, articuloid, cantidad, precio, importe, vencimiento));
        }
    }
}
