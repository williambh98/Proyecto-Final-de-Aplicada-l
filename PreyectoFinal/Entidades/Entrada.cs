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

        public int  ProvedorID { get; set; }

        public int ProductoId { get; set; }

        public double Cantidad { get; set; }


        public Entrada()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ProductoId = 0;
            Cantidad = 0;
            ProvedorID = 0;
        }
    }
}
