using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using CPUFramework;
using CPUWindowsFormFramework;



namespace RecipeWinForms
{
    public partial class FrmRecipe : Form
    {
        BindingSource bindsource = new();
        DataTable dtRecipe;
        public FrmRecipe()
        {
            InitializeComponent();

            dtpCreatedDate.Format = DateTimePickerFormat.Custom;
            dtpCreatedDate.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            dtpCreatedDate.ShowUpDown = true;

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
            bindsource.DataSource = dtRecipe;

            if (recipeid == 0)
            {
                dtRecipe.Rows.Add();
                dtRecipe.Rows[0]["CreatedDate"] = DateTime.Now;
            }

            DataTable dtCuisine = SQLUtility.GetDataTable("select CuisineId, CuisineName from Cuisine");
            if (lstCuisineName != null)
                WindowsFormsUtility.SetListButtons(lstCuisineName, dtCuisine, dtRecipe, "Cuisine", "CuisineName");

            DataTable dtUser = SQLUtility.GetDataTable("select UserId, UserName from users");
            if (lstUser != null)
                WindowsFormsUtility.SetListButtons(lstUser, dtUser, dtRecipe, "User", "UserName");

            WindowsFormsUtility.SetControlBinding(txtRecipename, bindsource);
            WindowsFormsUtility.SetControlBinding(txtPictureRecipe, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormsUtility.SetControlBinding(dtpCreatedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, bindsource);

            this.Show();
        }
        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtRecipe);
            }
            catch (Exception ex)
            {
                string friendlyMsg = SQLUtility.ParseConstraintMsg(ex.Message);
                MessageBox.Show(friendlyMsg, "Error");
            }
            finally {
                Application.UseWaitCursor = false;
            }
        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this Recipe", "RecordKeeper", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtRecipe);
                this.Close();
            }
            catch (Exception ex)
            {
                string friendlyMsg = SQLUtility.ParseConstraintMsg(ex.Message);
                MessageBox.Show(friendlyMsg, "Error");
            }
            finally {
                Application.UseWaitCursor = false;
                
            }
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
