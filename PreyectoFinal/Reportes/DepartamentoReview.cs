using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.Reportes
{
    public partial class DepartamentoReview : Form
    {
        private List<Departamento> departamentos = new List<Departamento>();
        public DepartamentoReview(List<Departamento> lista)
        {
            InitializeComponent();
            this.departamentos = lista;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DepartamentoReporte departamentoReporte = new DepartamentoReporte();
            departamentoReporte.SetDataSource(departamentos);
            crystalReportViewer1.ReportSource = departamentoReporte;
            departamentoReporte.Refresh();

        }
    }
}
