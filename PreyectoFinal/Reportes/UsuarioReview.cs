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
    public partial class UsuarioReview : Form
    {
        private List<CrearUsuario> usuarios = new List<CrearUsuario>();
        public UsuarioReview(List<CrearUsuario> lista)
        {
            InitializeComponent();
            this.usuarios = lista;
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            UsuarioReporte usuarioReporte = new UsuarioReporte();
            usuarioReporte.SetDataSource(usuarios);
            crystalReportViewer.ReportSource = usuarioReporte;
            usuarioReporte.Refresh();

        }
    }
}
