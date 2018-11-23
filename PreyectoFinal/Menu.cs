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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void entradaDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RArticulo Art = new RArticulo();
            Art.Show();
            Art.MdiParent = this;
        }

        private void registroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REgistroUsuario rp = new REgistroUsuario();
            rp.Show();
            rp.MdiParent = this;
        }

        

        private void consutasDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarDepartameto m = new ConsultarDepartameto();
            m.Show();
            m.MdiParent = this;
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REntradeDeProducto Pro = new REntradeDeProducto();
            Pro.Show();
            Pro.MdiParent = this;
            
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

        private void entradaInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RProveedores Pro = new RProveedores();
            Pro.Show();
            Pro.MdiParent = this;

        }

        private void Menu_Load(object sender, EventArgs e)
        {
         //  registroUsuarioToolStripMenuItem.Visible = Program.usuario.Administrador;

        }

        private void captureDeInvetarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCapturarInventario cap = new ConsultaCapturarInventario();
            cap.Show();
            cap.MdiParent = this;
        }

      
    }
}
