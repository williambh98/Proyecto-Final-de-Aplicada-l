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
    public partial class ConsultaProveedores : Form
    {
       
        public ConsultaProveedores()
        {
            InitializeComponent();
            Filtro_comboBox.SelectedIndex = 0;

        }
        List<Proveedores> lista = new List<Proveedores>();

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio;
            repositorio = new RepositorioBase<Proveedores>();
            var filtro = new List<Proveedores>();
    
            if (Criterio_textBox.Text.Trim().Length >= 0)
            {
                switch (Filtro_comboBox.SelectedIndex)
                {
                    case 0://Todos
                        filtro = repositorio.GetList(p => true);
                        break;
                    case 1:
                   
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        int id = Convert.ToInt32(Criterio_textBox.Text);
                        filtro = repositorio.GetList(p => p.IDProveedor == id);

                        break;
                    case 2://Nombre
                    
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        filtro = repositorio.GetList(p => p.NombreProveedor.Contains(Criterio_textBox.Text));
                        break;
                    case 3://Email
                       
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        filtro = repositorio.GetList(p => p.Email.Contains(Criterio_textBox.Text));
                        break;
                    case 4://Direccion
                        
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        filtro = repositorio.GetList(p => p.Direccion.Contains(Criterio_textBox.Text));
                        break;
                    case 5://telefono
                        Limpiar();

                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }

                        filtro = repositorio.GetList(p => p.Telefono.Contains(Criterio_textBox.Text));
                        break;
                }
                filtro = filtro.Where(c => c.FechaProveedor.Date >= DesdedateTimePicker.Value.Date && c.FechaProveedor.Date <= HastadateTimePicker.Value.Date).ToList();
            }
           
            Consulta_dataGridView.DataSource = null;
            Consulta_dataGridView.DataSource = filtro;
            
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int ejem = 0;
            double ejemplo = 0;
            if(error ==1 && double.TryParse(Criterio_textBox.Text, out ejemplo) == false)
            {
                errorProvider.SetError(Criterio_textBox, "Debe de ser un numero");
                paso = true;
            }
            if(error == 2 && int.TryParse(Criterio_textBox.Text, out ejem) == true)
            {
                errorProvider.SetError(Criterio_textBox, "Debe de ser un Caracter");
                paso = true;
            }
            return paso;
        }

        private void Limpiar()
        {
            errorProvider.Clear();
        }

        private void Hasta_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ConsultaProveedores_Load(object sender, EventArgs e)
        {

        }

        /*
        private void Filtro_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Criterio_textBox.Clear();
            Limpiar();
            if(Filtro_comboBox.SelectedIndex ==5)
            {
                Criterio_textBox.Enabled = false;
            }
            else
            {
                Criterio_textBox.Enabled = true;
            }
            if(Filtro_comboBox.SelectedIndex == 3)
            {
                Criterio_textBox.MaxLength = 11;
            }
            if (Filtro_comboBox.SelectedIndex == 4)
            {
                Criterio_textBox.MaxLength = 10;
            }
            else
                Criterio_textBox.MaxLength = 200;
        }
        */
    }
            
  }
    

