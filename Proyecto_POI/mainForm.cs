using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Proyecto_POI
{
    public partial class mainForm : Form
    {

        public delegate void delegar(string toAdd);

        NetworkStream network;

        public mainForm()
        {
            InitializeComponent();
            new Thread(() => { connect(); }).Start();
        }

        public void connect() {
            try
            {
                int port = 8080;
                string IP = "127.0.0.1";
                TcpClient client = new TcpClient(IP, port);

                addMessage("Conectado.");

                network = client.GetStream();
                while (true) {
                    string message = Utilidades.getMessage(network);
                    addMessage(message);
                }
            }
            catch (Exception)
            {
                addMessage("Ocurrio un problema al establecer la conexion.");
            }
        }

        public void addMessage(string msgToAdd) {
            delegar delegado = new delegar((string toAdd) => { listChat.Items.Add(toAdd); });
            listChat.BeginInvoke(delegado, msgToAdd);
        }

        private void mainForm_Load(object sender, EventArgs e) {
            cuentaPanel.Hide();
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editAceptarBtn.Enabled = false;
            editCancelarBtn.Enabled = false;
        }

        void sendBtn_Click(object sender, EventArgs e)
        {
            Utilidades.sendMessage(network, editMensaje.Text);
            editMensaje.Text = "";
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

        private void sendBtn_Click_1(object sender, EventArgs e)
        {
            Utilidades.sendMessage(network, editMensaje.Text);
            editMensaje.Text = "";
        }
    }
}
