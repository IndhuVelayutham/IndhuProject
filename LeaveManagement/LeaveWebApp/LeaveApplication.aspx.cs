using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeaveWebApp.LeaveWSR;

namespace LeaveWebApp
{
    public partial class LeaveApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LeaveWebServices service = new LeaveWebServices();
            //LeaveEntity[] reasons = service.GetAllReasons();
            //ddlReason.DataSource = reasons;
            //ddlReason.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool added = false;
            txtEmpId.Text = Request.QueryString.Get("UserId");

            LeaveWebServices service = new LeaveWebServices();
            LeaveEntity leave = new LeaveEntity();
            leave.StartDate = Convert.ToDateTime(txtStartDate.Text);
            leave.EndDate = Convert.ToDateTime(txtEndDate.Text);

            leave.Reason = ddlReason.SelectedItem.ToString();

            leave.Comments = txtComments.Text;

            added = service.Addleave(leave);
            if (added)
            {

            }
            else
            {
            }
        }
    }
}