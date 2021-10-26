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
    public partial class ClientList : Form
    {
        bool isNew = false;
        public ClientList()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();
            string query = "select * from clientDB";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];

            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
                conn.Open();
                string query = "select * from clientDB where ID=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];


                richTextBox1.Text = dt.Rows[0]["ID"].ToString();
                richTextBox2.Text = dt.Rows[0]["name"].ToString();
                richTextBox3.Text = dt.Rows[0]["username"].ToString();
                richTextBox4.Text = dt.Rows[0]["email"].ToString();
                richTextBox5.Text = dt.Rows[0]["password"].ToString();
                richTextBox6.Text = dt.Rows[0]["contact"].ToString();
                richTextBox7.Text = dt.Rows[0]["nid"].ToString();
                richTextBox8.Text = dt.Rows[0]["occupation"].ToString();
                richTextBox9.Text = dt.Rows[0]["address"].ToString();


                conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();
            string query;
            if (isNew == false)
            {
                query = "update clientDB set name='" + richTextBox2.Text + "', username='" + richTextBox3.Text + "',email= '" + richTextBox4.Text + "', password='" + richTextBox5.Text + "', contact='" + richTextBox6.Text + "', nid='" + richTextBox7.Text + "', occupation='" + richTextBox8.Text + "', address='" + richTextBox9.Text + "' where ID =" + richTextBox1.Text + "";
            }
            else
            {
                query = "insert into clientDB (name,username,email,password,contact,nid,occupation,address) values ('" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + richTextBox4.Text +"','"+ richTextBox5.Text+"','"+richTextBox6+"','"+richTextBox7+"','"+richTextBox8+"','"+richTextBox9+"')";
            }

            isNew = false;
            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Successfully Updated ");



                query = "select * from  clientDB";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                conn.Close();
            }
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();
         
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";
            richTextBox6.Text = "";
            richTextBox7.Text = "";
            richTextBox8.Text = "";
            richTextBox9.Text = "";
            isNew = true;
            richTextBox2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2PTJ945\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True");
            conn.Open();


            string query = "delete from clientDB where ID=" + richTextBox1.Text;


            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("Successfully Deleted ");
            }
            query = "select * from clientDB";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();

            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
