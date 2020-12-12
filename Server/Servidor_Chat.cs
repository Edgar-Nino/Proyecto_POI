using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Server
{
    /// <summary>
    /// Es la clase del servidor aqui se reciben paquetes que contienen comandos a realizar
    /// </summary>
    partial class Servidor_Chat
    {
        //Del profe ----------------------------------------------------------------------------------------------

        //public static int clients;
        //public static List<NetworkStream> networks;

        //static void Main(string [] args)
        //{
        //    networks = new List<NetworkStream>();
        //    clients = 0;
        //    byte[] IP = new byte[] {127, 0, 0, 1};
        //    int port = 8080;
        //    IPAddress address = new IPAddress(IP);

        //    TcpListener Listener = new TcpListener(address, port);
        //    Listener.Start();

        //    while (true) {
        //        Console.WriteLine("Esperando a clientes...");
        //        TcpClient client = Listener.AcceptTcpClient();
        //        new Thread(() => { listen(client); }).Start();
        //    }
        //}

        //public static void listen(TcpClient client) {
        //    Console.WriteLine("Escuchando a un cliente...");
        //    NetworkStream network = client.GetStream();
        //    clients++;
        //    int actualClient = clients;
        //    networks.Add(network);
        //    while (true) {
        //        string clientMessage = Utilidades.getMessage(network);
        //        string toSend = $"Usuario {actualClient}: {clientMessage}";
        //        Console.WriteLine(toSend);
        //        foreach (NetworkStream stream in networks)
        //        {
        //            Utilidades.sendMessage(stream, toSend);
        //        }
        //        //Aqui en algun lugarrrrrrr, cuando se desconecta hay que hacer un .remove(network) a networks 
        //    }

        //}

        /// <summary>
        /// Es el listado de los mensajes publicos, son los que estan en la sección PUBLICA
        /// </summary>
        public List<String> messagesPublic = new List<String>();


        //public List<String> usuariosRegistrados = new List<String>();

        /// <summary>
        /// Es el listado de todos los usuarios registrados.
        /// </summary>
        public List<Usuario> usuariosRegister = new List<Usuario>();

        /// <summary>
        /// Es el listado de todos los grupos, contiene sus mensajes, usuarios y nombre
        /// </summary>
        public List<MensajesGrupo> mensajesGrupo = new List<MensajesGrupo>();

        /// <summary>
        /// Es el listener que se va a utilizar
        /// </summary>
        public TcpListener server;

        /// <summary>
        /// Es el cliente actual
        /// </summary>
        public TcpClient client = new TcpClient();
        /// <summary>
        /// Es el endpoint que se utilizara para las conexiones
        /// </summary>
        public IPEndPoint ipenpoint = new IPEndPoint(IPAddress.Any, 8080);
        /// <summary>
        /// Es el listado de todos los usuarios conectados.
        /// </summary>
        public List<Connection> listConn = new List<Connection>();

        /// <summary>
        /// Es la conexión actual.
        /// </summary>
        Connection con;

        /// <summary>
        /// Es la estructura para los usuarios, esto incluye username, contraseña y email.
        /// </summary>
        public struct Usuario
        {
            public string username;
            public string password;
            public string email;
        }

        /// <summary>
        /// Es la estructura para la conexion, esto lo utilizamos para escuchar a los usuarios conectados
        /// </summary>
        public struct Connection
        {
            public TcpClient client;
            public NetworkStream stream;
            public StreamWriter streamW;
            public StreamReader streamR;
            public String username;
        }

        /// <summary>
        /// Es la estructura para mensajesGrupos, se incluyen una lista de todos los usuarios que pertenecen al grupo, la lista de los mensajes, un booleano que dice si es un grupo o es un chat privado y el nombre del grupo.
        /// </summary>
        public struct MensajesGrupo
        {
            public List<string> Users;
            public List<string> Mensajes;
            public bool esGrupo;
            public String nombreGrupo;
        }

        /// <summary>
        /// Es el constructor de nuestra clase, aquí iniciamos todo
        /// </summary>
        public Servidor_Chat()
        {
            Inicio();
        }

        /// <summary>
        /// Es el metodo que prepara la llegada de mensajes de clientes.
        /// </summary>
        public void Inicio()
        {
            Console.WriteLine("Servidor Iniciado");
            server = new TcpListener(ipenpoint);
            server.Start();

            while (true)
            {
                client = server.AcceptTcpClient();

                con = new Connection();
                con.client = client;
                con.stream = client.GetStream();
                con.streamR = new StreamReader(con.stream);
                con.streamW = new StreamWriter(con.stream);

                con.username = con.streamR.ReadLine();

                listConn.Add(con);
                seConecto(con);
                Console.WriteLine(con.username + " Se ha conectado");

                Thread t = new Thread(Escuchar_Conexion);

                t.Start();

            }
        }

        /// <summary>
        /// Aquí escuchamos los comandos de los clientes, todo esto a traves de la clase paquete.
        /// </summary>
        void Escuchar_Conexion()
        {
            Connection hcon = con;

            do
            {
                try
                {
                    var key = "a1b2c3d4e5f6g7h8";

                    string tmp = hcon.streamR.ReadLine();

                    //Paquete paquete = new Paquete(tmp);

                    string[] splitted = tmp.Split(':');

                    var decryptedCommand = Cifrado.DecryptString(key, splitted[0]);
                    var decryptedValues = Cifrado.DecryptString(key, splitted[1]);

                    Paquete paquete = new Paquete(decryptedCommand, decryptedValues);

                    switch (paquete.Comando)
                    {
                        case "mensajepublico":
                            {
                                publicMessage(hcon, paquete.Contenido);
                                break;
                            }
                        case "mensajegrupo":
                            {
                                groupMessage(hcon, paquete.Contenido);
                                break;
                            }
                        case "conseguirusuarios":
                            {
                                conseguirUsuarios(hcon);
                                break;
                            }
                        case "conseguirmensajespublicos":
                            {
                                conseguirMensajesPublicos(hcon);
                                break;
                            }
                        case "conseguirmensajesgrupo":
                            {
                                conseguirMensajesGrupo(hcon, paquete.Contenido);
                                break;
                            }
                        case "creargrupo":
                            {
                                crearGrupo(hcon, paquete.Contenido);
                                break;
                            }
                        case "salirgrupo":
                            {
                                salirGrupo(hcon, paquete.Contenido);
                                break;
                            }
                        case "invitargrupo":
                            {
                                invitarGrupo(hcon, paquete.Contenido);
                                break;
                            }
                        case "registrarse":
                            {
                                registrarUsuario(hcon, paquete.Contenido);
                                break;
                            }
                        case "ingresar":
                            {
                                ingresarUsuario(hcon, paquete.Contenido);
                                break;
                            }
                        case "recibircorreousuario":
                            {
                                recibircorreousuario(hcon, paquete.Contenido);
                                break;
                            }
                        case "videollamadainvitar":
                            {
                                invitarVideollamada(hcon, paquete.Contenido);
                                break;
                            }
                        case "respondervideollamada":
                            {
                                responderVideollamada(hcon, paquete.Contenido);
                                break;
                            }
                        case "conseguirdatausuario":
                            {
                                conseguirDatosUsuario(hcon);
                                break;
                            }
                        case "eliminarusuario":
                            {
                                eliminarUsuario(hcon);
                                break;
                            }
                        case "editarusuario":
                            {
                                editarUsuario(hcon, paquete.Contenido);
                                break;
                            }
                    }
                }
                catch
                {
                    seDesconecto(hcon);
                    listConn.Remove(hcon);
                    Console.WriteLine(hcon.username + " se ha desconectado");
                    break;
                }
            } while (true);
        }
    }
}
