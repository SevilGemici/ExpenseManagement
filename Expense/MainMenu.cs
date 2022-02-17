using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            Daylb.Text = DateTime.Today.Day.ToString();
            Monthlb.Text = DateTime.Today.Month.ToString();
            UnameLbl.Text = Login.User;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Reports Obj = new Reports();
            Obj.Show();
        }
    }
}
