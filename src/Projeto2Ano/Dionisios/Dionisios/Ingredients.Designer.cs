namespace Dionisios
{
    partial class Ingredients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.IngredientGridView = new System.Windows.Forms.DataGridView();
            this.ingredientsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dionisiosDBDataSet = new Dionisios.DionisiosDBDataSet();
            this.ingredientsInfoTableAdapter = new Dionisios.DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter();
            this.ImageIng = new System.Windows.Forms.PictureBox();
            this.IngredientListRichTextBox = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.quantityStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeUsada = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageIng)).BeginInit();
            this.SuspendLayout();
            // 
            // IngredientGridView
            // 
            this.IngredientGridView.AllowUserToAddRows = false;
            this.IngredientGridView.AutoGenerateColumns = false;
            this.IngredientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.priceDataGridViewTextBoxColumn,
            this.ColImage,
            this.quantityStockDataGridViewTextBoxColumn,
            this.ColUnit,
            this.descriptionDataGridViewTextBoxColumn});
            this.IngredientGridView.DataSource = this.ingredientsInfoBindingSource;
            this.IngredientGridView.Location = new System.Drawing.Point(12, 12);
            this.IngredientGridView.MultiSelect = false;
            this.IngredientGridView.Name = "IngredientGridView";
            this.IngredientGridView.ReadOnly = true;
            this.IngredientGridView.RowHeadersVisible = false;
            this.IngredientGridView.Size = new System.Drawing.Size(204, 345);
            this.IngredientGridView.TabIndex = 0;
            this.IngredientGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IngredientGridView_CellClick);
            // 
            // ingredientsInfoBindingSource
            // 
            this.ingredientsInfoBindingSource.DataMember = "IngredientsInfo";
            this.ingredientsInfoBindingSource.DataSource = this.dionisiosDBDataSet;
            // 
            // dionisiosDBDataSet
            // 
            this.dionisiosDBDataSet.DataSetName = "DionisiosDBDataSet";
            this.dionisiosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingredientsInfoTableAdapter
            // 
            this.ingredientsInfoTableAdapter.ClearBeforeFill = true;
            // 
            // ImageIng
            // 
            this.ImageIng.Location = new System.Drawing.Point(222, 12);
            this.ImageIng.Name = "ImageIng";
            this.ImageIng.Size = new System.Drawing.Size(183, 154);
            this.ImageIng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageIng.TabIndex = 1;
            this.ImageIng.TabStop = false;
            // 
            // IngredientListRichTextBox
            // 
            this.IngredientListRichTextBox.Location = new System.Drawing.Point(222, 172);
            this.IngredientListRichTextBox.Name = "IngredientListRichTextBox";
            this.IngredientListRichTextBox.Size = new System.Drawing.Size(183, 98);
            this.IngredientListRichTextBox.TabIndex = 5;
            this.IngredientListRichTextBox.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(222, 276);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(119, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Ingredient";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(222, 334);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(119, 23);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "Finish the list";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(222, 305);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove Ingredient";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColImage
            // 
            this.ColImage.DataPropertyName = "Image";
            this.ColImage.HeaderText = "Image";
            this.ColImage.Name = "ColImage";
            this.ColImage.ReadOnly = true;
            this.ColImage.Visible = false;
            // 
            // quantityStockDataGridViewTextBoxColumn
            // 
            this.quantityStockDataGridViewTextBoxColumn.DataPropertyName = "QuantityStock";
            this.quantityStockDataGridViewTextBoxColumn.HeaderText = "QuantityStock";
            this.quantityStockDataGridViewTextBoxColumn.Name = "quantityStockDataGridViewTextBoxColumn";
            this.quantityStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColUnit
            // 
            this.ColUnit.DataPropertyName = "Unit";
            this.ColUnit.HeaderText = "Unit";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // QuantidadeUsada
            // 
            this.QuantidadeUsada.Location = new System.Drawing.Point(347, 279);
            this.QuantidadeUsada.Name = "QuantidadeUsada";
            this.QuantidadeUsada.Size = new System.Drawing.Size(57, 20);
            this.QuantidadeUsada.TabIndex = 9;
            // 
            // Ingredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(413, 364);
            this.Controls.Add(this.QuantidadeUsada);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.IngredientListRichTextBox);
            this.Controls.Add(this.ImageIng);
            this.Controls.Add(this.IngredientGridView);
            this.MaximizeBox = false;
            this.Name = "Ingredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingredients";
            this.Load += new System.EventHandler(this.Ingredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageIng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView IngredientGridView;
        private DionisiosDBDataSet dionisiosDBDataSet;
        private System.Windows.Forms.BindingSource ingredientsInfoBindingSource;
        private DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter ingredientsInfoTableAdapter;
        private System.Windows.Forms.PictureBox ImageIng;
        private System.Windows.Forms.RichTextBox IngredientListRichTextBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox QuantidadeUsada;
    }
}