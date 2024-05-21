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
        public int Managerclose { get; set; }
        public ManagerPage()
        {
            Managerclose = 0;   
            InitializeComponent();
        }
        private void ManagerPage_Load(object sender, EventArgs e)
        {
            this.ingredientsInfoTableAdapter1.Fill(this.dionisiosDBDataSet1.IngredientsInfo);
        }
        private void IngredientAddBtn_Click(object sender, EventArgs e)
        {
            if (IngNameBox.Text != "" && UnitBox.Text != "")
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
            this.ingredientsInfoTableAdapter1.Fill(this.dionisiosDBDataSet1.IngredientsInfo);
            IngredientGridView.DataSource = this.dionisiosDBDataSet1.IngredientsInfo;
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
    }
}
