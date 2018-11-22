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

namespace PreyectoFinal.Reportes
{
    public partial class ProveedoresReview : Form
    {
        private List<Proveedores> proveedores = new List<Proveedores>();
        public ProveedoresReview(List<Proveedores> lista)
        {
            InitializeComponent();
            this.proveedores = lista;
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            ProveedoresReporte proveedoresReporte = new ProveedoresReporte();
            proveedoresReporte.SetDataSource(proveedores);
            crystalReportViewer.ReportSource = proveedoresReporte;
            proveedoresReporte.Refresh();

        }
    }
}
