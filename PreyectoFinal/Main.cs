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
    }
}
