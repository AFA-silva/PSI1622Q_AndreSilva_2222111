using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Dionisios
{
    public partial class Form1 : Form
    {
        bool validationV;
        string role;
        public static int LoggedInUserId { get; set; }
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(424, 515);
            this.MaximumSize = new System.Drawing.Size(424, 515);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BIbox.TabStop = false;
            Passwordbox.TabStop = false;
            Emailbox.TabStop = false;
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register RegisterPage = new Register();
            RegisterPage.ShowDialog();
            if (RegisterPage.Registerclose == 1)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
        private void BIBox_Click(object sender, EventArgs e)
        {
            if (BIbox.Text == "BI")
            {
                BIbox.Text = "";
            }
            BIbox.ForeColor = Color.Black;
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

        private void BIBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BIbox.Text))
            {
                BIbox.ForeColor = Color.Gray;
                BIbox.Text = "BI";
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
            ConfirmLogin();
            if(role == "ADMIN")
            {
                this.Hide();
                AdminPage adminpage = new AdminPage();
                adminpage.ShowDialog();
                if (adminpage.Adminclose == 1)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            if (role == "EMPLOYEE")
            {
                this.Hide();
                EmployeePage employeepage = new EmployeePage();
                employeepage.ShowDialog();
                if (employeepage.EmployeeClose == 1)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            if (role == "MANAGER")
            {
                this.Hide();
                ManagerPage managerPage = new ManagerPage();
                managerPage.ShowDialog();
                if (managerPage.Managerclose == 1)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
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
                PasscheckIcon.Image = Properties.Resources.olhoF;
            }
            else
            {
                Passwordbox.PasswordChar = '*';
                PasscheckIcon.Image = Properties.Resources.olhoA;
            }
        }
        private void ConfirmLogin()
        {
            validationV = false;
            bool biFound = false;
            int v1 = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string biQuery = "SELECT * FROM UserAccount WHERE BI = @BI";
                using (SqlCommand command = new SqlCommand(biQuery, connection))
                {
                    command.Parameters.AddWithValue("@BI", BIbox.Text);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString();
                            if (storedPassword == Passwordbox.Text)
                            {
                                v1++;
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password! Try Again.");
                                role = "";
                                return;
                            }
                            string storedEmail = reader["Email"].ToString();
                            if (storedEmail == Emailbox.Text)
                            {
                                v1++;
                                role = reader["Role"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Email/BI! Try again.");
                                role = "";
                                return;
                            }
                            LoggedInUserId = Convert.ToInt32(reader["ID"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("BI not found! Try another.");
                        role = "";
                        return;
                    }
                }
            }
            if (v1==2)
            {
                MessageBox.Show("Login Successful!");
            }
        }
    }
}

