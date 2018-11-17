using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI.Consultas
{
    public partial class ConsultasArticulo : Form
    {
        Expression<Func<Articulo, bool>> filtro = p => true;
        private List<Articulo> articulos = new List<Articulo>();
        public ConsultasArticulo()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulo, bool>> filtro = p => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        id = Convert.ToInt32(CristeriotextBox.Text);
                    filtro = p => p.ArticuloID == id;
                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este ID, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    break;
                case 1://Filtrando por la Descripcion del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Digitar una Descripcion!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = p => p.Descripcion.Contains(CristeriotextBox.Text);
                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Descripcion, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;
                case 2://Filtrando por Costo del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = p => p.Costo.Equals(CristeriotextBox.Text);

                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Monto, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    break;
                case 3://Filtrando por Precio del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = p => p.Precio.Equals(CristeriotextBox.Text);

                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Precio, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;
                case 4://Filtrando por PorcientoGanacia del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                     //   filtro = p => p.PorCientoGanancia.Equals(CristeriotextBox.Text);
                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este Porciento, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;
                case 5://Filtrando por Cantidad en el Inventario del Producto.
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                       // filtro = p => p.CantidadIventario.Equals(CristeriotextBox.Text);
                        if (ArticuloBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("No  hay Existencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;
                case 6:// Fecha
                  //  filtro = p => p.FechaVencimiento >= DesdedateTimePicker.Value.Date && p.FechaVencimiento <= HastadateTimePicker.Value.Date;
                    break;
                case 7://Todo
                    filtro = p => true;
                    break;


                    
            }
            ConsultaDataGridView.DataSource =  ArticuloBLL.GetList(filtro);
            CristeriotextBox.Clear();
            errorProvider.Clear();
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && string.IsNullOrEmpty(CristeriotextBox.Text))
            {
                errorProvider.SetError(CristeriotextBox, "Por Favor, Llenar Casilla!");
                paso = true;
            }
            if (error == 2 && int.TryParse(CristeriotextBox.Text, out num) == false)
            {
                errorProvider.SetError(CristeriotextBox, "Ingrese un Numero");
                paso = true;
            }

            if (error == 3 && int.TryParse(CristeriotextBox.Text, out num) == true)
            {
                errorProvider.SetError(CristeriotextBox, "Ingrese Caracteres");
                paso = true;
            }

            return paso;
        }
        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (articulos.Count == 0)
            {
                MessageBox.Show("No hay datos pra mostrar en el Reporte");
                return;
            }
            //ProductosReviewer productoReviewer = new ProductosReviewer(articulo);
            //productoReviewer.ShowDialog();
        }
    }
}
