using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Proyecto_POI
{
    /// <summary>
    /// Aqui se encuentran los metodos que utilizaremos 
    /// </summary>
    partial class mainForm
    {
        /// <summary>
        /// Sirve para enviar mensajes encriptados al servidor
        /// </summary>
        /// <param name="Comando">Es el comando a realizar de parte del servidor</param>
        /// <param name="Valores">Son los valores de la accion a realizar</param>
        void enviarPaquete(string Comando, string Valores)
        {
            var key = "a1b2c3d4e5f6g7h8";

            var encryptedCommand = Cifrado.EncryptString(key, Comando);
            var encryptedValues = Cifrado.EncryptString(key, Valores);

            Paquete paquete = new Paquete(encryptedCommand, encryptedValues);
            streamw.WriteLine(paquete);
            streamw.Flush();
        }
    }
}
