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
    public partial class RArticulo : Form
    {
        public RArticulo()
        {
            InitializeComponent();
            LlenarCombo();

        }

        private void LlenarCombo()
        {
            RepositorioBase<Departamento> DepRepositorio = new RepositorioBase<Departamento>();

            DepartamentoComboBox.DataSource = DepRepositorio.GetList(c => true);
            DepartamentoComboBox.ValueMember = "DepartamentoId";
            DepartamentoComboBox.DisplayMember = "Nombre";

            RepositorioBase<TipoArticulo> TipRepositorio = new RepositorioBase<TipoArticulo>();
            TipoCombox.DataSource = TipRepositorio.GetList(x => true);
            TipoCombox.ValueMember = "TiposId";
            TipoCombox.DisplayMember = "Nombre";

            RepositorioBase<Proveedores> com = new RepositorioBase<Proveedores>();
            ProvedorCOmbobox.DataSource = com.GetList(x => true);
            ProvedorCOmbobox.ValueMember = "IDProveedor";
            ProvedorCOmbobox.DisplayMember = "NombreProveedor";
        }

        private void Limpiar()
        {
            ErrorProvider.Clear();
            ArticuloIdNumericUpDown.Value = 0;
          //  FechaDateTimePicker.Value = DateTime.Now;
            DepartamentoComboBox.SelectedIndex = 0;
            DescripcionTextBox.Clear();
            CostoTextBox.Clear();
            PrecioTextBox.Clear();
            CantidatextBox.Clear();
          //  PctGananciaTextBox.Clear();
          //  InventarioTextBox.Clear();



        }
        private Articulo LlenaClase()
        {
            Articulo articulo = new Articulo();

            articulo.ArticuloID = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
            articulo.DepartamentoId = Convert.ToInt32(DepartamentoComboBox.SelectedValue);
           // articulo.FechaVencimiento = FechaDateTimePicker.Value;
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Costo = Convert.ToDouble(CostoTextBox.Text);
            articulo.Precio = Convert.ToDouble(PrecioTextBox.Text);
           // articulo.PorCientoGanancia = Convert.ToDouble(PctGananciaTextBox.Text);
           // articulo.CantidadIventario = 0;

            return articulo;
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }
       /* private void CalcularGanancia()
        {
            double costo, precio;
            costo = ToDouble(CostoTextBox.Text);
            precio = ToDouble(PrecioTextBox.Text);
         //   PctGananciaTextBox.Text = ArticuloBLL.PorcientoGanancia(costo, precio).ToString();
        }*/
        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                ErrorProvider.SetError(DescripcionTextBox,
                    "Debe escribir una Descripción para el Articulo");
                paso = true;
            }
            if (String.IsNullOrEmpty(CostoTextBox.Text))
            {
                ErrorProvider.SetError(CostoTextBox,
                    "Debe ingresar un Costo para el Articulo");
                paso = true;
            }
            if (String.IsNullOrEmpty(PrecioTextBox.Text))
            {
                ErrorProvider.SetError(PrecioTextBox,
                    "Debe ingresar un Precio para el Articulo");
                paso = true;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void CostoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede digitar Números", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Articulo articulo;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            articulo = LlenaClase();

            if (ArticuloIdNumericUpDown.Value == 0)
            {
                paso = ArticuloBLL.Guardar(articulo);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
                articulo = ArticuloBLL.Buscar(id);

                if (articulo != null)
                {
                    paso = ArticuloBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(ArticuloIdNumericUpDown.Value);

            Articulo articulo = ArticuloBLL.Buscar(id);
            if (articulo != null)
            {
                if (ArticuloBLL.Eliminar(id))
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
            int id = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
            Articulo articulo = ArticuloBLL.Buscar(id);

            if (articulo != null)
            {
                DepartamentoComboBox.SelectedValue = articulo.DepartamentoId;
                DescripcionTextBox.Text = articulo.Descripcion;
                CostoTextBox.Text = articulo.Costo.ToString();
                PrecioTextBox.Text = articulo.Precio.ToString();
                CantidatextBox.Text = articulo.sumar.ToString();
               // PctGananciaTextBox.Text = articulo.PorCientoGanancia.ToString();
               // InventarioTextBox.Text = articulo.CantidadIventario.ToString();
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            RDepapartamento rp = new RDepapartamento();
            rp.ShowDialog();
            LlenarCombo();
        }

        private void InventarioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public Articulo articulo()
        {
            
            int id = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
            Articulo articulo = ArticuloBLL.Buscar(id);
            if (articulo != null)
            {
               // textBox1. = articulo.sumar;
            }
            return articulo;
        }
        private void tipoButton_Click(object sender, EventArgs e)
        {
            RTipoArticulo tp = new RTipoArticulo();
            tp.ShowDialog();
            LlenarCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RProveedores pv = new RProveedores();
            pv.ShowDialog();
            LlenarCombo();
        }

        private void RArticulo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
          
        }
        /*
private void tipoButton_Click(object sender, EventArgs e)
{
RTipoArticulo tp = new RTipoArticulo();
tp.ShowDialog();
LlenarComb();
}
*/
    }
}
