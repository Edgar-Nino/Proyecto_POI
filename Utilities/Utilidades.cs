﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Utilities
{
    /// <summary>
    /// Es la clase que utilizamos para funciones que utilizamos mucho
    /// </summary>
    public class Utilidades
    {
        /// <summary>
        /// Es la funcion enviar, esto lo utilizamos para enviar el video
        /// </summary>
        /// <param name="client">Es el cliente a quien enviamos el arreglo de Bytes</param>
        /// <param name="aEnviar">Son los Bytes a enviar</param>
        public static void Enviar(UdpClient client, byte[] aEnviar)
        {
            int faltante = aEnviar.Length;
            int porEnviar = 0;

            for (int i = 0; i < aEnviar.Length; i += porEnviar)
            {
                byte[] dataGrama = new byte[65507];
                porEnviar = (faltante > 65507) ? 65507 : faltante;
                Array.Copy(aEnviar, i, dataGrama, 0, porEnviar);
                client.Send(dataGrama, porEnviar);
                faltante = faltante - porEnviar;
            }
        }

        /// <summary>
        /// Es la función que utilizamos para recibir la videollamada
        /// </summary>
        /// <param name="client">Es el cliente de quien recibimos el arreglo de bytes</param>
        /// <param name="endpoint">Representa un endpoint como un Ip address o un número de puerto</param>
        /// <returns>Retorna el arreglo de bytes restante</returns>
        public static byte[] Recibir(UdpClient client, IPEndPoint endpoint)
        {
            byte[] completo = new byte[0];
            int actual = 0;
            while (true)
            {
                byte[] datagrama = client.Receive(ref endpoint);
                Array.Resize<byte>(ref completo, completo.Length + datagrama.Length);
                Array.Copy(datagrama, 0, completo, actual, datagrama.Length);
                actual += datagrama.Length;
                if (datagrama.Length != 65507)
                {
                    break;
                }
            }
            return completo;
        }
    }
    /// <summary>
    /// Es la clase que utilizamos para serializar y deserializar el contenido del Paquete
    /// </summary>
    public class Mapa
    {
        /// <summary>
        /// Lo utilizamos para serializar un contenido destinado a un paquete
        /// </summary>
        /// <param name="lista">Es la lista la cual vamos a serializara</param>
        /// <returns>regresa un string serializado ex. "username,pepep,hola"</returns>
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
        /// <summary>
        /// Lo utilizamos para  formar una lista de strings a partir de un string serializado
        /// </summary>
        /// <param name="entrada">es el string serializado</param>
        /// <returns>Una lista resultante de el string serializado</returns>
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
    /// <summary>
    /// Clase primordial en el proyecto, es el encargado de enviar mensajes serializados al servidor, asi como del servidor al cliente
    /// </summary>
    public class Paquete
    {
        /// <summary>
        /// Es la propiedad que utilizamos para hacer una función ex. Login, Register, Recibir mensajes.
        /// </summary>
        public string Comando { get; set; }
        /// <summary>
        /// Es el contenido que utilizamos para la función ex. username, texto, mensaje.
        /// </summary>
        public string Contenido { get; set; }

        public Paquete()
        {

        }

        /// <summary>
        /// Es el constructor que utilizamos para hacer un paquete a partir de un comando y un contenido dado
        /// </summary>
        /// <param name="comando">Es el comando del paquete</param>
        /// <param name="contenido">Es el contenido que hace que funcione el comando, puede estar vacio</param>
        public Paquete(string comando, string contenido)
        {
            Comando = comando;
            Contenido = contenido;
        }

        /// <summary>
        /// Es el contructor que utilizamos para hacer un paquete a partir de un texto ya serializado
        /// </summary>
        /// <param name="datos">Es el texto ya serializado, formato: ("{0}:{1}",Comando,Contenido)</param>
        public Paquete(string datos) // ej: login:usuario,contrasena
        {
            int sepIndex = datos.IndexOf(":", StringComparison.Ordinal);
            Comando = datos.Substring(0, sepIndex);
            Contenido = datos.Substring(Comando.Length + 1);
        }
        /// <summary>
        /// Es la funcion que utilizamos para serializar un paquete, esto a partir de un Comando y un Contenido
        /// </summary>
        /// <returns>Retorna un string con un paquete serializado</returns>
        public string Serializar()
        {
            return string.Format("{0}:{1}", Comando, Contenido);
        }

        /// <summary>
        /// Automaticamente pasar un paquete a un string 
        /// </summary>
        /// <param name="paquete">Es el paquete no serializado compuesto por un Comando y un Contenido</param>
        public static implicit operator string(Paquete paquete)
        {
            return paquete.Serializar();
        }


    }
    /// <summary>
    /// Esta clase la utilizamos para abrir un prompt, el cual nos servira para conseguir información.
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// Es el metodo para mostrar un prompt
        /// </summary>
        /// <param name="text">Es el parametro que damos para el cuerpo del prompt</param>
        /// <param name="caption">Es el parametro que damos para el titulo del prompt</param>
        /// <returns></returns>
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }


    }
    /// <summary>
    /// Es la clase que se va a hacer referencia para descifrar o cifrar un mensaje
    /// </summary>
    public class Cifrado
    {
        /// <summary>
        /// Sirve para encriptar un string, dados una key y un string
        /// </summary>
        /// <param name="key">Es la llave con la cual se va a encriptar el string</param>
        /// <param name="plainText">Es el string a desencriptar</param>
        /// <returns></returns>
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// Sirve para desencriptar un texto dada una llave.
        /// </summary>
        /// <param name="key">Es la llave que utilizamos para desencriptar la llave</param>
        /// <param name="cipherText">Es el texto a desencriptar</param>
        /// <returns></returns>
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Clase que nos sirve para validar cosas como los correos
    /// </summary>
    public class Verificacion
    {
        /// <summary>
        /// Sirve para validar un email, se asegura que tenga un arroba y un punto
        /// </summary>
        /// <param name="email">Es el email a validar</param>
        /// <returns>Retorna un verdadero si el email es valido</returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");

                bool isValidEmail = regex.IsMatch(email);

                if (isValidEmail)
                    return true;
                else
                    return false;
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;

            }
            
        }
        public bool isValidLength(string text)
        {
            try
            {
                if(text.Length>0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;

            }

        }
    }
}
