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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dionisios
{
    public partial class Register : Form
    {
        bool validationV;
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        public int Registerclose { get; set; }
        public Register()
        {
            Registerclose = 0;
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(424, 515);
            this.MaximumSize = new System.Drawing.Size(424, 515);
        }
        private void Register_Load(object sender, EventArgs e)
        {
            UsernameBox.TabStop = false;
            Passwordbox.TabStop = false;
            Emailbox.TabStop = false;
            BIbox.TabStop = false;
        }
        private void LoginLabel_Click(object sender, EventArgs e)
        {
            Registerclose = 1;
            this.Close();
        }
        private void BIbox_Click(object sender, EventArgs e)
        {
            if (BIbox.Text == "BI")
            {
                BIbox.Text = "";
            }
            BIbox.ForeColor = Color.Black;
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

        // Eventos de saída dos campos de texto para restaurar o texto padrão se estiver vazio
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

        private void BIbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BIbox.Text))
            {
                BIbox.ForeColor = Color.Gray;
                BIbox.Text = "BI";
            }
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            Validations();
            if (validationV == true) { return; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserAccount (Username, Password, Role, Email, BI) VALUES (@Username, @Password, @Role, @Email, @BI)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", UsernameBox.Text);
                    command.Parameters.AddWithValue("@Password", Passwordbox.Text);
                    command.Parameters.AddWithValue("@Role", "EMPLOYEE");
                    command.Parameters.AddWithValue("@Email", Emailbox.Text);
                    command.Parameters.AddWithValue("@BI", BIbox.Text);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Registro inserido com sucesso!");
                        Registerclose = 1;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao inserir o registro: " + ex.Message);
                    }
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

        // Método para validar o formato do email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Método para validar os dados de entrada
        private void Validations()
        {
            validationV = false;
            // Verifica se todos os campos estão preenchidos corretamente
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || string.IsNullOrWhiteSpace(Passwordbox.Text)
                || string.IsNullOrWhiteSpace(Emailbox.Text) || string.IsNullOrWhiteSpace(BIbox.Text) ||
                UsernameBox.Text == "Username" || Passwordbox.Text == "Password" || Emailbox.Text == "Email" || BIbox.Text == "BI")
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                validationV = true;
                return;
            }
            // Verifica se o BI tem 8 dígitos
            if (BIbox.TextLength != 8)
            {
                MessageBox.Show("Seu BI deve conter 8 números!\nVerifique seu BI");
                validationV = true;
                return;
            }
            // Verifica se o BI contém apenas números
            foreach (char c in BIbox.Text)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Seu BI deve conter apenas números!\nVerifique seu BI");
                    validationV = true;
                    return;
                }
            }
            // Verifica se o email é válido
            if (!IsValidEmail(Emailbox.Text))
            {
                MessageBox.Show("Email inválido!\nPor favor, verifique seu email");
                validationV = true;
                return;
            }

            // Verifica se o BI já está registrado no banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM UserAccount WHERE BI = @BI";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BI", BIbox.Text);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Este BI já está registrado!\n");
                        validationV = true;
                        return;
                    }
                }
            }
            // Verifica se o email já está registrado no banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM UserAccount WHERE EMAIL = @EMAIL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EMAIL", Emailbox.Text);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Este email já está registrado!\nTente outro.");
                        validationV = true;
                        return;
                    }
                }
            }
        }
    }
}
