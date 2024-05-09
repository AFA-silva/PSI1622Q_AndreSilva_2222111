namespace Dionisios
{
    partial class Register
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
            this.Emailbox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.Passwordbox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.BIbox = new System.Windows.Forms.TextBox();
            this.PasscheckIcon = new System.Windows.Forms.PictureBox();
            this.BIicon = new System.Windows.Forms.PictureBox();
            this.EmailIcon = new System.Windows.Forms.PictureBox();
            this.UserIcon = new System.Windows.Forms.PictureBox();
            this.PassIcon = new System.Windows.Forms.PictureBox();
            this.LogoIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PasscheckIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BIicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // Emailbox
            // 
            this.Emailbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emailbox.ForeColor = System.Drawing.Color.Gray;
            this.Emailbox.Location = new System.Drawing.Point(108, 263);
            this.Emailbox.Name = "Emailbox";
            this.Emailbox.Size = new System.Drawing.Size(218, 29);
            this.Emailbox.TabIndex = 17;
            this.Emailbox.Text = "Email";
            this.Emailbox.Click += new System.EventHandler(this.Emailbox_Click);
            this.Emailbox.Leave += new System.EventHandler(this.Emailbox_Leave);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.LoginLabel.Location = new System.Drawing.Point(105, 423);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(203, 18);
            this.LoginLabel.TabIndex = 16;
            this.LoginLabel.Text = "Have an account? Click Here!";
            this.LoginLabel.Click += new System.EventHandler(this.LoginLabel_Click);
            // 
            // BtnRegister
            // 
            this.BtnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BtnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.BtnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.BtnRegister.Location = new System.Drawing.Point(137, 366);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(145, 54);
            this.BtnRegister.TabIndex = 15;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.UseVisualStyleBackColor = false;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // Passwordbox
            // 
            this.Passwordbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordbox.ForeColor = System.Drawing.Color.Gray;
            this.Passwordbox.Location = new System.Drawing.Point(108, 217);
            this.Passwordbox.Name = "Passwordbox";
            this.Passwordbox.PasswordChar = '*';
            this.Passwordbox.Size = new System.Drawing.Size(218, 29);
            this.Passwordbox.TabIndex = 12;
            this.Passwordbox.Text = "Password";
            this.Passwordbox.Click += new System.EventHandler(this.Passwordbox_Click);
            this.Passwordbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Passwordbox_KeyPress);
            this.Passwordbox.Leave += new System.EventHandler(this.Passwordbox_Leave);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.ForeColor = System.Drawing.Color.Gray;
            this.UsernameBox.Location = new System.Drawing.Point(108, 168);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(218, 29);
            this.UsernameBox.TabIndex = 11;
            this.UsernameBox.Text = "Username";
            this.UsernameBox.Click += new System.EventHandler(this.UsernameBox_Click);
            this.UsernameBox.Leave += new System.EventHandler(this.UsernameBox_Leave);
            // 
            // BIbox
            // 
            this.BIbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIbox.ForeColor = System.Drawing.Color.Gray;
            this.BIbox.Location = new System.Drawing.Point(108, 312);
            this.BIbox.Name = "BIbox";
            this.BIbox.Size = new System.Drawing.Size(218, 29);
            this.BIbox.TabIndex = 19;
            this.BIbox.Text = "BI";
            this.BIbox.Click += new System.EventHandler(this.BIbox_Click);
            this.BIbox.Leave += new System.EventHandler(this.BIbox_Leave);
            // 
            // PasscheckIcon
            // 
            this.PasscheckIcon.Image = global::Dionisios.Properties.Resources.hide;
            this.PasscheckIcon.Location = new System.Drawing.Point(332, 217);
            this.PasscheckIcon.Name = "PasscheckIcon";
            this.PasscheckIcon.Size = new System.Drawing.Size(37, 28);
            this.PasscheckIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasscheckIcon.TabIndex = 21;
            this.PasscheckIcon.TabStop = false;
            this.PasscheckIcon.Click += new System.EventHandler(this.PasscheckIcon_Click);
            // 
            // BIicon
            // 
            this.BIicon.Image = global::Dionisios.Properties.Resources._88591_removebg_preview;
            this.BIicon.Location = new System.Drawing.Point(55, 306);
            this.BIicon.Name = "BIicon";
            this.BIicon.Size = new System.Drawing.Size(36, 35);
            this.BIicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BIicon.TabIndex = 20;
            this.BIicon.TabStop = false;
            // 
            // EmailIcon
            // 
            this.EmailIcon.Image = global::Dionisios.Properties.Resources.kisspng_computer_icons_stock_photography_email_clip_art_simblo_5b4faed2d78991_2976490215319487548829_removebg_preview;
            this.EmailIcon.Location = new System.Drawing.Point(55, 257);
            this.EmailIcon.Name = "EmailIcon";
            this.EmailIcon.Size = new System.Drawing.Size(36, 35);
            this.EmailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EmailIcon.TabIndex = 18;
            this.EmailIcon.TabStop = false;
            // 
            // UserIcon
            // 
            this.UserIcon.Image = global::Dionisios.Properties.Resources.a_removebg_preview;
            this.UserIcon.Location = new System.Drawing.Point(53, 163);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new System.Drawing.Size(49, 39);
            this.UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserIcon.TabIndex = 14;
            this.UserIcon.TabStop = false;
            // 
            // PassIcon
            // 
            this.PassIcon.Image = global::Dionisios.Properties.Resources._9999e0ae7aa424f5fa5c319433b229ed_removebg_preview;
            this.PassIcon.Location = new System.Drawing.Point(45, 210);
            this.PassIcon.Name = "PassIcon";
            this.PassIcon.Size = new System.Drawing.Size(63, 35);
            this.PassIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PassIcon.TabIndex = 13;
            this.PassIcon.TabStop = false;
            // 
            // LogoIcon
            // 
            this.LogoIcon.Image = global::Dionisios.Properties.Resources.Dionisios_removebg_preview;
            this.LogoIcon.Location = new System.Drawing.Point(64, -20);
            this.LogoIcon.Name = "LogoIcon";
            this.LogoIcon.Size = new System.Drawing.Size(277, 177);
            this.LogoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoIcon.TabIndex = 10;
            this.LogoIcon.TabStop = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(408, 476);
            this.Controls.Add(this.PasscheckIcon);
            this.Controls.Add(this.BIicon);
            this.Controls.Add(this.BIbox);
            this.Controls.Add(this.EmailIcon);
            this.Controls.Add(this.Emailbox);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.UserIcon);
            this.Controls.Add(this.PassIcon);
            this.Controls.Add(this.Passwordbox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.LogoIcon);
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PasscheckIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BIicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EmailIcon;
        private System.Windows.Forms.TextBox Emailbox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.PictureBox UserIcon;
        private System.Windows.Forms.PictureBox PassIcon;
        private System.Windows.Forms.TextBox Passwordbox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.PictureBox LogoIcon;
        private System.Windows.Forms.TextBox BIbox;
        private System.Windows.Forms.PictureBox BIicon;
        private System.Windows.Forms.PictureBox PasscheckIcon;
    }
}