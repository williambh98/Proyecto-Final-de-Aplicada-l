using PreyectoFinal.BLL;
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

namespace PreyectoFinal.UI.Registros
{
    public partial class RAlmacen : Form
    {
        RepositorioBase<Almacen> rep;
        public RAlmacen()
        {

            InitializeComponent();
            rep = new RepositorioBase<Almacen>();
        }
        private Almacen LlenaClase()
        {
            Almacen departamento = new Almacen();

            departamento.DepartamentoId = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
            departamento.Nombre = NombreTextBox.Text;

            return departamento;
        }

        private void Limpiar()
        {
            DepartamentoIdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
            myErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(NombreTextBox.Text))
            {
                myErrorProvider.SetError(NombreTextBox,
                    "Debe escribir el Nombre para el Departamento");
                paso = true;
            }

            return paso;
        }

        //Progrmación de los Botones
        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            rep = new RepositorioBase<Almacen>();
            int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
            Almacen departamento = rep.Buscar(id);

            if (departamento != null)
            {
                NombreTextBox.Text = departamento.Nombre;
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Almacen departamento;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            departamento = LlenaClase();

            if (DepartamentoIdNumericUpDown.Value == 0)
            {
                paso = rep.Guardar(departamento);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
                departamento = rep.Buscar(id);

                if (departamento != null)
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
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);

            Almacen departamento = rep.Buscar(id);
            if (departamento != null)
            {
                if (rep.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
