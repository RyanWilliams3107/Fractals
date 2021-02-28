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
    public partial class SaveForm : Form
    {
        public bool mTextChanged;

        public SaveForm()
        {
            InitializeComponent();
        }
        public bool getTextChanged()
        {
            return this.mTextChanged;
        }
        public string getName()
        {
            return textBox1.Text;
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("Default"))
            {
                mTextChanged = true;
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            mTextChanged = false;
            this.Close();
        }


        private void SaveForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text.Equals("Default"))
            {
                this.mTextChanged = false;
            }
            else
            {
                this.mTextChanged = true;
            }
        }
    }
}
