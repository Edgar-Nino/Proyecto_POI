using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Server
{
    partial class Servidor_Chat
    {
        /// <summary>
        /// Es la key con la que se encripta la información
        /// </summary>
        string key = "a1b2c3d4e5f6g7h8";

        /// <summary>
        /// Sirve para publicar un mensaje publico.
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
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
                    Console.WriteLine("Hubo un error");
                }
            }
        }

        /// <summary>
        /// Sirve para enviar mensaje en un grupo
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="mapa"></param>
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
                        if (grupo.nombreGrupo == users[0] + users[1] || grupo.nombreGrupo == usernameMapa)
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
                        if (c.username == user)
                        {
                            string grupoID = (msgGroup.esGrupo) ? msgGroup.nombreGrupo : msgGroup.Users[0] + ":" + msgGroup.Users[1];

                            Paquete paquete = new Paquete("mensajegrupo", message + "," + grupoID);

                            c.streamW.WriteLine(paquete);
                            c.streamW.Flush();
                        }
                    }
                }

            }
            catch
            {
                Console.WriteLine("Hubo un error");
            }

        }

        /// <summary>
        /// Sirve para conseguir los usuarios conectados
        /// </summary>
        /// <param name="hcon"></param>
        public void conseguirUsuarios(Connection hcon)
        {
            var usuariosRegistrados = usuariosRegister.Select(C => C.username).ToList();
            string usuarios = Mapa.Serializar(usuariosRegistrados);

            Paquete paquete = new Paquete("usuariosregistrados", usuarios);

            hcon.streamW.WriteLine(paquete);
            hcon.streamW.Flush();
        }

        /// <summary>
        /// Es la que se encarga de actualiza la lista de los grupos
        /// </summary>
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
                    Console.WriteLine("Hubo un error");
                }
            }
            actualizarlistagrupos();
        }

        /// <summary>
        /// Es la que se encarga de cargar la lista de los grupos
        /// </summary>
        public void actualizarlistagrupos()
        {
            foreach (Connection c in listConn)
            {
                try
                {
                    List<string> gruposLista = new List<string>();

                    foreach (var grupo in mensajesGrupo)
                    {
                        if (grupo.esGrupo == true)
                        {
                            if (grupo.Users.Any(str => str.Contains(c.username)))
                            {
                                gruposLista.Add(grupo.nombreGrupo);
                            }
                        }
                    }

                    string grupos = Mapa.Serializar(gruposLista);

                    Paquete paquete = new Paquete("gruposregistrados", grupos);

                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
                catch
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }

        /// <summary>
        /// Con esto consigues todos los mensajes publicos.
        /// </summary>
        /// <param name="hcon"></param>
        public void conseguirMensajesPublicos(Connection hcon)
        {
            string msgPublic = Mapa.Serializar(messagesPublic);

            Paquete paquete = new Paquete("mensajespublicos", msgPublic);

            hcon.streamW.WriteLine(paquete);
            hcon.streamW.Flush();
        }

        /// <summary>
        /// Con esto consigues los mensajes de un grupo especifico
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="grupoName"></param>
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
                        if (c.username == users[0])
                        {
                            userC = ",true";
                        }
                    }

                    Paquete paquete = new Paquete("mensajesgrupo", grupo.esGrupo.ToString() + userC + "," + msgPublic);

                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                    return;
                }

            }
            Paquete paqueteVacio = new Paquete("mensajesgrupo", "");
            hcon.streamW.WriteLine(paqueteVacio);
            hcon.streamW.Flush();
        }

        /// <summary>
        /// Con esto actualizamos la la lista de los conectados
        /// </summary>
        /// <param name="hcon"></param>
        public void seDesconecto(Connection hcon)
        {
            foreach (Connection c in listConn)
            {
                if (c.username != hcon.username)
                {
                    Paquete paquete = new Paquete("sedesconecto", hcon.username);
                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
            }
        }

        /// <summary>
        /// Es para saber si un usuario se conecto
        /// </summary>
        /// <param name="hcon"></param>
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
                if (grupo.nombreGrupo == msg)
                {
                    existe = false;
                }
            }
            if (existe)
            {
                MensajesGrupo MGaux = new MensajesGrupo();
                MGaux.Users = new List<string>();
                MGaux.Mensajes = new List<string>();

                MGaux.nombreGrupo = msg;
                MGaux.Users.Add(hcon.username);
                MGaux.esGrupo = true;
                mensajesGrupo.Add(MGaux);
                actualizarlistausuarios();
            }
        }

        /// <summary>
        /// Con esto salimos de un grupo, esto dado un nombre
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void salirGrupo(Connection hcon, string msg)
        {
            foreach (var grupo in mensajesGrupo)
            {
                if (grupo.nombreGrupo == msg)
                {
                    grupo.Users.Remove(hcon.username);
                }
            }
            actualizarlistausuarios();
        }

        /// <summary>
        /// Este metodo sirve para invitar a alguien a un grupo
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void invitarGrupo(Connection hcon, string msg)
        {
            List<string> userGroup = Mapa.Deserializar(msg);

            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == userGroup[0])
                {
                    foreach (var grupo in mensajesGrupo)
                    {
                        if (grupo.nombreGrupo == userGroup[1])
                        {
                            if (!grupo.Users.Any(str => str.Contains(userGroup[0])))
                            {
                                grupo.Users.Add(userGroup[0]);
                            }
                        }
                    }
                }
            }
            actualizarlistausuarios();
        }

        /// <summary>
        /// Sirve para registrar usuarios, dado un username, password y email.
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
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
                if (usuario.username == useraux.username || usuario.email == useraux.email)
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

        /// <summary>
        /// Sirve para ingresar, esto dado un username y un password
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void ingresarUsuario(Connection hcon, string msg)
        {
            List<string> identificador = Mapa.Deserializar(msg);

            bool noEsta = true;

            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == identificador[0])
                {
                    if (usuario.password == identificador[1])
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

        /// <summary>
        /// Este metodo nos sirve para conseguir el correo de un usuario especifico, dado su username
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void recibircorreousuario(Connection hcon, string msg)
        {
            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == msg)
                {
                    Paquete paquete = new Paquete("recibirCorreo", usuario.email);
                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                }
            }
        }

        /// <summary>
        /// Sirve para invitar a alguien a una videollamada, esto dado un username
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void invitarVideollamada(Connection hcon, string msg)
        {
            foreach (Connection c in listConn)
            {
                if (c.username == msg)
                {
                    Paquete paquete = new Paquete("recibirInvitacion", hcon.username);
                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
            }
        }
        /// <summary>
        /// Sirve para contestar una invitacion a una videollamada, regresa un si o un no y el usuario.
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void responderVideollamada(Connection hcon, string msg)
        {
            List<string> content = Mapa.Deserializar(msg);

            foreach (Connection c in listConn)
            {
                if (c.username == content[0])
                {
                    Paquete paquete = new Paquete("videollamada", hcon.username + "," + content[1]);
                    c.streamW.WriteLine(paquete);
                    c.streamW.Flush();
                }
            }
        }

        /// <summary>
        /// Este metodo sirve para conseguir todos los datos de un usuario, esto dado su connection
        /// </summary>
        /// <param name="hcon"></param>
        public void conseguirDatosUsuario(Connection hcon)
        {
            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == hcon.username)
                {
                    Paquete paquete = new Paquete("userData", usuario.username + "," + usuario.password + "," + usuario.email);
                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                }
            }
        }

        /// <summary>
        /// Sirve para eliminar un usuario dado el Connection
        /// </summary>
        /// <param name="hcon"></param>
        public void eliminarUsuario(Connection hcon)
        {
            foreach (var usuario in usuariosRegister)
            {
                if (usuario.username == hcon.username)
                {
                    usuariosRegister.Remove(usuario);
                    Paquete paquete = new Paquete("volverLoginRegister", "");
                    hcon.streamW.WriteLine(paquete);
                    hcon.streamW.Flush();
                    actualizarlistausuarios();
                }
            }
        }

        /// <summary>
        /// Editar usuarios, nada mas se edita el password y el email.
        /// </summary>
        /// <param name="hcon"></param>
        /// <param name="msg"></param>
        public void editarUsuario(Connection hcon, string msg)
        {
            List<string> datos = Mapa.Deserializar(msg);

            int index = usuariosRegister.FindIndex(a => a.username == hcon.username);

            Usuario auxUsuario = new Usuario();

            auxUsuario.username = hcon.username;
            auxUsuario.password = datos[1];
            auxUsuario.email = datos[2];

            usuariosRegister[index] = auxUsuario;

            Paquete paquete = new Paquete("editarusuario", hcon.username+","+datos[1]+","+datos[2]);

            hcon.streamW.WriteLine(paquete);
            hcon.streamW.Flush();
            actualizarlistausuarios();
        }

        void enviarPaquete(StreamWriter sw, string Comando, string Valores)
        {
            var key = "a1b2c3d4e5f6g7h8";

            var encryptedCommand = Cifrado.EncryptString(key, Comando);
            var encryptedValues = Cifrado.EncryptString(key, Valores);

            Paquete paquete = new Paquete(encryptedCommand, encryptedValues);
            sw.WriteLine(paquete);
            sw.Flush();
        }
    }
}
