using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(424, 515);
            this.MaximumSize = new System.Drawing.Size(424, 515);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UsernameBox.TabStop = false;
            Passwordbox.TabStop = false;
            Emailbox.TabStop = false;
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register RegisterPage = new Register();
            RegisterPage.ShowDialog();
            if (RegisterPage.fclose == 1)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
        private void UsernameBox_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "Username")
            {
                UsernameBox.Text = "";
            }
            UsernameBox.ForeColor = Color.Black;
        }
        private void Passwordbox_Click(object sender, EventArgs e)
        {
            if (Passwordbox.Text == "Password")
            {
                Passwordbox.Text = "";
            }
            Passwordbox.ForeColor = Color.Black;
        }
        private void Emailbox_Click(object sender, EventArgs e)
        {
            if (Emailbox.Text == "Email")
            {
                Emailbox.Text = "";
            }
            Emailbox.ForeColor = Color.Black;
        }

        private void Passwordbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Passwordbox.Text))
            {
                Passwordbox.ForeColor = Color.Gray;
                Passwordbox.Text = "Password";
            }
        }

        private void UsernameBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameBox.Text))
            {
                UsernameBox.ForeColor = Color.Gray;
                UsernameBox.Text = "Username";
            }
        }

        private void Emailbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Emailbox.Text))
            {
                Emailbox.ForeColor = Color.Gray;
                Emailbox.Text = "Email";
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
        }
        private void Passwordbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void PasscheckIcon_Click(object sender, EventArgs e)
        {
            if (Passwordbox.PasswordChar != '\0')
            {
                Passwordbox.PasswordChar = '\0';
                PasscheckIcon.Image = Properties.Resources.eye;
            }
            else
            {
                Passwordbox.PasswordChar = '*';
                PasscheckIcon.Image = Properties.Resources.hide;
            }
        }
    }
}

