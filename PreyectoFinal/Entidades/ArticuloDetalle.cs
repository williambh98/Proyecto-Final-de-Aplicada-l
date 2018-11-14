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

       /* [ForeignKey("FacturaId")]
        public virtual Factura Factura { get; set; }*/

        [ForeignKey("ProductoId")]
        public virtual Articulo Articulo { get; set; }


        public ArticuloDetalle()
        {
            Id = 0;
            Fecha = DateTime.Now;
            ArticuloID = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

       /* public ArticuloDetalle(int id, int facturaId, int productoId, double cantidad, double precio, double importe)
        {
            Id = id;
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }*/

    }
}
