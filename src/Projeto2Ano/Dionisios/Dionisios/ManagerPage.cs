using Dionisios.Properties;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public ManagerPage()
        {
            Managerclose = 0;
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(725, 479);
            this.MaximumSize = new System.Drawing.Size(725, 479);
        }

        private void ManagerPage_Load(object sender, EventArgs e)
        {
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
        }

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
                string query = "INSERT INTO IngredientsInfo (Name, Unit, QuantityStock, Image, Description) VALUES (@Name, @Unit, @Quantity, @Image, @Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);
                float quantity;
                if (float.TryParse(IngQuantityBox.Text, out quantity))
                {
                    command.Parameters.AddWithValue("@Quantity", quantity);
                }
                else
                {
                    MessageBox.Show("Please enter a valid floating point number for the quantity.");
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
                ingId = Convert.ToInt32(row.Cells["IdCol"].Value);
                IngNameBox.Text = row.Cells["NameCol"].Value.ToString();
                IngDescriptionBox.Text = row.Cells["DescriptionCol"].Value.ToString();
                IngUnitBox.Text = row.Cells["UnitCol"].Value.ToString();
                IngQuantityBox.Text = row.Cells["QuantityCol"].Value.ToString();
                if (row.Cells["ImageCol"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["ImageCol"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        selectedImage = Image.FromStream(stream);
                        IngImageBox.Image = selectedImage;
                    }
                }
                else
                {
                    IngImageBox.Image = null;
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
                string query = "UPDATE IngredientsInfo SET Name = @Name, Unit = @Unit, QuantityStock = @Quantity, Image = @Image, Description = @Description WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", IngUnitBox.Text);
                command.Parameters.AddWithValue("@Quantity", int.Parse(IngQuantityBox.Text));
                command.Parameters.AddWithValue("@Description", IngDescriptionBox.Text);
                byte[] imageData;
                if (selectedImage != null)
                {
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
                else
                {
                    command.Parameters.AddWithValue("@Image", DBNull.Value);
                }
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
            IngImageBox.Image = Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
            selectedImage = null;
        }
    }
}
