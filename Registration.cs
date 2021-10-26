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
    public partial class Registration : Form
    {
      


        public Registration()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            
            string name,username, email, password, contact, nid, address,occupation, gender = " ";

            DateTime dob = Convert.ToDateTime(dateTimePicker1.Text);
            name = txtName.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            contact = txtContact.Text;
            email = txtEmail.Text;
            address = txtAddress.Text;
            nid = txtNID.Text;
            occupation = txtOcc.Text;

            if (radioButton1.Checked)
            {
                gender = "Male";

            }
            else if (radioButton2.Checked)
            {
                gender = "Female";

            }
            else
            {
                MessageBox.Show("No Gender Selected");
            }

            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtAddress.Text == "" || txtNID.Text == "" || txtOcc.Text == "" )
                MessageBox.Show("Please fillup all the information!");

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();

            string query = "insert into clientDB (name,username, email,password,contact,nid ,dob,address,gender,occupation ) values" +
                                                        "('" + name + "','" + username + "','" + email + "','" + password + "','" + contact + "','" + nid + "','" + dob + "','" + address + "','" + gender + "','" + occupation + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Successfully registered");
            }
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
