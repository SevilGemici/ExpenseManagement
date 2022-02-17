﻿using System;
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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevil\Documents\ExpenseDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            ExpNameTb.Text = "";
            ExpDescTb.Text = "";
            ExpAmtTb.Text = "";
            ExpCatCb.SelectedIndex = 0;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (ExpNameTb.Text == "" || ExpAmtTb.Text == "" || ExpDescTb.Text == "" || ExpCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into ExpenseTbl (ExpName,ExpAmt,ExpCat,ExpDate,ExpComment,ExpUser) values(@EN,@EA,@EC,@ED,@ECo,@EU)", Con);
                cmd.Parameters.AddWithValue("@EN", ExpNameTb.Text);
                cmd.Parameters.AddWithValue("@EA", ExpAmtTb.Text);
                cmd.Parameters.AddWithValue("@EC", ExpCatCb.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ED", ExpDate.Value.Date);
                cmd.Parameters.AddWithValue("@ECo", ExpDescTb.Text);
                cmd.Parameters.AddWithValue("@EU", Login.User);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Expense Added");
                Con.Close();                
                Clear();
            }
        }
    }
}
