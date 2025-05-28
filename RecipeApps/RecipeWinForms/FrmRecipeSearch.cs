using System.Data;
using System.Diagnostics;
using CPUFramework;
using Microsoft.Data.SqlClient;
namespace RecipeWinForms
{
    public partial class FrmRecipeSearch : Form
    {
        public FrmRecipeSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            GRecipe.DoubleClick += GRecipe_DoubleClick;
            btnNew.Click += BtnNew_Click;
            FormatGrid();
        }
        private void SearchForRecipe(string recipename)
        {
            string sql = "select r.recipeID, r.recipename, r.calories from recipe r where r.recipename like '%" + recipename + "%'";
            Debug.Print(sql);
            DataTable dt = SQLUtility.GetDataTable(sql);
            GRecipe.DataSource = dt;
            
        }
        private void FormatGrid()
        {
            GRecipe.AllowUserToAddRows = false;
            GRecipe.ReadOnly = true;
            GRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = (int)GRecipe.Rows[rowindex].Cells["RecipeID"].Value;
            }
            FrmRecipe frm = new();
            frm.ShowForm(id);
        }
        private void GRecipe_DoubleClick(object? sender, EventArgs e)
        {
            int rowIndex = GRecipe.CurrentCell.RowIndex;
            ShowRecipeForm(rowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtSearch.Text);
        }
        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }
    }
}
