using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalLibrary.Entity;
using frontLoginPage;

namespace WelcomePage
{
    public partial class WelcomeForm : Form
    {
        HomePage homeFrm;
        public WelcomeForm()
        {
            InitializeComponent();
            
            
        }
        public WelcomeForm(User user)
        {
            InitializeComponent();
            panel3.AutoSize=true;
            this.IsMdiContainer = true;
            label1.Text += user.LastName + "," + user.FirstName;
            label2.Text = DateTime.Now.Date.ToString();
            homeFrm = new HomePage(user);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            this.IsMdiContainer = true;
            homeFrm.MdiParent = this;
            panel3.Controls.Add(homeFrm);
            homeFrm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Controls.Clear();
            this.IsMdiContainer = true;
            homeFrm.MdiParent = this;
            panel3.Controls.Add(homeFrm);
            homeFrm.Show();
       
        }

        private void lnkPatientReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Controls.Clear();
            Patient_Registration patientRegistration = new Patient_Registration();
            this.IsMdiContainer = true;
            patientRegistration.MdiParent = this;
            panel3.Controls.Add(patientRegistration);
            patientRegistration.Show();
        }

        private void lnkDoctorSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Controls.Clear();
            LoginForm patientRegistration = new LoginForm();
            this.IsMdiContainer = true;
            patientRegistration.MdiParent = this;
            panel3.Controls.Add(patientRegistration);
            patientRegistration.Show();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Dispose();
            new LoginForm().Show();
        }


    }
}
