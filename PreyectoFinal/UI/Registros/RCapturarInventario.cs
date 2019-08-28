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
    public partial class RCapturarInventario : Form
    {
        public List<ArticuloDetalle> detalle = new List<ArticuloDetalle>();
        public List<ArticuloDetalle> DetalleEliminar = new List<ArticuloDetalle>();
        public RCapturarInventario()
        {
            detalle = new List<ArticuloDetalle>();
            InitializeComponent();
            LlenarComboBox();
            ProductoComboBox.SelectedIndex = 0;
        }
        private void LlenarComboBox()
        {
            RepositorioBase<Articulo> ArtRepositorio = new RepositorioBase<Articulo>();
            ProductoComboBox.ValueMember = "Articuloid";
            ProductoComboBox.DisplayMember = "Descripcion";
            ProductoComboBox.DataSource = ArtRepositorio.GetList(c => true);
        }
        private void LlenaCampos(Entrada entrada)
        {

            FechaDateTimePicker.Value = entrada.FechaVencimiento;
            CantidadnumericUpDown.Text = entrada.Cantidad.ToString();
            this.detalle = entrada.Detalle;
            CargarGrid();
        }
        private Entrada LlenaClase()
        {
            Entrada entrada = new Entrada();

            entrada.EntradaId = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            entrada.FechaVencimiento = FechaDateTimePicker.Value;
            entrada.Fecha = DateTime.Now;
            entrada.Cantidad = Convert.ToDouble(CantidadnumericUpDown.Text);
            entrada.Detalle = this.detalle;
            return entrada;
        }
        private void Limpiar()
        {
            EntradaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ProductoComboBox.SelectedIndex = 0; ;
            CantidadnumericUpDown.Value = 0;
            EntradadataGridView.DataSource = null;
            errorProvider.Clear();
            this.detalle = new List<ArticuloDetalle>();
            this.DetalleEliminar = new List<ArticuloDetalle>();
        }

        private bool Validar()
        {
            bool paso = true;
            //if (FechaDateTimePicker.Value >= DateTime.Now)
            //{
            //    errorProvider.SetError(FechaDateTimePicker, "La fecha debe ser mayor que la de actual");
            //    paso = false;
            //}
            if (String.IsNullOrEmpty(CantidadnumericUpDown.Text))
            {
                errorProvider.SetError(CantidadnumericUpDown,
                    "Debe digitar un Cantidad de Entrada para el Producto");
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
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            bool paso = false;
            if (!Validar())
                return;
            if (id == 0)
                paso = EntradaBLL.Guardar(LlenaClase());
            else
            {
                if (EntradaBLL.Buscar(id) != null)
                {
                    if(this.DetalleEliminar.Count > 0)
                    {
                        Entrada eliminar = LlenaClase();
                        eliminar.Detalle = this.DetalleEliminar;
                        EntradaBLL.EliminarDetalle(eliminar);
                    }
                    paso = EntradaBLL.Modificar(LlenaClase());
                    MessageBox.Show("Modificado");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar");
                    return;
                }
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Registro guardado Con Exito");
            }
            else
            {
                MessageBox.Show("No se pudo modificar");
            }
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
                LlenaCampos(entrada);
            }
            else
            {
                errorProvider.SetError(EntradaIdNumericUpDown, " No Existe");
            }
        }

        private void REntradeDeProducto_Load(object sender, EventArgs e)
        {

        }

        private void agregarbutton_Click(object sender, EventArgs e)
        {


            if (EntradadataGridView.DataSource != null)
            {
                detalle = (List<ArticuloDetalle>)EntradadataGridView.DataSource;
            }
            /*if (ContarCantidadInventario())
            {
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else*/
            if (CantidadnumericUpDown.Value == 0)
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.detalle.Add(
                    new ArticuloDetalle(
                       id: 0,
                       entradaId: (int)EntradaIdNumericUpDown.Value,
                       cantidad: Convert.ToDouble(CantidadnumericUpDown.Text),
                       precio: Convert.ToDouble(PrecioTextBox.Text),
                       articuloID: ConvertToArticulo(ProductoComboBox).ArticuloID,
                       fecha: DateTime.Now,
                       fechaVencimiento: (DateTime)dateTimePicker1.Value
               ));
                CargarGrid();
            }
        }
        private void CargarGrid()
        {
            EntradadataGridView.DataSource = null;
            EntradadataGridView.DataSource = this.detalle;
            EntradadataGridView.Columns[1].Visible = false;
        }
        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (EntradadataGridView.Rows.Count >= 0 && EntradadataGridView.CurrentRow != null)
            {
                List<ArticuloDetalle> detalle = (List<ArticuloDetalle>)EntradadataGridView.DataSource;
                DetalleEliminar.Add(detalle.ElementAt(EntradadataGridView.CurrentRow.Index));
                detalle.RemoveAt(EntradadataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }
        private static Articulo ConvertToArticulo(ComboBox con)
        {
            return (Articulo)con.SelectedItem;
        }
        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Articulo articulo = (Articulo)ProductoComboBox.SelectedItem;
            PrecioTextBox.Text = articulo.Precio.ToString();
            CostoTextBox.Text = articulo.Costo.ToString();
        }
    }
}
