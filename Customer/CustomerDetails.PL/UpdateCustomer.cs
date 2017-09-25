using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerDetails.Entities;
using CustomerDetails.BL;
using CustomerExceptions;

namespace CustomerDetails.PL
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private static UpdateCustomer instance = null;


        public static UpdateCustomer GetInstance()
        {
            if (instance == null)
                instance = new UpdateCustomer();
            return instance;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int updateCustomerId;
                updateCustomerId = Convert.ToInt32(txtId.Text);
                Customer updatedCustomer = CustomerBL.SearchCustomerBL(updateCustomerId);
                if (updatedCustomer != null)
                {
                    updatedCustomer.CustomerFirstName = txtFirstName.Text;
                    updatedCustomer.CustomerLastName = txtLatName.Text;
                    updatedCustomer.DOB = DateTime.Parse(dateTimePicker.Text);

                    if (ckbPen.Checked)
                        updatedCustomer.CustomerItems = ckbPen.Text;
                    if (ckbBook.Checked)
                        updatedCustomer.CustomerItems += ckbBook.Text;

                    if (rdoMale.Checked)
                        updatedCustomer.Gender = (GenderType)Enum.Parse(typeof(GenderType), rdoMale.Text);
                    if (rdoFemale.Checked)
                        updatedCustomer.Gender = (GenderType)Enum.Parse(typeof(GenderType), rdoFemale.Text);

                    updatedCustomer.CustomerCountry = cmboCountry.Text;
                    updatedCustomer.CustomerCity = cmboCity.Text;
                    updatedCustomer.CustomerAddress = rtxtAddress.Text;
                    updatedCustomer.CustomerPhoneNumber = txtPhoneNumber.Text;
                    updatedCustomer.CustomerPinCode = txtPinCode.Text;
                    updatedCustomer.CustomerEmailId = txtEmailId.Text;
                    updatedCustomer.CustomerListOfItems = clbListOfItems.Text;
                    updatedCustomer.CustomerTown = cmboTown.Text;
                    updatedCustomer.CustomerVillage = dmuVillage.Text;
                    updatedCustomer.Products = lstProducts.Text;

                    if (!txtMPT.Text.Equals(""))
                        updatedCustomer.CustomerMPTMarks = Int32.Parse(txtMPT.Text);
                    if (!txtMTT.Text.Equals(""))
                        updatedCustomer.CustomerMTTMarks = Int32.Parse(txtMTT.Text);
                    if (!txtAssignment.Text.Equals(""))
                        updatedCustomer.CustomerAssignment = Int32.Parse(txtAssignment.Text);
                    if (!txtTotal.Text.Equals(""))
                        updatedCustomer.CustomerTotalMarks = Int32.Parse(txtTotal.Text);

                    updatedCustomer.CustomerGrade = txtGrade.Text;

                    if (!txtAge.Text.Equals(""))
                        updatedCustomer.CustomerAge = Int32.Parse(txtAge.Text);

                    if (txtBloodGroup.Text == "Apos" || txtBloodGroup.Text == "Bpos" || txtBloodGroup.Text == "ABpos" || txtBloodGroup.Text == "Opos" || txtBloodGroup.Text == "ABneg")
                        updatedCustomer.CustomerBloodGroup = (CustomerBloodGroupType)Enum.Parse(typeof(CustomerBloodGroupType), txtBloodGroup.Text); ;

                    bool CustomerUpdated = CustomerBL.UpdateCustomerBL(updatedCustomer);
                    if (CustomerUpdated)
                        MessageBox.Show("Customer Details Updated");
                    else
                        MessageBox.Show("Customer Details not Updated ");
                }
                else
                {
                    MessageBox.Show("No Customer Details Available");
                }


            }
            catch (CustomerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




   

        private void cmboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> str = null;
            cmboCity.Items.Clear();
            str = CustomerBL.GetCities((string)cmboCountry.SelectedItem);
            foreach (string city in str)
                cmboCity.Items.Add(city);
        }




        private void txtTotal_MouseClick(object sender, MouseEventArgs e)
        {
            int Total = ((Int32.Parse(txtMPT.Text) + Int32.Parse(txtMTT.Text) + Int32.Parse(txtAssignment.Text)) / 3);
            string str = "";
            if (Total >= 90 && Total <= 100)
            {
                str = ("result=5");
            }
            else if (Total >= 80 && Total <= 90)
            {
                str = ("result=4");
            }
            else if (Total >= 70 && Total <= 80)
            {
                str = ("result=3");
            }
            else if (Total >= 60 && Total <= 70)
            {
                str = ("result=2");
            }
            else
            {
                str = ("result=fail");
            }
            this.txtTotal.Text = Total.ToString();
            this.txtGrade.Text = str;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }    

      
    }
}








































































