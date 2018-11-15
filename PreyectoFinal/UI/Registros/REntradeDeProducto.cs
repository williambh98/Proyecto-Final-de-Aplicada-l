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
    public partial class REntradeDeProducto : Form
    {
        public REntradeDeProducto()
        {
            InitializeComponent();
          //  LlenarComboBox();
        }
        private void LlenarComboBox()
        {
            RepositorioBase<Articulo> ArtRepositorio = new RepositorioBase<Articulo>();

            ProductoComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ProductoComboBox.ValueMember = "Articuloid";
            ProductoComboBox.DisplayMember = "Descripcion";
        }

        private Entrada LlenaClase()
        {
            Entrada entrada = new Entrada();

            entrada.EntradaId = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            entrada.Fecha = FechaDateTimePicker.Value;
            entrada.ArticuloID = Convert.ToInt32(ProductoComboBox.SelectedValue);
            entrada.Cantidad = Convert.ToDouble(CantidadTextBox.Text);

            return entrada;
        }

        private void Limpiar()
        {
            EntradaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ProductoComboBox.SelectedIndex = 0; ;
            CantidadTextBox.Clear();
            errorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(CantidadTextBox.Text))
            {
                errorProvider.SetError(CantidadTextBox,
                    "Debe digitar un Cantidad de Entrada para el Producto");
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
            Entrada entrada;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            entrada = LlenaClase();

            if (EntradaIdNumericUpDown.Value == 0)
            {
                paso = EntradaBLL.Guardar(entrada);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
                entrada = EntradaBLL.Buscar(id);

                if (entrada != null)
                {
                    paso = EntradaBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);

            Entrada entrada = EntradaBLL.Buscar(id);
            if (entrada != null)
            {
                if (EntradaBLL.Eliminar(id))
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
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            Entrada entrada = EntradaBLL.Buscar(id);

            if (entrada != null)
            {
                FechaDateTimePicker.Value = entrada.Fecha;
                ProductoComboBox.SelectedValue = entrada.ArticuloID;
                CantidadTextBox.Text = entrada.Cantidad.ToString();
            }
        }
    }
}
