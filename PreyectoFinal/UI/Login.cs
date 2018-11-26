using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Limpiar()
        {
            errorProvider.Clear();
            UsuarioTextBox.Clear();
            ContraseñaTextBox.Clear();
        }

        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text) || string.IsNullOrWhiteSpace(ContraseñaTextBox.Text))
            {
                paso = true;
            }
            return paso;
        }

        public CrearUsuario Llenarclase()
        {
            CrearUsuario usuario = new CrearUsuario()
            {
                Nombres = UsuarioTextBox.Text,
                Contraseña = Program.Hash(ContraseñaTextBox.Text)
            };
            return usuario;
        }


        public void Entrar()
        {
            if (Validar())
            {
                CrearUsuario usuario = Llenarclase();
                RepositorioBase<CrearUsuario> repositorio = new RepositorioBase<CrearUsuario>();
                List<CrearUsuario> lista = repositorio.GetList(u => true);
                if (lista.Count > 0)
                {
                    bool paso = false;
                    CrearUsuario UsuarioIniciado = null;
                    foreach (var item in lista)
                    {
                        if (item.Nombres == usuario.Nombres && item.Contraseña == usuario.Contraseña)
                        {
                            UsuarioIniciado = item;
                            paso = true;
                            break;
                        }
                    }

                    if (paso)
                    {
                        Limpiar();
                        Program.usuario = UsuarioIniciado;
                        Program.menu = new Menu();
                        Program.menu.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("El usuario y la Contrasena No conciden");
                    }
                }
                else
                {
                    repositorio.Guardar(new CrearUsuario()
                    {
                        Nombres = "william",
                        Administrador = true,
                        Contraseña = Program.Hash("polo"),
                        Email = "root",
                        NoTelefono = "root",
                        FechaCreacion = DateTime.Now
                    });
                    MessageBox.Show("Intentar De Nuevo");
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("LLenar Todo  lo Campo");
                if (string.IsNullOrEmpty(ContraseñaTextBox.Text))
                {
                    errorProvider.SetError(ContraseñaTextBox, " LLenar Este Campo");
                }
                if (string.IsNullOrEmpty(UsuarioTextBox.Text))
                {
                    errorProvider.SetError(UsuarioTextBox, "Llenar Campo");
                }
            }

        }

        private void Entrarbutton_Click_1(object sender, EventArgs e)
        {
            Entrar();
        }
    }

}



    

    

