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
            LlenarComboBox();
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
            entrada.Cantidad = Convert.ToDouble(CantidadnumericUpDown.Text);

            return entrada;
        }

        private void Limpiar()
        {
            EntradaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ProductoComboBox.SelectedIndex = 0; ;
            CantidadnumericUpDown.Value = 0;
            errorProvider.Clear();
        }

        private bool Validar()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(CantidadnumericUpDown.Text))
            {
                errorProvider.SetError(CantidadnumericUpDown,
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

            if (Validar())
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
                CantidadnumericUpDown.Text = entrada.Cantidad.ToString();
            }
        }

        private void REntradeDeProducto_Load(object sender, EventArgs e)
        {

        }

        private void agregarbutton_Click(object sender, EventArgs e)
        {
            List<ArticuloDetalle> detalle = new List<ArticuloDetalle>();

            if (EntradadataGridView.DataSource != null)
            {
                detalle = (List<ArticuloDetalle>)EntradadataGridView.DataSource;
            }
            /*if (ContarCantidadInventario())
            {
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else*/ if (CantidadnumericUpDown.Value == 0)
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RArticulo ra = new RArticulo();
                detalle.Add(
                    new ArticuloDetalle(
                       id: 0,
                       fecha: DateTime.Now,
                       articuloid: (int)EntradaIdNumericUpDown.Value,
                       //: (int)ProductoComboBox.SelectedValue,
                       cantidad: (double)Convert.ToDouble(CantidadnumericUpDown.Text),
                       precio: (double)Convert.ToDouble(CantidadnumericUpDown.Text),
                       importe: (double)Convert.ToDouble(CantidadnumericUpDown.Value * 10),
                       vencimiento: (DateTime)dateTimePicker1.Value
               //    precio: (double)Convert.ToDouble(PrecioTextBox.Text),
               //  importe: (double)Convert.ToDouble(ImporteTextBox.Text)

               ));

                EntradadataGridView.DataSource = null;
                EntradadataGridView.DataSource = detalle;
                EntradadataGridView.Columns[0].Visible = false;
               // LlenarValores();
            }
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (EntradadataGridView.Rows.Count > 0 && EntradadataGridView.CurrentRow != null)
            {
                List<ArticuloDetalle> detalle = (List<ArticuloDetalle>)EntradadataGridView.DataSource;

                detalle.RemoveAt(EntradadataGridView.CurrentRow.Index);

                EntradadataGridView.DataSource = null;
                EntradadataGridView.DataSource = detalle;

                //RebajarValores();
            }
        }
    }
}
