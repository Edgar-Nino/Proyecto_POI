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
    class Servidor_Chat
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

        private TcpListener server;
        private TcpClient client = new TcpClient();
        private IPEndPoint ipenpoint = new IPEndPoint(IPAddress.Any, 8080);
        private List<Connection> listConn = new List<Connection>();

        Connection con;

        private struct Connection
        {
            public TcpClient client;
            public NetworkStream stream;
            public StreamWriter streamW;
            public StreamReader streamR;
            public String username;
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
                    Console.WriteLine(hcon.username + ": " + tmp);
                    foreach (Connection c in listConn)
                    {
                        if (!IsConnected(c.client))
                        {
                            
                                Console.WriteLine(c.username + "se ha desconectado");
                                DisconnectClient(c.username);
                                continue;
                        }
                        try
                        {
                            c.streamW.WriteLine(hcon.username + ": " + tmp);
                            c.streamW.Flush();
                        }
                        catch
                        {
                            Console.WriteLine("Hubo un error jeje");
                        }
                    }
                }
                catch
                {
                    listConn.Remove(hcon);
                    Console.WriteLine(con.username + " se ha desconectado");
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

        public bool IsConnected(TcpClient tcpclient)
        {
            try
            {
                if (tcpclient != null && tcpclient.Client != null && tcpclient.Client.Connected)
                {
                    /* pear to the documentation on Poll:
                     * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                     * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                     * -or- true if data is available for reading; 
                     * -or- true if the connection has been closed, reset, or terminated; 
                     * otherwise, returns false
                     */

                    // Detect if client disconnected
                    if (tcpclient.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (tcpclient.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            // Client disconnected
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
