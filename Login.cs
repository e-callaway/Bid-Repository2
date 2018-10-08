using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Text;
                Upload up = new Upload();
                up.Show();

                this.Close();

                //if (password != "")
                //{
                //    if (password == "lipsey2018!")
                //    {
                //        Upload up = new Upload();
                //        up.Show();

                //        this.Close();
                //    }
                //    else
                //    {
                //        txtPassword.Text = "";
                //        MessageBox.Show("The password you entered is invalid.");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Please enter a password to continue.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
