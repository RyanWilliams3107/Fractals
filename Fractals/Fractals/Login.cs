using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing.Imaging;

namespace Fractals
{
    public partial class Login : Form
    {
        private string CompName = Environment.UserName;
        private string FPath = null;
        private bool AuthLogin = false;
        private string rName = String.Empty;

        public Login()
        {
            this.FPath = @"C:\Users\" + this.CompName + "\\Documents\\Fractals\\Users\\";
            InitializeComponent();
        }
        public Tuple<bool, string> GetResults()
        {
            return new Tuple<bool, string>(AuthLogin, rName);
        }


        private bool Authenticate(User Input, User Compare)
        {
            return Input == Compare;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (this.UNameTextBox.Text != "User name" && this.PWordTextBox.Text != "password")
            {
                string Username = this.UNameTextBox.Text;
                string Pass = this.PWordTextBox.Text;
                Pass = Pass.HashString();
                User InputtedData = new User(Username, Pass);
                foreach (string FileName in Directory.GetFiles(this.FPath))
                {
                    string RawFileContents = File.ReadAllText(FileName);
                    User curFile = RawFileContents.FromXml<User>();

                    if (Authenticate(InputtedData, curFile))
                    {
                        rName = FileName;
                        AuthLogin = true;
                    }
                }
                if (!AuthLogin)
                {
                    MessageBox.Show("User not found, entering guest mode");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password not inputted appropriately");
            }
        }
        private void NewUser_Click(object sender, EventArgs e)
        {
            try
            {
                Signup NewUser = new Signup();
                NewUser.ShowDialog();
                Tuple<string, string, string, string> user = NewUser.GetUser();

                string Name = user.Item1;
                string UserName = user.Item2;
                string Password = user.Item3;
                string FilePath = user.Item4;


                File.WriteAllText(FilePath, new User(UserName, Password.HashString()).ToXml());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        } 
    }
}
