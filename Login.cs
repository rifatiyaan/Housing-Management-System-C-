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
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminLogin form = new AdminLogin();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dashboard form = new Dashboard();
            //form.Show();
            //this.Hide();


            string name = richTextBox1.Text;
            string password = richTextBox2.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM clientDB where name='" + richTextBox1.Text + "' AND password='" + richTextBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Dashboard form = new Dashboard();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login ! Please check username and password");
            }
            con.Close();

        }
    }
}
