using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 48;
            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.TopMost = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
