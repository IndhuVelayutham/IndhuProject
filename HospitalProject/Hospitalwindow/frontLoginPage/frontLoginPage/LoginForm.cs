using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalLibrary.BL;
using HospitalLibrary.Entity;
using WelcomePage;

namespace frontLoginPage
{
    public partial class LoginForm : Form
    {
        WelcomeForm frm = new WelcomeForm();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lbl1Name_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbl3_password_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txt1_userName.Text;
                string password = txt2_password.Text;
                HospitalBusinessLayer business = new HospitalBusinessLayer();
                User user = null;
                user = business.validateCredential(userName, password);
                if (user != null)
                {
                    WelcomeForm welcomeForm = new WelcomeForm(user);
                    welcomeForm.Show();
                    this.Hide();
                }
            }
            catch (HospitalExceptionLayer.HospitalException ex)
            {
                lblError.Text = ex.Message;
            }
           
            
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }
}
