using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamSystemManager.Data;
using ExamSystemManager.Bussiness;

namespace ExamSystemManager.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string role = "";
            if (HDS_UserBL.checkLogin(txtUserName.Text, txtPassword.Text, ref role))
            {
                HDS_User user = new HDS_User();
                user = HDS_UserBL.getByUsername(txtUserName.Text);
                Session["srcImg"] = user.Usr_Avata;
                Session["ad_user"] = txtUserName.Text;
                Session["ad_role"] = role;
                Session["Emp_ID"] = user.Emp_ID;
                Response.Redirect("~/admin/Default.aspx");
            }
            else
            {
                lblMsg.Visible = true;
            }
        }
    }
}