using PreyectoFinal.UI.Consultas;
using PreyectoFinal.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void entradaDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REntradeDeProducto rp = new REntradeDeProducto();
            rp.ShowDialog();
        }

        private void registroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REgistroUsuario rp = new REgistroUsuario();
            rp.ShowDialog();
        }

        private void rArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RArticulo ra = new RArticulo();
            ra.ShowDialog();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consutasDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarDepartameto m = new ConsultarDepartameto();
            m.Show();
            m.MdiParent = this;
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCapturarInventario cap = new ConsultaCapturarInventario();
            cap.Show();
            cap.MdiParent = this;
        }

        private void consutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaProveedores pro = new ConsultaProveedores();
            pro.Show();
            pro.MdiParent = this;
        }

        private void consultaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasArticulo Ar = new ConsultasArticulo();
            Ar.Show();
            Ar.MdiParent = this;
        }

        private void consultaTipoarticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaTipoArticulo Tip = new ConsultaTipoArticulo();
            Tip.Show();
            Tip.MdiParent = this;
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsutaUsuario usuario = new ConsutaUsuario();
            usuario.Show();
            usuario.MdiParent = this;
        }
    }
}
