using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerDetails.PL
{
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form AddCustomerformobj = AddCustomer.GetInstance();
            AddCustomerformobj.Show();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            Form GetAllCustomersformobj = GetAllCustomers.GetInstance();
            GetAllCustomersformobj.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form SearchCustomerformobj = SearchCustomer.GetInstance();
            SearchCustomerformobj.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form DeleteCustomerformobj = DeleteCustomer.GetInstance();
            DeleteCustomerformobj.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form UpdateCustomerformobj = UpdateCustomer.GetInstance();
            UpdateCustomerformobj.Show();

        }
       
    }
}
