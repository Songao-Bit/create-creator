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
            textBox1.ReadOnly  = true;
            textBox1.Enabled = false;
            textBox1.BackColor = Color.White;
            textBox1.Multiline = true; 
            textBox1.Text = "函数的极小值是：" + MyPSO.gbestf.ToString()+"\r\n";
            textBox1.AppendText("执行时间是：" + MyPSO.Program.time);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
