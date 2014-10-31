using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamSystemManager.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ad_user"] == null)
            {
                Response.Redirect("~/admin/Login.aspx");
            }
            else
            {
                srcImg.ImageUrl = Session["srcImg"].ToString();
                lbluser.Text = Session["ad_user"].ToString();
                lblrole.Text = Session["ad_role"].ToString();
            }
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Session["ad_user"] = null;
            Session["ad_role"] = null;
            Session["srcImg"] = null;
            Response.Redirect("~/admin/Login.aspx");
        }
    }
}