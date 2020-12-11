using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_POI
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            
        }

        private void cuentaBtn_Click(object sender, EventArgs e)
        {
            registroForm newForm = new registroForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();

        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            mainForm newForm = new mainForm(textBoxUser.Text);
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
    }
}
