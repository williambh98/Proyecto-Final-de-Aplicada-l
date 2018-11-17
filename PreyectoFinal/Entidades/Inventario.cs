﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
   public class Inventario
    {
        [Key]
        public int IDInveentario { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInventario { get; set; }
        public decimal precio { get; set; }

        public Inventario()
        {
            IDInveentario = 0;
            Descripcion = string.Empty;
            FechaInventario = DateTime.Now;
            precio = 0;
        }

    }
}