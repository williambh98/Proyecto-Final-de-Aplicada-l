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
            errorProvider1.Clear();
            CantidadTextBox.Clear();
            ArticuloIdNumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            DepartamentoComboBox.SelectedIndex = 0;
            DescripcionTextBox.Clear();
            CostotextBox.Clear();
            PreciotextBox.Clear();

        }
        private Articulo LlenaClase()
        {
            Articulo articulo = new Articulo();
            articulo.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            articulo.ArticuloID = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
            articulo.DepartamentoId = Convert.ToInt32(DepartamentoComboBox.SelectedValue);
            articulo.FechaCreacion = FechadateTimePicker.Value;
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Costo = Convert.ToDouble(CostotextBox.Text);
            articulo.Precio = Convert.ToDouble(PreciotextBox.Text);
  

            return articulo;
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }
      
        private bool Validar()
        {
            bool paso = false;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider1.SetError(DescripcionTextBox,
                    "Llenar Campo Descripcion");
                paso = true;
            }
            if (string.IsNullOrEmpty(CostotextBox.Text))
            {
                errorProvider1.SetError(CostotextBox,
                    "Llenar Campo Articulo");
                paso = true;
            }
            if (string.IsNullOrEmpty(PreciotextBox.Text))
            {
                errorProvider1.SetError(PreciotextBox,
                    "Llenar Campo Precio");
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
            Articulo articulo;
            bool paso = false;

            if (Validar())
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
                    MessageBox.Show("Id no existe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    MessageBox.Show("No se pudo eliminar!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArticuloIdNumericUpDown.Value);
            Articulo articulo = ArticuloBLL.Buscar(id);

            if (articulo != null)
            {
                DepartamentoComboBox.SelectedValue = articulo.DepartamentoId;
                DescripcionTextBox.Text = articulo.Descripcion;
                CostotextBox.Text = articulo.Costo.ToString();
                PreciotextBox.Text = articulo.Precio.ToString();
                FechadateTimePicker.Value = articulo.FechaCreacion;
                CantidadTextBox.Text = Convert.ToString(articulo.Cantidad);

            }
            else
                errorProvider1.SetError(ArticuloIdNumericUpDown, "No Existe");

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            RDepapartamento rp = new RDepapartamento();
            rp.ShowDialog();
            LlenarCombo();
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

        
        public static void SoloNumero(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Números");
            }
        }
        public static void NumerosDecimal(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (v.KeyChar.ToString().Equals("."))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
            }

        }

        private void CostotextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            NumerosDecimal(e);
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumerosDecimal(e);
        }

    }
}
