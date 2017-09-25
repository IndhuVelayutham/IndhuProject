using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeaveWebApp.LeaveWSR;
using System.Web.Services.Protocols;

namespace LeaveWebApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                //LoginEntity login = new LoginEntity();
                //LeaveWebServices service = new LeaveWebServices();
                //login.UserId = Convert.ToInt32(txtUserId.Text);
                //login.Password = txtPassword.Text;
                // success = service.LoginUser(login);

                if (!success)
                {
                    Response.Redirect("LeaveApplication.aspx?UserId="+ Server.UrlEncode(txtUserId.Text));
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), null, "<script>alert('Incorrect UserId Or password')</script>");
                }
            }
            catch (SoapException)
            {
                throw;
            }            
        }
    }
}