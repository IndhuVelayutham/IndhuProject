using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerDetails.BL;
using CustomerDetails.Entities;
using CustomerExceptions;

namespace CustomerDetails.PL
{
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void DeleteCustomer_Load(object sender, EventArgs e)
        {

        }


        private static DeleteCustomer instance = null;


        public static DeleteCustomer GetInstance()
        {
            if (instance == null)
                instance = new DeleteCustomer();
            return instance;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int deleteCustomerId;
                deleteCustomerId = Convert.ToInt32(txtId.Text);
                Customer deleteCustomer = CustomerBL.SearchCustomerBL(deleteCustomerId);
                if (deleteCustomer != null)
                {
                    bool customerdeleted = CustomerBL.DeleteCustomerBL(deleteCustomerId);
                    if (customerdeleted)
                        MessageBox.Show("Customer Deleted");
                    else
                        MessageBox.Show("Customer not Deleted ");
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
