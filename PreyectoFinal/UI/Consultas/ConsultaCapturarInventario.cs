using BLL;
using Entidades;
using PreyectoFinal.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI.Consultas
{
    
    public partial class ConsultaCapturarInventario : Form
    {
        private List<ArticuloDetalle> articulosDetalle = new List<ArticuloDetalle>();
        public ConsultaCapturarInventario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<ArticuloDetalle> repositorio;
            repositorio = new RepositorioBase<ArticuloDetalle>();
            var filtro = new List<ArticuloDetalle>();
            int id;
            if (CristeriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0://Todo
                        filtro = repositorio.GetList(p => true);

                        break;
                    case 1: //Filtrando por ID del Producto.
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        id = Convert.ToInt32(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.EntradaId == id);

                        break;
                    case 2://Filtrando por la Descripcion del Producto.
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        double cantidad = Convert.ToDouble(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.Cantidad == cantidad);

                        break;
                    case 3://Filtrando por Costo del Producto.
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        double precio = Convert.ToDouble(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.Precio == precio);
                        break;
                   
                }
                filtro = filtro.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                articulosDetalle = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = filtro;
            articulosDetalle = filtro;
        }
        private bool Validar(int error)
        {
            bool paso = false;
            int ejem = 0;
            double ejemplo = 0;
            if (error == 1 && double.TryParse(CristeriotextBox.Text, out ejemplo) == false)
            {
                errorProvider.SetError(CristeriotextBox, "Debe de ser un numero");
                paso = true;
            }
            if (error == 2 && int.TryParse(CristeriotextBox.Text, out ejem) == true)
            {
                errorProvider.SetError(CristeriotextBox, "Debe de ser un Caracter");
                paso = true;
            }
            return paso;
        }

        private void Limpiar()
        {
            errorProvider.Clear();
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (articulosDetalle.Count == 0)
            {
                MessageBox.Show("No hay datos");
                return;
            }
            CapInventarioReview articuloReview = new CapInventarioReview(articulosDetalle);
            articuloReview.Show();
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CristeriotextBox.Clear();
            Limpiar();
            if (FiltrocomboBox.SelectedIndex == 0)
            {
                CristeriotextBox.Enabled = false;
            }
            else
            {
                CristeriotextBox.Enabled = true;
            }
        }

        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DesdedateTimePicker.Value.Date > HastadateTimePicker.Value.Date)
                errorProvider.SetError(HastadateTimePicker, "La fecha inicial no puede ser mayor que la Terminal");
            else
                errorProvider.Clear();
        }
    }
}
