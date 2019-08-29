using BLL;
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

namespace PreyectoFinal.UI.Registros
{
    public partial class RTipoArticulo : Form
    {
        RepositorioBase<TipoArticulo> rep; 
        public RTipoArticulo()
        {
            InitializeComponent();
            rep = new RepositorioBase<TipoArticulo>();
        }

        private void Limpiar()
        {
           
            TipoIdNumericUpDown.Value = 0;
            TipoTextbox.Clear();
            ErrorProvider.Clear();

            DescripcionTextBox.Clear();
        }
        private TipoArticulo LlenaClase()
        {
            TipoArticulo tipo = new TipoArticulo();

            tipo.TiposId = Convert.ToInt32(TipoIdNumericUpDown.Value);
            tipo.Descripcion = DescripcionTextBox.Text;
            tipo.Nombre = TipoTextbox.Text;
            return tipo;
        }
        private void LlenarCampos(TipoArticulo tipos)
        {

            TipoIdNumericUpDown.Value = Convert.ToInt32(tipos.TiposId);
            TipoTextbox.Text = tipos.Nombre;
            DescripcionTextBox.Text = tipos.Descripcion;

        }

        private bool Validar()
        {
            bool paso = true;
         
            if (String.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                ErrorProvider.SetError(DescripcionTextBox,
                    "LLenar Campo Descripcion");
                paso = false;
            }
          
            if (String.IsNullOrEmpty(TipoTextbox.Text))
            {
                ErrorProvider.SetError(TipoTextbox,
                    "Llenar Campo Tipo");
                paso = false;
            }
            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            rep = new RepositorioBase<TipoArticulo>();
            TipoArticulo tipo;
            bool paso = false;
            if (!Validar())
            {
                MessageBox.Show("Llenar campos ", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            tipo = LlenaClase();

            if (TipoIdNumericUpDown.Value == 0)
            {
                paso = rep.Guardar(tipo);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(TipoIdNumericUpDown.Value);
                tipo = rep.Buscar(id);

                if (tipo != null)
                {
                    paso = rep.Modificar(LlenaClase());
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No guardardado!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ExiteEnLaDb()
        {
            rep = new RepositorioBase<TipoArticulo>();
            TipoArticulo Tpi = rep.Buscar((int)TipoIdNumericUpDown.Value);
            return (Tpi != null);
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            int id;
            rep = new RepositorioBase<TipoArticulo>();
            int.TryParse(TipoIdNumericUpDown.Text, out id);
            if (!ExiteEnLaDb())
            {
                ErrorProvider.SetError(TipoIdNumericUpDown, "No Eliminado");
                TipoIdNumericUpDown.Focus();
                return;
            }
            Limpiar();
            if (rep.Eliminar(id))
                MessageBox.Show("Eliminado ");
            else
            {
                MessageBox.Show("No Elimino");
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            int id;
            rep = new RepositorioBase<TipoArticulo>();
            TipoArticulo Tip = new TipoArticulo();
            int.TryParse(TipoIdNumericUpDown.Text, out id);
            Tip = rep.Buscar(id);
            if (Tip != null)
            {
                LlenarCampos(Tip);
                MessageBox.Show("Encotrada");
            }
            else
            {
                ErrorProvider.SetError(TipoIdNumericUpDown, "No Existe");
            }
        }

        private void NuevoButton_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void RTipoArticulo_Load(object sender, EventArgs e)
        {

        }
    }
}
