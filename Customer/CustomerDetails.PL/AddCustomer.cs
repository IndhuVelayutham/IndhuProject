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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Customer newCustomer = new Customer();

                newCustomer.CustomerId = Int32.Parse(label1.Text);
                newCustomer.CustomerFirstName = txtFirstName.Text;
                newCustomer.CustomerLastName = txtLatName.Text;
                newCustomer.DOB = DateTime.Parse(dateTimePicker.Text);

                if (ckbPen.Checked)
                    newCustomer.CustomerItems = ckbPen.Text;
                if (ckbBook.Checked)
                    newCustomer.CustomerItems += ckbBook.Text;

                if (rdoMale.Checked)
                    newCustomer.Gender = (GenderType)Enum.Parse(typeof(GenderType), rdoMale.Text);
                if (rdoFemale.Checked)
                    newCustomer.Gender = (GenderType)Enum.Parse(typeof(GenderType), rdoFemale.Text);

                newCustomer.CustomerCountry = cmboCountry.Text;
                newCustomer.CustomerCity = cmboCity.Text;
                newCustomer.CustomerAddress = rtxtAddress.Text;
                newCustomer.CustomerPhoneNumber = txtPhoneNumber.Text;
                newCustomer.CustomerPinCode = txtPinCode.Text;
                newCustomer.CustomerEmailId = txtEmailId.Text;
                newCustomer.CustomerListOfItems = clbListOfItems.Text;
                newCustomer.CustomerTown = cmboTown.Text;
                newCustomer.CustomerVillage = dmuVillage.Text;
                newCustomer.Products = lstProducts.Text;

                int mpt,mtt,assign;
                Int32.TryParse(txtMPT.Text,out mpt);
                newCustomer.CustomerMPTMarks = mpt;
                Int32.TryParse(txtMTT.Text, out mtt);
                newCustomer.CustomerMTTMarks = mtt;
                Int32.TryParse(txtAssignment.Text, out assign);
                newCustomer.CustomerAssignment = assign;
                if (!txtTotal.Text.Equals(""))
                newCustomer.CustomerTotalMarks = Int32.Parse(txtTotal.Text);

                newCustomer.CustomerGrade = txtGrade.Text;

                if (!txtAge.Text.Equals(""))
                newCustomer.CustomerAge = Int32.Parse(txtAge.Text);

                  if(txtBloodGroup.Text!="")
                newCustomer.CustomerBloodGroup = (CustomerBloodGroupType)Enum.Parse(typeof(CustomerBloodGroupType), txtBloodGroup.Text); 

                bool customerAdded = CustomerBL.AddCustomerBL(newCustomer);
                if (customerAdded)
                    MessageBox.Show("Customer Details are Added");
                else
                    MessageBox.Show("Customer Details are not Added");
            }
            catch (CustomerException ex)
            {
                MessageBox.Show(ex.Message);
            }
         }




        private static AddCustomer instance = null;

        public static AddCustomer GetInstance()
        {
            if (instance == null)
                instance = new AddCustomer();
            return instance;
        }



        private void cmboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {


            List<String> str = null;
            cmboCity.Items.Clear();
            str = CustomerBL.GetCities((string)cmboCountry.SelectedItem);
            foreach (string city in str)
                cmboCity.Items.Add(city);
         }


        private void txtTotal_MouseClick(object sender, MouseEventArgs e)//go to textbox properties and click on mouceclick thing then we get this line.
        {
            int mptMarks;
            int mttMarks = 0;
            int assign = 0;

            Int32.TryParse(txtMPT.Text,out mptMarks);
            Int32.TryParse(txtMTT.Text,out mttMarks);
            Int32.TryParse(txtAssignment.Text, out assign);

            int Total = mptMarks + mttMarks + assign;

            //int Total = ((Int32.Parse(txtMPT.Text) + Int32.Parse(txtMTT.Text) + Int32.Parse(txtAssignment.Text)) / 3);
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




        private void AddCustomer_Load_1(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
            label1.Text = CustomerBL.GetCustomerId().ToString();
        }
     }
}

      


    
