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
     
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio;
            repositorio = new RepositorioBase<Proveedores>();
            Expression<Func<Proveedores, bool>> filtro = c => true;
            int id;

        switch(Filtro_comboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://ID

                    id = Convert.ToInt32(Criterio_textBox.Text);
                    filtro = c=> c.IDProveedor == id;
                    break;
                case 2://Nombre
                    filtro = c => c.NombreProveedor.Contains(Criterio_textBox.Text);
                    break;
                case 3://Email
                    filtro = c => c.Email.Contains(Criterio_textBox.Text);
                    break;
                case 4://Direccion
                    filtro = c => c.Direccion.Contains(Criterio_textBox.Text);
                    break;
                case 5://telefono
                    filtro = c => c.Telefono.Contains(Criterio_textBox.Text);
                    break;    
            }
            filtro = c => c.FechaProveedor >= Desde_dateTimePicker.Value.Date && c.FechaProveedor <= Hasta_dateTimePicker.Value.Date;
            Consulta_dataGridView.DataSource = repositorio.GetList(filtro);


        }

        private void ConsultaProveedores_Load(object sender, EventArgs e)
        {

        }

        /*
        private void Filtro_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filtro_comboBox.SelectedIndex == 0)
            {
                Criterio_textBox.Visible = false;
                label2.Visible = false;
            }
            if (Filtro_comboBox.SelectedIndex == 1)
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                Hasta_dateTimePicker.Visible = false;
                Desde_dateTimePicker.Visible = false;

                Criterio_textBox.Visible = true;
                label2.Visible = true;
                // Criterio();
                //Criterio_textBox = .Criterio_textBox();
                */
    }
            
        }
    

