using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalLibrary.Entity;
using WelcomePage;
using HospitalLibrary.BL;

namespace frontLoginPage
{
    public partial class Patient_Registration : Form
    {
        Patient patient;
        HospitalBusinessLayer businessLayer;
        public Patient_Registration()
        {
            InitializeComponent();
        }

        private void Patient_Registration_Load(object sender, EventArgs e)
        {
            LoadPatientType();
        }

        private void LoadPatientType()
        {
            cmbPatientType.Items.Add("New Patient");
            cmbPatientType.Items.Add("Review");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_submit_Click(object sender, EventArgs e)
        {
            patient = new Patient();
            businessLayer = new HospitalBusinessLayer();
            if(btnSubmit.Text=="Submit")
            {
                patient.Name = txtPatientName.Text;
                patient.Address = txtAddress.Text;
                patient.DateOfBirth = Convert.ToDateTime(txtDOB.Text);
                if (rbtn_Male.Checked)
                {
                    patient.Gender = Gender.M;
                }
                else
                {
                    patient.Gender = Gender.F;
                }

                patient.ContactNumber = txtContact.Text;
                patient.Emergency = txtEmergrncy.Text;
                int patientId = businessLayer.AddPatient(patient);
                string Message = string.Empty;
                if (patientId > 0)
                {
                    Message = "Patient ID " + patientId;
                }
                else
                {
                    Message = "Patient Not Added";
                }

                MessageBox.Show(Message);
            }
            else
            {
                int patientID = Convert.ToInt32(txtPatientID.Text);
                bool exist = businessLayer.GetPatientDetailByPatientID(patientID, out patient);
                if (exist)
                {
                    txtPatientName.Text = patient.Name;
                    txtAddress.Text = patient.Address;
                    txtContact.Text = patient.ContactNumber;
                    txtDOB.Text = patient.DateOfBirth.ToString();
                    if (patient.Gender == Gender.M)
                        rbtn_Male.Checked = true;
                    else
                        rbtn_Female.Checked = true;
                }
                else
                {
                    MessageBox.Show("Patient Not found");
                }
                
            }

        }

        private void cmbPatientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPatientType.SelectedItem.Equals("Review"))
            {
                lblPatientID.Visible = true;
                txtPatientID.Visible = true;
                btnSubmit.Text = "Search";
            }
            else
            {
                lblPatientID.Visible = false;
                txtPatientID.Visible = false;
            }
        }
           
      
        


    }
}
