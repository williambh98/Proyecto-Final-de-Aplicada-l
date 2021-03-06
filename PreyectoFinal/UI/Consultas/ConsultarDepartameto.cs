﻿using BLL;
using Entidades;
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
    public partial class ConsultarDepartameto : Form
    {
        private List<Departamento> departamentos = new List<Departamento>();

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
            if (CristeriotextBox.Text.Trim().Length >= 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        filtro = repositorio.GetList(p => true);
                        break;
                    case 1://Filtrando por ID del Departamento.
                        Limpiar();
                        if (Validar(1))
                        {
                            MessageBox.Show("Introduce un numero");
                            return;
                        }
                        id = Convert.ToInt32(CristeriotextBox.Text);
                        filtro = repositorio.GetList(p => p.DepartamentoId == id);
                        break;
                    case 2://Filtrando por Nombre del Departamento.
                        Limpiar();
                        if (Validar(2))
                        {
                            MessageBox.Show("Introduce un caracter");
                            return;
                        }
                        filtro = repositorio.GetList(p => p .Nombre.Contains(CristeriotextBox.Text));
                        break; 
                }
                filtro = filtro.Where(c => c.fecha.Date >= DesdedateTimePicker.Value.Date && c.fecha.Date <= HastadateTimePicker.Value.Date).ToList();

            }
            else
            {
                departamentos = repositorio.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = filtro;
            departamentos = filtro;


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
            
            if (departamentos.Count == 0)
            {
                MessageBox.Show("No hay en el Reporte");
                return;
            }
            DepartamentoReview departamentosReviewer = new DepartamentoReview(departamentos);
            departamentosReviewer.ShowDialog();
            

        }

        private void ConsultarAlmacen_Load(object sender, EventArgs e)
        {

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

