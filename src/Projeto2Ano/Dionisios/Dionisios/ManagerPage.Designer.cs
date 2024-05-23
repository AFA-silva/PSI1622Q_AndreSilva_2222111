namespace Dionisios
{
    partial class ManagerPage
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
            this.btnHome = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.IngredientAddBtn = new System.Windows.Forms.Button();
            this.IngNameBox = new System.Windows.Forms.TextBox();
            this.QuantityAddedBox = new System.Windows.Forms.TextBox();
            this.StockAddBtn = new System.Windows.Forms.Button();
            this.NewIngImage = new System.Windows.Forms.PictureBox();
            this.IngredientsImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BackgroundTab = new System.Windows.Forms.PictureBox();
            this.IngDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.IngNameB = new System.Windows.Forms.TextBox();
            this.IngUnitB = new System.Windows.Forms.TextBox();
            this.IngQuantityB = new System.Windows.Forms.TextBox();
            this.UnitBox = new System.Windows.Forms.ComboBox();
            this.BtnDeleteIng = new System.Windows.Forms.Button();
            this.IngredientGridView = new System.Windows.Forms.DataGridView();
            this.dionisiosDBDataSet = new Dionisios.DionisiosDBDataSet();
            this.ingredientsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsInfoTableAdapter = new Dionisios.DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.btnHome.Location = new System.Drawing.Point(0, 1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(127, 42);
            this.btnHome.TabIndex = 8;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // StockBtn
            // 
            this.StockBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.StockBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.StockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockBtn.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.StockBtn.Location = new System.Drawing.Point(124, 1);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(118, 42);
            this.StockBtn.TabIndex = 12;
            this.StockBtn.Text = "Stock";
            this.StockBtn.UseVisualStyleBackColor = false;
            // 
            // IngredientAddBtn
            // 
            this.IngredientAddBtn.Location = new System.Drawing.Point(756, 162);
            this.IngredientAddBtn.Name = "IngredientAddBtn";
            this.IngredientAddBtn.Size = new System.Drawing.Size(96, 23);
            this.IngredientAddBtn.TabIndex = 15;
            this.IngredientAddBtn.Text = "New Ingrediente";
            this.IngredientAddBtn.UseVisualStyleBackColor = true;
            this.IngredientAddBtn.Click += new System.EventHandler(this.IngredientAddBtn_Click);
            // 
            // IngNameBox
            // 
            this.IngNameBox.Location = new System.Drawing.Point(756, 79);
            this.IngNameBox.Name = "IngNameBox";
            this.IngNameBox.Size = new System.Drawing.Size(100, 20);
            this.IngNameBox.TabIndex = 16;
            this.IngNameBox.Text = "Name";
            // 
            // QuantityAddedBox
            // 
            this.QuantityAddedBox.Location = new System.Drawing.Point(372, 328);
            this.QuantityAddedBox.Name = "QuantityAddedBox";
            this.QuantityAddedBox.Size = new System.Drawing.Size(100, 20);
            this.QuantityAddedBox.TabIndex = 19;
            // 
            // StockAddBtn
            // 
            this.StockAddBtn.Location = new System.Drawing.Point(372, 351);
            this.StockAddBtn.Name = "StockAddBtn";
            this.StockAddBtn.Size = new System.Drawing.Size(100, 23);
            this.StockAddBtn.TabIndex = 20;
            this.StockAddBtn.Text = "Adicionar Stock";
            this.StockAddBtn.UseVisualStyleBackColor = true;
            // 
            // NewIngImage
            // 
            this.NewIngImage.Image = global::Dionisios.Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
            this.NewIngImage.Location = new System.Drawing.Point(592, 79);
            this.NewIngImage.Name = "NewIngImage";
            this.NewIngImage.Size = new System.Drawing.Size(158, 106);
            this.NewIngImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NewIngImage.TabIndex = 21;
            this.NewIngImage.TabStop = false;
            this.NewIngImage.Click += new System.EventHandler(this.NewIngImage_Click);
            // 
            // IngredientsImage
            // 
            this.IngredientsImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IngredientsImage.Location = new System.Drawing.Point(28, 243);
            this.IngredientsImage.Name = "IngredientsImage";
            this.IngredientsImage.Size = new System.Drawing.Size(175, 159);
            this.IngredientsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IngredientsImage.TabIndex = 14;
            this.IngredientsImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.pictureBox2.Location = new System.Drawing.Point(239, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(3, 42);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.pictureBox3.Location = new System.Drawing.Point(124, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(3, 42);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // BackgroundTab
            // 
            this.BackgroundTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BackgroundTab.Location = new System.Drawing.Point(0, 1);
            this.BackgroundTab.Name = "BackgroundTab";
            this.BackgroundTab.Size = new System.Drawing.Size(898, 42);
            this.BackgroundTab.TabIndex = 7;
            this.BackgroundTab.TabStop = false;
            // 
            // IngDescriptionBox
            // 
            this.IngDescriptionBox.Location = new System.Drawing.Point(209, 243);
            this.IngDescriptionBox.Name = "IngDescriptionBox";
            this.IngDescriptionBox.Size = new System.Drawing.Size(263, 79);
            this.IngDescriptionBox.TabIndex = 22;
            this.IngDescriptionBox.Text = "";
            // 
            // IngNameB
            // 
            this.IngNameB.Location = new System.Drawing.Point(209, 328);
            this.IngNameB.Name = "IngNameB";
            this.IngNameB.Size = new System.Drawing.Size(100, 20);
            this.IngNameB.TabIndex = 23;
            // 
            // IngUnitB
            // 
            this.IngUnitB.Location = new System.Drawing.Point(209, 354);
            this.IngUnitB.Name = "IngUnitB";
            this.IngUnitB.Size = new System.Drawing.Size(100, 20);
            this.IngUnitB.TabIndex = 24;
            // 
            // IngQuantityB
            // 
            this.IngQuantityB.Location = new System.Drawing.Point(209, 380);
            this.IngQuantityB.Name = "IngQuantityB";
            this.IngQuantityB.Size = new System.Drawing.Size(100, 20);
            this.IngQuantityB.TabIndex = 25;
            // 
            // UnitBox
            // 
            this.UnitBox.FormattingEnabled = true;
            this.UnitBox.Items.AddRange(new object[] {
            "g",
            "Kg",
            "mL",
            "L",
            "Unit"});
            this.UnitBox.Location = new System.Drawing.Point(756, 105);
            this.UnitBox.Name = "UnitBox";
            this.UnitBox.Size = new System.Drawing.Size(100, 21);
            this.UnitBox.TabIndex = 26;
            // 
            // BtnDeleteIng
            // 
            this.BtnDeleteIng.Location = new System.Drawing.Point(372, 379);
            this.BtnDeleteIng.Name = "BtnDeleteIng";
            this.BtnDeleteIng.Size = new System.Drawing.Size(100, 23);
            this.BtnDeleteIng.TabIndex = 27;
            this.BtnDeleteIng.Text = "Delete Ingredient";
            this.BtnDeleteIng.UseVisualStyleBackColor = true;
            // 
            // IngredientGridView
            // 
            this.IngredientGridView.AllowUserToAddRows = false;
            this.IngredientGridView.AllowUserToOrderColumns = true;
            this.IngredientGridView.AutoGenerateColumns = false;
            this.IngredientGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.IngredientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCol,
            this.DescriptionCol,
            this.ImageCol,
            this.NameCol,
            this.QuantityCol,
            this.UnitCol});
            this.IngredientGridView.DataSource = this.ingredientsInfoBindingSource;
            this.IngredientGridView.Location = new System.Drawing.Point(28, 64);
            this.IngredientGridView.Name = "IngredientGridView";
            this.IngredientGridView.ReadOnly = true;
            this.IngredientGridView.RowHeadersVisible = false;
            this.IngredientGridView.Size = new System.Drawing.Size(444, 161);
            this.IngredientGridView.TabIndex = 13;
            this.IngredientGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IngredientGridView_CellClick);
            // 
            // dionisiosDBDataSet
            // 
            this.dionisiosDBDataSet.DataSetName = "DionisiosDBDataSet";
            this.dionisiosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingredientsInfoBindingSource
            // 
            this.ingredientsInfoBindingSource.DataMember = "IngredientsInfo";
            this.ingredientsInfoBindingSource.DataSource = this.dionisiosDBDataSet;
            // 
            // ingredientsInfoTableAdapter
            // 
            this.ingredientsInfoTableAdapter.ClearBeforeFill = true;
            // 
            // IDCol
            // 
            this.IDCol.DataPropertyName = "ID";
            this.IDCol.HeaderText = "ID";
            this.IDCol.Name = "IDCol";
            this.IDCol.ReadOnly = true;
            // 
            // DescriptionCol
            // 
            this.DescriptionCol.DataPropertyName = "Description";
            this.DescriptionCol.HeaderText = "Description";
            this.DescriptionCol.Name = "DescriptionCol";
            this.DescriptionCol.ReadOnly = true;
            this.DescriptionCol.Visible = false;
            // 
            // ImageCol
            // 
            this.ImageCol.DataPropertyName = "Image";
            this.ImageCol.HeaderText = "Image";
            this.ImageCol.Name = "ImageCol";
            this.ImageCol.ReadOnly = true;
            this.ImageCol.Visible = false;
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // QuantityCol
            // 
            this.QuantityCol.DataPropertyName = "QuantityStock";
            this.QuantityCol.HeaderText = "Quantity Stock";
            this.QuantityCol.Name = "QuantityCol";
            this.QuantityCol.ReadOnly = true;
            // 
            // UnitCol
            // 
            this.UnitCol.DataPropertyName = "Unit";
            this.UnitCol.HeaderText = "Unit";
            this.UnitCol.Name = "UnitCol";
            this.UnitCol.ReadOnly = true;
            // 
            // ManagerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.BtnDeleteIng);
            this.Controls.Add(this.UnitBox);
            this.Controls.Add(this.IngQuantityB);
            this.Controls.Add(this.IngUnitB);
            this.Controls.Add(this.IngNameB);
            this.Controls.Add(this.IngDescriptionBox);
            this.Controls.Add(this.NewIngImage);
            this.Controls.Add(this.StockAddBtn);
            this.Controls.Add(this.QuantityAddedBox);
            this.Controls.Add(this.IngNameBox);
            this.Controls.Add(this.IngredientAddBtn);
            this.Controls.Add(this.IngredientsImage);
            this.Controls.Add(this.IngredientGridView);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.BackgroundTab);
            this.MaximizeBox = false;
            this.Name = "ManagerPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerPage";
            this.Load += new System.EventHandler(this.ManagerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox BackgroundTab;
        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.PictureBox IngredientsImage;
        private System.Windows.Forms.Button IngredientAddBtn;
        private System.Windows.Forms.TextBox IngNameBox;
        private System.Windows.Forms.TextBox QuantityAddedBox;
        private System.Windows.Forms.Button StockAddBtn;
        private System.Windows.Forms.PictureBox NewIngImage;
        private System.Windows.Forms.RichTextBox IngDescriptionBox;
        private System.Windows.Forms.TextBox IngNameB;
        private System.Windows.Forms.TextBox IngUnitB;
        private System.Windows.Forms.TextBox IngQuantityB;
        private System.Windows.Forms.ComboBox UnitBox;
        private System.Windows.Forms.Button BtnDeleteIng;
        private System.Windows.Forms.DataGridView IngredientGridView;
        private DionisiosDBDataSet dionisiosDBDataSet;
        private System.Windows.Forms.BindingSource ingredientsInfoBindingSource;
        private DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter ingredientsInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionCol;
        private System.Windows.Forms.DataGridViewImageColumn ImageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCol;
    }
}