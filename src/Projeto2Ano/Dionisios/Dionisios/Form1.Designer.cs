namespace Dionisios
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BIbox = new System.Windows.Forms.TextBox();
            this.Passwordbox = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.Emailbox = new System.Windows.Forms.TextBox();
            this.PasscheckIcon = new System.Windows.Forms.PictureBox();
            this.EmailIcon = new System.Windows.Forms.PictureBox();
            this.UserIcon = new System.Windows.Forms.PictureBox();
            this.PassIcon = new System.Windows.Forms.PictureBox();
            this.LogoIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PasscheckIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // BIbox
            // 
            this.BIbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIbox.ForeColor = System.Drawing.Color.Gray;
            this.BIbox.Location = new System.Drawing.Point(108, 168);
            this.BIbox.MaxLength = 8;
            this.BIbox.Name = "BIbox";
            this.BIbox.Size = new System.Drawing.Size(218, 29);
            this.BIbox.TabIndex = 1;
            this.BIbox.Text = "BI";
            this.BIbox.Click += new System.EventHandler(this.BIBox_Click);
            this.BIbox.Leave += new System.EventHandler(this.BIBox_Leave);
            // 
            // Passwordbox
            // 
            this.Passwordbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordbox.ForeColor = System.Drawing.Color.Gray;
            this.Passwordbox.Location = new System.Drawing.Point(108, 214);
            this.Passwordbox.Name = "Passwordbox";
            this.Passwordbox.PasswordChar = '*';
            this.Passwordbox.Size = new System.Drawing.Size(218, 29);
            this.Passwordbox.TabIndex = 2;
            this.Passwordbox.Text = "Password";
            this.Passwordbox.Click += new System.EventHandler(this.Passwordbox_Click);
            this.Passwordbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Passwordbox_KeyPress);
            this.Passwordbox.Leave += new System.EventHandler(this.Passwordbox_Leave);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.BtnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.BtnLogin.Location = new System.Drawing.Point(133, 317);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(145, 54);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.RegisterLabel.Location = new System.Drawing.Point(82, 374);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(236, 18);
            this.RegisterLabel.TabIndex = 7;
            this.RegisterLabel.Text = "Dont have an account? Click Here!";
            this.RegisterLabel.Click += new System.EventHandler(this.RegisterLabel_Click);
            // 
            // Emailbox
            // 
            this.Emailbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emailbox.ForeColor = System.Drawing.Color.Gray;
            this.Emailbox.Location = new System.Drawing.Point(108, 263);
            this.Emailbox.Name = "Emailbox";
            this.Emailbox.Size = new System.Drawing.Size(218, 29);
            this.Emailbox.TabIndex = 8;
            this.Emailbox.Text = "Email";
            this.Emailbox.Click += new System.EventHandler(this.Emailbox_Click);
            this.Emailbox.Leave += new System.EventHandler(this.Emailbox_Leave);
            // 
            // PasscheckIcon
            // 
            this.PasscheckIcon.Image = global::Dionisios.Properties.Resources.olhoA;
            this.PasscheckIcon.Location = new System.Drawing.Point(314, 188);
            this.PasscheckIcon.Name = "PasscheckIcon";
            this.PasscheckIcon.Size = new System.Drawing.Size(91, 82);
            this.PasscheckIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasscheckIcon.TabIndex = 22;
            this.PasscheckIcon.TabStop = false;
            this.PasscheckIcon.Click += new System.EventHandler(this.PasscheckIcon_Click);
            // 
            // EmailIcon
            // 
            this.EmailIcon.Image = global::Dionisios.Properties.Resources.image_removebg_preview__5_;
            this.EmailIcon.Location = new System.Drawing.Point(45, 239);
            this.EmailIcon.Name = "EmailIcon";
            this.EmailIcon.Size = new System.Drawing.Size(65, 66);
            this.EmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmailIcon.TabIndex = 9;
            this.EmailIcon.TabStop = false;
            // 
            // UserIcon
            // 
            this.UserIcon.Image = global::Dionisios.Properties.Resources.a_removebg_preview;
            this.UserIcon.Location = new System.Drawing.Point(53, 163);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new System.Drawing.Size(49, 39);
            this.UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserIcon.TabIndex = 5;
            this.UserIcon.TabStop = false;
            // 
            // PassIcon
            // 
            this.PassIcon.Image = global::Dionisios.Properties.Resources._9999e0ae7aa424f5fa5c319433b229ed_removebg_preview;
            this.PassIcon.Location = new System.Drawing.Point(45, 210);
            this.PassIcon.Name = "PassIcon";
            this.PassIcon.Size = new System.Drawing.Size(63, 35);
            this.PassIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PassIcon.TabIndex = 4;
            this.PassIcon.TabStop = false;
            // 
            // LogoIcon
            // 
            this.LogoIcon.Image = global::Dionisios.Properties.Resources.Dionisios_removebg_preview;
            this.LogoIcon.Location = new System.Drawing.Point(64, -20);
            this.LogoIcon.Name = "LogoIcon";
            this.LogoIcon.Size = new System.Drawing.Size(277, 177);
            this.LogoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoIcon.TabIndex = 0;
            this.LogoIcon.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(408, 476);
            this.Controls.Add(this.Emailbox);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.UserIcon);
            this.Controls.Add(this.PassIcon);
            this.Controls.Add(this.Passwordbox);
            this.Controls.Add(this.BIbox);
            this.Controls.Add(this.LogoIcon);
            this.Controls.Add(this.EmailIcon);
            this.Controls.Add(this.PasscheckIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PasscheckIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoIcon;
        private System.Windows.Forms.TextBox BIbox;
        private System.Windows.Forms.TextBox Passwordbox;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.TextBox Emailbox;
        private System.Windows.Forms.PictureBox PasscheckIcon;
        private System.Windows.Forms.PictureBox EmailIcon;
        private System.Windows.Forms.PictureBox PassIcon;
        private System.Windows.Forms.PictureBox UserIcon;
    }
}

