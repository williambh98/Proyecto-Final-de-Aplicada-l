using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class Cotizacion
    {
        [Key]
        public int IDCotizacion { get; set; }
        public int CantidadArticulo { get; set; }
        public float precio { get; set; }
        public int RNC { get; set; }
        public string NombreCliente { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string GarantiaArticulo { get; set; }
        public int NumeroCotizacion { get; set; }


    }
}
