namespace RecipeWinForms
{
    partial class RecipeSearch
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
            tblMain = new TableLayoutPanel();
            tblSearch = new TableLayoutPanel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblRecipeName = new Label();
            GRecipe = new DataGridView();
            tblMain.SuspendLayout();
            tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GRecipe).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            tblMain.Controls.Add(tblSearch, 0, 0);
            tblMain.Controls.Add(GRecipe, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6531162F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 88.3468857F));
            tblMain.Size = new Size(870, 422);
            tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            tblSearch.ColumnCount = 3;
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.Controls.Add(btnSearch, 2, 0);
            tblSearch.Controls.Add(txtSearch, 1, 0);
            tblSearch.Controls.Add(lblRecipeName, 0, 0);
            tblSearch.Location = new Point(4, 4);
            tblSearch.Margin = new Padding(4);
            tblSearch.Name = "tblSearch";
            tblSearch.RowCount = 1;
            tblSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSearch.Size = new Size(414, 41);
            tblSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left;
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(283, 5);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(117, 31);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left;
            txtSearch.Location = new Point(112, 6);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(163, 29);
            txtSearch.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 10);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(102, 21);
            lblRecipeName.TabIndex = 2;
            lblRecipeName.Text = "Recipe Name";
            // 
            // GRecipe
            // 
            GRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GRecipe.Dock = DockStyle.Fill;
            GRecipe.Location = new Point(3, 52);
            GRecipe.Name = "GRecipe";
            GRecipe.Size = new Size(864, 367);
            GRecipe.TabIndex = 1;
            // 
            // RecipeSearch
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 422);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "RecipeSearch";
            Text = "RecipeApp";
            tblMain.ResumeLayout(false);
            tblSearch.ResumeLayout(false);
            tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GRecipe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView GRecipe;
        private Label lblRecipeName;
    }
}