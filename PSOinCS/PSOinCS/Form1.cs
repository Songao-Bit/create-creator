using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSOinCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = MyPSO.gbestf.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
