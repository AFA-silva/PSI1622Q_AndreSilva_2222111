using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Dionisios
{
    public partial class Ingredients : Form
    {
        private List<(string Name, string Quantity)> ingredientList; // Lista de tuplas para armazenar nome e quantidade
        private int ingId;
        private Image selectedImage;
        private string currentImageHash;
        private string selectedIngredientName;

        public Ingredients()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(436, 398);
            this.MaximumSize = new System.Drawing.Size(436, 398);
            ingredientList = new List<(string, string)>();
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            this.ingredientsInfoTableAdapter.Fill(this.dionisiosDBDataSet.IngredientsInfo);
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
                AddIngredientToList(selectedIngredientName, quantity);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedIngredientName))
            {
                RemoveIngredientFromList(selectedIngredientName);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingredientes concluídos!");
            this.Close();
        }

        private void AddIngredientToList(string ingredientName, string quantity)
        {
            if (!ingredientList.Exists(x => x.Name == ingredientName))
            {
                ingredientList.Add((ingredientName, quantity));
                UpdateIngredientListRichTextBox();
            }
        }

        private void RemoveIngredientFromList(string ingredientName)
        {
            var ingredient = ingredientList.Find(x => x.Name == ingredientName);
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
