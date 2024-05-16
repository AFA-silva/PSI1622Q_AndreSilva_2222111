using Dionisios.DionisiosDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dionisios
{
    public partial class AdminPage : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        public int Adminclose { get; set; }
        public bool ValidationV { get; set; }

        public AdminPage()
        {
            ValidationV = true;
            InitializeComponent();
            VisibiltyChanger();
            Adminclose = 0;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            Adminclose = 1;
            this.Close();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            this.userAccountTableAdapter.Fill(this.dionisiosDBDataSet.UserAccount);
        }
        private void UserGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UsersGridView.Rows[e.RowIndex].Selected = true;
                RoleCombo.Text = UsersGridView.Rows[e.RowIndex].Cells["RoleCol"].Value.ToString();
                UsernameBox.Text = UsersGridView.Rows[e.RowIndex].Cells["UsernameCol"].Value.ToString();
                BIbox.Text = UsersGridView.Rows[e.RowIndex].Cells["BICol"].Value.ToString();
                EmailBox.Text = UsersGridView.Rows[e.RowIndex].Cells["EmailCol"].Value.ToString();
                PasswordBox.Text = UsersGridView.Rows[e.RowIndex].Cells["PasswordCol"].Value.ToString();
            }
        }
        private void RoleUpdate(int userId, string newRole)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UserAccount SET Role = @NewRole WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewRole", newRole);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can`t change your own informations!");
            }
        }
        private void BIUpdate(int userId, string biN)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UserAccount SET BI = @NewBI WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewBI", biN);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can't change your own information!");
            }
        }

        private void PasswordUpdate(int userId, string passwordN)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UserAccount SET Password = @NewPassword WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewPassword", passwordN);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can't change your own information!");
            }
        }

        private void EmailUpdate(int userId, string emailN)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UserAccount SET Email = @NewEmail WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewEmail", emailN);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can't change your own information!");
            }
        }
        private void UsernameUpdate(int userId, string usernameN)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE UserAccount SET Username = @NewUsername WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewUsername", usernameN);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can`t change your own informations!");
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersGridView.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["IDcol"].Value);
                string newRole = RoleCombo.Text;
                string newUser = UsernameBox.Text;
                string newEmail = EmailBox.Text;
                string newPassword = PasswordBox.Text;
                string newBI = BIbox.Text;
                ValidationV = true;
                IsValidBI(newBI);
                IsValidEmail(newEmail);
                if (ValidationV == false)
                {
                    clearbox();
                    return;
                }
                UsernameUpdate(userId, newUser);
                BIUpdate(userId, newBI);
                EmailUpdate(userId, newEmail);
                PasswordUpdate(userId, newPassword);
                if (newRole == "ADMIN")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change this user to admin?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        RoleCombo.SelectedIndex = -1;
                        return;
                    }
                }
                RoleUpdate(userId, newRole);
                clearbox();
                RefreshGridView();
                UsersGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show("Select a user from the Table!");
            }
        }

        private void RefreshGridView()
        {
            UsersGridView.DataSource = null;
            this.userAccountTableAdapter.Fill(this.dionisiosDBDataSet.UserAccount);
            UsersGridView.DataSource = this.dionisiosDBDataSet.UserAccount;
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            BackgroundSquare1.Visible = true;
            BackgroundSquare2.Visible = true;
            UsersGridView.Visible = true;
            btnSave.Visible = true;
            RoleCombo.Visible = true;
            LabelRole.Visible = true;
            LabelPassword.Visible = true;
            LabelBI.Visible = true;
            LabelUsername.Visible = true;
            LabelEmail.Visible = true;
            UsernameBox.Visible = true;
            EmailBox.Visible = true;
            PasswordBox.Visible = true;
            BIbox.Visible = true;
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            UsersGridView.ClearSelection();
        }
        private void VisibiltyChanger()
        {
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            UsernameBox.Visible = false;
            EmailBox.Visible = false;
            PasswordBox.Visible = false;
            BIbox.Visible = false;
            BackgroundSquare1.Visible = false;
            BackgroundSquare2.Visible = false;
            UsersGridView.Visible = false;
            btnSave.Visible = false;
            RoleCombo.Visible = false;
            LabelRole.Visible = false;
            LabelPassword.Visible = false;
            LabelBI.Visible = false;
            LabelUsername.Visible = false;
            LabelEmail.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersGridView.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["IDcol"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteUser(userId);
                    RefreshGridView();
                    UsersGridView.ClearSelection();
                    clearbox();
                }
            }
        }
        private void DeleteUser(int userId)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM UserAccount WHERE ID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("You can't delete your own account!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text != "" && EmailBox.Text != "" && PasswordBox.Text != "" && BIbox.Text != "" && RoleCombo.Text != "")
            {
                AddUser();
                RefreshGridView();
                UsersGridView.ClearSelection();
                clearbox();
                MessageBox.Show("User added successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void AddUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserAccount (Username, Email, Password, BI, Role) VALUES (@Username, @Email, @Password, @BI, @Role)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", UsernameBox.Text);
                command.Parameters.AddWithValue("@Email", EmailBox.Text);
                command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                command.Parameters.AddWithValue("@BI", BIbox.Text);
                command.Parameters.AddWithValue("@Role", RoleCombo.Text);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Invalid email address");
                ValidationV = false;
                return ValidationV;
            }
        }
        private void IsValidBI(string bi)
        {
            foreach (char c in bi)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("BI must contain only numbers");
                    ValidationV = false;
                    return;
                }
            }
            if (bi.Length != 8)
            {
                MessageBox.Show("BI must contain 8 numbers");
                ValidationV = false;
                return;
            }
        }

        private void clearbox()
        {
            UsernameBox.Text = "";
            EmailBox.Text = "";
            PasswordBox.Text = "";
            BIbox.Text = "";
            RoleCombo.SelectedIndex = -1;
        }
    }
}
