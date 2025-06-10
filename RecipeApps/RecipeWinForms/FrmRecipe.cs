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

            dtRecipe = Recipe.Load(recipeid);
            
            if (recipeid == 0)
            {
                dtRecipe.Rows.Add();
            }
            DataTable dtCuisine = SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
            WindowsFormsUtility.SetListButtons(lstCuisineName, dtCuisine, dtRecipe, "Cuisine", "CuisineName");
            DataTable dtUser = SQLUtility.GetDataTable("select UserId, UserName from users");
            WindowsFormsUtility.SetListButtons(lstUser, dtUser, dtRecipe, "User", "UserName");
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
            Recipe.Save(dtRecipe);
        }

        private void Delete()
        {
            Recipe.Delete(dtRecipe);
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
