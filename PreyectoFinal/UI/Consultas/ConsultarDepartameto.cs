using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
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
    public partial class ConsultarDepartameto : Form
    {
       
        public ConsultarDepartameto()
        {
            InitializeComponent();
            
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Departamento> repositorio;
            repositorio = new RepositorioBase<Departamento>();
            var filtro = new List<Departamento>();
            int id;
            if (CristeriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        filtro = repositorio.GetList(p => true);
                        break;
                    case 1://Filtrando por ID del Departamento.
                        id = Convert.ToInt32(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.DepartamentoId == id);
                        break;
                    case 2://Filtrando por Nombre del Departamento.
                        filtro = repositorio.GetList(p => p .Nombre.Contains(CristeriotextBox.Text));
                        break; 
                }
                filtro = filtro.Where(c => c.fecha.Date >= DesdedateTimePicker.Value.Date && c.fecha.Date <= HastadateTimePicker.Value.Date).ToList();

            }
            else
            {
                filtro = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = filtro;

        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            /*
            if (departamentos.Count == 0)
            {
                MessageBox.Show("No hay datos pra mostrar en el Reporte");
                return;
            }
            DepartamentosReviewer departamentosReviewer = new DepartamentosReviewer(departamentos);
            departamentosReviewer.ShowDialog();
            */

        }

        private void ConsultarAlmacen_Load(object sender, EventArgs e)
        {

        }
    }
}

