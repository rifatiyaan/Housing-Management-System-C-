using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRManagement
{
    public partial class Rent : Form
    {
        public Rent()
        {
            InitializeComponent();
        }
        public void Rent_Load(object sender, EventArgs e)
        {
            
        }

      
     
        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            
        }
    }
}
