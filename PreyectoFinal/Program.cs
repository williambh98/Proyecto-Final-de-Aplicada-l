using PreyectoFinal.Entidades;
using PreyectoFinal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoFinal
{
    static class Program
    {
        public static CrearUsuario usuario = null;

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login lg = new Login();
           
            Application.Run(lg);
            if(lg.DialogResult == DialogResult.OK)
            {
                lg.Dispose();
                Application.Run(new Menu());
            }
        }
    }
}
