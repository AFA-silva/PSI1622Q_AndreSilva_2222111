using Dionisios.DionisiosDBDataSetTableAdapters;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dionisios
{
    public partial class AdminPage : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        public int Adminclose { get; set; }

        public AdminPage()
        {
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
                string userRole = UsersGridView.Rows[e.RowIndex].Cells["RoleCol"].Value.ToString();
                RoleCombo.Text = userRole;
            }
        }
        private void AtualizarPapelUsuario(int userId, string newRole)
        {
            if(userId != Form1.LoggedInUserId)
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersGridView.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["IDcol"].Value);
                string newRole = RoleCombo.Text;
                AtualizarPapelUsuario(userId, newRole);
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
            UsersGridView.Visible = true;
            btnSave.Visible = true;
            RoleCombo.Visible = true;
            LabelRole.Visible = true;
            UsersGridView.ClearSelection();
        }
        private void VisibiltyChanger()
        {
            UsersGridView.Visible = false;
            btnSave.Visible = false;
            RoleCombo.Visible = false;
            LabelRole.Visible = false;
        }
    }
}
