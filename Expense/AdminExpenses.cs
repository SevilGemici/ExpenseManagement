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
    public partial class AdminExpenses : Form
    {
        public AdminExpenses()
        {
            InitializeComponent();
            ShowExpenses();
        }

        System.Data.SqlClient.SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevil\Documents\ExpenseDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowExpenses()
        {
            Con.Open();
            string Query = "select * from ExpenseTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterByCat()
        {
            Con.Open();
            string Query = "select * from ExpenseTbl where ExpCat='" + ExpCatCb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AExpenseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShowExpenses();
        }

        private void ExpCatCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterByCat();
        }
    }
}
