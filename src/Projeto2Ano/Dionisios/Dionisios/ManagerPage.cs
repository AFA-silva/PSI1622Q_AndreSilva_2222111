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
using System.Windows.Forms.DataVisualization.Charting;

namespace Dionisios
{
    public partial class ManagerPage : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        private Image selectedImage;
        public int IDing, IDdrink, Confirm;
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
                label1.Location = new Point(-7, 184);
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

        // Page Loadres Code -------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void StockBtn_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 1;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            Managerclose = 1;
            this.Close();
        }
        private void btnDrinks_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 2;
        }
        private void btnPopular_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 3;
        }
        private void btnIncome_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 4;
        }
        private void Employees_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 5;
        }

        // Stock Menu Code ---------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void IngredientAddBtn_Click(object sender, EventArgs e)
        {
            if (IngNameBox.Text != "" && IngUnitBox.Text != "" && selectedImage != null)
            {
                Confirm = 0;
                AddIngredient(); 
                if (Confirm == 1)
                {
                }
                else
                {
                    RefreshGridView(); // Atualiza o GridView
                    ClearForm(); // Limpa o formulário
                    MessageBox.Show("Ingrediente adicionado com sucesso!"); 
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios."); 
            }
        }

        // Função para adicionar um ingrediente a base de dados
        private void AddIngredient()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO IngredientsInfo (Name, Unit, QuantityStock, Image, Description, Price) VALUES (@Name, @Unit, @Quantity, @Image, @Description, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);

                int quantity;
                float price;
                if (int.TryParse(IngQuantityBox.Text, out quantity) && float.TryParse(IngPriceBox.Text, out price))
                {
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", Math.Round(price, 2));
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor inteiro válido para a quantidade e um número válido para o preço.");
                    Confirm = 1;
                    return;
                }

                byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Converte a imagem para byte array
                command.Parameters.AddWithValue("@Image", imageData);

                connection.Open();
                command.ExecuteNonQuery(); 
            }
        }

        // Atualiza os dados exibidos no GridView
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
                    selectedImage = new Bitmap(openFileDialog.FileName); // Carrega a imagem selecionada
                    IngImageBox.Image = selectedImage; // Exibe a imagem no PictureBox
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
                        selectedImage = Image.FromStream(stream); // Carrega a imagem da base de dados
                        IngImageBox.Image = selectedImage; // Exibe a imagem no PictureBox
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
        private void UpdateIngBtn_Click(object sender, EventArgs e)
        {
            if (IngNameBox.Text != "" && IngUnitBox.Text != "" && IngQuantityBox.Text != "")
            {
                UpdateIngredient(); // Atualiza o ingrediente na base de dados
                RefreshGridView(); // Atualiza o GridView
                ClearForm(); // Limpa o formulário
                MessageBox.Show("Ingrediente atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios."); 
            }
        }
        private void BtnDeleteIng_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza de que deseja deletar este item?", "Deletar Ingrediente", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;

                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        // Deleta relacionamentos com DrinksIngredients
                        string deleteDrinksIngredientsQuery = "DELETE FROM DrinksIngredients WHERE ID_Ingredients = @Id";
                        SqlCommand deleteDrinksIngredientsCommand = new SqlCommand(deleteDrinksIngredientsQuery, connection, transaction);
                        deleteDrinksIngredientsCommand.Parameters.AddWithValue("@Id", ingId);
                        deleteDrinksIngredientsCommand.ExecuteNonQuery();

                        // Deleta relacionamentos com IngredientUsage
                        string deleteIngredientUsageQuery = "DELETE FROM IngredientUsage WHERE ID_Ingredient = @Id";
                        SqlCommand deleteIngredientUsageCommand = new SqlCommand(deleteIngredientUsageQuery, connection, transaction);
                        deleteIngredientUsageCommand.Parameters.AddWithValue("@Id", ingId);
                        deleteIngredientUsageCommand.ExecuteNonQuery();

                        // Deleta o ingrediente da tabela IngredientsInfo
                        string deleteIngredientQuery = "DELETE FROM IngredientsInfo WHERE Id = @Id";
                        SqlCommand deleteIngredientCommand = new SqlCommand(deleteIngredientQuery, connection, transaction);
                        deleteIngredientCommand.Parameters.AddWithValue("@Id", ingId);
                        deleteIngredientCommand.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Ingrediente deletado com sucesso!");
                    }
                    catch (SqlException ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback(); // Faz rollback em caso de erro
                        }

                        MessageBox.Show("Erro ao deletar ingrediente: " + ex.Message); 
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
                // Base da query de atualização sem a imagem
                string query = "UPDATE IngredientsInfo SET Name = @Name, Unit = @Unit, QuantityStock = @Quantity, Description = @Description, Price = @Price";

                // Verifica se a imagem foi alterada
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

                try
                {
                    // Adiciona os parâmetros fora do bloco try-catch para garantir que eles sejam sempre adicionados
                    command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                    command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                    command.Parameters.AddWithValue("@Quantity", int.Parse(IngQuantityBox.Text));
                    command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);
                    command.Parameters.AddWithValue("@Price", float.Parse(IngPriceBox.Text)); // Garante que o preço seja atualizado

                    // Adiciona o parâmetro da imagem apenas se a imagem foi alterada
                    if (selectedImage != null)
                    {
                        string newImageHash = GetImageHash(selectedImage);
                        if (newImageHash != currentImageHash)
                        {
                            byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Converte a imagem para byte array
                            command.Parameters.AddWithValue("@Image", imageData);
                        }
                    }

                    command.Parameters.AddWithValue("@Id", ingId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Erro ao digitar algum dos valores. Verifique os campos de quantidade e preço.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao executar a atualização no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }
        private void ClearForm()
        {
            IngNameBox.Text = "Nome";
            IngDescriptionBox.Text = "Descrição";
            IngUnitBox.Text = "Unidade";
            IngQuantityBox.Text = "Quantidade";
            IngPriceBox.Text = "Preço";
            IngImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614; // Define a imagem padrão
            selectedImage = null;
            currentImageHash = null;
        }

        // Calcula o hash da imagem para verificar se foi alterada
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

        // Converte uma imagem para um array de bytes
        private byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        // Drinks Menu Code -------------------------------------------------------------------------------------------------------------------------          
        private void AddDrinkBtn_Click(object sender, EventArgs e)
        {
            if (DrinkNameBox.Text != "" && DrinkPriceBox.Text != "" && selectedImage != null)
            {
                AddDrink(); // Adiciona a bebida a base de dados
                RefreshDrinkGridView(); // Atualiza o GridView
                ClearDrinkForm(); // Limpa o formulário
                MessageBox.Show("Drink adicionado com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
            }
        }

        // Função para adicionar uma bebida a base de dados
        private void AddDrink()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DrinksInfo (Name, Price, Image) VALUES (@Name, @Price, @Image)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", DrinkNameBox.Text);

                // Valida e formata o preço
                float price;
                if (float.TryParse(DrinkPriceBox.Text, out price))
                {
                    command.Parameters.AddWithValue("@Price", Math.Round(price, 2)); // Format o preço com 2 casas decimais
                }
                else
                {
                    MessageBox.Show("Por favor, insira um número válido para o preço.");
                    return;
                }
                byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png);
                command.Parameters.AddWithValue("@Image", imageData);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Atualiza os dados exibidos no GridView de bebidas
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
                UpdateDrink(); // Atualiza a bebida na base de dados
                RefreshDrinkGridView(); // Atualiza o GridView
                ClearDrinkForm(); // Limpa o formulário
                MessageBox.Show("Drink atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
            }
        }
        // Função para atualizar uma bebida na base de dados
        private void UpdateDrink()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Base da query de atualização sem a imagem
                    string query = "UPDATE DrinksInfo SET Name = @Name, Price = @Price";

                    // Verifica se a imagem foi alterada
                    if (selectedImage != null)
                    {
                        query += ", Image = @Image";
                    }
                    query += " WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", DrinkNameBox.Text);

                    // Tenta converter o preço para float
                    if (float.TryParse(DrinkPriceBox.Text, out float price))
                    {
                        command.Parameters.AddWithValue("@Price", price); // Garante que o preço seja atualizado
                    }
                    else
                    {
                        MessageBox.Show("Formato de preço inválido. Por favor, insira um número válido.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Sai do método se o preço for inválido
                    }

                    // Adiciona o parâmetro da imagem apenas se a imagem foi alterada
                    if (selectedImage != null)
                    {
                        byte[] imageData = ImageToByteArray(selectedImage, ImageFormat.Png); // Converte a imagem para byte array
                        command.Parameters.AddWithValue("@Image", imageData);
                    }

                    command.Parameters.AddWithValue("@Id", drinkId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro de formatação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de SQL: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro desconhecido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDrinkBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza de que deseja deletar este item?", "Deletar Drink", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;

                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction();

                        // Primeiro, remover as associações da tabela DrinksIngredients
                        string deleteDrinksIngredientsQuery = "DELETE FROM DrinksIngredients WHERE ID_Drinks = @ID_Drinks";
                        SqlCommand deleteDrinksIngredientsCommand = new SqlCommand(deleteDrinksIngredientsQuery, connection, transaction);
                        deleteDrinksIngredientsCommand.Parameters.AddWithValue("@ID_Drinks", drinkId);
                        deleteDrinksIngredientsCommand.ExecuteNonQuery();

                        // Em seguida, remover as associações da tabela DrinkUsage
                        string deleteDrinkUsageQuery = "DELETE FROM DrinkUsage WHERE ID_Drink = @ID_Drinks";
                        SqlCommand deleteDrinkUsageCommand = new SqlCommand(deleteDrinkUsageQuery, connection, transaction);
                        deleteDrinkUsageCommand.Parameters.AddWithValue("@ID_Drinks", drinkId);
                        deleteDrinkUsageCommand.ExecuteNonQuery();

                        // Finalmente, deletar a bebida da tabela DrinksInfo
                        string deleteDrinkQuery = "DELETE FROM DrinksInfo WHERE Id = @Id";
                        SqlCommand deleteDrinkCommand = new SqlCommand(deleteDrinkQuery, connection, transaction);
                        deleteDrinkCommand.Parameters.AddWithValue("@Id", drinkId);
                        deleteDrinkCommand.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Drink deletado com sucesso!");
                    }
                    catch (SqlException ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback(); // Faz rollback em caso de erro
                        }

                        MessageBox.Show("Erro ao deletar drink: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                RefreshDrinkGridView(); // Atualiza o GridView
                ClearDrinkForm(); // Limpa o formulário
            }
        }

        // Limpa o formulário de entrada de dados
        private void ClearDrinkForm()
        {
            DrinkNameBox.Text = "";
            DrinkPriceBox.Text = "";
            DrinkImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614; // Define a imagem padrão
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
                    selectedImage = new Bitmap(openFileDialog.FileName); // Carrega a imagem selecionada
                    DrinkImageBox.Image = selectedImage; // Exibe a imagem no PictureBox
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
                    DrinkImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614; // Define a imagem padrão
                    selectedImage = null;
                }
                LoadDrinkIngredients(drinkId); // Carrega os ingredientes da bebida
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
                    if (int.TryParse(quantity, out int parsedQuantity))
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
                            string entry = $"{ingredientName} - {parsedQuantity}";
                            DIrichbox.AppendText(entry + Environment.NewLine);
                        }
                        else
                        {
                            MessageBox.Show("Ingrediente já adicionado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira um número inteiro válido para a quantidade.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira a quantidade.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um ingrediente da lista.");
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
                MessageBox.Show("Por favor, selecione uma entrada para remover.");
            }
        }
        private void FinishBtn_Click(object sender, EventArgs e)
        {
            AddIngredientsToDatabase(); // Adiciona os ingredientes a base de dados
        }

        // Adiciona os ingredientes da bebida a base de dados
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
                        // Extrai o nome e a quantidade do ingrediente da linha
                        string[] parts = line.Split(new[] { " - " }, StringSplitOptions.None);
                        if (parts.Length == 2)
                        {
                            string ingredientName = parts[0].Trim();
                            if (int.TryParse(parts[1].Trim(), out int quantity))
                            {
                                int ingId = GetIngredientIdByName(connection, ingredientName);
                                if (ingId != -1)
                                {
                                    if (!IngredientExists(connection, drinkId, ingId))
                                    {
                                        string query = "INSERT INTO DrinksIngredients (ID_Drinks, ID_Ingredients, Quantity) VALUES (@drinkId, @ingId, @Qtd)";
                                        SqlCommand command = new SqlCommand(query, connection);
                                        command.Parameters.AddWithValue("@drinkId", drinkId);
                                        command.Parameters.AddWithValue("@ingId", ingId);
                                        command.Parameters.AddWithValue("@Qtd", quantity);
                                        command.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Ingrediente '{ingredientName}' não encontrado na base de dados.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Quantidade inválida para o ingrediente '{ingredientName}'.");
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Ingredientes adicionados com sucesso!!");
        }

        // Verifica se o ingrediente já existe para a bebida na base de dados
        private bool IngredientExists(SqlConnection connection, int drinkId, int ingId)
        {
            string query = "SELECT COUNT(*) FROM DrinksIngredients WHERE ID_Drinks = @drinkId AND ID_Ingredients = @ingId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@drinkId", drinkId);
            command.Parameters.AddWithValue("@ingId", ingId);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        // Obtém o ID do ingrediente pelo nome
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

        // Carrega os ingredientes da bebida e exibe no RichTextBox
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
                    // Verifica o Stock, se tem algum ingrediente indisponivel/disponivel
                    bool stockAvailable = true;

                    foreach (var item in ingredientsToUpdate)
                    {
                        if (item.quantityStock < item.requiredQuantity)
                        {
                            stockAvailable = false;
                            break;
                        }
                    }
                    // Se tiver disponivel continua o evento
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

                // Restrição para Managers: não podem editar admins ou outros managers
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

                // Validações de BI e Email
                ValidationV = true;
                ValidateBI(newBI);
                ValidateEmail(newEmail);

                // Se a validação falhar, limpa os campos e sai do método
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
            // Verifica se os inputs do utilizador são válidos
            if (ValidateUserInputs())
            {
                string currentUserRole = Form1.UserRole;

                // Restrição para Managers: não podem adicionar admins ou outros Managers
                if (currentUserRole == "MANAGER")
                {
                    if (RoleCombo.Text == "ADMIN" || RoleCombo.Text == "MANAGER")
                    {
                        MessageBox.Show("Managers cannot assign Admin or Manager roles.");
                        return;
                    }
                }

                // Verifica se já existe um utilizador com o mesmo BI ou Email
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

                // Restrição para Managers: só podem apagar empregados
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

        // Método que valida os inputs do utilizador
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

            // Validações de BI e Email
            ValidationV = true;
            ValidateBI(BIbox.Text);
            ValidateEmail(EmailBox.Text);

            return ValidationV;
        }

        // Método que verifica se já existe um utilizador com o mesmo BI ou Email
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
            // Verifica se o utilizador a ser apagado não é o próprio utilizador logado
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
            // Verifica se o campo a ser atualizado não é do próprio utilizador logado
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

        // Método que valida o BI
        private void ValidateBI(string bi)
        {
            if (bi.Length != 8 || !long.TryParse(bi, out _))
            {
                MessageBox.Show("BI must contain 8 digits.");
                ValidationV = false;
            }
        }

        // Método que valida o Email
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


        // Popular Menu Tab Code ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void IngredientsGrid_Click(object sender, EventArgs e)
        {
            // Carrega as bebidas populares e configura a aparência do gráfico
            LoadPopularDrinks();
            ConfigureChartAppearance();
            Chart.Visible = true;  
        }
        private void DrinksGrid_Click(object sender, EventArgs e)
        {
            // Carrega os ingredientes populares e configura a aparência do gráfico
            LoadPopularIngredients();
            ConfigureChartAppearance();
            Chart.Visible = true;  
        }
        private void LoadPopularDrinks()
        {
            Chart.Series.Clear();  
            Chart.ChartAreas.Clear();  

            var series = new Series("Bebidas");  
            series.ChartType = SeriesChartType.Bar;  
            series.IsVisibleInLegend = false;  
            Chart.Series.Add(series); 
            Chart.ChartAreas.Add(new ChartArea("ChartArea"));  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT d.Name, du.UsageCount FROM DrinkUsage du JOIN DrinksInfo d ON du.ID_Drink = d.ID ORDER BY du.UsageCount DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string drinkName = reader["Name"].ToString();
                        int usageCount = Convert.ToInt32(reader["UsageCount"]);
                        series.Points.AddXY(drinkName, usageCount);  // Adiciona os dados ao gráfico
                    }
                }
            }
        }
        private void LoadPopularIngredients()
        {
            Chart.Series.Clear(); 
            Chart.ChartAreas.Clear();  

            var series = new Series("Ingredientes"); 
            series.ChartType = SeriesChartType.Bar; 
            series.IsVisibleInLegend = false; 

            Chart.Series.Add(series);  
            Chart.ChartAreas.Add(new ChartArea("ChartArea"));  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT i.Name, iu.UsageCount FROM IngredientUsage iu JOIN IngredientsInfo i ON iu.ID_Ingredient = i.ID ORDER BY iu.UsageCount DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ingredientName = reader["Name"].ToString();
                        int usageCount = Convert.ToInt32(reader["UsageCount"]);
                        series.Points.AddXY(ingredientName, usageCount);  // Adiciona os dados ao gráfico
                    }
                }
            }
        }

        // Método que configura a aparência do gráfico
        private void ConfigureChartAppearance()
        {
            Chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            Chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            Chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            Chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            ChartIncome.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            ChartIncome.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            ChartIncome.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            ChartIncome.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold);
        }
        private void btnReceita_Click(object sender, EventArgs e)
        {
            LoadReceita();  
            ConfigureChartAppearance();  
            ChartIncome.Visible = true;  
        }

        private void btnDespesas_Click(object sender, EventArgs e)
        {
            LoadDespesas(); 
            ConfigureChartAppearance();  
            ChartIncome.Visible = true; 
        }

        // Método que carrega as despesas no gráfico
        private void LoadDespesas()
        {
            ChartIncome.Series.Clear();  
            ChartIncome.ChartAreas.Clear();  

            var series = new Series("Despesas");  
            series.ChartType = SeriesChartType.Bar; 
            series.IsVisibleInLegend = false; 
            ChartIncome.Series.Add(series);  
            ChartIncome.ChartAreas.Add(new ChartArea("ChartArea")); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT i.Name, SUM(i.Price * di.Quantity) AS TotalSpent FROM DrinksIngredients di JOIN IngredientsInfo i ON di.ID_Ingredients = i.ID GROUP BY i.Name ORDER BY TotalSpent DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ingredientName = reader["Name"].ToString();
                        double totalSpent = Convert.ToDouble(reader["TotalSpent"]);
                        series.Points.AddXY(ingredientName, totalSpent);  // Adiciona os dados ao gráfico
                    }
                }
            }
        }

        // Método que carrega a receita no gráfico
        private void LoadReceita()
        {
            ChartIncome.Series.Clear(); 
            ChartIncome.ChartAreas.Clear();  

            var series = new Series("Receita");  
            series.ChartType = SeriesChartType.Bar; 
            series.IsVisibleInLegend = false;  
            ChartIncome.Series.Add(series);  
            ChartIncome.ChartAreas.Add(new ChartArea("ChartArea")); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT d.Name, SUM(d.Price * du.UsageCount) AS TotalEarned FROM DrinkUsage du JOIN DrinksInfo d ON du.ID_Drink = d.ID GROUP BY d.Name ORDER BY TotalEarned DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string drinkName = reader["Name"].ToString();
                        double totalEarned = Convert.ToDouble(reader["TotalEarned"]);
                        series.Points.AddXY(drinkName, totalEarned);  // Adiciona os dados ao gráfico
                    }
                }
            }
        }
    }
}
