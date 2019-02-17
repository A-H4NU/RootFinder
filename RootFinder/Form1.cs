using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RootFinder
{
    public partial class RootFinder : Form
    {
        public RootFinder()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = false;
            TxtRoots.Text = String.Empty;
            _roots.Clear();
            using (VisualFunction vf = new VisualFunction(500, 500, TxtFunction.Text, BarSpeed.Value / 10.0, BarRange.Value / 10.0, Math.Pow(2, -BarAccuracy.Value), BarYSqueeze.Value / 10.0, this))
            {
                vf.VSync = OpenTK.VSyncMode.Off;
                //MessageBox.Show(vf.FindRoot(-0.5, 1, double.Epsilon).ToString());
                vf.Run(144, 144);
                BtnStart.Enabled = true;
            }
        }

        private List<double> _roots = new List<double>();

        public void AddRoot(double root)
        {
            foreach(double r in _roots)
            {
                if (Math.Abs(r - root) <= 0.000001)
                {
                    return;
                }
            }
            _roots.Add(root);
            TxtRoots.Text = "";
            foreach(double r in _roots)
            {
                TxtRoots.Text += String.Format("{0:F20}",r) + Environment.NewLine;
            }
        }

        private void BarRange_Scroll(object sender, EventArgs e)
        {
            LblRange.Text = "Range: " + BarRange.Value / 10.0;
        }

        private void BarSpeed_Scroll(object sender, EventArgs e)
        {
            LblSpeed.Text = "Speed(Xps): " + BarSpeed.Value / 10.0;
        }
        
        private void BarAccuracy_Scroll(object sender, EventArgs e)
        {
            LblAccuracy.Text = "Accuracy: " + BarAccuracy.Value;
        }

        private void BarYSqueeze_Scroll(object sender, EventArgs e)
        {
            LblYSqueeze.Text = "Y Squeeze: " + BarYSqueeze.Value / 10.0;
        }
    }
}
