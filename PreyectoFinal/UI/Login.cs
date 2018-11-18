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
                    Main M = new Main();
                    M.Show();
                   // M.Activos();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("El Email o la Contraseña estan incorrectos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            conexion.Close();
            
    */
        }
        
    
    
    }
    
}
