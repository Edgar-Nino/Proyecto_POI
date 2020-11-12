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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            cuentaPanel.Hide();
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editAceptarBtn.Enabled = false;
            editCancelarBtn.Enabled = false;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {

        }

        private void correoBtn_Click(object sender, EventArgs e)
        {
            correoForm newForm = new correoForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void videoBtn_Click(object sender, EventArgs e)
        {
            videollamadaForm newForm = new videollamadaForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void archivoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void cuentaBtn_Click(object sender, EventArgs e)
        {
            
            cuentaPanel.Show();
          
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            textBoxUser.Enabled = true;
            textBoxPass.Enabled = true;
            textBoxMail.Enabled = true;
            editBtn.Enabled = false;
        }

        private void editAceptarBtn_Click(object sender, EventArgs e)
        {
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editBtn.Enabled = true;
        }

        private void editCancelarBtn_Click(object sender, EventArgs e)
        {
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editBtn.Enabled = true;
        }

        private void chatsBtn_Click(object sender, EventArgs e)
        {
            cuentaPanel.Hide();
        }

        private void correoBtn_Click_1(object sender, EventArgs e)
        {
            correoForm newForm = new correoForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void archivoBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
        }

        private void videoBtn_Click_1(object sender, EventArgs e)
        {
            videollamadaForm newForm = new videollamadaForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
    }
}
