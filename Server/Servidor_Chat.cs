using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Server
{
    class Servidor_Chat
    {
        private TcpListener server;
        private TcpClient client = new TcpClient();
        private IPEndPoint ipenpoint = new IPEndPoint(IPAddress.Any,8000);
        private List<Connection> listConn = new List<Connection>();

        Connection con;

        private struct Connection
        {
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
                con.stream = client.GetStream();
                con.streamR = new StreamReader(con.stream);
                con.streamW = new StreamWriter(con.stream);

                con.username = con.streamR.ReadLine();

                listConn.Add(con);
                Console.WriteLine(con.username + "Se ha conectado");

                Thread t = new Thread(Escuchar_Conexion);
            
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
                    foreach(Connection c in listConn)
                    {
                        try
                        {
                            c.streamW.WriteLine(hcon.username + ": " + tmp);
                            c.streamW.Flush();
                        }
                        catch
                        {

                        }
                    }
                }catch
                {
                    listConn.Remove(hcon);
                    Console.WriteLine(con.username + "se ha desconectado");
                    break;
                }
            } while (true);
        }
    }
}
