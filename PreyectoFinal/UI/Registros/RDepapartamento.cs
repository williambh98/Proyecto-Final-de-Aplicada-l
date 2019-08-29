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
    public partial class RDepapartamento : Form
    {
        RepositorioBase<Departamento> rep;
        public RDepapartamento()
        {

            InitializeComponent();
            rep = new RepositorioBase<Departamento>();
        }
        private Departamento LlenaClase()
        {
            Departamento departamento = new Departamento();

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
            bool paso = true;

            if (String.IsNullOrEmpty(NombreTextBox.Text))
            {
                myErrorProvider.SetError(NombreTextBox,
                    "Debe escribir el Nombre para el Departamento");
                paso = false;
            }

            return paso;
        }

        //Progrmación de los Botones
        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            rep = new RepositorioBase<Departamento>();
            int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
            Departamento departamento = rep.Buscar(id);

            if (departamento != null)
            {
                NombreTextBox.Text = departamento.Nombre;
                FechadateTimePicker.Value = departamento.fecha;
            }
            else
            {
                myErrorProvider.SetError(DepartamentoIdNumericUpDown, "No Existe");
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            rep = new RepositorioBase<Departamento>();
            Departamento departamento;
            bool paso = false;

            if (!HayErrores())
                {
                    MessageBox.Show("Llenar campos ", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

            Departamento departamento = rep.Buscar(id);
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

        public static void SoloLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
            }
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

       
    }
}
