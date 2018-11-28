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
        public RCapturarInventario()
        {
            detalle = new List<ArticuloDetalle>();
            InitializeComponent();
            LlenarComboBox();
        }
        private void LlenarComboBox()
        {
            RepositorioBase<Articulo> ArtRepositorio = new RepositorioBase<Articulo>();

            ProductoComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ProductoComboBox.ValueMember = "Articuloid";
            ProductoComboBox.DisplayMember = "Descripcion";

            CostocomboBox.DataSource = ArtRepositorio.GetList(c => true);
            CostocomboBox.ValueMember = "Articuloid";
            CostocomboBox.DisplayMember = "Costo";

            PreciocomboBox.DataSource = ArtRepositorio.GetList(c => true);
            PreciocomboBox.ValueMember = "Articuloid";
            PreciocomboBox.DisplayMember = "Precio";

        }
        private void LlenaCampos(Entrada entrada)
        {
            FechaDateTimePicker.Value = entrada.FechaVencimiento;
            ProductoComboBox.SelectedValue = entrada.ArticuloID;
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
            entrada.ArticuloID = Convert.ToInt32(ProductoComboBox.SelectedValue);
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

            if (Validar())
            {
                bool paso = false;
                Entrada entrada = LlenaClase();
                Contexto contexto = new Contexto();
                if(id == 0)
                {
                    contexto.Entrada.Add(entrada);
                   
                    foreach(ArticuloDetalle d in entrada.Detalle)
                    {
                        Articulo articulo = ArticuloBLL.Buscar(entrada.ArticuloID);
                        articulo.Cantidad += Convert.ToInt32(d.Cantidad);
                        contexto.Entry<Articulo>(articulo).State = System.Data.Entity.EntityState.Modified;

                    }
                    
                    paso = contexto.SaveChanges() > 0;
                }
                else
                {
                    foreach(ArticuloDetalle articulo in entrada.Detalle)
                    {
                        if(entrada.ArticuloID == articulo.Id)
                        {
                            articulo.Cantidad = entrada.Cantidad;
                            Articulo buscado = ArticuloBLL.Buscar(entrada.ArticuloID);
                            buscado.Cantidad = Convert.ToInt32(articulo.Cantidad);
                            ArticuloBLL.Modificar(buscado);
                        }
                        contexto.Entry<ArticuloDetalle>(articulo).State = System.Data.Entity.EntityState.Modified;
                    }
                    contexto.Entry<Entrada>(entrada).State = System.Data.Entity.EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }

                contexto.Dispose();

                if (paso)
                {
                    if(id == 0)
                    {
                        MessageBox.Show("Registro guardado Con Exito");
                    }
                    else
                    {
                        MessageBox.Show("Registro actualizado Con Exito");
                    }
                }


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
            else*/ if (CantidadnumericUpDown.Value == 0)
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //RArticulo ra = new RArticulo();
                this.detalle.Add(
                    new ArticuloDetalle(
                       id: 0,
                       fecha: DateTime.Now,
                       entradaId: (int)EntradaIdNumericUpDown.Value,
                       //: (int)ProductoComboBox.SelectedValue,
                       cantidad: Convert.ToDouble(CantidadnumericUpDown.Text),
                       precio: Convert.ToDouble(PreciocomboBox.Text),
                       vencimiento: (DateTime)dateTimePicker1.Value
               //    precio: (double)Convert.ToDouble(PrecioTextBox.Text),
               //  importe: (double)Convert.ToDouble(ImporteTextBox.Text)

               ));

                EntradadataGridView.DataSource = null;
                
                EntradadataGridView.DataSource = detalle;
                EntradadataGridView.Columns[1].Visible = false;

                CargarGrid();
               // LlenarValores();
            }
        }
        private void CargarGrid()
        {
            EntradadataGridView.DataSource = null;
            EntradadataGridView.DataSource = this.detalle;
        }
        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (EntradadataGridView.Rows.Count >= 0 && EntradadataGridView.CurrentRow != null)
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
