using Dionisios.Properties;
using System;
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
        private int ingId;
        private int retorno;
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
            this.drinksInfoTableAdapter.Fill(this.dionisiosDBDataSet.DrinksInfo);
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
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
                byte[] imageData;
                using (MemoryStream stream = new MemoryStream())
                {
                    selectedImage.Save(stream, ImageFormat.Jpeg);
                    imageData = stream.ToArray();
                }
                command.Parameters.AddWithValue("@Image", imageData);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void RefreshGridView()
        {
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
                if (selectedImage != null)
                {
                    string newImageHash = GetImageHash(selectedImage);
                    if (newImageHash != currentImageHash)
                    {
                        byte[] imageData;
                        try
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                selectedImage.Save(stream, ImageFormat.Png);
                                imageData = stream.ToArray();
                            }
                            command.Parameters.AddWithValue("@Image", imageData);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao salvar a imagem: " + ex.Message);
                            return;
                        }
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

        // Drinks Menu Code -------------------------------------------------------------------------------------------------------------------------

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 2;
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {

        }
    }
}
