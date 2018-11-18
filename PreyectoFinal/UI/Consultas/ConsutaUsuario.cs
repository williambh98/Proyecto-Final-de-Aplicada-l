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
    public partial class ConsutaUsuario : Form
    {
        public ConsutaUsuario()
        {
            InitializeComponent();
        }

        private void ConsultaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            var Filtro = new List<CrearUsuario>();
            if (CristeriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        Filtro = repositorio.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CristeriotextBox.Text);
                        Filtro = repositorio.GetList(p => p.UsuarioId == id);
                        break;
                    case 2:
                        Filtro = repositorio.GetList(p => p.Nombres.Contains(CristeriotextBox.Text));
                        break;
                    case 3:
                        Filtro = repositorio.GetList(p => p.Email.Contains(CristeriotextBox.Text));
                        break;
                    case 4:
                        Filtro = repositorio.GetList(p => p.NoTelefono.Contains(CristeriotextBox.Text));
                        break;
                    case 5:
                        Filtro = repositorio.GetList(p => p.Contraseña.Contains(CristeriotextBox.Text));
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


