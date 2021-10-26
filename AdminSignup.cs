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
    public partial class AdminSignup : Form
    {
        public AdminSignup()
        {
            InitializeComponent();
        }

        private void AdminSignup_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name, username, email, password, contact;

 
            name = richTextBox0.Text;
            username = richTextBox1.Text;
            email = richTextBox2.Text;
            password = richTextBox3.Text;
            contact = richTextBox4.Text;
            
            

         

            if (richTextBox0.Text == "" || richTextBox1.Text == "" || richTextBox2.Text == "" || richTextBox3.Text == "" || richTextBox4.Text == "" )
                MessageBox.Show("Please fillup all the information!");

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();

            string query = "insert into adminDB (name,username,email,password,contact) values" +
                                                        "('" + name + "','" + username + "','" + email + "','" + password + "','" + contact + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Successfully registered New Admin");
            }
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Hide();
        }
    }
}
