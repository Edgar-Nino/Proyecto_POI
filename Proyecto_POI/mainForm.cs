using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public delegate void DAddItem(string toAdd);

        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private string username = "unknown";

        private void AddItem(string s)
        {
            listChat.Items.Add(s);
        }

        public mainForm(string Param_username)
        {
            InitializeComponent();
            username = Param_username;
            Conectar();
        }

        public mainForm()
        {
            InitializeComponent();
        }

        void Listen()
        {
            while(client.Connected)
            {
                try
                {
                    this.Invoke(new DAddItem(AddItem),streamr.ReadLine());
                }catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    MessageBox.Show("No se pudo conectar al servidor");
                    Application.Exit();
                }
            }
        }

        void Conectar()
        {
            try
            {
                client.Connect("127.0.0.1", 8080);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);

                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);

                    streamw.WriteLine(username);
                    streamw.Flush();

                    t.Start();
                }
                else
                {
                    MessageBox.Show("Servidor no disponible");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Servidor no disponible");
                Application.Exit();
            }
        }

        private void mainForm_Load(object sender, EventArgs e) {
            cuentaPanel.Hide();
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editAceptarBtn.Enabled = false;
            editCancelarBtn.Enabled = false;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            streamw.WriteLine(editMensaje.Text);
            streamw.Flush();
            editMensaje.Clear();
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
            Environment.Exit(0);
            //Application.Exit();
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
