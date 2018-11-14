using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class Proveedores
    {
        [Key]
        public int IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public int RNCCedula { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public float credito { get; set; }
        public float contado { get; set; }
        public DateTime FechaProveedor { get; set; }

        public Proveedores()
        {
            IDProveedor = 0;
            RNCCedula = 0;
            Direccion = string.Empty;
            Telefono = 0;
            NombreProveedor = string.Empty;
            Email = string.Empty;
            credito = 0;
            contado = 0;
            FechaProveedor= DateTime.Now;
        }
        
    }
}
