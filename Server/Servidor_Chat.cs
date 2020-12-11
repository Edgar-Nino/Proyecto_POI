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

        public List<String> messagesPublic = new List<String>();

        //public List<String> usuariosRegistrados = new List<String>();

        public List<Usuario> usuariosRegister = new List<Usuario>();

        public List<MensajesGrupo> mensajesGrupo = new List<MensajesGrupo>();

        public TcpListener server;
        public TcpClient client = new TcpClient();
        public IPEndPoint ipenpoint = new IPEndPoint(IPAddress.Any, 8080);
        public List<Connection> listConn = new List<Connection>();

        Connection con;

        public struct Usuario
        {
            public string username;
            public string password;
            public string email;
        }

        public struct Connection
        {
            public TcpClient client;
            public NetworkStream stream;
            public StreamWriter streamW;
            public StreamReader streamR;
            public String username;
        }

        public struct MensajesGrupo
        {
            public List<string> Users;
            public List<string> Mensajes;
            public bool esGrupo;
            public String nombreGrupo;
        }

        public Servidor_Chat()
        {
            Inicio();
        }

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

        void Escuchar_Conexion()
        {
            Connection hcon = con;



            do
            {
                try
                {
                    string tmp = hcon.streamR.ReadLine();

                    Paquete paquete = new Paquete(tmp);

                    switch(paquete.Comando)
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

        public void DisconnectClient(string username)
        {
            foreach (Connection client in listConn)
            {
                if (client.username == username)
                {
                    listConn.Remove(client);
                }
            }
        }
    }
}
