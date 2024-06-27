using Dionisios.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class ManagerPage : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        private Image selectedImage;
        public int IDing, IDdrink;
        private int ingId;
        private int drinkId;
        public bool ValidationV { get; set; }
        public int Managerclose { get; set; }
        private string currentImageHash;

        public ManagerPage()
        {
            Managerclose = 0;
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(725, 479);
            this.MaximumSize = new System.Drawing.Size(725, 479);
        }

        private void ManagerPage_Load(object sender, EventArgs e)
        {
            this.userAccountTableAdapter.Fill(this.dionisiosDBDataSet.UserAccount);
            this.drinksInfoTableAdapter.Fill(this.dionisiosDBDataSet.DrinksInfo);
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
            if (selectedImage != null)
            {
                DrinkImageBox.Image = selectedImage;
            }
            if (Form1.UserRole == "EMPLOYEE")
            {
                AddBtn.Location = new Point(356, 235);
                RemoverBtn.Location = new Point(356, 262);
                FinishBtn.Location = new Point(356, 289);
                QtdBox.Location = new Point(356, 316);
                DIrichbox.Location = new Point(356, 346);
                DIpicture.Location = new Point(437, 235);
                DrinksIngredientsGrid.Location = new Point(356, 54);
                TabEmployees.Visible = true;
                this.MinimumSize = new System.Drawing.Size(585, 479);
                this.MaximumSize = new System.Drawing.Size(585, 479);
            }
        }

        // Stock Menu Code -----------------------------------------------------------------------------------------------------------------------

        private void IngredientAddBtn_Click(object sender, EventArgs e)
        {
            if (IngNameBox.Text != "" && IngUnitBox.Text != "" && selectedImage != null)
            {
                AddIngredient();
                RefreshGridView();
                ClearForm();
                MessageBox.Show("Ingredient added successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void AddIngredient()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO IngredientsInfo (Name, Unit, QuantityStock, Image, Description, Price) VALUES (@Name, @Unit, @Quantity, @Image, @Description, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);
                float quantity;
                float price;
                if (float.TryParse(IngQuantityBox.Text, out quantity) && float.TryParse(IngPriceBox.Text, out price))
                {
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                }
                else
                {
                    MessageBox.Show("Please enter a valid floating point number for the quantity/price.");
                    return;
                }

                byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Save as PNG
                command.Parameters.AddWithValue("@Image", imageData);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void RefreshGridView()
        {
            UsersGridView.DataSource = null;
            this.userAccountTableAdapter.Fill(this.dionisiosDBDataSet.UserAccount);
            UsersGridView.DataSource = this.dionisiosDBDataSet.UserAccount;
            IngredientGridView.DataSource = null;
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
            IngredientGridView.DataSource = this.dionisiosDBDataSet.IngredientsInfo;
        }

        private void NewIngImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecione uma imagem";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImage = new Bitmap(openFileDialog.FileName);
                    IngImageBox.Image = selectedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao carregar a imagem: " + ex.Message);
                }
            }
        }

        private void IngredientGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = IngredientGridView.Rows[e.RowIndex];
                ingId = Convert.ToInt32(row.Cells["ColID"].Value);
                IngNameBox.Text = row.Cells["ColName"].Value.ToString();
                IngDescriptionBox.Text = row.Cells["ColDescription"].Value.ToString();
                IngUnitBox.Text = row.Cells["ColUnit"].Value.ToString();
                IngQuantityBox.Text = row.Cells["ColQuantityStock"].Value.ToString();
                IngPriceBox.Text = row.Cells["ColPrice"].Value.ToString();
                if (row.Cells["ColImage"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["ColImage"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        selectedImage = Image.FromStream(stream);
                        IngImageBox.Image = selectedImage;
                        currentImageHash = GetImageHash(selectedImage);
                    }
                }
                else
                {
                    IngImageBox.Image = null;
                    currentImageHash = null;
                }
            }
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 1;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Managerclose = 1;
            this.Close();
        }

        private void UpdateIngBtn_Click(object sender, EventArgs e)
        {
            if (IngNameBox.Text != "" && IngUnitBox.Text != "" && IngQuantityBox.Text != "")
            {
                UpdateIngredient();
                RefreshGridView();
                ClearForm();
                MessageBox.Show("Ingredient updated successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void BtnDeleteIng_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Delete Ingredient", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM IngredientsInfo WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", ingId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ingredient deleted successfully!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting ingredient: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                RefreshGridView();
                ClearForm();
            }
        }

        private void UpdateIngredient()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Base query without the image
                string query = "UPDATE IngredientsInfo SET Name = @Name, Unit = @Unit, QuantityStock = @Quantity, Description = @Description, Price = @Price";
                // Check if the image was changed
                if (selectedImage != null)
                {
                    string newImageHash = GetImageHash(selectedImage);
                    if (newImageHash != currentImageHash)
                    {
                        query += ", Image = @Image";
                    }
                }
                query += " WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                command.Parameters.AddWithValue("@Quantity", int.Parse(IngQuantityBox.Text));
                command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);
                command.Parameters.AddWithValue("@Price", float.Parse(IngPriceBox.Text)); // Ensure that price is updated

                // Only add the image parameter if the image was changed
                if (selectedImage != null)
                {
                    string newImageHash = GetImageHash(selectedImage);
                    if (newImageHash != currentImageHash)
                    {
                        byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Save as PNG
                        command.Parameters.AddWithValue("@Image", imageData);
                    }
                }

                command.Parameters.AddWithValue("@Id", ingId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void ClearForm()
        {
            IngNameBox.Text = "";
            IngDescriptionBox.Text = "";
            IngUnitBox.Text = "";
            IngQuantityBox.Text = "";
            IngPriceBox.Text = "";
            IngImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
            selectedImage = null;
            currentImageHash = null;
        }

        private string GetImageHash(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(stream.ToArray());
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }

        private byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }








        // Drinks Menu Code -------------------------------------------------------------------------------------------------------------------------
                








        private void btnDrinks_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 2;
        }
        private void AddDrinkBtn_Click(object sender, EventArgs e)
        {
            if (DrinkNameBox.Text != "" && DrinkPriceBox.Text != "" && selectedImage != null)
            {
                AddDrink();
                RefreshDrinkGridView();
                ClearDrinkForm();
                MessageBox.Show("Drink added successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void AddDrink()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DrinksInfo (Name, Price, Image) VALUES (@Name, @Price, @Image)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", DrinkNameBox.Text);
                float price;
                if (float.TryParse(DrinkPriceBox.Text, out price))
                {
                    command.Parameters.AddWithValue("@Price", price);
                }
                else
                {
                    MessageBox.Show("Please enter a valid floating point number for the price.");
                    return;
                }

                byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Save as PNG
                command.Parameters.AddWithValue("@Image", imageData);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void RefreshDrinkGridView()
        {
            DrinkGridView.DataSource = null;
            this.drinksInfoTableAdapter.Fill(this.dionisiosDBDataSet.DrinksInfo);
            DrinkGridView.DataSource = this.dionisiosDBDataSet.DrinksInfo;
        }
        private void UpdateDrinkBtn_Click(object sender, EventArgs e)
        {
            if (DrinkNameBox.Text != "" && DrinkPriceBox.Text != "")
            {
                UpdateDrink();
                RefreshDrinkGridView();
                ClearDrinkForm();
                MessageBox.Show("Drink updated successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void UpdateDrink()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Base query without the image
                string query = "UPDATE DrinksInfo SET Name = @Name, Price = @Price";
                // Check if the image was changed
                if (selectedImage != null)
                {
                    query += ", Image = @Image";
                }
                query += " WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", DrinkNameBox.Text);
                command.Parameters.AddWithValue("@Price", float.Parse(DrinkPriceBox.Text)); // Ensure that price is updated

                // Only add the image parameter if the image was changed
                if (selectedImage != null)
                {
                    byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Save as PNG
                    command.Parameters.AddWithValue("@Image", imageData);
                }

                command.Parameters.AddWithValue("@Id", drinkId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void DeleteDrinkBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Delete Drink", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string deleteAssociationsQuery = "DELETE FROM DrinksIngredients WHERE ID_Drinks = @ID_Drinks";
                        SqlCommand deleteAssociationsCommand = new SqlCommand(deleteAssociationsQuery, connection);
                        deleteAssociationsCommand.Parameters.AddWithValue("@ID_Drinks", drinkId);
                        deleteAssociationsCommand.ExecuteNonQuery();

                        string deleteDrinkQuery = "DELETE FROM DrinksInfo WHERE Id = @Id";
                        SqlCommand deleteDrinkCommand = new SqlCommand(deleteDrinkQuery, connection);
                        deleteDrinkCommand.Parameters.AddWithValue("@Id", drinkId);
                        deleteDrinkCommand.ExecuteNonQuery();

                        MessageBox.Show("Drink deleted successfully!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting drink: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                RefreshDrinkGridView();
                ClearDrinkForm();
            }
        }

        private void ClearDrinkForm()
        {
            DrinkNameBox.Text = "";
            DrinkPriceBox.Text = "";
            DrinkImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
            selectedImage = null;
        }
        private void DrinkImageBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecione uma imagem";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedImage = new Bitmap(openFileDialog.FileName);
                    DrinkImageBox.Image = selectedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao carregar a imagem: " + ex.Message);
                }
            }
        }
        private void DrinkGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DrinkGridView.Rows[e.RowIndex];
                drinkId = Convert.ToInt32(row.Cells["ColID2"].Value);
                DrinkNameBox.Text = row.Cells["ColName2"].Value.ToString();
                DrinkPriceBox.Text = row.Cells["ColPrice2"].Value.ToString();

                if (row.Cells["ColImage2"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["ColImage2"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        selectedImage = Image.FromStream(stream);
                        DrinkImageBox.Image = selectedImage;
                    }
                }
                else
                {
                    DrinkImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
                    selectedImage = null;
                }
                LoadDrinkIngredients(drinkId);
            }
        }


        private void DrinksIngredientsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DrinksIngredientsGrid.Rows[e.RowIndex];
                IDing = Convert.ToInt32(row.Cells["IDing2"].Value);
                string ingredientName = row.Cells["DIname"].Value.ToString();
                if (row.Cells["DIimage"].Value != DBNull.Value) 
                {
                    byte[] imageData = (byte[])row.Cells["DIimage"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        DIpicture.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    DIpicture.Image = null;
                }
                foreach (string line in DIrichbox.Lines)
                {
                    if (line.StartsWith(ingredientName))
                    {
                        int index = DIrichbox.Text.IndexOf(line);
                        DIrichbox.Select(index, line.Length);
                        break;
                    }
                }
            }
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (DrinksIngredientsGrid.SelectedCells.Count > 0)
            {
                int rowIndex = DrinksIngredientsGrid.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = DrinksIngredientsGrid.Rows[rowIndex];
                string ingredientName = selectedRow.Cells["DIname"].Value.ToString();
                string quantity = QtdBox.Text;

                if (!string.IsNullOrEmpty(ingredientName) && !string.IsNullOrEmpty(quantity))
                {
                    bool ingredientAlreadyAdded = false;

                    foreach (string line in DIrichbox.Lines)
                    {
                        if (line.StartsWith(ingredientName + " -"))
                        {
                            ingredientAlreadyAdded = true;
                            break;
                        }
                    }

                    if (!ingredientAlreadyAdded)
                    {
                        string entry = $"{ingredientName} - {quantity}";
                        DIrichbox.AppendText(entry + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("Ingredient already added.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter quantity.");
                }
            }
            else
            {
                MessageBox.Show("Please select an ingredient from the list.");
            }
        }
        private void RemoverBtn_Click(object sender, EventArgs e)
        {
            if (DIrichbox.SelectionLength > 0)
            {
                string selectedText = DIrichbox.SelectedText.Trim();
                string[] parts = selectedText.Split('-');
                if (parts.Length == 2)
                {
                    string ingredientName = parts[0].Trim();
                    int quantity;
                    if (int.TryParse(parts[1].Trim(), out quantity))
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            int ingId = GetIngredientIdByName(connection, ingredientName);
                            if (ingId != -1)
                            {
                                string query = "DELETE FROM DrinksIngredients WHERE ID_Drinks = @drinkId AND ID_Ingredients = @ingId AND Quantity = @quantity";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@drinkId", drinkId);
                                command.Parameters.AddWithValue("@ingId", ingId);
                                command.Parameters.AddWithValue("@quantity", quantity);
                                command.ExecuteNonQuery();
                            }
                        }
                        string[] lines = DIrichbox.Lines;
                        List<string> updatedLines = new List<string>();
                        foreach (string line in lines)
                        {
                            if (!line.Trim().Equals(selectedText, StringComparison.OrdinalIgnoreCase))
                            {
                                updatedLines.Add(line);
                            }
                        }

                        DIrichbox.Lines = updatedLines.ToArray();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an entry to remove.");
            }
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            AddIngredientsToDatabase();
        }
        private void AddIngredientsToDatabase()
        {
            string[] ingredientLines = DIrichbox.Lines;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (string line in ingredientLines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string ingredientName = line.Trim();
                        int spaceIndex = ingredientName.IndexOf(' ');
                        if (spaceIndex >= 0)
                        {
                            ingredientName = ingredientName.Substring(0, spaceIndex);
                        }
                        int ingId = GetIngredientIdByName(connection, ingredientName);
                        if (ingId != -1) 
                        {
                            string query = "INSERT INTO DrinksIngredients (ID_Drinks, ID_Ingredients, Quantity) VALUES (@drinkId, @ingId, @Qtd)";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@drinkId", drinkId); 
                            command.Parameters.AddWithValue("@ingId", ingId); 
                            int Qtd = Convert.ToInt32(QtdBox.Text); 
                            command.Parameters.AddWithValue("@Qtd", Qtd);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show($"Ingrediente '{ingredientName}' não encontrado no banco de dados.");
                        }
                    }
                }
            }
        }

        private int GetIngredientIdByName(SqlConnection connection, string ingredientName)
        {
            string query = "SELECT ID FROM IngredientsInfo WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", ingredientName);
            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1;
        }
        private void LoadDrinkIngredients(int drinkId)
        {
            DIrichbox.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT i.Name, di.Quantity
            FROM DrinksIngredients di
            JOIN IngredientsInfo i ON di.ID_Ingredients = i.ID
            WHERE di.ID_Drinks = @drinkId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@drinkId", drinkId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ingredientName = reader["Name"].ToString();  
                        int quantity = Convert.ToInt32(reader["Quantity"]);
                        DIrichbox.AppendText($"{ingredientName} - {quantity}" + Environment.NewLine);
                    }
                }
            }
        }


















        //
        private void Employees_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 5;
        }

        //










































































        // Employee Manager Menu ----------------------------------------------------------------------------------------------------------------------------------------------------------------




        private void UsersGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UsersGridView.Rows[e.RowIndex].Selected = true;
                RoleCombo.Text = UsersGridView.Rows[e.RowIndex].Cells["RoleColumn"].Value.ToString();
                UsernameBox.Text = UsersGridView.Rows[e.RowIndex].Cells["UsernameColumn"].Value.ToString();
                BIbox.Text = UsersGridView.Rows[e.RowIndex].Cells["BIColumn"].Value.ToString();
                EmailBox.Text = UsersGridView.Rows[e.RowIndex].Cells["EmailColumn"].Value.ToString();
                PasswordBox.Text = UsersGridView.Rows[e.RowIndex].Cells["PasswordColumn"].Value.ToString();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersGridView.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["IDColumn"].Value);
                string newRole = RoleCombo.Text;
                string newUser = UsernameBox.Text;
                string newEmail = EmailBox.Text;
                string newPassword = PasswordBox.Text;
                string newBI = BIbox.Text;
                string currentUserRole = Form1.UserRole;

                // Restrict Managers from editing Admins or other Managers
                if (currentUserRole == "MANAGER")
                {
                    if (row.Cells["RoleColumn"].Value.ToString() != "EMPLOYEE")
                    {
                        MessageBox.Show("Managers can only edit Employees.");
                        return;
                    }
                    if (newRole == "ADMIN" || newRole == "MANAGER")
                    {
                        MessageBox.Show("Managers cannot assign Admin or Manager roles.");
                        return;
                    }
                }

                ValidationV = true;
                ValidateBI(newBI);
                ValidateEmail(newEmail);

                if (!ValidationV)
                {
                    ClearFields();
                    return;
                }

                UpdateUserDetails(userId, newUser, newEmail, newPassword, newBI, newRole);

                ClearFields();
                RefreshGridView();
                UsersGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show("Select a user from the table!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateUserInputs())
            {
                string currentUserRole = Form1.UserRole;

                if (currentUserRole == "MANAGER")
                {
                    if (RoleCombo.Text == "ADMIN" || RoleCombo.Text == "MANAGER")
                    {
                        MessageBox.Show("Managers cannot assign Admin or Manager roles.");
                        return;
                    }
                }

                if (!IsUserExists(BIbox.Text, EmailBox.Text))
                {
                    AddUser();
                    RefreshGridView();
                    UsersGridView.ClearSelection();
                    ClearFields();
                    MessageBox.Show("User added successfully!");
                }
                else
                {
                    MessageBox.Show("A user with the same BI or Email already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersGridView.SelectedRows[0];
                int userId = Convert.ToInt32(row.Cells["IDColumn"].Value);
                string currentUserRole = Form1.UserRole;

                // Restrict Managers to delete only Employees
                if (currentUserRole == "MANAGER" && row.Cells["RoleColumn"].Value.ToString() != "EMPLOYEE")
                {
                    MessageBox.Show("Managers can only delete Employees.");
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteUser(userId);
                    RefreshGridView();
                    UsersGridView.ClearSelection();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Select a user from the table!");
            }
        }

        private bool ValidateUserInputs()
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                string.IsNullOrWhiteSpace(BIbox.Text) ||
                string.IsNullOrWhiteSpace(RoleCombo.Text))
            {
                return false;
            }

            ValidationV = true;
            ValidateBI(BIbox.Text);
            ValidateEmail(EmailBox.Text);

            return ValidationV;
        }

        private bool IsUserExists(string bi, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM UserAccount WHERE BI = @BI OR Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BI", bi);
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void AddUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserAccount (Username, Email, Password, BI, Role) VALUES (@Username, @Email, @Password, @BI, @Role)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", UsernameBox.Text);
                    command.Parameters.AddWithValue("@Email", EmailBox.Text);
                    command.Parameters.AddWithValue("@Password", PasswordBox.Text);
                    command.Parameters.AddWithValue("@BI", BIbox.Text);
                    command.Parameters.AddWithValue("@Role", RoleCombo.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
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
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("You can't delete your own account!");
            }
        }

        private void UpdateUserDetails(int userId, string newUser, string newEmail, string newPassword, string newBI, string newRole)
        {
            UpdateField(userId, "Username", newUser, "Username");
            UpdateField(userId, "Email", newEmail, "Email");
            UpdateField(userId, "Password", newPassword, "Password");
            UpdateField(userId, "BI", newBI, "BI");

            if (newRole == "ADMIN")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to change this user to admin?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    RoleCombo.SelectedIndex = -1;
                    return;
                }
            }
            UpdateField(userId, "Role", newRole, "Role");
        }

        private void UpdateField(int userId, string fieldName, string newValue, string fieldDisplayName)
        {
            if (userId != Form1.LoggedInUserId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"UPDATE UserAccount SET {fieldName} = @NewValue WHERE ID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@UserID", userId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show($"You can't change your own {fieldDisplayName.ToLower()}!");
            }
        }

        private void ClearFields()
        {
            UsernameBox.Text = "";
            EmailBox.Text = "";
            PasswordBox.Text = "";
            BIbox.Text = "";
            RoleCombo.SelectedIndex = -1;
        }

        private void ValidateBI(string bi)
        {
            if (bi.Length != 8 || !long.TryParse(bi, out _))
            {
                MessageBox.Show("BI must contain 8 digits.");
                ValidationV = false;
            }
        }

        private void DrinkMaker_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja fazer esta bebida?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT di.ID_Ingredients, di.Quantity, i.QuantityStock
                FROM DrinksIngredients di
                JOIN IngredientsInfo i ON di.ID_Ingredients = i.ID
                WHERE di.ID_Drinks = @drinkId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@drinkId", drinkId);

                    List<(int ingredientId, int requiredQuantity, int quantityStock)> ingredientsToUpdate = new List<(int ingredientId, int requiredQuantity, int quantityStock)>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ingredientId = Convert.ToInt32(reader["ID_Ingredients"]);
                            int requiredQuantity = Convert.ToInt32(reader["Quantity"]);
                            int quantityStock = Convert.ToInt32(reader["QuantityStock"]);

                            ingredientsToUpdate.Add((ingredientId, requiredQuantity, quantityStock));
                        }
                    }

                    bool stockAvailable = true;

                    foreach (var item in ingredientsToUpdate)
                    {
                        if (item.quantityStock < item.requiredQuantity)
                        {
                            stockAvailable = false;
                            break;
                        }
                    }

                    if (stockAvailable)
                    {
                        foreach (var item in ingredientsToUpdate)
                        {
                            string updateQuery = "UPDATE IngredientsInfo SET QuantityStock = QuantityStock - @quantity WHERE ID = @ingredientId";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@quantity", item.requiredQuantity);
                            updateCommand.Parameters.AddWithValue("@ingredientId", item.ingredientId);
                            updateCommand.ExecuteNonQuery();

                            string usageQuery = @"
                        MERGE IngredientUsage AS target
                        USING (SELECT @ingredientId AS ID_Ingredient) AS source
                        ON (target.ID_Ingredient = source.ID_Ingredient)
                        WHEN MATCHED THEN
                            UPDATE SET UsageCount = UsageCount + @quantity
                        WHEN NOT MATCHED THEN
                            INSERT (ID_Ingredient, UsageCount)
                            VALUES (source.ID_Ingredient, @quantity);";
                            SqlCommand usageCommand = new SqlCommand(usageQuery, connection);
                            usageCommand.Parameters.AddWithValue("@ingredientId", item.ingredientId);
                            usageCommand.Parameters.AddWithValue("@quantity", item.requiredQuantity);
                            usageCommand.ExecuteNonQuery();
                        }

                        string drinkUsageQuery = @"
                    MERGE DrinkUsage AS target
                    USING (SELECT @drinkId AS ID_Drink) AS source
                    ON (target.ID_Drink = source.ID_Drink)
                    WHEN MATCHED THEN
                        UPDATE SET UsageCount = UsageCount + 1
                    WHEN NOT MATCHED THEN
                        INSERT (ID_Drink, UsageCount)
                        VALUES (source.ID_Drink, 1);";
                        SqlCommand drinkUsageCommand = new SqlCommand(drinkUsageQuery, connection);
                        drinkUsageCommand.Parameters.AddWithValue("@drinkId", drinkId);
                        drinkUsageCommand.ExecuteNonQuery();
                        RefreshGridView();
                        MessageBox.Show("Bebida feita com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Estoque insuficiente para fazer a bebida.");
                    }
                }
            }
        }

        private void btnPopular_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 3;
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 4;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Invalid email address.");
                ValidationV = false;
                return ValidationV;
            }
        }





        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
