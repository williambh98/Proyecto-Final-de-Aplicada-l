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
    public partial class ArticuloReview : Form
    {
        private List<Articulo> articulo = new List<Articulo>();
        public ArticuloReview(List<Articulo>Lista)
        {
            InitializeComponent();
            this.articulo = Lista;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ArticuloReporte reporte = new ArticuloReporte();
            reporte.SetDataSource(articulo);
            crystalReportViewer.ReportSource = reporte;
            reporte.Refresh();
        }
    }
}
