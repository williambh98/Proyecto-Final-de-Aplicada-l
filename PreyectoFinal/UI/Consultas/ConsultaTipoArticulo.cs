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

namespace PreyectoFinal.UI.Consultas
{
    public partial class ConsultaTipoArticulo : Form
    {
        public ConsultaTipoArticulo()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoArticulo> repositorio;
            repositorio = new RepositorioBase<TipoArticulo>();
            var Filtro = new List<TipoArticulo>();
            if (CristeriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        Filtro = repositorio.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CristeriotextBox.Text);
                        Filtro= repositorio.GetList(p => p.TiposId == id);
                        break;
                    case 2:
                        Filtro = repositorio.GetList(p => p.Nombre.Contains(CristeriotextBox.Text));
                        break;
                    case 3:
                        Filtro = repositorio.GetList(p => p.Descripcion.Contains(CristeriotextBox.Text));
                        break;
                }
                Filtro = Filtro.Where(c => c.FechaCreacion.Date >= DesdedateTimePicker.Value.Date && c.FechaCreacion.Date <= HastadateTimePicker.Value.Date).ToList();

            }
            else
            {
                Filtro = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = Filtro;
        }
    }
}
