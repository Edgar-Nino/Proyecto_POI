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

        public delegate void RecibirMensaje(string toAdd);

        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private string username = "unknown";

        private void EjecutarComando(string msg)
        {
            Paquete paquete = new Paquete(msg);

            switch (paquete.Comando)
            {
                case "usuariosregistrados":
                    {
                        lb_Grupos.Items.Clear();
                        List<string> listaUsuarios = Mapa.Deserializar(paquete.Contenido);
                        lb_Grupos.Items.Add("PUBLICO");
                        foreach (string usuario in listaUsuarios)
                        {
                            if (usuario != username)
                                lb_Grupos.Items.Add(usuario);
                        }
                        break;
                    }
                case "mensajespublicos":
                    {
                        listChat.Items.Clear();

                        videoBtn.Enabled = false;

                        List<string> listaMensajes = Mapa.Deserializar(paquete.Contenido);

                        foreach (string mensaje in listaMensajes)
                        {
                            listChat.Items.Add(mensaje);
                        }
                        break;
                    }
                case "mensajepublico":
                    {
                        if (lb_Grupos.SelectedIndex == 0 || lb_Grupos.SelectedIndex == -1)
                        {
                            listChat.Items.Add(paquete.Contenido);
                        }
                        break;
                    }
                case "mensajesgrupo":
                    {

                        List<string> listaMensajes = Mapa.Deserializar(paquete.Contenido);

                        listChat.Items.Clear();

                        if (listaMensajes.Count!=0)
                        {
                            string esGrupo = listaMensajes.First();

                            videoBtn.Enabled = (esGrupo == "true") ? false : true;

                            listaMensajes.RemoveAt(0);

                            foreach (string mensaje in listaMensajes)
                            {
                                listChat.Items.Add(mensaje);
                            }
                        }
                        
                        break;
                    }
                case "mensajegrupo":
                    {
                        List<string> Contenido = Mapa.Deserializar(paquete.Contenido);

                        List<string> grupoNombre = Contenido[1].Split(':').ToList();

                        if (lb_Grupos.Text == grupoNombre[0] || lb_Grupos.Text == grupoNombre[1])
                        {
                            listChat.Items.Add(Contenido[0]);
                        }
                        break;
                    }
            }
        }

        public mainForm(string Param_username)
        {
            InitializeComponent();

            username = Param_username;
        }

        public mainForm()
        {
            InitializeComponent();
        }

        void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    this.Invoke(new RecibirMensaje(EjecutarComando), streamr.ReadLine());

                }
                catch (Exception e)
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

                    enviarPaquete("conseguirusuarios", "");

                    enviarPaquete("conseguirmensajespublicos", "");

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

        private void mainForm_Load(object sender, EventArgs e)
        {
            cuentaPanel.Hide();
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editAceptarBtn.Enabled = false;
            editCancelarBtn.Enabled = false;

            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(1);
            Conectar();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (lb_Grupos.SelectedIndex == 0 || lb_Grupos.SelectedIndex == -1)
            {
                enviarPaquete("mensajepublico", editMensaje.Text);
                editMensaje.Clear();
            }
            else
            {
                enviarPaquete("mensajegrupo", lb_Grupos.Text + "," + editMensaje.Text);
                editMensaje.Clear();
            }


        }

        private void lb_Grupos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lb_Grupos.SelectedIndex != -1)
            {
                if (lb_Grupos.SelectedIndex == 0)
                {
                    enviarPaquete("conseguirmensajespublicos", "");
                }
                else
                {
                    enviarPaquete("conseguirmensajesgrupo", lb_Grupos.Text);
                }

                //textBox1.Text = ListBox1.SelectedValue.ToString();
                // If we also wanted to get the displayed text we could use
                // the SelectedItem item property:
                // string s = ((USState)ListBox1.SelectedItem).LongName;
            }
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
