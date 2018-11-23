using PreyectoFinal.BLL;
using PreyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Entrarbutton_Click(object sender, EventArgs e)
        {

            
                     DialogResult = DialogResult.OK;
                     Close();

          
            /*
                   SqlConnection conexion = new SqlConnection("Data Source =DESKTOP-4RSAB0P\\SQLEXPRESS; Initial Catalog=ProyectoFinalBD;"
                       + "Integrated Security = true;");

                   conexion.Open();
                   string cadena = "select Email, Contraseña from CrearUsuarios where Email ='" + EmailTextBox.Text + "' and Contraseña = '" + ContraseñaTextBox.Text + "' ";
                   SqlCommand comando = new SqlCommand(cadena, conexion);
                   SqlDataReader registro = comando.ExecuteReader();
                   if (registro.Read())
                   {

                       if ((registro["Email"].ToString() == EmailTextBox.Text) && (registro["Contraseña"].ToString() == ContraseñaTextBox.Text))
                       {
                           //MessageBox.Show("Correcto");
                           Menu M = new Menu();
                           M.Show();
                          // M.Activos();
                           this.Hide();
                       }
                   }
                   else
                       MessageBox.Show("El Email o la Contraseña estan incorrectos", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                   conexion.Close();
                     
            string usuario = EmailTextBox.Text;
                   string clave = ContraseñaTextBox.Text;
                   RepositorioBase<CrearUsuario> repositorio = new RepositorioBase<CrearUsuario>();
                   List<CrearUsuario> lista = repositorio.GetList(x => true);
                   foreach (var item in lista)
                   {
                       if (usuario== item.Email && clave == item.Contraseña)
                       {
                           new Menu().Show();
                           Program.usuario = item;
                           this.Visible = false;
                           MessageBox.Show("Bienbenido ");
                           break;
                       }
                       else
                       {
                           MessageBox.Show("usuario o password incorrectos ");
                           break;
                       }
                   */
                   }
                   
                 
        }


    }

    

