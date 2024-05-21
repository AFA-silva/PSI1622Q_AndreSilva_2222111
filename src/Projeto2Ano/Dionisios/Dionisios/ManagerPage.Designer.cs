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
            this.IngredientGridView = new System.Windows.Forms.DataGridView();
            this.ingredientsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dionisiosDBDataSet = new Dionisios.DionisiosDBDataSet();
            this.ingredientsInfoTableAdapter = new Dionisios.DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter();
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
            this.IngPriceB = new System.Windows.Forms.TextBox();
            this.IngQuantityB = new System.Windows.Forms.TextBox();
            this.dionisiosDBDataSet1 = new Dionisios.DionisiosDBDataSet1();
            this.ingredientsInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsInfoTableAdapter1 = new Dionisios.DionisiosDBDataSet1TableAdapters.IngredientsInfoTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource1)).BeginInit();
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
            // IngredientGridView
            // 
            this.IngredientGridView.AllowUserToAddRows = false;
            this.IngredientGridView.AllowUserToOrderColumns = true;
            this.IngredientGridView.AutoGenerateColumns = false;
            this.IngredientGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.IngredientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Unit,
            this.nameDataGridViewTextBoxColumn,
            this.quantityStockDataGridViewTextBoxColumn});
            this.IngredientGridView.DataSource = this.ingredientsInfoBindingSource1;
            this.IngredientGridView.Location = new System.Drawing.Point(28, 64);
            this.IngredientGridView.Name = "IngredientGridView";
            this.IngredientGridView.ReadOnly = true;
            this.IngredientGridView.Size = new System.Drawing.Size(444, 161);
            this.IngredientGridView.TabIndex = 13;
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
            this.StockAddBtn.Location = new System.Drawing.Point(372, 354);
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
            this.IngredientsImage.Location = new System.Drawing.Point(28, 243);
            this.IngredientsImage.Name = "IngredientsImage";
            this.IngredientsImage.Size = new System.Drawing.Size(175, 159);
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
            // IngPriceB
            // 
            this.IngPriceB.Location = new System.Drawing.Point(209, 354);
            this.IngPriceB.Name = "IngPriceB";
            this.IngPriceB.Size = new System.Drawing.Size(100, 20);
            this.IngPriceB.TabIndex = 24;
            // 
            // IngQuantityB
            // 
            this.IngQuantityB.Location = new System.Drawing.Point(209, 380);
            this.IngQuantityB.Name = "IngQuantityB";
            this.IngQuantityB.Size = new System.Drawing.Size(100, 20);
            this.IngQuantityB.TabIndex = 25;
            // 
            // dionisiosDBDataSet1
            // 
            this.dionisiosDBDataSet1.DataSetName = "DionisiosDBDataSet1";
            this.dionisiosDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingredientsInfoBindingSource1
            // 
            this.ingredientsInfoBindingSource1.DataMember = "IngredientsInfo";
            this.ingredientsInfoBindingSource1.DataSource = this.dionisiosDBDataSet1;
            // 
            // ingredientsInfoTableAdapter1
            // 
            this.ingredientsInfoTableAdapter1.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityStockDataGridViewTextBoxColumn
            // 
            this.quantityStockDataGridViewTextBoxColumn.DataPropertyName = "QuantityStock";
            this.quantityStockDataGridViewTextBoxColumn.HeaderText = "QuantityStock";
            this.quantityStockDataGridViewTextBoxColumn.Name = "quantityStockDataGridViewTextBoxColumn";
            this.quantityStockDataGridViewTextBoxColumn.ReadOnly = true;
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
            // ManagerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.UnitBox);
            this.Controls.Add(this.IngQuantityB);
            this.Controls.Add(this.IngPriceB);
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
            this.Text = "ManagerPage";
            this.Load += new System.EventHandler(this.ManagerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox BackgroundTab;
        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.DataGridView IngredientGridView;
        private DionisiosDBDataSet dionisiosDBDataSet;
        private System.Windows.Forms.BindingSource ingredientsInfoBindingSource;
        private DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter ingredientsInfoTableAdapter;
        private System.Windows.Forms.PictureBox IngredientsImage;
        private System.Windows.Forms.Button IngredientAddBtn;
        private System.Windows.Forms.TextBox IngNameBox;
        private System.Windows.Forms.TextBox QuantityAddedBox;
        private System.Windows.Forms.Button StockAddBtn;
        private System.Windows.Forms.PictureBox NewIngImage;
        private System.Windows.Forms.RichTextBox IngDescriptionBox;
        private System.Windows.Forms.TextBox IngNameB;
        private System.Windows.Forms.TextBox IngPriceB;
        private System.Windows.Forms.TextBox IngQuantityB;
        private DionisiosDBDataSet1 dionisiosDBDataSet1;
        private System.Windows.Forms.BindingSource ingredientsInfoBindingSource1;
        private DionisiosDBDataSet1TableAdapters.IngredientsInfoTableAdapter ingredientsInfoTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox UnitBox;
    }
}