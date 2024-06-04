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
            this.IngDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.IngNameB = new System.Windows.Forms.TextBox();
            this.IngUnitB = new System.Windows.Forms.TextBox();
            this.IngQuantityB = new System.Windows.Forms.TextBox();
            this.UnitBox = new System.Windows.Forms.ComboBox();
            this.BtnDeleteIng = new System.Windows.Forms.Button();
            this.IngredientGridView = new System.Windows.Forms.DataGridView();
            this.ingredientsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dionisiosDBDataSet = new Dionisios.DionisiosDBDataSet();
            this.ingredientsInfoTableAdapter = new Dionisios.DionisiosDBDataSetTableAdapters.IngredientsInfoTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDrinks = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.TabControl();
            this.TabHome = new System.Windows.Forms.TabPage();
            this.TabStock = new System.Windows.Forms.TabPage();
            this.TabDrinks = new System.Windows.Forms.TabPage();
            this.TabPopular = new System.Windows.Forms.TabPage();
            this.TabIncome = new System.Windows.Forms.TabPage();
            this.TabEmployees = new System.Windows.Forms.TabPage();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).BeginInit();
            this.Menu.SuspendLayout();
            this.TabStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.btnHome.Location = new System.Drawing.Point(-5, -1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(120, 41);
            this.btnHome.TabIndex = 8;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // StockBtn
            // 
            this.StockBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.StockBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.StockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockBtn.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.StockBtn.Location = new System.Drawing.Point(106, -1);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(128, 41);
            this.StockBtn.TabIndex = 12;
            this.StockBtn.Text = "Stock";
            this.StockBtn.UseVisualStyleBackColor = false;
            this.StockBtn.Click += new System.EventHandler(this.StockBtn_Click);
            // 
            // IngredientAddBtn
            // 
            this.IngredientAddBtn.Location = new System.Drawing.Point(598, 154);
            this.IngredientAddBtn.Name = "IngredientAddBtn";
            this.IngredientAddBtn.Size = new System.Drawing.Size(96, 23);
            this.IngredientAddBtn.TabIndex = 15;
            this.IngredientAddBtn.Text = "New Ingrediente";
            this.IngredientAddBtn.UseVisualStyleBackColor = true;
            this.IngredientAddBtn.Visible = false;
            this.IngredientAddBtn.Click += new System.EventHandler(this.IngredientAddBtn_Click);
            // 
            // IngNameBox
            // 
            this.IngNameBox.Location = new System.Drawing.Point(598, 88);
            this.IngNameBox.Name = "IngNameBox";
            this.IngNameBox.Size = new System.Drawing.Size(100, 20);
            this.IngNameBox.TabIndex = 16;
            this.IngNameBox.Text = "Name";
            this.IngNameBox.Visible = false;
            // 
            // QuantityAddedBox
            // 
            this.QuantityAddedBox.Location = new System.Drawing.Point(331, 329);
            this.QuantityAddedBox.Name = "QuantityAddedBox";
            this.QuantityAddedBox.Size = new System.Drawing.Size(100, 20);
            this.QuantityAddedBox.TabIndex = 19;
            this.QuantityAddedBox.Visible = false;
            // 
            // StockAddBtn
            // 
            this.StockAddBtn.Location = new System.Drawing.Point(331, 355);
            this.StockAddBtn.Name = "StockAddBtn";
            this.StockAddBtn.Size = new System.Drawing.Size(100, 23);
            this.StockAddBtn.TabIndex = 20;
            this.StockAddBtn.Text = "Adicionar Stock";
            this.StockAddBtn.UseVisualStyleBackColor = true;
            this.StockAddBtn.Visible = false;
            this.StockAddBtn.Click += new System.EventHandler(this.StockAddBtn_Click);
            // 
            // NewIngImage
            // 
            this.NewIngImage.Image = global::Dionisios.Properties.Resources.Captura_de_ecrã_2024_05_21_144614;
            this.NewIngImage.Location = new System.Drawing.Point(454, 61);
            this.NewIngImage.Name = "NewIngImage";
            this.NewIngImage.Size = new System.Drawing.Size(138, 116);
            this.NewIngImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NewIngImage.TabIndex = 21;
            this.NewIngImage.TabStop = false;
            this.NewIngImage.Visible = false;
            this.NewIngImage.Click += new System.EventHandler(this.NewIngImage_Click);
            // 
            // IngredientsImage
            // 
            this.IngredientsImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IngredientsImage.Location = new System.Drawing.Point(13, 244);
            this.IngredientsImage.Name = "IngredientsImage";
            this.IngredientsImage.Size = new System.Drawing.Size(175, 159);
            this.IngredientsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IngredientsImage.TabIndex = 14;
            this.IngredientsImage.TabStop = false;
            this.IngredientsImage.Visible = false;
            // 
            // IngDescriptionBox
            // 
            this.IngDescriptionBox.Location = new System.Drawing.Point(199, 244);
            this.IngDescriptionBox.Name = "IngDescriptionBox";
            this.IngDescriptionBox.Size = new System.Drawing.Size(232, 79);
            this.IngDescriptionBox.TabIndex = 22;
            this.IngDescriptionBox.Text = "";
            this.IngDescriptionBox.Visible = false;
            // 
            // IngNameB
            // 
            this.IngNameB.Location = new System.Drawing.Point(199, 329);
            this.IngNameB.Name = "IngNameB";
            this.IngNameB.Size = new System.Drawing.Size(100, 20);
            this.IngNameB.TabIndex = 23;
            this.IngNameB.Visible = false;
            // 
            // IngUnitB
            // 
            this.IngUnitB.Location = new System.Drawing.Point(199, 355);
            this.IngUnitB.Name = "IngUnitB";
            this.IngUnitB.Size = new System.Drawing.Size(100, 20);
            this.IngUnitB.TabIndex = 24;
            this.IngUnitB.Visible = false;
            // 
            // IngQuantityB
            // 
            this.IngQuantityB.Location = new System.Drawing.Point(199, 381);
            this.IngQuantityB.Name = "IngQuantityB";
            this.IngQuantityB.Size = new System.Drawing.Size(100, 20);
            this.IngQuantityB.TabIndex = 25;
            this.IngQuantityB.Visible = false;
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
            this.UnitBox.Location = new System.Drawing.Point(598, 61);
            this.UnitBox.Name = "UnitBox";
            this.UnitBox.Size = new System.Drawing.Size(100, 21);
            this.UnitBox.TabIndex = 26;
            this.UnitBox.Visible = false;
            // 
            // BtnDeleteIng
            // 
            this.BtnDeleteIng.Location = new System.Drawing.Point(331, 381);
            this.BtnDeleteIng.Name = "BtnDeleteIng";
            this.BtnDeleteIng.Size = new System.Drawing.Size(100, 23);
            this.BtnDeleteIng.TabIndex = 27;
            this.BtnDeleteIng.Text = "Delete Ingredient";
            this.BtnDeleteIng.UseVisualStyleBackColor = true;
            this.BtnDeleteIng.Visible = false;
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
            this.IngredientGridView.Location = new System.Drawing.Point(13, 61);
            this.IngredientGridView.Name = "IngredientGridView";
            this.IngredientGridView.ReadOnly = true;
            this.IngredientGridView.RowHeadersVisible = false;
            this.IngredientGridView.Size = new System.Drawing.Size(418, 161);
            this.IngredientGridView.TabIndex = 13;
            this.IngredientGridView.Visible = false;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MV Boli", 14.25F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.button1.Location = new System.Drawing.Point(455, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 41);
            this.button1.TabIndex = 28;
            this.button1.Text = "Income";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDrinks
            // 
            this.btnDrinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnDrinks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnDrinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrinks.Font = new System.Drawing.Font("MV Boli", 14.25F);
            this.btnDrinks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.btnDrinks.Location = new System.Drawing.Point(228, -1);
            this.btnDrinks.Name = "btnDrinks";
            this.btnDrinks.Size = new System.Drawing.Size(115, 41);
            this.btnDrinks.TabIndex = 30;
            this.btnDrinks.Text = "Drinks";
            this.btnDrinks.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("MV Boli", 14.25F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.button3.Location = new System.Drawing.Point(583, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 41);
            this.button3.TabIndex = 34;
            this.button3.Text = "Employees";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("MV Boli", 14.25F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.button4.Location = new System.Drawing.Point(340, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 41);
            this.button4.TabIndex = 36;
            this.button4.Text = "Popular";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.Menu.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.Menu.Controls.Add(this.TabHome);
            this.Menu.Controls.Add(this.TabStock);
            this.Menu.Controls.Add(this.TabDrinks);
            this.Menu.Controls.Add(this.TabPopular);
            this.Menu.Controls.Add(this.TabIncome);
            this.Menu.Controls.Add(this.TabEmployees);
            this.Menu.Location = new System.Drawing.Point(-5, -1);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(718, 463);
            this.Menu.TabIndex = 38;
            // 
            // TabHome
            // 
            this.TabHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabHome.Location = new System.Drawing.Point(4, 4);
            this.TabHome.Name = "TabHome";
            this.TabHome.Padding = new System.Windows.Forms.Padding(3);
            this.TabHome.Size = new System.Drawing.Size(710, 437);
            this.TabHome.TabIndex = 0;
            this.TabHome.Text = "Home";
            // 
            // TabStock
            // 
            this.TabStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabStock.Controls.Add(this.IngredientGridView);
            this.TabStock.Controls.Add(this.IngDescriptionBox);
            this.TabStock.Controls.Add(this.IngredientAddBtn);
            this.TabStock.Controls.Add(this.UnitBox);
            this.TabStock.Controls.Add(this.IngNameB);
            this.TabStock.Controls.Add(this.StockAddBtn);
            this.TabStock.Controls.Add(this.NewIngImage);
            this.TabStock.Controls.Add(this.IngUnitB);
            this.TabStock.Controls.Add(this.IngNameBox);
            this.TabStock.Controls.Add(this.IngredientsImage);
            this.TabStock.Controls.Add(this.IngQuantityB);
            this.TabStock.Controls.Add(this.BtnDeleteIng);
            this.TabStock.Controls.Add(this.QuantityAddedBox);
            this.TabStock.Location = new System.Drawing.Point(4, 4);
            this.TabStock.Name = "TabStock";
            this.TabStock.Padding = new System.Windows.Forms.Padding(3);
            this.TabStock.Size = new System.Drawing.Size(710, 437);
            this.TabStock.TabIndex = 1;
            this.TabStock.Text = "Stock";
            // 
            // TabDrinks
            // 
            this.TabDrinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabDrinks.Location = new System.Drawing.Point(4, 4);
            this.TabDrinks.Name = "TabDrinks";
            this.TabDrinks.Padding = new System.Windows.Forms.Padding(3);
            this.TabDrinks.Size = new System.Drawing.Size(710, 437);
            this.TabDrinks.TabIndex = 2;
            this.TabDrinks.Text = "Drinks";
            // 
            // TabPopular
            // 
            this.TabPopular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabPopular.Location = new System.Drawing.Point(4, 4);
            this.TabPopular.Name = "TabPopular";
            this.TabPopular.Padding = new System.Windows.Forms.Padding(3);
            this.TabPopular.Size = new System.Drawing.Size(710, 437);
            this.TabPopular.TabIndex = 3;
            this.TabPopular.Text = "Popular";
            // 
            // TabIncome
            // 
            this.TabIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabIncome.Location = new System.Drawing.Point(4, 4);
            this.TabIncome.Name = "TabIncome";
            this.TabIncome.Padding = new System.Windows.Forms.Padding(3);
            this.TabIncome.Size = new System.Drawing.Size(710, 437);
            this.TabIncome.TabIndex = 4;
            this.TabIncome.Text = "Income";
            // 
            // TabEmployees
            // 
            this.TabEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.TabEmployees.Location = new System.Drawing.Point(4, 4);
            this.TabEmployees.Name = "TabEmployees";
            this.TabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.TabEmployees.Size = new System.Drawing.Size(710, 437);
            this.TabEmployees.TabIndex = 5;
            this.TabEmployees.Text = "Employees";
            // 
            // IDCol
            // 
            this.IDCol.DataPropertyName = "ID";
            this.IDCol.FillWeight = 25F;
            this.IDCol.HeaderText = "ID";
            this.IDCol.Name = "IDCol";
            this.IDCol.ReadOnly = true;
            this.IDCol.Width = 40;
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
            this.NameCol.FillWeight = 30F;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // QuantityCol
            // 
            this.QuantityCol.DataPropertyName = "QuantityStock";
            this.QuantityCol.FillWeight = 25F;
            this.QuantityCol.HeaderText = "Quantity Stock";
            this.QuantityCol.Name = "QuantityCol";
            this.QuantityCol.ReadOnly = true;
            // 
            // UnitCol
            // 
            this.UnitCol.DataPropertyName = "Unit";
            this.UnitCol.FillWeight = 20F;
            this.UnitCol.HeaderText = "Unit";
            this.UnitCol.Name = "UnitCol";
            this.UnitCol.ReadOnly = true;
            // 
            // ManagerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(709, 455);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDrinks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Menu);
            this.MaximizeBox = false;
            this.Name = "ManagerPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerPage";
            this.Load += new System.EventHandler(this.ManagerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NewIngImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).EndInit();
            this.Menu.ResumeLayout(false);
            this.TabStock.ResumeLayout(false);
            this.TabStock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnHome;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDrinks;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage TabHome;
        private System.Windows.Forms.TabPage TabStock;
        private System.Windows.Forms.TabPage TabDrinks;
        private System.Windows.Forms.TabPage TabPopular;
        private System.Windows.Forms.TabPage TabIncome;
        private System.Windows.Forms.TabPage TabEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionCol;
        private System.Windows.Forms.DataGridViewImageColumn ImageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCol;
    }
}