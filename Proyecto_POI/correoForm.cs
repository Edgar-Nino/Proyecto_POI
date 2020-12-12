using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proyecto_POI
{
    /// <summary>
    /// Es la clase del form del correo, aquí como su nombre lo dice mandaremos un correo al usuario actual.
    /// </summary>
    public partial class correoForm : Form
    {
        string filename = "";

        /// <summary>
        /// Es el constructor de la clase del correo, aqui inicializaremos el textbox destinatario.
        /// </summary>
        /// <param name="destinatario"></param>
        public correoForm(string destinatario)
        {
            InitializeComponent();

            L_Filename.Text = "Archivo";
            tb_Destinatario.Text = destinatario;
            tb_Destinatario.Enabled = false;
        }
        /// <summary>
        /// Aquí lo que hacemos es  mandar el correo con las especificicaciones de los textboxes, un titulo, descripción y un attachment, el destinatario no se puede cambiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    using(MailMessage email = new MailMessage())
                    {
                        email.From = new MailAddress("edgar123456789052@gmail.com");
                        email.To.Add(tb_Destinatario.Text);
                        email.Subject = tb_Title.Text;
                        email.Body = tb_Message.Text;

                        if(filename!="")
                        {
                            System.Net.Mail.Attachment attachment;
                            attachment = new Attachment(filename);
                            email.Attachments.Add(attachment);
                        }
                        
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("edgar123456789052@gmail.com", "www.123.com");
                        client.EnableSsl = true;

                        client.Send(email);
                        MessageBox.Show("Email enviado");
                    }
                }
                    
            }
            catch
            {
                MessageBox.Show("Hubo un error al enviar el email");
            }
            

            
            this.Close();
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Aquí llamamos el evento de openfiledialog, aqui vamos a mandar un correo, se pueden mandar archivos conjuntos de tipo texto o imágen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                L_Filename.Text = openFileDialog1.FileName;
                filename = openFileDialog1.FileName;
                string mime = MimeMapping.GetMimeMapping(filename);

                if(!((mime.Contains("image")) || (mime.Contains("text"))))
                {
                    MessageBox.Show("Solo se pueden subir archivos de tipo mime imagen o texto");
                    L_Filename.Text = "";
                    filename = "";
                }
            }
            else
            {
                L_Filename.Text = "";
                filename = "";
            }
        }
    }
}
