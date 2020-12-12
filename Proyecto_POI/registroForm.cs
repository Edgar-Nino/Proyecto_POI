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
    public partial class registroForm : Form
    {
        public registroForm()
        {
            InitializeComponent();
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            formLogin newForm = new formLogin();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {

            Verificacion check = new Verificacion();
            if (check.IsValidEmail(textBoxEmail.Text))
            {
                Paquete paquete = new Paquete("registrarse", textBoxUser.Text + "," + textBoxPass.Text + "," + textBoxEmail.Text);

                mainForm newForm = new mainForm(paquete);
                this.Hide();
                newForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Su direccion de correo no es valida.");
            }
        }
    }
}
