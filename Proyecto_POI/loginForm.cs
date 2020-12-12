using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
namespace Proyecto_POI
{
    public partial class formLogin : Form
    {

        /// <summary>
        /// CONSTRUCTOR DEL FORMLOGIN
        /// </summary>
        public formLogin()
        {
            InitializeComponent();
            panel1.Draggable(true);
        }

        /// <summary>
        /// Sirve para ir al form del registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuentaBtn_Click(object sender, EventArgs e)
        {
            registroForm newForm = new registroForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();

        }
        /// <summary>
        /// Sirve para salir de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirBtn_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Es el encargado de ingresar al mainform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete("ingresar", textBoxUser.Text + "," + textBoxPass.Text);
            
            mainForm newForm = new mainForm(paquete);
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
    }
}
