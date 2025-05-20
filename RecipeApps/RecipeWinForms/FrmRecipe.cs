using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUFramework;

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
            
            string sql = "select r.* from recipe r  where r.recipeid = " + recipeid.ToString();
            
            dtRecipe = SQLUtility.GetDataTable(sql);

            if(recipeid == 0)
            {
                dtRecipe.Rows.Add();
            }
            
            txtRecipename.DataBindings.Add("Text", dtRecipe, "RecipeName");
            txtPicture.DataBindings.Add("Text", dtRecipe, "PictureRecipe");
            txtCalaroies.DataBindings.Add("Text", dtRecipe, "Calories");
            dtpCreatedDate.DataBindings.Add("Text", dtRecipe, "CreatedDate");
            dtpPublishedDate.DataBindings.Add("Text", dtRecipe, "PublishedDate");
            dtpArchivedDate.DataBindings.Add("Text", dtRecipe, "ArchivedDate");
            txtRecipeStatus.DataBindings.Add("Text", dtRecipe, "RecipeStatus");
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
                sql = string.Join(Environment.NewLine, $"update Recipe set",

                    $" RecipeName = '{r["RecipeName"]}',",
                    $" Calories = '{r["Calories"]}',",
                    $" CreatedDate = '{r["CreatedDate"]}',",
                    $" PublishedDate = '{r["PublishedDate"]}',",
                    $" ArchivedDate = '{r["ArchivedDate"]}'",
                    $" where RecipeId = {r["RecipeId"]}");
            }
            else
            {
                sql = "INSERT INTO Recipe (RecipeName, Calories, CreatedDate, PublishedDate, ArchivedDate) ";
                sql += $"VALUES ('{r["RecipeName"]}', {r["Calories"]}, '{r["CreatedDate"]}', '{r["PublishedDate"]}', '{r["ArchivedDate"]}')";
            }
            Debug.Print("--------------");
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }


        private void Delete()
        {

        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
    }
}
