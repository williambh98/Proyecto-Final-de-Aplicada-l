using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class FacturaD
    {
        [Key]
        public int IDfactura { get; set; }
        public string NombreCliente { get; set; }
        public int PrecioArt { get; set; }
        public int TotalFactura { get; set; }
        public int RNC { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
 
    }
}
