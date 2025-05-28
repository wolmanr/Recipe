using System.Data;
using System.Diagnostics;
using CPUFramework;
using CPUWindowsFormFramework;

namespace RecipeWinForms
{
    public partial class FrmRecipe : Form
    {
        DataTable dtRecipe;
        public FrmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            foreach(Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            } 
        }

        public void ShowForm(int recipeid)
        {
            
            string sql = "select r.*, c.CuisineName from recipe r join Cuisine c on c.Cuisineid = r.CuisineId where r.recipeid = " + recipeid.ToString();
            
            dtRecipe = SQLUtility.GetDataTable(sql);
            if (recipeid == 0)
            {
                dtRecipe.Rows.Add();
            }
            DataTable dtCuisine = SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
            WindowsFormsUtility.SetListButtons(lstCuisineName, dtCuisine, dtRecipe, "Cuisine");
            WindowsFormsUtility.SetControlBinding(txtRecipename, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtPictureRecipe, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipe);
            WindowsFormsUtility.SetControlBinding(dtpCreatedDate, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtPublishedDate, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtArchivedDate, dtRecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtRecipe);
            this.Show();
        }
        private void Save()
        {
            SQLUtility.DebugPrintDataTable(dtRecipe);
            DataRow r = dtRecipe.Rows[0];
            string sql = "";
            int id = (int)r["RecipeId"];

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $" CuisineId = '{r["CuisineId"]}',",
                    $" RecipeName = '{r["RecipeName"]}',",
                    $" Calories = '{r["Calories"]}',",
                    $" CreatedDate = '{r["CreatedDate"]}'",
                    $" where RecipeId = {r["Recipeid"]}"); 
            }
            else
            {
                sql = $"INSERT INTO Recipe (CuisineId, RecipeName, Calories, CreatedDate) " +
                $"SELECT '{r["CuisineId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["CreatedDate"]}'";
            }

            Debug.Print("--------------");
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            int id = (int)dtRecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where Recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }
    }
}
