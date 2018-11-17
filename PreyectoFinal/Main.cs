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
            ConsultarAlmacen m = new ConsultarAlmacen();
            m.ShowDialog();
        }

        private void entradaInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REntradeDeProducto rp = new REntradeDeProducto();
            rp.ShowDialog();
        }
    }
}
