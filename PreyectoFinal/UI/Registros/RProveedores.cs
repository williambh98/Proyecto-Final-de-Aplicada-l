using PreyectoFinal.BLL;
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
    public partial class RProveedores : Form
    {
        RepositorioBase<Proveedores> repositorio;
        public RProveedores()
        {
            InitializeComponent();
            repositorio = new RepositorioBase<Proveedores>();
        }

        public void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;

        }

        public Proveedores LlenarClase()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.IDProveedor = Convert.ToInt32(IDnumericUpDown.Value);
            proveedores.Direccion = DirecciontextBox.Text;
            proveedores.NombreProveedor = NombretextBox.Text;
            proveedores.Email = EmailtextBox.Text;
            proveedores.Telefono = TelefonoMaskedTextBox.Text;
            proveedores.FechaProveedor = FechadateTimePicker.Value;
            return proveedores;
        }

        private void LlenarCampos(Proveedores proveedor)
        {
            IDnumericUpDown.Value = proveedor.IDProveedor;
            NombretextBox.Text = proveedor.NombreProveedor;
            DirecciontextBox.Text = proveedor.Direccion;
            EmailtextBox.Text = proveedor.Email;
            TelefonoMaskedTextBox.Text = proveedor.Telefono;
            FechadateTimePicker.Value = proveedor.FechaProveedor;

        }
        

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int id;
            repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores = new Proveedores();
            int.TryParse(IDnumericUpDown.Text, out id);
            proveedores = repositorio.Buscar(id);
            if (proveedores != null)
            {
                LlenarCampos(proveedores);
                MessageBox.Show("Encotrada");
            }
            else
            {
                MessageBox.Show("No Encotro");
            }

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;
            if (FechadateTimePicker.Value < DateTime.Now)
            {
                errorProvider.SetError(FechadateTimePicker, "Fecha Invalida");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
            {
                errorProvider.SetError(TelefonoMaskedTextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                errorProvider.SetError(EmailtextBox, "Llenar Campo");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "Llenar campo");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Llenar Campo");
                paso = false;
            }

            return paso;
        }

        private bool ExiteEnLaDb()
        {
            repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores = repositorio.Buscar((int)IDnumericUpDown.Value);
            return (proveedores != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores;
            bool paso = false;

            proveedores = LlenarClase();
            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
                paso = repositorio.Guardar(proveedores);
            else
            {
                if (!ExiteEnLaDb())
                {
                    MessageBox.Show("No se puede modificar no Exite!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                paso = repositorio.Modificar(proveedores);
            }
            Limpiar();
            if (paso)
            {
                MessageBox.Show("Guadado!!", "Guardo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int id;
            repositorio = new RepositorioBase<Proveedores>();
            int.TryParse(IDnumericUpDown.Text, out id);
            if (!ExiteEnLaDb())
            {
                errorProvider.SetError(IDnumericUpDown, "No Eliminado");
                IDnumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
                MessageBox.Show("Eliminada ");
            else
            {
                MessageBox.Show("No Elimino");
            }
        }

        
    }
}