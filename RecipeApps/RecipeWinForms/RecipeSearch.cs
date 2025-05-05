using System.Data;
using System.Diagnostics;
using CPUFramework;
using Microsoft.Data.SqlClient;
namespace RecipeWinForms
{
    public partial class RecipeSearch : Form
    {
        public RecipeSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            GRecipe.DoubleClick += GRecipe_DoubleClick;
        }

        private void SearchForRecipe(string recipename)
        {
            string sql = "select * from recipe r where r.recipename like '%" + recipename + "%'";
            Debug.Print(sql);
            DataTable dt = GetDataTable(sql);
            GRecipe.DataSource = dt;
            
        }

        private void GRecipe_DoubleClick(object? sender, EventArgs e)
        {
            
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtSearch.Text);
        }
        private string GetConnectionString()
        {
            var s = "Server=(localdb)\\MSSQLLocalDB;Database=RecipeDB;Trusted_Connection=True;";
            return s;
        }
        private  DataTable  GetDataTable(string sqlstatement)
        {
            
            DataTable dt = new();
            SqlConnection conn = new();
            conn.ConnectionString = GetConnectionString();
            conn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstatement;
            var dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}
