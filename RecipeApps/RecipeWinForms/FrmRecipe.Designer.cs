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
            txtCreatedDate = new TextBox();
            txtPublishedDate = new TextBox();
            txtArchivedDate = new TextBox();
            txtRecipeStatus = new TextBox();
            lblCuisine = new Label();
            lstCuisineName = new ComboBox();
            tsMain = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tblMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(lblcaptionRecipename, 0, 1);
            tblMain.Controls.Add(lblcaptionPicturerecipe, 0, 2);
            tblMain.Controls.Add(lblcaptionCalories, 0, 3);
            tblMain.Controls.Add(lblcaptionCreatedDate, 0, 4);
            tblMain.Controls.Add(lblcaptionPublishedDate, 0, 5);
            tblMain.Controls.Add(lblcaptionArchivedDate, 0, 6);
            tblMain.Controls.Add(lblcaptionRecipeStatus, 0, 7);
            tblMain.Controls.Add(txtRecipename, 1, 1);
            tblMain.Controls.Add(txtPictureRecipe, 1, 2);
            tblMain.Controls.Add(txtCalories, 1, 3);
            tblMain.Controls.Add(txtCreatedDate, 1, 4);
            tblMain.Controls.Add(txtPublishedDate, 1, 5);
            tblMain.Controls.Add(txtArchivedDate, 1, 6);
            tblMain.Controls.Add(txtRecipeStatus, 1, 7);
            tblMain.Controls.Add(lblCuisine, 0, 0);
            tblMain.Controls.Add(lstCuisineName, 1, 0);
            tblMain.Location = new Point(0, 43);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
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
            lblcaptionRecipename.Location = new Point(3, 42);
            lblcaptionRecipename.Name = "lblcaptionRecipename";
            lblcaptionRecipename.Size = new Size(102, 21);
            lblcaptionRecipename.TabIndex = 1;
            lblcaptionRecipename.Text = "Recipe Name";
            // 
            // lblcaptionPicturerecipe
            // 
            lblcaptionPicturerecipe.Anchor = AnchorStyles.Left;
            lblcaptionPicturerecipe.AutoSize = true;
            lblcaptionPicturerecipe.Location = new Point(3, 77);
            lblcaptionPicturerecipe.Name = "lblcaptionPicturerecipe";
            lblcaptionPicturerecipe.Size = new Size(58, 21);
            lblcaptionPicturerecipe.TabIndex = 2;
            lblcaptionPicturerecipe.Text = "Picture";
            // 
            // lblcaptionCalories
            // 
            lblcaptionCalories.Anchor = AnchorStyles.Left;
            lblcaptionCalories.AutoSize = true;
            lblcaptionCalories.Location = new Point(3, 112);
            lblcaptionCalories.Name = "lblcaptionCalories";
            lblcaptionCalories.Size = new Size(66, 21);
            lblcaptionCalories.TabIndex = 3;
            lblcaptionCalories.Text = "Calories";
            // 
            // lblcaptionCreatedDate
            // 
            lblcaptionCreatedDate.Anchor = AnchorStyles.Left;
            lblcaptionCreatedDate.AutoSize = true;
            lblcaptionCreatedDate.Location = new Point(3, 147);
            lblcaptionCreatedDate.Name = "lblcaptionCreatedDate";
            lblcaptionCreatedDate.Size = new Size(100, 21);
            lblcaptionCreatedDate.TabIndex = 4;
            lblcaptionCreatedDate.Text = "Created Date";
            // 
            // lblcaptionPublishedDate
            // 
            lblcaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblcaptionPublishedDate.AutoSize = true;
            lblcaptionPublishedDate.Location = new Point(3, 182);
            lblcaptionPublishedDate.Name = "lblcaptionPublishedDate";
            lblcaptionPublishedDate.Size = new Size(114, 21);
            lblcaptionPublishedDate.TabIndex = 5;
            lblcaptionPublishedDate.Text = "Published Date";
            // 
            // lblcaptionArchivedDate
            // 
            lblcaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblcaptionArchivedDate.AutoSize = true;
            lblcaptionArchivedDate.Location = new Point(3, 217);
            lblcaptionArchivedDate.Name = "lblcaptionArchivedDate";
            lblcaptionArchivedDate.Size = new Size(107, 21);
            lblcaptionArchivedDate.TabIndex = 6;
            lblcaptionArchivedDate.Text = "Archived Date";
            // 
            // lblcaptionRecipeStatus
            // 
            lblcaptionRecipeStatus.Anchor = AnchorStyles.Left;
            lblcaptionRecipeStatus.AutoSize = true;
            lblcaptionRecipeStatus.Location = new Point(3, 252);
            lblcaptionRecipeStatus.Name = "lblcaptionRecipeStatus";
            lblcaptionRecipeStatus.Size = new Size(102, 21);
            lblcaptionRecipeStatus.TabIndex = 7;
            lblcaptionRecipeStatus.Text = "Recipe Status";
            // 
            // txtRecipename
            // 
            txtRecipename.Dock = DockStyle.Fill;
            txtRecipename.Location = new Point(123, 38);
            txtRecipename.Name = "txtRecipename";
            txtRecipename.Size = new Size(318, 29);
            txtRecipename.TabIndex = 9;
            // 
            // txtPictureRecipe
            // 
            txtPictureRecipe.Dock = DockStyle.Fill;
            txtPictureRecipe.Location = new Point(123, 73);
            txtPictureRecipe.Name = "txtPictureRecipe";
            txtPictureRecipe.Size = new Size(318, 29);
            txtPictureRecipe.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(123, 108);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(318, 29);
            txtCalories.TabIndex = 11;
            // 
            // txtCreatedDate
            // 
            txtCreatedDate.Dock = DockStyle.Fill;
            txtCreatedDate.Location = new Point(123, 143);
            txtCreatedDate.Name = "txtCreatedDate";
            txtCreatedDate.Size = new Size(318, 29);
            txtCreatedDate.TabIndex = 12;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Dock = DockStyle.Fill;
            txtPublishedDate.Location = new Point(123, 178);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(318, 29);
            txtPublishedDate.TabIndex = 13;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Dock = DockStyle.Fill;
            txtArchivedDate.Location = new Point(123, 213);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.Size = new Size(318, 29);
            txtArchivedDate.TabIndex = 14;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(123, 248);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(318, 29);
            txtRecipeStatus.TabIndex = 15;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 7);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(103, 21);
            lblCuisine.TabIndex = 16;
            lblCuisine.Text = "Cusine Name";
            // 
            // lstCuisineName
            // 
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(123, 3);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(175, 29);
            lstCuisineName.TabIndex = 17;
            // 
            // tsMain
            // 
            tsMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(447, 28);
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
            // FrmRecipe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 283);
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
        private TextBox txtCreatedDate;
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
    }
}