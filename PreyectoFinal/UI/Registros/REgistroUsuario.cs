using PreyectoFinal.BLL;
using PreyectoFinal.DAL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI.Registros
{
    public partial class REgistroUsuario : Form
    {

       
        public REgistroUsuario()
        {
            InitializeComponent();
        }


        private CrearUsuario LlenaClase()
        {
            CrearUsuario usuario = new CrearUsuario();

            usuario.UsuarioId = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            usuario.Nombres = NombresTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.NoTelefono = NoTelefonoMaskedTextBox.Text;
            usuario.Administrador = true;
            usuario.Contraseña = ContraseñaTextBox.Text;

            return usuario;
        }

        private void Limpiar()
        {
            UsuarioIdNumericUpDown.Value = 0;
            NombresTextBox.Clear();
            EmailTextBox.Clear();
            AdministradorradioButton.Text = string.Empty;
            NoTelefonoMaskedTextBox.Clear();
            ContraseñaTextBox.Clear();
            ErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(NombresTextBox.Text))
            {
                ErrorProvider.SetError(NombresTextBox,
                    "Debe escribir el Nombre Completo para el Usuario");
                paso = true;
            }
            if (String.IsNullOrEmpty(EmailTextBox.Text))
            {
                ErrorProvider.SetError(EmailTextBox,
                    "Debe ingresar un Email para el Usuario");
                paso = true;
            }
            if (String.IsNullOrEmpty(NoTelefonoMaskedTextBox.Text))
            {
                ErrorProvider.SetError(NoTelefonoMaskedTextBox,
                    "Debe ingresar un Número de Teléfono para el Usuario");
                paso = true;
            }
            if (String.IsNullOrEmpty(ContraseñaTextBox.Text))
            {
                ErrorProvider.SetError(ContraseñaTextBox,
                    "Debe ingresar una Contraseña para el Usuario");
                paso = true;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repos = new RepositorioBase<CrearUsuario>();
            CrearUsuario usuario;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            usuario = LlenaClase();

            if (UsuarioIdNumericUpDown.Value == 0)
            {
                paso = repos.Guardar(usuario);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
                usuario = repos.Buscar(id);

                if (usuario != null)
                {
                    paso = repos.Modificar(LlenaClase());
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repos = new RepositorioBase<CrearUsuario>();
            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);

            CrearUsuario usuario = repos.Buscar(id);
            if (usuario != null)
            {
                if (repos.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repos = new RepositorioBase<CrearUsuario>();
            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            CrearUsuario usuario = repos.Buscar(id);

            if (usuario != null)
            {
                NombresTextBox.Text = usuario.Nombres;
                EmailTextBox.Text = usuario.Email;
                NoTelefonoMaskedTextBox.Text = usuario.NoTelefono;
                ContraseñaTextBox.Text = usuario.Contraseña;
                AdministradorradioButton.Checked = usuario.Administrador;
            
            }
        }

        private void UsuariocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            REgistroUsuario usuario = new REgistroUsuario();
            usuario.Show();
        
            

        }

        private void AdministradorcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            REgistroUsuario usuario = new REgistroUsuario();
          
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
