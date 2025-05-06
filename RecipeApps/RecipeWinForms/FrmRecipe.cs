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
        public FrmRecipe()
        {
            InitializeComponent();
           
        }
        public void ShowForm(int recipeid)
        {
            
            string sql = "select r.* from recipe r  where r.recipeid = " + recipeid.ToString();
            
            DataTable dt = SQLUtility.GetDataTable(sql);
            
            txtRecipename.DataBindings.Add("Text", dt, "RecipeName");
            txtPicture.DataBindings.Add("Text", dt, "PictureRecipe");
            txtCalaroies.DataBindings.Add("Text", dt, "Calories");
            txtCreatedDate.DataBindings.Add("Text", dt, "CreatedDate");
            txtPublishedDate.DataBindings.Add("Text", dt, "PublishedDate");
            txtArchivedDate.DataBindings.Add("Text", dt, "ArchivedDate");
            txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            this.Show();
        }
    }
}
