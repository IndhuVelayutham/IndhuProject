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
    public partial class SearchCustomer : Form
    {
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void SearchCustomer_Load(object sender, EventArgs e)
        {

            List<int> Ids = null;
            comboId.Items.Clear();
            Ids = CustomerBL.GetIds();
            foreach (int Id in Ids)
                comboId.Items.Add(Id);

        }
        private static SearchCustomer instance = null;

        public static SearchCustomer GetInstance()
        {
            if (instance == null)
                instance = new SearchCustomer();
            return instance;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboId_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                int searchCustomerId;
                searchCustomerId = Convert.ToInt32(comboId.SelectedItem);
                Customer searchCustomer = CustomerBL.SearchCustomerBL(searchCustomerId);
                if (searchCustomer != null)
                {

                    txtFirstName.Text = searchCustomer.CustomerFirstName;
                    txtLastName.Text = searchCustomer.CustomerLastName;
                    txtDOB.Text = searchCustomer.DOB.ToString();
                    txtItems.Text = searchCustomer.CustomerItems;
                    txtGender.Text = searchCustomer.Gender.ToString();
                    txtCountry.Text = searchCustomer.CustomerCountry;
                    txtEmailId.Text = searchCustomer.CustomerEmailId;
                    txtPinCode.Text = searchCustomer.CustomerPinCode;
                    txtTown.Text = searchCustomer.CustomerTown;
                    txtVillage.Text = searchCustomer.CustomerVillage;
                    txtProducts.Text = searchCustomer.Products;
                    txtPhoneNumber.Text = searchCustomer.CustomerPhoneNumber;
                    txtListOfItems.Text = searchCustomer.CustomerListOfItems;
                    txtCity.Text = searchCustomer.CustomerCity;
                    txtMPT.Text = searchCustomer.CustomerMPTMarks.ToString();
                    txtMTT.Text = searchCustomer.CustomerMTTMarks.ToString();
                    txtAssignment.Text = searchCustomer.CustomerAssignment.ToString();
                    txtTotal.Text = searchCustomer.CustomerTotalMarks.ToString();
                    txtGrade.Text = searchCustomer.CustomerGrade;
                    txtAge.Text = searchCustomer.CustomerAge.ToString();
                    txtBloodGroup.Text = searchCustomer.CustomerBloodGroup.ToString();
                    rtxtAddress.Text = searchCustomer.CustomerAddress;

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

    }
}