using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Desk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            rtx.Text = string.Concat(rtx.Text, tb.Text, Environment.NewLine);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            rtx.Text = string.Concat(rtx.Text, Environment.NewLine);
        }
    }
}
