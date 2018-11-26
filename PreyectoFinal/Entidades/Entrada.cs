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
        public DateTime FechaVencimiento { get; set; }
        public int ProvedorID { get; set; }
        public int ArticuloID { get; set; }
        public double Cantidad { get; set; }

        public virtual List<ArticuloDetalle> Detalle { get; set; }

        public Entrada()
        {
              EntradaId = 0;
              Fecha = DateTime.Now;
              ArticuloID = 0;
              Cantidad = 0;
              ProvedorID = 0;
            FechaVencimiento = DateTime.Now;

            this.Detalle = new List<ArticuloDetalle>();
        }

        public Entrada(int entradaId, DateTime fecha, int provedorID, int articuloID, double cantidad, List<ArticuloDetalle> detalle)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            ProvedorID = provedorID;
            ArticuloID = articuloID;
            Cantidad = cantidad;
            Detalle = detalle;
        }

    }
}
