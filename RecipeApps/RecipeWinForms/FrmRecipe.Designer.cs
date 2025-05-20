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
            txtPicture = new TextBox();
            txtCalaroies = new TextBox();
            txtRecipeStatus = new TextBox();
            dtpCreatedDate = new DateTimePicker();
            dtpPublishedDate = new DateTimePicker();
            dtpArchivedDate = new DateTimePicker();
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
            tblMain.Controls.Add(lblcaptionRecipename, 0, 0);
            tblMain.Controls.Add(lblcaptionPicturerecipe, 0, 1);
            tblMain.Controls.Add(lblcaptionCalories, 0, 2);
            tblMain.Controls.Add(lblcaptionCreatedDate, 0, 3);
            tblMain.Controls.Add(lblcaptionPublishedDate, 0, 4);
            tblMain.Controls.Add(lblcaptionArchivedDate, 0, 5);
            tblMain.Controls.Add(lblcaptionRecipeStatus, 0, 6);
            tblMain.Controls.Add(txtRecipename, 1, 0);
            tblMain.Controls.Add(txtPicture, 1, 1);
            tblMain.Controls.Add(txtCalaroies, 1, 2);
            tblMain.Controls.Add(txtRecipeStatus, 1, 6);
            tblMain.Controls.Add(dtpCreatedDate, 1, 3);
            tblMain.Controls.Add(dtpPublishedDate, 1, 4);
            tblMain.Controls.Add(dtpArchivedDate, 1, 5);
            tblMain.Location = new Point(0, 51);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(444, 247);
            tblMain.TabIndex = 0;
            // 
            // lblcaptionRecipename
            // 
            lblcaptionRecipename.Anchor = AnchorStyles.Left;
            lblcaptionRecipename.AutoSize = true;
            lblcaptionRecipename.Location = new Point(3, 7);
            lblcaptionRecipename.Name = "lblcaptionRecipename";
            lblcaptionRecipename.Size = new Size(102, 21);
            lblcaptionRecipename.TabIndex = 1;
            lblcaptionRecipename.Text = "Recipe Name";
            // 
            // lblcaptionPicturerecipe
            // 
            lblcaptionPicturerecipe.Anchor = AnchorStyles.Left;
            lblcaptionPicturerecipe.AutoSize = true;
            lblcaptionPicturerecipe.Location = new Point(3, 42);
            lblcaptionPicturerecipe.Name = "lblcaptionPicturerecipe";
            lblcaptionPicturerecipe.Size = new Size(58, 21);
            lblcaptionPicturerecipe.TabIndex = 2;
            lblcaptionPicturerecipe.Text = "Picture";
            // 
            // lblcaptionCalories
            // 
            lblcaptionCalories.Anchor = AnchorStyles.Left;
            lblcaptionCalories.AutoSize = true;
            lblcaptionCalories.Location = new Point(3, 77);
            lblcaptionCalories.Name = "lblcaptionCalories";
            lblcaptionCalories.Size = new Size(66, 21);
            lblcaptionCalories.TabIndex = 3;
            lblcaptionCalories.Text = "Calories";
            // 
            // lblcaptionCreatedDate
            // 
            lblcaptionCreatedDate.Anchor = AnchorStyles.Left;
            lblcaptionCreatedDate.AutoSize = true;
            lblcaptionCreatedDate.Location = new Point(3, 112);
            lblcaptionCreatedDate.Name = "lblcaptionCreatedDate";
            lblcaptionCreatedDate.Size = new Size(100, 21);
            lblcaptionCreatedDate.TabIndex = 4;
            lblcaptionCreatedDate.Text = "Created Date";
            // 
            // lblcaptionPublishedDate
            // 
            lblcaptionPublishedDate.Anchor = AnchorStyles.Left;
            lblcaptionPublishedDate.AutoSize = true;
            lblcaptionPublishedDate.Location = new Point(3, 147);
            lblcaptionPublishedDate.Name = "lblcaptionPublishedDate";
            lblcaptionPublishedDate.Size = new Size(114, 21);
            lblcaptionPublishedDate.TabIndex = 5;
            lblcaptionPublishedDate.Text = "Published Date";
            // 
            // lblcaptionArchivedDate
            // 
            lblcaptionArchivedDate.Anchor = AnchorStyles.Left;
            lblcaptionArchivedDate.AutoSize = true;
            lblcaptionArchivedDate.Location = new Point(3, 182);
            lblcaptionArchivedDate.Name = "lblcaptionArchivedDate";
            lblcaptionArchivedDate.Size = new Size(107, 21);
            lblcaptionArchivedDate.TabIndex = 6;
            lblcaptionArchivedDate.Text = "Archived Date";
            // 
            // lblcaptionRecipeStatus
            // 
            lblcaptionRecipeStatus.Anchor = AnchorStyles.Left;
            lblcaptionRecipeStatus.AutoSize = true;
            lblcaptionRecipeStatus.Location = new Point(3, 218);
            lblcaptionRecipeStatus.Name = "lblcaptionRecipeStatus";
            lblcaptionRecipeStatus.Size = new Size(102, 21);
            lblcaptionRecipeStatus.TabIndex = 7;
            lblcaptionRecipeStatus.Text = "Recipe Status";
            // 
            // txtRecipename
            // 
            txtRecipename.Dock = DockStyle.Fill;
            txtRecipename.Location = new Point(123, 3);
            txtRecipename.Name = "txtRecipename";
            txtRecipename.Size = new Size(318, 29);
            txtRecipename.TabIndex = 9;
            // 
            // txtPicture
            // 
            txtPicture.Dock = DockStyle.Fill;
            txtPicture.Location = new Point(123, 38);
            txtPicture.Name = "txtPicture";
            txtPicture.Size = new Size(318, 29);
            txtPicture.TabIndex = 10;
            // 
            // txtCalaroies
            // 
            txtCalaroies.Dock = DockStyle.Fill;
            txtCalaroies.Location = new Point(123, 73);
            txtCalaroies.Name = "txtCalaroies";
            txtCalaroies.Size = new Size(318, 29);
            txtCalaroies.TabIndex = 11;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(123, 213);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(318, 29);
            txtRecipeStatus.TabIndex = 15;
            // 
            // dtpCreatedDate
            // 
            dtpCreatedDate.DropDownAlign = LeftRightAlignment.Right;
            dtpCreatedDate.Format = DateTimePickerFormat.Short;
            dtpCreatedDate.Location = new Point(123, 108);
            dtpCreatedDate.Name = "dtpCreatedDate";
            dtpCreatedDate.Size = new Size(104, 29);
            dtpCreatedDate.TabIndex = 16;
            // 
            // dtpPublishedDate
            // 
            dtpPublishedDate.Format = DateTimePickerFormat.Short;
            dtpPublishedDate.Location = new Point(123, 143);
            dtpPublishedDate.Name = "dtpPublishedDate";
            dtpPublishedDate.Size = new Size(104, 29);
            dtpPublishedDate.TabIndex = 17;
            // 
            // dtpArchivedDate
            // 
            dtpArchivedDate.Format = DateTimePickerFormat.Short;
            dtpArchivedDate.Location = new Point(123, 178);
            dtpArchivedDate.Name = "dtpArchivedDate";
            dtpArchivedDate.Size = new Size(104, 29);
            dtpArchivedDate.TabIndex = 18;
            // 
            // tsMain
            // 
            tsMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Size = new Size(446, 28);
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
            ClientSize = new Size(446, 299);
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
        private TextBox txtPicture;
        private TextBox txtCalaroies;
        private TextBox txtRecipeStatus;
        private ToolStrip tsMain;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private DateTimePicker dtpCreatedDate;
        private DateTimePicker dtpPublishedDate;
        private DateTimePicker dtpArchivedDate;
    }
}