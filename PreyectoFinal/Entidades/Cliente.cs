using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoFinal.Entidades
{
    public class Cliente
    {
        [Key]
        public int IDcliente { get; set; }
        public int NumeroCedula { get; set; }
        public int edad { get; set; }
        public int ceduala { get; set; }
        public int RNC { get; set; }
        public int Telefono { get; set; }
        public string Nombrecliente { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil {get; set;}
        public string Email { get; set; }
        public DateTime FechaCliete { get; set; }

        public Cliente()
        {
            IDcliente = 0;
            NumeroCedula = 0;
            edad = 0;
            ceduala = 0;
            Telefono = 0;
            Nombrecliente = string.Empty;
            Sexo = string.Empty;
            EstadoCivil = string.Empty;
            Email = string.Empty;
            FechaCliete = DateTime.Now;
        }
        
    }
}
