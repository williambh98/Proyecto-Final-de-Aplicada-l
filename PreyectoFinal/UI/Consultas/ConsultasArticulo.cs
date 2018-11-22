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
                        id = Convert.ToInt32(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.ArticuloID == id);

                        break;
                    case 2://Filtrando por la Descripcion del Producto.
                       filtro = repositorio.GetList(p => p.Descripcion.Contains(CristeriotextBox.Text));

                        break;
                    case 3://Filtrando por Costo del Producto.
                        double costo = Convert.ToDouble(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.Costo == costo);


                        break;
                    case 4://Filtrando por Precio del Producto.
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
    }
}
