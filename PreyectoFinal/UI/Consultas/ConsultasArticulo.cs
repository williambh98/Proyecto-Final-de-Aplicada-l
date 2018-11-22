using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
using PreyectoFinal.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI.Consultas
{
    public partial class ConsultasArticulo : Form
    {
        
        private List<Articulo> articulos = new List<Articulo>();
        public ConsultasArticulo()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulo> repositorio;
            repositorio = new RepositorioBase<Articulo>();
            var filtro = new List<Articulo>();
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
                        filtro = repositorio.GetList(p => p.ArticuloID == id);

                        break;
                    case 2://Filtrando por la Descripcion del Producto.
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        filtro = repositorio.GetList(p => p.Descripcion.Contains(CristeriotextBox.Text));

                        break;
                    case 3://Filtrando por Costo del Producto.
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        double costo = Convert.ToDouble(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.Costo == costo);

                        break;
                    case 4://Filtrando por Precio del Producto.
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
                filtro = filtro.Where(c => c.FechaCreacion.Date >= DesdedateTimePicker.Value.Date && c.FechaCreacion.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                articulos = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = filtro;
            articulos = filtro;

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
            if (articulos.Count == 0)
            {
                MessageBox.Show("No hay datos");
                return;
            }
            ArticuloReview articuloReview = new ArticuloReview(articulos);
            articuloReview.Show();



        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CristeriotextBox.Clear();
            Limpiar();
            if(FiltrocomboBox.SelectedIndex == 0)
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
