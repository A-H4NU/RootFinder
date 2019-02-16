using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RootFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false;
            using (VisualFunction vf = new VisualFunction(500, 500, TxtFunction.Text, 10, 5, 0.01))
            {
                vf.VSync = OpenTK.VSyncMode.Off;
                //MessageBox.Show(vf.FindRoot(-0.5, 1, double.Epsilon).ToString());
                vf.Run(60);
                BtnStart.Enabled = true;
            }
        }
    }
}
