using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Text;
using MBOX = System.Windows.Forms.MessageBox;

namespace Fractals
{
    public partial class Signup : Form
    {
        public string UserRealName, UserName, Password, PCName, FilePath;  
        public Signup()
        {
            this.UserRealName = this.UserName = this.Password = null;
            this.PCName = Environment.UserName;
            this.FilePath = @"C:\Users\" + this.PCName + "\\Documents\\Fractals\\Users\\";
            InitializeComponent();
        }
        public Tuple<string, string, string, string> GetUser()
        {
            return new Tuple<string, string, string, string>(UserRealName, UserName, Password, FilePath + UserRealName+ ".xml");
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.UserRealName = this.NameTextBox.Text;
            this.UserName = this.UserNameTextBox.Text;
            this.Password = this.PasswordTextBox.Text;

            if (this.UserRealName != "Name" || this.UserName != "User name" || this.Password != "password")
            {
                this.Close();
            }
            else
            {
                MBOX.Show("One or more fields were not inputted appropriately");
                return;
            }
        }
        private void NewUserForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.FilePath))
            {
                Directory.CreateDirectory(this.FilePath);
            }
        }
    }
}
