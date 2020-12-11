using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Server
{
    partial class Servidor_Chat
    {

        public void publicMessage(Connection hcon, string msg)
        {
            Console.WriteLine(hcon.username + ": " + msg);
            string message = hcon.username + ": " + msg;
            messagesPublic.Add(message);
            foreach (Connection c in listConn)
            {
                try
                {
                    Paquete paquete = new Paquete("mensajepublico", message);

                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
                catch
                {
                    Console.WriteLine("Hubo un error jeje");
                }
            }
        }

        public void groupMessage(Connection hcon, string mapa)
        {
            List<string> msgUsername = Mapa.Deserializar(mapa);

            string usernameMapa = msgUsername[0];
            string msgMapa = msgUsername[1];

            List<string> users = Mapa.Deserializar(usernameMapa + "," + hcon.username);

            users.Sort();

            Console.WriteLine("MensajeAGrupo " + usernameMapa + ": " + hcon.username + ": " + msgMapa);
            try
            {

                string message = hcon.username + ": " + msgMapa;

                bool noexiste = true;

                MensajesGrupo msgGroup = new MensajesGrupo();
                if (mensajesGrupo.Count != 0)
                {
                    foreach (MensajesGrupo grupo in mensajesGrupo)
                    {
                        if (grupo.nombreGrupo == users[0] + users[1])
                        {
                            noexiste = false;
                            msgGroup = grupo;
                            grupo.Mensajes.Add(message);
                        }
                    }
                }

                MensajesGrupo MGaux = new MensajesGrupo();
                if (noexiste)
                {


                    MGaux.Users = new List<string>();
                    MGaux.Mensajes = new List<string>();

                    MGaux.nombreGrupo = users[0] + users[1];
                    MGaux.Users.Add(users[0]);
                    MGaux.Users.Add(users[1]);
                    MGaux.Mensajes.Add(message);
                    MGaux.esGrupo = false;
                    msgGroup = MGaux;
                    mensajesGrupo.Add(MGaux);
                }


                foreach (Connection c in listConn)
                {
                    foreach (string user in msgGroup.Users)
                    {
                        if(c.username == user)
                        {
                            string grupoID = (msgGroup.esGrupo) ? msgGroup.nombreGrupo : msgGroup.Users[0]+":" + msgGroup.Users[1];

                            Paquete paquete = new Paquete("mensajegrupo", message + ","+ grupoID);

                            c.streamW.WriteLine(paquete);
                            c.streamW.Flush();
                        }
                    }
                }

            }
            catch
            {
                Console.WriteLine("Hubo un error jeje");
            }

        }

        public void conseguirUsuarios(Connection hcon)
        {
            var usuariosRegistrados = usuariosRegister.Select(C => C.username).ToList();
            string usuarios = Mapa.Serializar(usuariosRegistrados);

            Paquete paquete = new Paquete("usuariosregistrados", usuarios);

            hcon.streamW.WriteLine(paquete);
            hcon.streamW.Flush();
        }

        public void actualizarlistausuarios()
        {
            foreach (Connection c in listConn)
            {
                try
                {
                    var usuariosRegistrados = usuariosRegister.Select(C => C.username).ToList();
                    string usuarios = Mapa.Serializar(usuariosRegistrados);

                    Paquete paquete = new Paquete("usuariosregistrados", usuarios);

                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
                catch
                {
                    Console.WriteLine("Hubo un error jeje");
                }
            }
        }

        public void conseguirMensajesPublicos(Connection hcon)
        {
            string msgPublic = Mapa.Serializar(messagesPublic);

            Paquete paquete = new Paquete("mensajespublicos", msgPublic);

            hcon.streamW.WriteLine(paquete);
            hcon.streamW.Flush();
        }

        public void conseguirMensajesGrupo(Connection hcon, string grupoName)
        {
            List<string> users = Mapa.Deserializar(grupoName + "," + hcon.username);

            users.Sort();

            foreach (MensajesGrupo grupo in mensajesGrupo)
            {
                if (grupo.nombreGrupo == users[0] + users[1] || grupo.nombreGrupo == grupoName)
                {
                    string msgPublic = Mapa.Serializar(grupo.Mensajes);
                    string nombregrupo = (grupo.esGrupo) ? grupo.nombreGrupo : grupoName;

                    users.Remove(hcon.username);

                    string userC = "";

                    foreach (Connection c in listConn)
                    {
                        if(c.username==users[0])
                        {
                            userC = "true";
                        }
                    }

                    Paquete paquete = new Paquete("mensajesgrupo", grupo.esGrupo.ToString()+","+ userC + "," + msgPublic);

                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                    return;
                }

            }
            Paquete paqueteVacio = new Paquete("mensajesgrupo", "");
            hcon.streamW.WriteLine(paqueteVacio);
            hcon.streamW.Flush();
        }

        public void seDesconecto(Connection hcon)
        {
            foreach (Connection c in listConn)
            {
                Paquete paquete = new Paquete("sedesconecto", hcon.username);

                if(c.username != hcon.username)
                {
                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
            }
        }

        public void seConecto(Connection hcon)
        {
            foreach (Connection c in listConn)
            {
                Paquete paquete = new Paquete("seconecto", hcon.username);

                c.streamW.WriteLine(paquete);
                c.streamW.Flush();
            }
        }

        public void crearGrupo(Connection hcon, string msg)
        {
            bool existe = true;
            foreach (var grupo in mensajesGrupo)
            {
                if(grupo.nombreGrupo==msg)
                {
                    existe = false;
                }
            }
            if(existe)
            {
                MensajesGrupo MGaux = new MensajesGrupo();
                MGaux.Users = new List<string>();
                MGaux.Mensajes = new List<string>();

                MGaux.nombreGrupo = msg;
                MGaux.Users.Add(hcon.username);
                MGaux.esGrupo = true;
                mensajesGrupo.Add(MGaux);
            }
        }
        public void registrarUsuario(Connection hcon, string msg)
        {
            List<string> userdata = Mapa.Deserializar(msg);

            Usuario useraux = new Usuario();

            useraux.username = userdata[0];
            useraux.password = userdata[1];
            useraux.email = userdata[2];

            bool noEstaRegistrado = true;
            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == useraux.username)
                {
                    Paquete paquete = new Paquete("volverLoginRegister", "");
                    noEstaRegistrado = false;
                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                }
            }

            if (noEstaRegistrado)
            {
                usuariosRegister.Add(useraux);
                actualizarlistausuarios();
            }
        }

        public void ingresarUsuario(Connection hcon, string msg)
        {
            List<string> identificador = Mapa.Deserializar(msg);

            bool noEsta = true;

            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == identificador[0])
                {
                    if(usuario.password == identificador[1])
                    {
                        noEsta = false;
                    }
                }
            }
            if (noEsta)
            {
                Paquete paquete = new Paquete("volverLoginRegister", "");
                hcon.streamW.WriteLine(paquete);
                hcon.streamW.Flush();
            }
        }
    }
}
