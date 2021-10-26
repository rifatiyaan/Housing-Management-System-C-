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
    public partial class CC : Form
    {
        public CC()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            House form = new House();
            form.Show();
            this.Hide();
        }
    }
}
