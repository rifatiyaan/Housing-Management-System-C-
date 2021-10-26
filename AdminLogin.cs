using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HRManagement
{
    public partial class AdminLogin : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public AdminLogin()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
        }
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //AdminDashboard form = new AdminDashboard();
            //form.Show();
            //this.Hide();


            string name = richTextBox1.Text;
            string password = richTextBox2.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM adminDB where name='" + richTextBox1.Text + "' AND password='" + richTextBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                AdminDashboard form = new AdminDashboard();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin Login Error ! Check username and password");
            }
            con.Close();

        }


    }
}
