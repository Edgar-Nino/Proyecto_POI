namespace Proyecto_POI
{
    partial class mainForm
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
            this.DragControl = new System.Windows.Forms.Panel();
            this.salirBtn = new System.Windows.Forms.Button();
            this.cuentaBtn = new System.Windows.Forms.Button();
            this.chatsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_Grupos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chatViewPanel = new System.Windows.Forms.Panel();
            this.L_IsConnected = new System.Windows.Forms.Label();
            this.cuentaPanel = new System.Windows.Forms.Panel();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.editAceptarBtn = new System.Windows.Forms.Button();
            this.editCancelarBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.correoBtn = new System.Windows.Forms.Button();
            this.videoBtn = new System.Windows.Forms.Button();
            this.listChat = new System.Windows.Forms.ListBox();
            this.archivoBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.editMensaje = new System.Windows.Forms.TextBox();
            this.l_Username = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_invite = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.DragControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.chatViewPanel.SuspendLayout();
            this.cuentaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DragControl
            // 
            this.DragControl.BackColor = System.Drawing.Color.CadetBlue;
            this.DragControl.Controls.Add(this.salirBtn);
            this.DragControl.Controls.Add(this.cuentaBtn);
            this.DragControl.Controls.Add(this.chatsBtn);
            this.DragControl.Controls.Add(this.label2);
            this.DragControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragControl.Location = new System.Drawing.Point(0, 0);
            this.DragControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DragControl.Name = "DragControl";
            this.DragControl.Size = new System.Drawing.Size(564, 88);
            this.DragControl.TabIndex = 0;
            // 
            // salirBtn
            // 
            this.salirBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.salirBtn.FlatAppearance.BorderSize = 0;
            this.salirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirBtn.ForeColor = System.Drawing.Color.MintCream;
            this.salirBtn.Location = new System.Drawing.Point(406, 23);
            this.salirBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(120, 61);
            this.salirBtn.TabIndex = 4;
            this.salirBtn.Text = "Salir";
            this.salirBtn.UseVisualStyleBackColor = false;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // cuentaBtn
            // 
            this.cuentaBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.cuentaBtn.FlatAppearance.BorderSize = 0;
            this.cuentaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuentaBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaBtn.ForeColor = System.Drawing.Color.MintCream;
            this.cuentaBtn.Location = new System.Drawing.Point(280, 23);
            this.cuentaBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cuentaBtn.Name = "cuentaBtn";
            this.cuentaBtn.Size = new System.Drawing.Size(120, 61);
            this.cuentaBtn.TabIndex = 4;
            this.cuentaBtn.Text = "Cuenta";
            this.cuentaBtn.UseVisualStyleBackColor = false;
            this.cuentaBtn.Click += new System.EventHandler(this.cuentaBtn_Click);
            // 
            // chatsBtn
            // 
            this.chatsBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.chatsBtn.FlatAppearance.BorderSize = 0;
            this.chatsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatsBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatsBtn.ForeColor = System.Drawing.Color.MintCream;
            this.chatsBtn.Location = new System.Drawing.Point(154, 23);
            this.chatsBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatsBtn.Name = "chatsBtn";
            this.chatsBtn.Size = new System.Drawing.Size(120, 61);
            this.chatsBtn.TabIndex = 4;
            this.chatsBtn.Text = "Crear Grupo";
            this.chatsBtn.UseVisualStyleBackColor = false;
            this.chatsBtn.Click += new System.EventHandler(this.chatsBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSalmon;
            this.label2.Location = new System.Drawing.Point(38, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chat";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_Grupos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 476);
            this.panel2.TabIndex = 1;
            // 
            // lb_Grupos
            // 
            this.lb_Grupos.BackColor = System.Drawing.Color.Gainsboro;
            this.lb_Grupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Grupos.FormattingEnabled = true;
            this.lb_Grupos.ItemHeight = 19;
            this.lb_Grupos.Location = new System.Drawing.Point(22, 48);
            this.lb_Grupos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_Grupos.Name = "lb_Grupos";
            this.lb_Grupos.Size = new System.Drawing.Size(120, 399);
            this.lb_Grupos.TabIndex = 6;
            this.lb_Grupos.SelectedValueChanged += new System.EventHandler(this.lb_Grupos_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chats";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chatViewPanel
            // 
            this.chatViewPanel.Controls.Add(this.btn_Salir);
            this.chatViewPanel.Controls.Add(this.btn_invite);
            this.chatViewPanel.Controls.Add(this.L_IsConnected);
            this.chatViewPanel.Controls.Add(this.cuentaPanel);
            this.chatViewPanel.Controls.Add(this.correoBtn);
            this.chatViewPanel.Controls.Add(this.videoBtn);
            this.chatViewPanel.Controls.Add(this.listChat);
            this.chatViewPanel.Controls.Add(this.archivoBtn);
            this.chatViewPanel.Controls.Add(this.sendBtn);
            this.chatViewPanel.Controls.Add(this.editMensaje);
            this.chatViewPanel.Controls.Add(this.l_Username);
            this.chatViewPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.chatViewPanel.Location = new System.Drawing.Point(154, 88);
            this.chatViewPanel.Name = "chatViewPanel";
            this.chatViewPanel.Size = new System.Drawing.Size(410, 476);
            this.chatViewPanel.TabIndex = 2;
            // 
            // L_IsConnected
            // 
            this.L_IsConnected.AutoSize = true;
            this.L_IsConnected.Location = new System.Drawing.Point(283, 16);
            this.L_IsConnected.Name = "L_IsConnected";
            this.L_IsConnected.Size = new System.Drawing.Size(97, 19);
            this.L_IsConnected.TabIndex = 16;
            this.L_IsConnected.Text = "Conectado";
            // 
            // cuentaPanel
            // 
            this.cuentaPanel.Controls.Add(this.textBoxMail);
            this.cuentaPanel.Controls.Add(this.textBoxPass);
            this.cuentaPanel.Controls.Add(this.label5);
            this.cuentaPanel.Controls.Add(this.label6);
            this.cuentaPanel.Controls.Add(this.textBoxUser);
            this.cuentaPanel.Controls.Add(this.label7);
            this.cuentaPanel.Controls.Add(this.editAceptarBtn);
            this.cuentaPanel.Controls.Add(this.editCancelarBtn);
            this.cuentaPanel.Controls.Add(this.editBtn);
            this.cuentaPanel.Controls.Add(this.label4);
            this.cuentaPanel.Location = new System.Drawing.Point(10, 113);
            this.cuentaPanel.Name = "cuentaPanel";
            this.cuentaPanel.Size = new System.Drawing.Size(358, 285);
            this.cuentaPanel.TabIndex = 15;
            // 
            // textBoxMail
            // 
            this.textBoxMail.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMail.Location = new System.Drawing.Point(89, 205);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(169, 19);
            this.textBoxMail.TabIndex = 18;
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPass.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.Location = new System.Drawing.Point(89, 137);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(169, 19);
            this.textBoxPass.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Usuario";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "E-mail";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.Location = new System.Drawing.Point(89, 68);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(169, 19);
            this.textBoxUser.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Contraseña";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // editAceptarBtn
            // 
            this.editAceptarBtn.BackColor = System.Drawing.Color.DarkSalmon;
            this.editAceptarBtn.FlatAppearance.BorderSize = 0;
            this.editAceptarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAceptarBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAceptarBtn.ForeColor = System.Drawing.Color.MintCream;
            this.editAceptarBtn.Location = new System.Drawing.Point(63, 249);
            this.editAceptarBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editAceptarBtn.Name = "editAceptarBtn";
            this.editAceptarBtn.Size = new System.Drawing.Size(78, 26);
            this.editAceptarBtn.TabIndex = 14;
            this.editAceptarBtn.Text = "Aceptar";
            this.editAceptarBtn.UseVisualStyleBackColor = false;
            this.editAceptarBtn.Click += new System.EventHandler(this.editAceptarBtn_Click);
            // 
            // editCancelarBtn
            // 
            this.editCancelarBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.editCancelarBtn.FlatAppearance.BorderSize = 0;
            this.editCancelarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCancelarBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCancelarBtn.ForeColor = System.Drawing.Color.MintCream;
            this.editCancelarBtn.Location = new System.Drawing.Point(184, 249);
            this.editCancelarBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editCancelarBtn.Name = "editCancelarBtn";
            this.editCancelarBtn.Size = new System.Drawing.Size(85, 26);
            this.editCancelarBtn.TabIndex = 14;
            this.editCancelarBtn.Text = "Cancelar";
            this.editCancelarBtn.UseVisualStyleBackColor = false;
            this.editCancelarBtn.Click += new System.EventHandler(this.editCancelarBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.editBtn.FlatAppearance.BorderSize = 0;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.Color.MintCream;
            this.editBtn.Location = new System.Drawing.Point(107, 9);
            this.editBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(76, 26);
            this.editBtn.TabIndex = 14;
            this.editBtn.Text = "Editar";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mi Cuenta";
            // 
            // correoBtn
            // 
            this.correoBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.correoBtn.FlatAppearance.BorderSize = 0;
            this.correoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.correoBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correoBtn.ForeColor = System.Drawing.Color.MintCream;
            this.correoBtn.Location = new System.Drawing.Point(173, 48);
            this.correoBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.correoBtn.Name = "correoBtn";
            this.correoBtn.Size = new System.Drawing.Size(74, 26);
            this.correoBtn.TabIndex = 13;
            this.correoBtn.Text = "Correo";
            this.correoBtn.UseVisualStyleBackColor = false;
            this.correoBtn.Click += new System.EventHandler(this.correoBtn_Click);
            // 
            // videoBtn
            // 
            this.videoBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.videoBtn.FlatAppearance.BorderSize = 0;
            this.videoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBtn.ForeColor = System.Drawing.Color.MintCream;
            this.videoBtn.Location = new System.Drawing.Point(256, 48);
            this.videoBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoBtn.Name = "videoBtn";
            this.videoBtn.Size = new System.Drawing.Size(124, 26);
            this.videoBtn.TabIndex = 14;
            this.videoBtn.Text = "Videollamada";
            this.videoBtn.UseVisualStyleBackColor = false;
            this.videoBtn.Click += new System.EventHandler(this.videoBtn_Click);
            // 
            // listChat
            // 
            this.listChat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listChat.FormattingEnabled = true;
            this.listChat.ItemHeight = 19;
            this.listChat.Location = new System.Drawing.Point(34, 89);
            this.listChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(346, 228);
            this.listChat.TabIndex = 11;
            // 
            // archivoBtn
            // 
            this.archivoBtn.BackColor = System.Drawing.Color.CadetBlue;
            this.archivoBtn.FlatAppearance.BorderSize = 0;
            this.archivoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.archivoBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoBtn.ForeColor = System.Drawing.Color.MintCream;
            this.archivoBtn.Location = new System.Drawing.Point(173, 417);
            this.archivoBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.archivoBtn.Name = "archivoBtn";
            this.archivoBtn.Size = new System.Drawing.Size(118, 28);
            this.archivoBtn.TabIndex = 8;
            this.archivoBtn.Text = "Archivo";
            this.archivoBtn.UseVisualStyleBackColor = false;
            this.archivoBtn.Click += new System.EventHandler(this.archivoBtn_Click_1);
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.DarkSalmon;
            this.sendBtn.FlatAppearance.BorderSize = 0;
            this.sendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.ForeColor = System.Drawing.Color.MintCream;
            this.sendBtn.Location = new System.Drawing.Point(33, 417);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(118, 28);
            this.sendBtn.TabIndex = 9;
            this.sendBtn.Text = "Enviar";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // editMensaje
            // 
            this.editMensaje.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editMensaje.Location = new System.Drawing.Point(34, 329);
            this.editMensaje.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editMensaje.Multiline = true;
            this.editMensaje.Name = "editMensaje";
            this.editMensaje.Size = new System.Drawing.Size(346, 69);
            this.editMensaje.TabIndex = 12;
            // 
            // l_Username
            // 
            this.l_Username.AutoSize = true;
            this.l_Username.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Username.Location = new System.Drawing.Point(14, 16);
            this.l_Username.Name = "l_Username";
            this.l_Username.Size = new System.Drawing.Size(137, 18);
            this.l_Username.TabIndex = 10;
            this.l_Username.Text = "NombreContacto";
            this.l_Username.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_invite
            // 
            this.btn_invite.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_invite.FlatAppearance.BorderSize = 0;
            this.btn_invite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_invite.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invite.ForeColor = System.Drawing.Color.MintCream;
            this.btn_invite.Location = new System.Drawing.Point(93, 48);
            this.btn_invite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_invite.Name = "btn_invite";
            this.btn_invite.Size = new System.Drawing.Size(74, 26);
            this.btn_invite.TabIndex = 17;
            this.btn_invite.Text = "Invitar";
            this.btn_invite.UseVisualStyleBackColor = false;
            this.btn_invite.Click += new System.EventHandler(this.btn_invite_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.CadetBlue;
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salir.ForeColor = System.Drawing.Color.MintCream;
            this.btn_Salir.Location = new System.Drawing.Point(13, 48);
            this.btn_Salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(74, 26);
            this.btn_Salir.TabIndex = 18;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(564, 564);
            this.Controls.Add(this.chatViewPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DragControl);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.DragControl.ResumeLayout(false);
            this.DragControl.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.chatViewPanel.ResumeLayout(false);
            this.chatViewPanel.PerformLayout();
            this.cuentaPanel.ResumeLayout(false);
            this.cuentaPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DragControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Button cuentaBtn;
        private System.Windows.Forms.Button chatsBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lb_Grupos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel chatViewPanel;
        private System.Windows.Forms.Button correoBtn;
        private System.Windows.Forms.Button videoBtn;
        private System.Windows.Forms.ListBox listChat;
        private System.Windows.Forms.Button archivoBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox editMensaje;
        private System.Windows.Forms.Label l_Username;
        private System.Windows.Forms.Panel cuentaPanel;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button editAceptarBtn;
        private System.Windows.Forms.Button editCancelarBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label L_IsConnected;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_invite;
    }
}