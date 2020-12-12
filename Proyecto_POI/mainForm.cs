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

        /// <summary>
        /// Es el NetworkStream de nuestra clase mainForm
        /// </summary>
        static private NetworkStream stream;
        /// <summary>
        /// Es el StreamWriter, es el que utilizaremos para mandar mensajes al servidor.
        /// </summary>
        static private StreamWriter streamw;
        /// <summary>
        /// Es el StreamReader, es el que utilizaremos para escuchar mensajes del servidor.
        /// </summary>
        static private StreamReader streamr;
        /// <summary>
        /// Es el tcp client de nuestra conexión.
        /// </summary>
        static private TcpClient client = new TcpClient();
        /// <summary>
        /// Es el username con el que identificamos al usuario actual.
        /// </summary>
        static private string username = "unknown";
        /// <summary>
        /// Es la contraseña del usuario.
        /// </summary>
        static private string password = "unknown";
        /// <summary>
        /// Es el email del usuario.
        /// </summary>
        static private string email = "unknown";
        /// <summary>
        /// Uso global para conseguir el username, password y email.
        /// </summary>
        List<string> userContent;
        /// <summary>
        /// Este es el paquete que le enviamos al usuario para que pueda ingresar o registrarse
        /// </summary>
        static private Paquete paqueteInicial;

        /// <summary>
        /// EjecutarComando es el metodo que utilizamos para recibir comandos del servidor, ponemos el comando en el switch y a partir de ahi se decide que acción hacer.
        /// </summary>
        /// <param name="msg">Es el mensaje del servidor al cliente, esta constituido por dos partes, un Comando y Contenido</param>
        private void EjecutarComando(string msg)
        {

            var key = "a1b2c3d4e5f6g7h8";

            string[] splitted = msg.Split(':');

            var decryptedCommand = Cifrado.DecryptString(key, splitted[0]);
            var decryptedValues = Cifrado.DecryptString(key, splitted[1]);

            Paquete paquete = new Paquete(decryptedCommand, decryptedValues);

            switch (paquete.Comando)
            {
                case "usuariosregistrados":
                    {
                        lb_Grupos.Items.Clear();
                        lb_Grupos.SelectedIndex = -1;

                        btn_invite.Visible = false;
                        btn_Salir.Visible = false;

                        List<string> listaUsuarios = Mapa.Deserializar(paquete.Contenido);
                        lb_Grupos.Items.Add("GLOBAL");

                        lb_Grupos.SelectedIndex = 0;

                        foreach (string usuario in listaUsuarios)
                        {
                            if (usuario != username)
                                lb_Grupos.Items.Add(usuario);
                        }
                        break;
                    }
                case "gruposregistrados":
                    {
                        List<string> listaGrupos = Mapa.Deserializar(paquete.Contenido);
                        foreach (string grupos in listaGrupos)
                        {
                            lb_Grupos.Items.Add(grupos);
                        }
                        break;
                    }
                case "mensajespublicos":
                    {
                        btn_invite.Visible = false;
                        btn_Salir.Visible = false;

                        listChat.Items.Clear();

                        videoBtn.Enabled = false;
                        correoBtn.Enabled = false;

                        List<string> listaMensajes = Mapa.Deserializar(paquete.Contenido);

                        foreach (string mensaje in listaMensajes)
                        {
                            string msgaux = mensaje;
                            msgaux = msgaux.Replace("<3", "💜");
                            msgaux = msgaux.Replace(";)", "😉");
                            msgaux = msgaux.Replace("=D", "😃");
                            msgaux = msgaux.Replace(">=(", "😡");
                            listChat.Items.Add(msgaux);
                        }
                        break;
                    }
                case "mensajepublico":
                    {
                        Console.Beep();
                        if (lb_Grupos.SelectedIndex == 0 || lb_Grupos.SelectedIndex == -1)
                        {
                            string msgaux = paquete.Contenido;
                            msgaux = msgaux.Replace("<3", "💜");
                            msgaux = msgaux.Replace(";)", "😉");
                            msgaux = msgaux.Replace("=D", "😃");
                            msgaux = msgaux.Replace(">=(", "😡");
                            listChat.Items.Add(msgaux);
                        }
                        break;
                    }
                case "mensajesgrupo":
                    {

                        List<string> listaMensajes = Mapa.Deserializar(paquete.Contenido);

                        listChat.Items.Clear();

                        btn_invite.Visible = false;
                        btn_Salir.Visible = false;

                        if (listaMensajes.Count != 0)
                        {
                            L_IsConnected.Text = "";

                            string esGrupo = listaMensajes.First();

                            videoBtn.Enabled = (esGrupo == "True") ? false : true;
                            correoBtn.Enabled = (esGrupo == "True") ? false : true;

                            listaMensajes.RemoveAt(0);

                            string userC = "";

                            if (esGrupo != "True")
                            {
                                userC = listaMensajes.First();

                                listaMensajes.RemoveAt(0);

                                L_IsConnected.Text = (userC == "true") ? "Conectado" : "Desconectado";

                                videoBtn.Enabled = (userC == "true") ? true : false;
                            }
                            else
                            {
                                btn_invite.Visible = true;
                                btn_Salir.Visible = true;
                                L_IsConnected.Text = "";
                            }




                            foreach (string mensaje in listaMensajes)
                            {
                                string msgaux = mensaje;
                                msgaux = msgaux.Replace("<3", "💜");
                                msgaux = msgaux.Replace(";)", "😉");
                                msgaux = msgaux.Replace("=D", "😃");
                                msgaux = msgaux.Replace(">=(", "😡");
                                listChat.Items.Add(msgaux);
                            }
                        }

                        break;
                    }
                case "mensajegrupo":
                    {
                        List<string> Contenido = Mapa.Deserializar(paquete.Contenido);

                        List<string> grupoNombre = Contenido[1].Split(':').ToList();

                        Console.Beep();

                        if (!(lb_Grupos.Text == ""))
                        {
                            try
                            {
                                if (lb_Grupos.Text == grupoNombre[0] || lb_Grupos.Text == grupoNombre[1])
                                {
                                    string msgaux = Contenido[0];
                                    msgaux = msgaux.Replace("<3", "💜");
                                    msgaux = msgaux.Replace(";)", "😉");
                                    msgaux = msgaux.Replace("=D", "😃");
                                    msgaux = msgaux.Replace(">=(", "😡");
                                    listChat.Items.Add(msgaux);
                                }
                            }catch
                            {

                            }
                            
                        }
                        break;
                    }
                case "sedesconecto":
                    {
                        if (!(lb_Grupos.SelectedIndex == 0 || lb_Grupos.SelectedIndex == -1))
                        {
                            if (lb_Grupos.Text == paquete.Contenido)
                            {
                                L_IsConnected.Text = "Desconectado";
                                videoBtn.Enabled = false;
                            }
                        }

                        break;
                    }
                case "seconecto":
                    {
                        if (!(lb_Grupos.SelectedIndex == 0 || lb_Grupos.SelectedIndex == -1))
                        {
                            if (lb_Grupos.Text == paquete.Contenido)
                            {
                                L_IsConnected.Text = "Conectado";
                                videoBtn.Enabled = true;
                            }
                        }

                        break;
                    }
                case "volverLoginRegister":
                    {
                        Environment.Exit(0);
                        break;
                    }
                case "recibirCorreo":
                    {
                        correoForm newForm = new correoForm(paquete.Contenido);
                        newForm.Show();
                        break;
                    }
                case "recibirInvitacion":
                    {
                        string usuario = paquete.Contenido;
                        DialogResult dialogResult = MessageBox.Show("¿Quieres aceptar la invitación?", usuario + " te ha invitado a una videollamada", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            enviarPaquete("respondervideollamada", usuario + "," + "si");

                            videollamadaForm newForm = new videollamadaForm(1);
                            newForm.Show();

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            enviarPaquete("respondervideollamada", usuario + "," + "no");
                        }
                        break;
                    }
                case "videollamada":
                    {
                        List<string> content = Mapa.Deserializar(paquete.Contenido);
                        if (content[1] == "si")
                        {
                            videollamadaForm newForm = new videollamadaForm(0);
                            newForm.Show();
                        }
                        else
                        {
                            MessageBox.Show(content[0] + " no acepto tu invitación");
                        }
                        break;
                    }
                case "userData":
                    {
                        List<string> content = Mapa.Deserializar(paquete.Contenido);

                        username = content[0];
                        password = content[1];
                        email = content[2];
                        textBoxUser.Text = username;
                        textBoxPass.Text = password;
                        textBoxMail.Text = email;

                        break;
                    }
                case "editarusuario":
                    {
                        List<string> content = Mapa.Deserializar(paquete.Contenido);

                        username = content[0];
                        password = content[1];
                        email = content[2];
                        textBoxUser.Text = username;
                        textBoxPass.Text = password;
                        textBoxMail.Text = email;

                        break;
                    }
            }
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {


        }
        /// <summary>
        /// Es la sobrecarga al constructor de nuestro mainForm, con esto puede recibir el login o register.
        /// </summary>
        /// <param name="paquete">Es el paquete con el que va a hacer la accion de login o register</param>
        public mainForm(string paquete)
        {
            InitializeComponent();
            DragControl.Draggable(true);

            paqueteInicial = new Paquete(paquete);
        }

        /// <summary>
        /// Es el contructor de nuestro mainForm.
        /// </summary>
        public mainForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Aqui es donde hacemos Invoke para que pueda funcionar nuestro Ejecutar comando.
        /// </summary>
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
                    Environment.Exit(0);
                }
            }
        }
        /// <summary>
        /// Aquí conectamos el cliente con el servidor, tambien se hace el login o el register, asimismo tambien hacemos acciones basicas como conseguir los usuarios, mensajes.
        /// </summary>
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

                    //t.IsBackground = true;

                    t.Start();

                    List<string> userContentConn = Mapa.Deserializar(paqueteInicial.Contenido);

                    enviarPaquete(paqueteInicial.Comando, paqueteInicial.Contenido);

                    enviarPaquete("conseguirusuarios", "");

                    enviarPaquete("conseguirmensajespublicos", "");

                    enviarPaquete("conseguirdatausuario", "");
                }
                else
                {
                    MessageBox.Show("Servidor no disponible");
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Servidor no disponible");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Aquí inicializamos nuestro MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            cuentaPanel.Hide();
            textBoxUser.Enabled = false;
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editAceptarBtn.Enabled = false;
            editCancelarBtn.Enabled = false;
            L_IsConnected.Text = "";

            btn_invite.Visible = false;
            btn_Salir.Visible = false;

            List<string> userContent = Mapa.Deserializar(paqueteInicial.Contenido);

            username = userContent[0];
            password = userContent[1];

            l_Username.Text = username;

            textBoxUser.Text = username;
            textBoxPass.Text = password;
            textBoxMail.Text = email;

            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(1);
            Conectar();
        }

        /// <summary>
        /// Esto lo usamos para saber si mandar un mensaje a un grupo o a una conversacion publica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!editMensaje.Text.Contains(":"))
            {
                if (!editMensaje.Text.Equals(""))
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
            }
            else
            {
                MessageBox.Show("No se admite :");
            }



        }

        /// <summary>
        /// Aquí recibimos el valor de la lista de grupos, lo utilizamos para cambiar los mensajes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_Grupos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lb_Grupos.SelectedIndex != -1)
            {
                if (lb_Grupos.SelectedIndex == 0)
                {
                    L_IsConnected.Text = "";
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

        /// <summary>
        /// Es el evento que utilizamos para el correo, aqui podremos enviar un correo, solamente sirve para conversaciones privadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void correoBtn_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["correoForm"] as correoForm) != null)
            {
                //Form is already open
            }
            else
            {
                enviarPaquete("recibircorreousuario", lb_Grupos.Text);
            }
        }

        /// <summary>
        /// Con este botón mandamos una invitación a participar a una videollamada, solamente sirve para conversaciones privadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoBtn_Click(object sender, EventArgs e)
        {

            enviarPaquete("videollamadainvitar", lb_Grupos.Text);

            MessageBox.Show("Se invito al usuario: " + lb_Grupos.Text);

            //videollamadaForm newForm = new videollamadaForm();
            //this.Hide();
            //newForm.Show();
            //this.Close();
        }

        private void archivoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
        }

        /// <summary>
        /// Es el botón que utilizamos para salir de la aplicación, Enviroment.Exit(0), sirve tambien para cerrar los threads que quedan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //Application.Exit();
        }

        /// <summary>
        /// Muestra la cuenta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cuentaBtn_Click(object sender, EventArgs e)
        {

            cuentaPanel.Show();
            videoBtn.Hide();
            correoBtn.Hide();
            l_Username.Hide();
            L_IsConnected.Hide();

        }
        /// <summary>
        /// Sirve para editar el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            textBoxPass.Enabled = true;
            textBoxMail.Enabled = true;
            editBtn.Enabled = false;
            editAceptarBtn.Enabled = true;
            editCancelarBtn.Enabled = true;
            editAceptarBtn.Show();
            editCancelarBtn.Show();
        }

        /// <summary>
        /// Es para aceptar los cambios del usuario;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editAceptarBtn_Click(object sender, EventArgs e)
        {
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editBtn.Enabled = true;
            editAceptarBtn.Hide();
            editCancelarBtn.Hide();

            enviarPaquete("editarusuario", textBoxUser.Text + "," + textBoxPass.Text + ","+ textBoxMail.Text);
            //username = userContent[0];
            // password = userContent[1];
            //email = userContent[2];
        }

        /// <summary>
        /// Cancelar editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editCancelarBtn_Click(object sender, EventArgs e)
        {
            textBoxPass.Enabled = false;
            textBoxMail.Enabled = false;
            editBtn.Enabled = true;
            editAceptarBtn.Hide();
            editCancelarBtn.Hide();

            textBoxUser.Text = username;
            textBoxPass.Text = password;
            textBoxMail.Text = email;

            //username = userContent[0];
            //password = userContent[1];
            //email = userContent[2];
        }

        /// <summary>
        /// Este botón lo utilizamos para  crear un grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chatsBtn_Click(object sender, EventArgs e)
        {
            cuentaPanel.Hide();
            videoBtn.Show();
            correoBtn.Show();
            l_Username.Show();
            L_IsConnected.Show();

            string value = Prompt.ShowDialog("Ingresa el nombre del grupo", "Crear grupo");
            if (value.Length == 0)
            {
                MessageBox.Show("No ingresaste nada");
            }
            else
            {
                enviarPaquete("creargrupo", value);
            }
        }

        private void archivoBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
        }

        /// <summary>
        /// Este boton lo utilizamos para salir de un grupo, logicamente solo sirve cuando estamos en un grupo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que quiere salir del grupo?", "Salir del grupo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                enviarPaquete("salirgrupo", lb_Grupos.Text);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        /// <summary>
        /// Este boton lo utilizamos para invitar a una persona al grupo actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_invite_Click(object sender, EventArgs e)
        {
            string value = Prompt.ShowDialog("Ingresa el nombre de la persona que quieres invitar", "Invitar persona");
            if (value.Length == 0)
            {
                MessageBox.Show("No ingresaste nada");
            }
            else
            {
                enviarPaquete("invitargrupo", value + "," + lb_Grupos.Text);
            }
        }

        /// <summary>
        /// Botón para eliminar el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que quiere salir del grupo?", "Salir del grupo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                enviarPaquete("eliminarusuario", "");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }
    }
}
