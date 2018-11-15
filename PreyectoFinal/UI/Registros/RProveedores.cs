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
        RepositorioBase<RProveedores> repositorio;
        public RProveedores()
        {
            InitializeComponent();
        }

        public void LImpiar()
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
            //proveedores.Telefono = TelefonoMaskedTextBox.Text;
            proveedores.FechaProveedor = FechadateTimePicker.Value;
            return proveedores;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
