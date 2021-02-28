using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Fractals
{
    public partial class UserChoice : Form
    {
        private string rName;
        public UserChoice()
        {
            bool GuestMode = false;
            Login l = new Login();
            l.ShowDialog();
            Tuple<bool, string> res = l.GetResults();

            if (!res.Item1)
            {
                GuestMode = true;
            }

            if (GuestMode)
            {
                rName = "guest";
            }
            else
            {
                rName = res.Item2;
            }

            l.Close();
            l.Dispose();


            InitializeComponent();
        }
        private void Mandelbrot_Click(object sender, EventArgs e)
        {
            Mandelbrot m = new Mandelbrot(rName);
            m.ShowDialog();
            m.Dispose();
        }
        private void JuliaSet_Click(object sender, EventArgs e)
        {
            JuliaSet j = new JuliaSet();
            j.ShowDialog();
            j.Dispose();
        }
    }
}
