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
    public partial class ViewExpenses : Form
    {
        public ViewExpenses()
        {
            InitializeComponent();
            ShowExp();
        }

        System.Data.SqlClient.SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevil\Documents\ExpenseDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowExp()
        {
            Con.Open();
            string Query = "select * from ExpenseTbl where ExpUser='"+Login.User+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpensesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void FilterByCat()
        {
            Con.Open();
            string Query = "select * from ExpenseTbl where ExpUser='" + Login.User + "' and ExpCat='"+ExpCatCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpensesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowExp();
        }

        private void ExpCatCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterByCat();
        }
    }
}
