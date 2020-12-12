using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Utilities;
namespace Proyecto_POI
{
    public partial class videollamadaForm : Form
    {
        int usuario;
        IPEndPoint endpoint;

        Thread tE;
        Thread tRV;

        UdpClient clientR;
        UdpClient clientS;

        Mat imagen;
        VideoCapture camara;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public videollamadaForm(int number)
        {
            usuario = number;
            InitializeComponent();

            camara = new VideoCapture(usuario);

            tE = new Thread(EnviarVideo);

            tE.IsBackground = true;

            tE.Start();
        }
        /// <summary>
        /// Aquí recibimos el video
        /// </summary>
        /// <param name="receivePort">es el parametro que recibe el puerto</param>
        void RecibirVideo(string receivePort)
        {
            try
            {
                endpoint = new IPEndPoint(IPAddress.Any, Int32.Parse(receivePort));
                clientR = new UdpClient(endpoint);
            }
            catch
            {
                MessageBox.Show("Hay un error con el endpoint");
            }
            
            while (true)
            {
                try
                {
                    byte[] imagen = Utilidades.Recibir(clientR, endpoint);
                    Stream stream = new MemoryStream(imagen);
                    pictureBox1.Image = new Bitmap(stream);
                }
                catch (Exception)
                {

                }
            }
        }
        /// <summary>
        /// Es la parte donde se manda el video.
        /// </summary>
        void EnviarVideo()
        {
            int ep = (usuario == 0) ? 1932 : 1933;
            string receivePort = (usuario == 0) ? "1933" : "1932";

            clientS = new UdpClient("127.0.0.1", ep);

            tRV = new Thread(() => { RecibirVideo(receivePort); });

            tRV.IsBackground = true;

            tRV.Start();
            while (true)
            {
                if (camara != null && camara.IsOpened)
                {
                    imagen = camara.QueryFrame();
                    if (imagen != null)
                    {
                        byte[] imagenBytes = imagen.ToImage<Bgr, byte>().ToJpegData(100);
                        Utilidades.Enviar(clientS, imagenBytes);
                    }
                }
            }
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            tRV.Abort();
            tE.Abort();
            this.Close();
        }
    }
}
