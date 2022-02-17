using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            GetMaxExp();
            GetMinExp();
            GetAvgExp();
            GetTotExp();
            GetBestCat();
        }

        System.Data.SqlClient.SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevil\Documents\ExpenseDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetMaxExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select MAX(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MaxLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GetMinExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select MIN(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MinLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GetAvgExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select SUM(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select COUNT(*) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            sda.Fill(dt);
            sda1.Fill(dt1);

            Double Avg = Convert.ToDouble(dt.Rows[0][0].ToString()) / Convert.ToDouble(dt1.Rows[0][0].ToString());
            AvgLbl.Text = Avg.ToString();
            CountLbl.Text = dt1.Rows[0][0].ToString()+"Expenses";
            Con.Close();
        }
        private void GetTotExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select SUM(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TotLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GetTotExpByCat()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select SUM(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "' and ExpCat='"+Catcb.SelectedItem.ToString()+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TotByCatLbl.Text = dt.Rows[0][0].ToString();
            TotByCatLbl.Visible = true;
            Con.Close();
        }

        private void GetBestCat()
        {
            Con.Open();
            string InnerQuery = "select max(ExpAmt) from ExpenseTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);
            string Query="select ExpCat from ExpenseTbl where ExpAmt='"+dt1.Rows[0][0].ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HighCatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void GetMinCat()
        {
            Con.Open();
            string InnerQuery = "select min(ExpAmt) from ExpenseTbl";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
            sda1.Fill(dt1);
            string Query = "select ExpCat from ExpenseTbl where ExpAmt='" + dt1.Rows[0][0].ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            LowCatLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Catcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTotExpByCat();
        }
    }
}
