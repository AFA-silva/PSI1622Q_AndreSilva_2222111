using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        public static string UserRole;
        public static int LoggedInUserId { get; private set; }
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
            Hide();
            Register RegisterPage = new Register();
            RegisterPage.ShowDialog();
            if (RegisterPage.Registerclose == 1)
                Show();
            else
                Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(BIbox.Text) || BIbox.Text == "BI" ||
                string.IsNullOrWhiteSpace(Passwordbox.Text) || Passwordbox.Text == "Password" ||
                string.IsNullOrWhiteSpace(Emailbox.Text) || Emailbox.Text == "Email")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Tenta realizar o login
            if (ConfirmLogin())
            {
                Hide();
                ManagerPage managerPage = new ManagerPage();
                managerPage.ShowDialog();
                if (managerPage.Managerclose == 1)
                    Show();
                else
                    Close();
            }
        }

        // Método para confirmar o login
        private bool ConfirmLogin()
        {
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
                            string storedEmail = reader["Email"].ToString();
                            if (storedPassword == Passwordbox.Text && storedEmail == Emailbox.Text)
                            {
                                UserRole = reader["Role"].ToString();
                                LoggedInUserId = Convert.ToInt32(reader["ID"]);
                                MessageBox.Show("Login Successful!");
                                return true;
                            }
                        }
                        MessageBox.Show("Wrong Email/BI or Password! Try again.");
                    }
                    else
                    {
                        MessageBox.Show("BI not found! Try another.");
                    }
                }
            }
            return false;
        }

        private void BIBox_Click(object sender, EventArgs e)
        {
            if (BIbox.Text == "BI")
            {
                BIbox.Text = "";
            }
            BIbox.ForeColor = Color.Black;
        }

        private void BIBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BIbox.Text))
            {
                BIbox.ForeColor = Color.Gray;
                BIbox.Text = "BI";
            }
        }

        // Eventos de interação com o campo de texto Password
        private void Passwordbox_Click(object sender, EventArgs e)
        {
            if (Passwordbox.Text == "Password")
            {
                Passwordbox.Text = "";
            }
            Passwordbox.ForeColor = Color.Black;
        }

        private void Passwordbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Passwordbox.Text))
            {
                Passwordbox.ForeColor = Color.Gray;
                Passwordbox.Text = "Password";
            }
        }

        // Eventos de interação com o campo de texto Email
        private void Emailbox_Click(object sender, EventArgs e)
        {
            if (Emailbox.Text == "Email")
            {
                Emailbox.Text = "";
            }
            Emailbox.ForeColor = Color.Black;
        }

        private void Emailbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Emailbox.Text))
            {
                Emailbox.ForeColor = Color.Gray;
                Emailbox.Text = "Email";
            }
        }

        private void Passwordbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        // Evento para exibir/ocultar a senha
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
    }
}
