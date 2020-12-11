using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Utilities
{
    public class Utilidades
    {
        public static string getMessage(NetworkStream network) {
            try {
            byte[] sent = new byte[1024];
            int readBytes = network.Read(sent, 0, sent.Length);
            string message = Encoding.UTF8.GetString(sent, 0, readBytes);
            return message;
            }
            catch (Exception)
            {
                return "FATAL ERROR!";
            }
        }

        public static void sendMessage(NetworkStream network, string message) {
            try
            {
                byte[] toSend = Encoding.UTF8.GetBytes(message);
                network.Write(toSend, 0, toSend.Length);
            }
            catch (Exception) {

            }
        }
    }

    public class Mapa
    {
        public static string Serializar(List<string> lista)
        {
            if (lista.Count == 0)
            {
                return null;
            }

            bool esElPrimero = true;
            var salida = new StringBuilder();

            foreach (var linea in lista)
            {
                if (esElPrimero)
                {
                    salida.Append(linea);
                    esElPrimero = false;
                }
                else
                {
                    salida.Append(string.Format(",{0}", linea));
                }
            }
            return salida.ToString();
        }

        public static List<string> Deserializar(string entrada)
        {
            string str = entrada;
            var lista = new List<string>();

            if (string.IsNullOrEmpty(str))
            {
                return lista;
            }

            try
            {
                foreach (string linea in entrada.Split(','))
                {
                    lista.Add(linea);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }
    }

    public class Paquete
    {
        public string Comando { get; set; }
        public string Contenido { get; set; }

        public Paquete()
        {

        }

        public Paquete(string comando, string contenido)
        {
            Comando = comando;
            Contenido = contenido;
        }

        public Paquete(string datos) // ej: login:usuario,contrasena
        {
            int sepIndex = datos.IndexOf(":", StringComparison.Ordinal);
            Comando = datos.Substring(0, sepIndex);
            Contenido = datos.Substring(Comando.Length + 1);
        }

        public string Serializar()
        {
            return string.Format("{0}:{1}", Comando, Contenido);
        }

        public static implicit operator string(Paquete paquete)
        {
            return paquete.Serializar();
        }
    }
}
