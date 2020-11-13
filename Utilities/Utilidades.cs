using System;
using System.Net.Sockets;
using System.Text;

namespace Utilities
{
    public class Utilidades
    {
        public static string getMessage(NetworkStream network) {
            byte[] sent = new byte[1024];
            int readBytes = network.Read(sent, 0, sent.Length);
            string message = Encoding.UTF8.GetString(sent, 0, readBytes);
            return message;
        }

        public static void sendMessage(NetworkStream network, string message) {
            byte[] toSend = Encoding.UTF8.GetBytes(message);
            network.Write(toSend, 0, toSend.Length);
        }
    }
}
