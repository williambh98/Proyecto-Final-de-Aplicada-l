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
    public partial class CapInventarioReview : Form
    {
        private List<ArticuloDetalle> articuloDetalle = new List<ArticuloDetalle>();
        public CapInventarioReview(List<ArticuloDetalle> Lista)
        {
            InitializeComponent();
            this.articuloDetalle = Lista;
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            CapInventarioReporte reporte = new CapInventarioReporte();
            reporte.SetDataSource(articuloDetalle);
            crystalReportViewer.ReportSource = reporte;
            reporte.Refresh();
        }
    }
}
