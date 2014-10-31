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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm(\"Are you sure ?\")");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm(\"Are you sure ?\")");
                gridBind();
            }
        }

        protected void gridEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                ((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onClick", "SelectAllClick(this)");
            if (e.Row.RowType == DataControlRowType.DataRow)
                ((CheckBox)e.Row.FindControl("chkSelect")).Attributes.Add("onClick", "SelectClick(this)");
        }

        protected void gridEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int strId = Int32.Parse(e.CommandArgument.ToString());
            HDS_User obj = new HDS_User();
            switch (e.CommandName)
            {
                case "cmdEdit":
                    pnlAddnew.Visible = true;
                    pnlData.Visible = false;
                    pnlMessage.Visible = true;
                    obj = HDS_UserBL.getById(strId);
                    txtid.Text = strId.ToString();
                    txtImg.Text = obj.Usr_Avata;
                    txtUserName.Text = obj.Usr_Username;
                    ddlEmp.SelectedValue = obj.Emp_ID.ToString();
                    ddlRole.SelectedValue = obj.Usr_Role;
                    break;
                case "cmdView":
                    pnlAddnew.Visible = true;
                    pnlData.Visible = false;
                    pnlMessage.Visible = true;
                    obj = HDS_UserBL.getById(strId);
                    txtid.Text = strId.ToString();
                    txtImg.Text = obj.Usr_Avata;
                    txtUserName.Text = obj.Usr_Username;
                    ddlEmp.SelectedValue = obj.Emp_ID.ToString();
                    ddlRole.SelectedValue = obj.Usr_Role;
                    break;
                case "cmdDelete":
                    string cusrent_user = Session["ad_user"].ToString();
                    string cusrent_role = Session["ad_role"].ToString();
                    if (HDS_UserBL.Delete(strId, Session["ad_user"].ToString(), cusrent_role))
                    {
                        ShowMessage(1, "Data deleted successfully ! ");
                        gridBind();
                    }
                    else
                    {
                        ShowMessage(0, "Data deleted fail : " + HDS_UserBL.errMsg);
                    }
                    break;
                default:
                    break;
            }
        }

        protected void gridEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUser.PageIndex = e.NewPageIndex;
            gridBind();
        }

        public void gridBind()
        {
            gridUser.DataSource = HDS_UserBL.getAll();
            gridUser.DataBind();
        }

        protected void ShowMessage(int MegType, string Message)
        {
            pnlMessage.Visible = true;
            ((Label)pnlMessage.FindControl("lblMessage")).Text = Message;
            switch (MegType)
            {
                case 1:
                    pnlMessage.CssClass = "sukses";
                    break;
                case 0:
                    pnlMessage.CssClass = "gagal";
                    break;
                default:
                    pnlMessage.CssClass = "informasi";
                    break;
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAll = (CheckBox)gridUser.HeaderRow.FindControl("chkSelectAll");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in gridUser.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("chkSelect");
                    chkSel.Checked = true;

                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            HDS_User user = new HDS_User();

            user.Usr_Avata=txtImg.Text;
            user.Usr_Username=txtUserName.Text;
            user.Emp_ID= Int32.Parse(ddlEmp.SelectedValue);
            user.Usr_Role=ddlRole.SelectedValue;
            string strid = txtid.Text;

            if (strid.Trim() == "")
            {
                user.Usr_ID = Int32.Parse(txtid.Text);
                if (HDS_UserBL.AddNew(user))
                {
                    ShowMessage(1, "Data added successfully !");
                    gridBind();
                }
                else
                {
                    ShowMessage(0, "Data added fail : " + HDS_UserBL.errMsg);
                }
            }
            else
            {
                user.Usr_ID = Int32.Parse(strid);
                if (HDS_UserBL.Update(user))
                {
                    ShowMessage(1, "Data updated successfully ! ");
                    gridBind();

                }
                else
                {
                    ShowMessage(0, "Data updated fail : " + HDS_UserBL.errMsg);
                }
            }

            pnlAddnew.Visible = false;
            pnlData.Visible = true;
        }

        protected void lbtBack_Click(object sender, EventArgs e)
        {
            pnlAddnew.Visible = false;
            pnlMessage.Visible = false;
            pnlData.Visible = true;
        }

        protected void lblrefresh_Click(object sender, EventArgs e)
        {
            txtImg.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        protected void lbtAddnewT_Click(object sender, EventArgs e)
        {
            pnlAddnew.Visible = true;
            pnlData.Visible = false;
            pnlMessage.Visible = true;
        }

        protected void lbtDeleteT_Click(object sender, EventArgs e)
        {
            bool result = true;
            bool isChecked = false;
            foreach (GridViewRow row in gridUser.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)row.FindControl("chkSelect")).Checked == true)
                    {
                        isChecked = true;
                        if (!HDS_UserBL.Delete(int.Parse(gridUser.DataKeys[row.RowIndex].Value.ToString()), Session["ad_user"].ToString(), Session["ad_role"].ToString()))
                            result = false;
                    }
                }
            }

            if (isChecked == false)
                ShowMessage(-1, "You have not selected data to delete ! ");
            else if (result)
            {
                ShowMessage(1, "Data deleted successfully ! ");
                gridBind();
            }
            else
            {
                ShowMessage(0, "Data deleted fail : " + HDS_UserBL.errMsg);
            }
        }

        protected void lbtRefreshT_Click(object sender, EventArgs e)
        {
            gridBind();
        }


    }
}