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
    public partial class TipoArticuloReview : Form
    {
        private List<TipoArticulo> tipoArticulos = new List<TipoArticulo>();
        public TipoArticuloReview(List<TipoArticulo> lista)
        {
            InitializeComponent();
            this.tipoArticulos = lista;
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            TipoArticuloReporte tipoArticuloReporte = new TipoArticuloReporte();
            tipoArticuloReporte.SetDataSource(tipoArticulos);
            crystalReportViewer.ReportSource = tipoArticuloReporte;
            tipoArticuloReporte.Refresh();
        }
    }
}
