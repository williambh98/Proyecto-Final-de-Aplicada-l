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
    public partial class ConsutaUsuario : Form
    {
        private List<CrearUsuario> usuario = new List<CrearUsuario>();
        public ConsutaUsuario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CrearUsuario> repositorio;
            repositorio = new RepositorioBase<CrearUsuario>();
            var Filtro = new List<CrearUsuario>();
            if (CristeriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0://Todo
                        Filtro = repositorio.GetList(p => true);
                        break;
                    case 1://ID
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        int id = Convert.ToInt32(CristeriotextBox.Text);
                        Filtro = repositorio.GetList(p => p.UsuarioId == id);
                        break;
                    case 2://Nombres
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        Filtro = repositorio.GetList(p => p.Nombres.Contains(CristeriotextBox.Text));
                        break;
                    case 3://Email
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        Filtro = repositorio.GetList(p => p.Email.Contains(CristeriotextBox.Text));
                        break;
                    case 4://NoTelefono
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        Filtro = repositorio.GetList(p => p.NoTelefono.Contains(CristeriotextBox.Text));
                        break;
                    case 5://Contrasena
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
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
            usuario = Filtro;

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
            if (usuario.Count == 0)
            {
                MessageBox.Show("No hay en el Reporte");
                return;
            }
            UsuarioReview departamentosReviewer = new UsuarioReview(usuario);
            departamentosReviewer.Show();
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


