namespace Dionisios
{
    partial class AdminPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPage));
            this.BackgroundTab = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RoleCombo = new System.Windows.Forms.ComboBox();
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            this.userAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dionisiosDBDataSet = new Dionisios.DionisiosDBDataSet();
            this.userAccountTableAdapter = new Dionisios.DionisiosDBDataSetTableAdapters.UserAccountTableAdapter();
            this.btnSave = new System.Windows.Forms.Button();
            this.LabelRole = new System.Windows.Forms.Label();
            this.IDcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundTab
            // 
            this.BackgroundTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.BackgroundTab.Location = new System.Drawing.Point(-1, -1);
            this.BackgroundTab.Name = "BackgroundTab";
            this.BackgroundTab.Size = new System.Drawing.Size(898, 42);
            this.BackgroundTab.TabIndex = 1;
            this.BackgroundTab.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.btnHome.Location = new System.Drawing.Point(-1, -1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(127, 42);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnUserManager
            // 
            this.btnUserManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnUserManager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.btnUserManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManager.Font = new System.Drawing.Font("MV Boli", 10F);
            this.btnUserManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.btnUserManager.Location = new System.Drawing.Point(123, -1);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(118, 42);
            this.btnUserManager.TabIndex = 4;
            this.btnUserManager.Text = "User Manager";
            this.btnUserManager.UseVisualStyleBackColor = false;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.pictureBox3.Location = new System.Drawing.Point(123, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(3, 42);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(172)))), ((int)(((byte)(100)))));
            this.pictureBox2.Location = new System.Drawing.Point(238, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(3, 42);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // RoleCombo
            // 
            this.RoleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleCombo.FormattingEnabled = true;
            this.RoleCombo.Items.AddRange(new object[] {
            "ADMIN",
            "MANAGER",
            "EMPLOYEE"});
            this.RoleCombo.Location = new System.Drawing.Point(763, 78);
            this.RoleCombo.Name = "RoleCombo";
            this.RoleCombo.Size = new System.Drawing.Size(121, 21);
            this.RoleCombo.TabIndex = 7;
            // 
            // UsersGridView
            // 
            this.UsersGridView.AllowUserToAddRows = false;
            this.UsersGridView.AllowUserToDeleteRows = false;
            this.UsersGridView.AutoGenerateColumns = false;
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDcol,
            this.Username,
            this.BI,
            this.RoleCol});
            this.UsersGridView.DataSource = this.userAccountBindingSource;
            this.UsersGridView.Location = new System.Drawing.Point(12, 59);
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.Size = new System.Drawing.Size(443, 154);
            this.UsersGridView.TabIndex = 8;
            this.UsersGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserGrid_CellClick);
            // 
            // userAccountBindingSource
            // 
            this.userAccountBindingSource.DataMember = "UserAccount";
            this.userAccountBindingSource.DataSource = this.dionisiosDBDataSet;
            // 
            // dionisiosDBDataSet
            // 
            this.dionisiosDBDataSet.DataSetName = "DionisiosDBDataSet";
            this.dionisiosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userAccountTableAdapter
            // 
            this.userAccountTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // LabelRole
            // 
            this.LabelRole.AutoSize = true;
            this.LabelRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(157)))), ((int)(((byte)(71)))));
            this.LabelRole.Location = new System.Drawing.Point(774, 51);
            this.LabelRole.Name = "LabelRole";
            this.LabelRole.Size = new System.Drawing.Size(93, 24);
            this.LabelRole.TabIndex = 10;
            this.LabelRole.Text = "User Role";
            // 
            // IDcol
            // 
            this.IDcol.DataPropertyName = "ID";
            this.IDcol.HeaderText = "ID";
            this.IDcol.Name = "IDcol";
            this.IDcol.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // BI
            // 
            this.BI.DataPropertyName = "BI";
            this.BI.HeaderText = "BI";
            this.BI.Name = "BI";
            // 
            // RoleCol
            // 
            this.RoleCol.DataPropertyName = "Role";
            this.RoleCol.HeaderText = "Role";
            this.RoleCol.Name = "RoleCol";
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(896, 409);
            this.Controls.Add(this.LabelRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.UsersGridView);
            this.Controls.Add(this.RoleCombo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.BackgroundTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(912, 448);
            this.MinimumSize = new System.Drawing.Size(912, 448);
            this.Name = "AdminPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPage";
            this.Load += new System.EventHandler(this.AdminPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dionisiosDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackgroundTab;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox RoleCombo;
        private System.Windows.Forms.DataGridView UsersGridView;
        private DionisiosDBDataSet dionisiosDBDataSet;
        private System.Windows.Forms.BindingSource userAccountBindingSource;
        private DionisiosDBDataSetTableAdapters.UserAccountTableAdapter userAccountTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label LabelRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn BI;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleCol;
    }
}