namespace Proyecto_POI
{
    partial class correoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Destinatario = new System.Windows.Forms.TextBox();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.salirBtn = new System.Windows.Forms.Button();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.L_Title = new System.Windows.Forms.Label();
            this.tb_Title = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_File = new System.Windows.Forms.Button();
            this.L_Filename = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 83);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSalmon;
            this.label2.Location = new System.Drawing.Point(238, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Correo electrónico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Destinatario:";
            // 
            // tb_Destinatario
            // 
            this.tb_Destinatario.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Destinatario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Destinatario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Destinatario.Location = new System.Drawing.Point(200, 144);
            this.tb_Destinatario.Name = "tb_Destinatario";
            this.tb_Destinatario.Size = new System.Drawing.Size(262, 19);
            this.tb_Destinatario.TabIndex = 9;
            // 
            // tb_Message
            // 
            this.tb_Message.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Message.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Message.Location = new System.Drawing.Point(200, 240);
            this.tb_Message.Multiline = true;
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(300, 95);
            this.tb_Message.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mensaje:";
            // 
            // salirBtn
            // 
            this.salirBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.salirBtn.FlatAppearance.BorderSize = 0;
            this.salirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirBtn.ForeColor = System.Drawing.Color.MintCream;
            this.salirBtn.Location = new System.Drawing.Point(325, 410);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(108, 27);
            this.salirBtn.TabIndex = 12;
            this.salirBtn.Text = "Cancelar";
            this.salirBtn.UseVisualStyleBackColor = false;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.BackColor = System.Drawing.Color.DarkSalmon;
            this.aceptarBtn.FlatAppearance.BorderSize = 0;
            this.aceptarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarBtn.ForeColor = System.Drawing.Color.MintCream;
            this.aceptarBtn.Location = new System.Drawing.Point(142, 410);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(108, 27);
            this.aceptarBtn.TabIndex = 13;
            this.aceptarBtn.Text = "Enviar";
            this.aceptarBtn.UseVisualStyleBackColor = false;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // L_Title
            // 
            this.L_Title.AutoSize = true;
            this.L_Title.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Title.Location = new System.Drawing.Point(66, 192);
            this.L_Title.Name = "L_Title";
            this.L_Title.Size = new System.Drawing.Size(49, 18);
            this.L_Title.TabIndex = 14;
            this.L_Title.Text = "Titulo:";
            // 
            // tb_Title
            // 
            this.tb_Title.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Title.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Title.Location = new System.Drawing.Point(200, 192);
            this.tb_Title.Name = "tb_Title";
            this.tb_Title.Size = new System.Drawing.Size(262, 19);
            this.tb_Title.TabIndex = 15;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_File
            // 
            this.btn_File.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_File.FlatAppearance.BorderSize = 0;
            this.btn_File.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_File.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_File.ForeColor = System.Drawing.Color.MintCream;
            this.btn_File.Location = new System.Drawing.Point(69, 354);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(108, 27);
            this.btn_File.TabIndex = 16;
            this.btn_File.Text = "Archivo";
            this.btn_File.UseVisualStyleBackColor = false;
            this.btn_File.Click += new System.EventHandler(this.btn_File_Click);
            // 
            // L_Filename
            // 
            this.L_Filename.AutoSize = true;
            this.L_Filename.Location = new System.Drawing.Point(183, 357);
            this.L_Filename.Name = "L_Filename";
            this.L_Filename.Size = new System.Drawing.Size(58, 19);
            this.L_Filename.TabIndex = 17;
            this.L_Filename.Text = "label3";
            // 
            // correoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(564, 460);
            this.Controls.Add(this.L_Filename);
            this.Controls.Add(this.btn_File);
            this.Controls.Add(this.tb_Title);
            this.Controls.Add(this.L_Title);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.aceptarBtn);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.tb_Destinatario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "correoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "correoForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Destinatario;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.Label L_Title;
        private System.Windows.Forms.TextBox tb_Title;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_File;
        private System.Windows.Forms.Label L_Filename;
    }
}