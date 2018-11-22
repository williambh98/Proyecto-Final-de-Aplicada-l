using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
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
    public partial class ConsultaTipoArticulo : Form
    {
        private List<TipoArticulo> tipoArticulos = new List<TipoArticulo>();
        public ConsultaTipoArticulo()
        {
            InitializeComponent();
            FiltrocomboBox.SelectedIndex = 0;

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoArticulo> repositorio;
            repositorio = new RepositorioBase<TipoArticulo>();
            var Filtro = new List<TipoArticulo>();
            
            if (CristeriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0://Todo
                        Filtro = repositorio.GetList(p => true);
                        break;
                    case 1://ID
                         int id = Convert.ToInt32(CristeriotextBox.Text);
                        Filtro= repositorio.GetList(p => p.TiposId == id);
                        break;
                    case 2://Nombre
                        Filtro = repositorio.GetList(p => p.Nombre.Contains(CristeriotextBox.Text));
                        break;
                    case 3://Descripcion
                        Filtro = repositorio.GetList(p => p.Descripcion.Contains(CristeriotextBox.Text));
                        break;
                }
                Filtro = Filtro.Where(c => c.FechaCreacion.Date >= DesdedateTimePicker.Value.Date && c.FechaCreacion.Date <= HastadateTimePicker.Value.Date).ToList();

            }
            else
            {
                tipoArticulos = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = Filtro;
            tipoArticulos = Filtro;


        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (tipoArticulos.Count == 0)
            {
                MessageBox.Show("No hay en el Reporte");
                return;
            }
            TipoArticuloReview tipoArticuloReview = new TipoArticuloReview(tipoArticulos);
            tipoArticuloReview.Show();
        }
    }
}
