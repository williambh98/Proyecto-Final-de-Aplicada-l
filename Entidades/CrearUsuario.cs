using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class CrearUsuario
    {
     
            [Key]

            public int UsuarioId { get; set; }
            public string Nombres { get; set; }
            public string NoTelefono { get; set; }
            public string Email { get; set; }
            public string Contraseña { get; set; }
            public Boolean Administrador { get; set; }
            public DateTime FechaCreacion { get; set; }

            public CrearUsuario()
            {
                UsuarioId = 0;
                Administrador = true;
                Nombres = string.Empty;
                NoTelefono = string.Empty;
                Email = string.Empty;
                Contraseña = string.Empty;
                FechaCreacion = DateTime.Now;
            }

        public CrearUsuario(int usuarioId, string nombres, string noTelefono, string email, string contraseña, bool administrador, DateTime fechaCreacion)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            NoTelefono = noTelefono;
            Email = email;
            Contraseña = contraseña;
            Administrador = administrador;
            FechaCreacion = fechaCreacion;
        }
    }
    }
