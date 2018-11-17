using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class ArticuloDetalle
    {
        [Key]

        public int Id { get; set; }
        public int ArticuloID { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        /*
        [ForeignKey("ProductoId")]
        public virtual Articulo Articulo { get; set; }
        */

        public ArticuloDetalle()
        {
            Id = 0;
            Fecha = DateTime.Now;
            ArticuloID = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
            FechaVencimiento = DateTime.Now;
        }

        public ArticuloDetalle(int id, DateTime fecha, int articuloid, double cantidad, double precio, double importe,DateTime vencimiento)
        {
            Id = id;
            Fecha = fecha;
            ArticuloID = articuloid;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            FechaVencimiento = vencimiento;
        }

    }
}
