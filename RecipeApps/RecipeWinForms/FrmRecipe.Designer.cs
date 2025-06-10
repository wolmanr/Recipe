namespace RecipeWinForms
{
    partial class FrmRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecipe));
            tblMain = new TableLayoutPanel();
            lblcaptionRecipename = new Label();
            lblcaptionPicturerecipe = new Label();
            lblcaptionCalories = new Label();
            lblcaptionCreatedDate = new Label();
            lblcaptionPublishedDate = new Label();
            lblcaptionArchivedDate = new Label();
            lblcaptionRecipeStatus = new Label();
            txtRecipename = new TextBox();
            txtPictureRecipe = new TextBox();
            txtCalories = new TextBox();
            txtPublishedDate = new TextBox();
            txtArchivedDate = new TextBox();
            txtRecipeStatus = new TextBox();
            lblCuisine = new Label();
            lstCuisineName = new ComboBox();
            dtpCreatedDate = new DateTimePicker();
            tsMain = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            lblUser = new Label();
            lstUser = new ComboBox();
            tblMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblcaptionRecipename, 0, 2);
            tblMain.Controls.Add(lblcaptionPicturerecipe, 0, 3);
            tblMain.Controls.Add(lblcaptionCalories, 0, 4);
            tblMain.Controls.Add(lblcaptionCreatedDate, 0, 5);
            tblMain.Controls.Add(lblcaptionPublishedDate, 0, 6);
            tblMain.Controls.Add(lblcaptionArchivedDate, 0, 7);
            tblMain.Controls.Add(lblcaptionRecipeStatus, 0, 8);
            tblMain.Controls.Add(txtRecipename, 1, 2);
            tblMain.Controls.Add(txtPictureRecipe, 1, 3);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(txtPublishedDate, 1, 6);
            tblMain.Controls.Add(txtArchivedDate, 1, 7);
            tblMain.Controls.Add(txtRecipeStatus, 1, 8);
            tblMain.Controls.Add(lblCuisine, 0, 1);
            tblMain.Controls.Add(lstCuisineName, 1, 1);
            tblMain.Controls.Add(dtpCreatedDate, 1, 5);
            tblMain.Controls.Add(lblUser, 0, 0);
            tblMain.Controls.Add(lstUser, 1, 0);
            tblMain.Location = new Point(0, 43);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(444, 244);
            tblMain.TabIndex = 0;
            // 
            // lblcaptionRecipename
            // 
            lblcaptionRecipename.Anchor = AnchorStyles.Left;
            lblcaptionRecipename.AutoSize = true;
            lblcaptionRecipename.Location = new Point(3, 71);
            lblcaptionRecipename.Name = "lblcaptionRecipename";
            lblcaptionRecipename.Size = new Size(102, 21);
            lblcaptionRecipename.TabIndex = 1;
            lblcaptionRecipename.Text = "Recipe Name";
            // 
            // lblcaptionPicturerecipe
            // 
            lblcaptionPicturerecipe.Anchor = AnchorStyles.Left;
            lblcaptionPicturerecipe.AutoSize = true;
            lblcaptionPicturerecipe.Location = new Point(3, 106);
            lblcaptionPicturerecipe.Name = "lblcaptionPicturerecipe";
            lblcaptionPicturerecipe.Size = new Size(58, 21);
            lblcaptionPicturerecipe.TabIndex = 2;
            lblcaptionPicturerecipe.Text = "Picture";
            // 
            // lblcaptionCalories
            // 
            lblcaptionCalories.Anchor = AnchorStyles.Left;
            lblcaptionCalories.AutoSize = true;
            lblcaptionCalories.Location = new Point(3, 141);
            lblcaptionCalories.Name = "lblcaptionCalories";
            lblcaptionCalories.Size = new Size(66, 21);
            lblcaptionCalories.TabIndex = 3;
            lblcaptionCalories.Text = "Calories";
            // 
            // lblcaptionCreatedDate
            // 
            lblcaptionCreatedDate.Anchor = AnchorStyles.Left;
            lblcaptionCreatedDate.AutoSize = true;
            lblcaptionCreatedDate.Location = new Point(3, 176);
            lblcaptionCreatedDate.Name = "lblcaptionCreatedDate";
            lblcaptionCreatedDate.Size = new Size(100, 21);
            lblcaptionCreatedDate.TabIndex = 4;
            lblcaptionCreatedDate.Text = "Created Date";
            // 
            // lblcaptionPublishedDate
            // 
            lblcaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblcaptionPublishedDate.AutoSize = true;
            lblcaptionPublishedDate.Location = new Point(3, 211);
            lblcaptionPublishedDate.Name = "lblcaptionPublishedDate";
            lblcaptionPublishedDate.Size = new Size(114, 21);
            lblcaptionPublishedDate.TabIndex = 5;
            lblcaptionPublishedDate.Text = "Published Date";
            // 
            // lblcaptionArchivedDate
            // 
            lblcaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblcaptionArchivedDate.AutoSize = true;
            lblcaptionArchivedDate.Location = new Point(3, 246);
            lblcaptionArchivedDate.Name = "lblcaptionArchivedDate";
            lblcaptionArchivedDate.Size = new Size(107, 21);
            lblcaptionArchivedDate.TabIndex = 6;
            lblcaptionArchivedDate.Text = "Archived Date";
            // 
            // lblcaptionRecipeStatus
            // 
            lblcaptionRecipeStatus.Anchor = AnchorStyles.Left;
            lblcaptionRecipeStatus.AutoSize = true;
            lblcaptionRecipeStatus.Location = new Point(3, 281);
            lblcaptionRecipeStatus.Name = "lblcaptionRecipeStatus";
            lblcaptionRecipeStatus.Size = new Size(102, 21);
            lblcaptionRecipeStatus.TabIndex = 7;
            lblcaptionRecipeStatus.Text = "Recipe Status";
            // 
            // txtRecipename
            // 
            txtRecipename.Dock = DockStyle.Fill;
            txtRecipename.Location = new Point(123, 67);
            txtRecipename.Name = "txtRecipename";
            txtRecipename.Size = new Size(318, 29);
            txtRecipename.TabIndex = 9;
            // 
            // txtPictureRecipe
            // 
            txtPictureRecipe.Dock = DockStyle.Fill;
            txtPictureRecipe.Location = new Point(123, 102);
            txtPictureRecipe.Name = "txtPictureRecipe";
            txtPictureRecipe.Size = new Size(318, 29);
            txtPictureRecipe.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(123, 137);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(318, 29);
            txtCalories.TabIndex = 11;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Dock = DockStyle.Fill;
            txtPublishedDate.Location = new Point(123, 207);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(318, 29);
            txtPublishedDate.TabIndex = 13;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Dock = DockStyle.Fill;
            txtArchivedDate.Location = new Point(123, 242);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.Size = new Size(318, 29);
            txtArchivedDate.TabIndex = 14;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(123, 277);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(318, 29);
            txtRecipeStatus.TabIndex = 15;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 36);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(103, 21);
            lblCuisine.TabIndex = 16;
            lblCuisine.Text = "Cusine Name";
            // 
            // lstCuisineName
            // 
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(123, 32);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(175, 29);
            lstCuisineName.TabIndex = 17;
            // 
            // dtpCreatedDate
            // 
            dtpCreatedDate.CustomFormat = "mm/dd/yyyy";
            dtpCreatedDate.Format = DateTimePickerFormat.Custom;
            dtpCreatedDate.Location = new Point(123, 172);
            dtpCreatedDate.Name = "dtpCreatedDate";
            dtpCreatedDate.Size = new Size(106, 29);
            dtpCreatedDate.TabIndex = 18;
            // 
            // tsMain
            // 
            tsMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(451, 28);
            tsMain.TabIndex = 1;
            tsMain.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(47, 25);
            btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(58, 25);
            btnDelete.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 4);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(42, 21);
            lblUser.TabIndex = 19;
            lblUser.Text = "User";
            // 
            // lstUser
            // 
            lstUser.FormattingEnabled = true;
            lstUser.Location = new Point(123, 3);
            lstUser.Name = "lstUser";
            lstUser.Size = new Size(175, 29);
            lstUser.TabIndex = 20;
            // 
            // FrmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 292);
            Controls.Add(tsMain);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblcaptionRecipename;
        private Label lblcaptionPicturerecipe;
        private Label lblcaptionCalories;
        private Label lblcaptionCreatedDate;
        private Label lblcaptionPublishedDate;
        private Label lblcaptionArchivedDate;
        private Label lblcaptionRecipeStatus;
        private TextBox txtRecipename;
        private TextBox txtPictureRecipe;
        private TextBox txtCalories;
        private TextBox txtPublishedDate;
        private TextBox txtArchivedDate;
        private TextBox txtRecipeStatus;
        private ToolStrip tsMain;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private Label lblCuisine;
        private ComboBox lstCuisineName;
        private DateTimePicker dtpCreatedDate;
        private Label lblUser;
        private ComboBox lstUser;
    }
}