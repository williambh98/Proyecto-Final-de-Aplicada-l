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
            UsuarioradioButton.Checked = true;
        }


        private CrearUsuario LlenaClase()
        {
            CrearUsuario usuario = new CrearUsuario();

            usuario.UsuarioId = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            usuario.Nombres = NombresTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.NoTelefono = NoTelefonoMaskedTextBox.Text;
            usuario.Administrador = (UsuarioradioButton.Checked) ? false : true;
            usuario.Contraseña = Program.Hash(ContraseñaTextBox.Text);

            return usuario;
        }

        public void LLenaCampo(CrearUsuario usuario)
        {
            UsuarioIdNumericUpDown.Value = usuario.UsuarioId;
            NombresTextBox.Text = usuario.Nombres;
            if (usuario.Administrador) AdministradorradioButton.Checked = true; else UsuarioradioButton.Checked = true;
            EmailTextBox.Text = usuario.Email;
            NoTelefonoMaskedTextBox.Text = usuario.NoTelefono;
            ContraseñaTextBox.Text = Program.Hash(usuario.Contraseña);

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
            bool paso = true;

            if (String.IsNullOrEmpty(NombresTextBox.Text))
            {
                ErrorProvider.SetError(NombresTextBox,
                    "Debe escribir el Nombre Completo para el Usuario");
                paso = false;
            }
            if (String.IsNullOrEmpty(EmailTextBox.Text))
            {
                ErrorProvider.SetError(EmailTextBox,
                    "Debe ingresar un Email para el Usuario");
                paso = false;
            }
            if (String.IsNullOrEmpty(NoTelefonoMaskedTextBox.Text))
            {
                ErrorProvider.SetError(NoTelefonoMaskedTextBox,
                    "Debe ingresar un Número de Teléfono para el Usuario");
                paso = false;
            }
            if (String.IsNullOrEmpty(ContraseñaTextBox.Text))
            {
                ErrorProvider.SetError(ContraseñaTextBox,
                    "Debe ingresar una Contraseña para el Usuario");
                paso = false;
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
            {

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
                        MessageBox.Show("Error", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repositorio = new RepositorioBase<CrearUsuario>();
            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            if(id <= 0)
            {
                ErrorProvider.SetError(UsuarioIdNumericUpDown, "Incorrecto");
            }
            else
            {
                CrearUsuario usuario = repositorio.Buscar(id);
                if (usuario != null)
                {
                    if(Program.usuario.UsuarioId == usuario.UsuarioId)
                    {
                        MessageBox.Show("Error No Puede Eliminarse el mismo Usuario");
                    }
                    else
                    {
                        if(repositorio.Eliminar(id))
                        {
                            MessageBox.Show("Usuario Eliminado");
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error no se puede eliminar");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existe ");
                }
            }
           

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repositorio = new RepositorioBase<CrearUsuario>();
            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);

            if (id <= 0)
            {
                ErrorProvider.SetError(UsuarioIdNumericUpDown, "No Exite");
            }
            else
            {
                CrearUsuario usuario = repositorio.Buscar(id);
                if (usuario != null)
                {
                    LLenaCampo(usuario);
                }
                else
                {
                    ErrorProvider.SetError(UsuarioIdNumericUpDown, " No existe");
                }
            }
        }

        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}



