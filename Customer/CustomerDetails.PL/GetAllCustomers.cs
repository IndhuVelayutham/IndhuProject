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
    public partial class GetAllCustomers : Form
    {
        public GetAllCustomers()
        {
            InitializeComponent();
        }

        private void GetAllCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                List<Customer> customerList = CustomerBL.GetAllCustomersBL();
                if (customerList != null)
                {
                    dataGridView.DataSource = customerList;
                }
                else
                {
                    MessageBox.Show("No Customer Details Available");
                    this.Close();
                }
            }
            catch (CustomerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private static GetAllCustomers instance = null;


        public static GetAllCustomers GetInstance()
        {
            if (instance == null)
                instance = new GetAllCustomers();
            return instance;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

      