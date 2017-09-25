using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalLibrary.Entity;

namespace frontLoginPage
{
    public partial class HomePage : Form
    {
        public User loggedinUser;
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(User user)
        {
            InitializeComponent();
            loggedinUser = new User();
            loggedinUser.FirstName = user.FirstName;
            loggedinUser.LastName = user.LastName;
            loggedinUser.RoleID = user.RoleID;
            loggedinUser.UserID = user.UserID;
            loggedinUser.Gender = user.Gender;
            loggedinUser.Department = user.Department;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            label2.Text += (Role)Enum.Parse(typeof(Role), loggedinUser.RoleID.ToString());
            label3.Text += " " + DateTime.Now.ToString();
        }
    }
}
