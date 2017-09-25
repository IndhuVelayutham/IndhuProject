using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace BankApplication
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUName.Text, txtPwd.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUName.Text, false);
               
                ViewState["UserName"] = txtUName.Text;
            }
        }
    }
}