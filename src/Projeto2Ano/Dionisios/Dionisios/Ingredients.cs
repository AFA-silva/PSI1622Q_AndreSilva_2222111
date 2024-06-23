using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class Ingredients : Form
    {
        private List<(int Id, string Name, string Quantity)> ingredientList; // Lista de tuplas para armazenar ID, nome e quantidade
        private int ingId;
        private Image selectedImage;
        private string currentImageHash;
        private string selectedIngredientName;
        private int drinkId;

        public Ingredients(int drinkId)
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(436, 398);
            this.MaximumSize = new System.Drawing.Size(436, 398);
            ingredientList = new List<(int, string, string)>();
            this.drinkId = drinkId;
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
            LoadExistingIngredients();
            UpdateIngredientListRichTextBox();
        }

        private void IngredientGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = IngredientGridView.Rows[e.RowIndex];
                ingId = Convert.ToInt32(row.Cells["ColID"].Value);
                selectedIngredientName = row.Cells["ColName"].Value.ToString();

                if (row.Cells["ColImage"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["ColImage"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        selectedImage = Image.FromStream(stream);
                        ImageIng.Image = selectedImage;
                        currentImageHash = GetImageHash(selectedImage);
                    }
                }
                else
                {
                    ImageIng.Image = null;
                    currentImageHash = null;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIngredientName))
            {
                string quantity = QuantidadeUsada.Text.Trim(); // Obtém a quantidade da TextBox
                AddIngredientToList(ingId, selectedIngredientName, quantity);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIngredientName))
            {
                RemoveIngredientFromList(ingId);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (ingredientList.Count == 0)
            {
                MessageBox.Show("A bebida deve ter pelo menos um ingrediente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveDrinkIngredients();
            MessageBox.Show("Ingredientes concluídos!");
            this.Close();
        }

        private void LoadExistingIngredients()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT I.ID_Ingredients, I.Name, DI.Quantity FROM DrinksIngredients DI JOIN Ingredients I ON DI.ID_Ingredients = I.ID_Ingredients WHERE DI.ID_Drinks = @DrinkId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DrinkId", drinkId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string quantity = reader.GetString(2);
                            ingredientList.Add((id, name, quantity));
                        }
                    }
                }
            }
        }

        private void SaveDrinkIngredients()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True"))
            {
                connection.Open();
                foreach (var ingredient in ingredientList)
                {
                    string query = "INSERT INTO DrinksIngredients (ID_Drinks, ID_Ingredients, Quantity) VALUES (@DrinkId, @IngredientId, @Quantity)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DrinkId", drinkId);
                        command.Parameters.AddWithValue("@IngredientId", ingredient.Id);
                        command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void AddIngredientToList(int id, string name, string quantity)
        {
            if (!ingredientList.Exists(x => x.Name == name))
            {
                ingredientList.Add((id, name, quantity));
                UpdateIngredientListRichTextBox();
            }
        }

        private void RemoveIngredientFromList(int id)
        {
            var ingredient = ingredientList.Find(x => x.Id == id);
            if (ingredient.Name != null)
            {
                ingredientList.Remove(ingredient);
                UpdateIngredientListRichTextBox();
            }
        }

        private void UpdateIngredientListRichTextBox()
        {
            IngredientListRichTextBox.Clear();
            foreach (var ingredient in ingredientList)
            {
                IngredientListRichTextBox.AppendText($"{ingredient.Name} - {ingredient.Quantity}\n");
            }
        }

        private string GetImageHash(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
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
    }
}
