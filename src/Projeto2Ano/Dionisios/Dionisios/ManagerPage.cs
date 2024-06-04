using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class ManagerPage : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DionisiosDB;Integrated Security=True";
        private Image selectedImage;
        private int ingId;
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
            if (IngNameBox.Text != "" && UnitBox.Text != "" && selectedImage != null)
            {
                AddIngredient();
                RefreshGridView();
                IngNameBox.Text = "";
                UnitBox.Text = "";
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
                string query = "INSERT INTO IngredientsInfo (Name, Unit, QuantityStock, Image) VALUES (@Name, @Unit, @Quantity, @Image)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", IngNameBox.Text);
                command.Parameters.AddWithValue("@Unit", UnitBox.Text);
                command.Parameters.AddWithValue("@Quantity", 0);
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
                    NewIngImage.Image = selectedImage;
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
                IngNameB.Text = row.Cells["NameCol"].Value.ToString();
                IngUnitB.Text = row.Cells["UnitCol"].Value.ToString();
                IngQuantityB.Text = row.Cells["QuantityCol"].Value.ToString();
                if (row.Cells["ImageCol"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["ImageCol"].Value;
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        selectedImage = Image.FromStream(stream);
                        IngredientsImage.Image = selectedImage;
                    }
                }
                else
                {
                    NewIngImage.Image = null;
                }
            }
        }

        private void StockVisualsToggle()
        {
            IngredientGridView.Visible = true;
            IngredientsImage.Visible = true;    
            IngUnitB.Visible = true;
            IngQuantityB.Visible = true;
            IngNameB.Visible = true;
            IngDescriptionBox.Visible = true;
            QuantityAddedBox.Visible = true;
            BtnDeleteIng.Visible = true;
            StockAddBtn.Visible = true;
            NewIngImage.Visible = true; 
            IngNameBox.Visible = true;  
            UnitBox.Visible = true; 
            IngredientAddBtn.Visible = true;
        }

        private void StockBtn_Click(object sender, EventArgs e)
        {
            Menu.SelectedIndex = 1;
            StockVisualsToggle();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Managerclose = 1;
            this.Close();
        }
        private void StockAddBtn_Click(object sender, EventArgs e)
        {
            if (IngredientGridView.SelectedRows.Count > 0 && int.TryParse(QuantityAddedBox.Text, out int quantityToAdd))
            {
                DataGridViewRow selectedRow = IngredientGridView.SelectedRows[0];
                int ingredientId = (int)selectedRow.Cells["IngredientID"].Value;
                int currentStock = (int)selectedRow.Cells["QuantityStock"].Value;
                int newStock = currentStock + quantityToAdd;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE IngredientsInfo SET QuantityStock = @QuantityStock WHERE IngredientID = @IngredientID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@QuantityStock", newStock);
                    command.Parameters.AddWithValue("@IngredientID", ingredientId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                RefreshGridView();
                QuantityAddedBox.Text = "";
                IngNameB.Text = "";
                IngQuantityB.Text = "";
                IngUnitB.Text = "";
                MessageBox.Show("Stock added successfully!");
            }
            else
            {
                MessageBox.Show("Please select an ingredient and enter a valid quantity.");
            }
        }
    }
}
