using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Proyecto_POI
{
    partial class mainForm
    {
        void enviarPaquete(string Comando, string Valores)
        {
            Paquete paquete = new Paquete(Comando, Valores);
            streamw.WriteLine(paquete);
            streamw.Flush();
        }
    }
}
