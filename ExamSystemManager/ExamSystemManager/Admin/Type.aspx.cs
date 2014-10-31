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
    public partial class Type : System.Web.UI.Page
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

        public void gridBind()
        {
            gridData.DataSource = HDS_TypeQuestionBL.getAll();
            gridData.DataBind();
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            HDS_TypeQuestion Type = new HDS_TypeQuestion();

            Type.Typ_Name = txtType.Text;
            Type.Typ_Description = txtdes.Text;
            string strid = txtid.Text;

            if (strid.Trim() == "")
            {
                Type.typ_ID = Int32.Parse(txtid.Text);
                if (HDS_TypeQuestionBL.AddNew(Type))
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
                Type.typ_ID = Int32.Parse(strid);
                if (HDS_TypeQuestionBL.Update(Type))
                {
                    ShowMessage(1, "Data updated successfully ! ");
                    gridBind();
                }
                else
                {
                    ShowMessage(0, "Data updated fail : " + HDS_TypeQuestionBL.errMsg);
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
            txtType.Text = "";
            txtdes.Text = "";
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
            foreach (GridViewRow row in gridData.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)row.FindControl("chkSelect")).Checked == true)
                    {
                        isChecked = true;
                        if (!HDS_TypeQuestionBL.Delete(int.Parse(gridData.DataKeys[row.RowIndex].Value.ToString()), Session["ad_role"].ToString()))
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
                ShowMessage(0, "Data deleted fail : " + HDS_TypeQuestionBL.errMsg);
            }
        }

        protected void lbtRefreshT_Click(object sender, EventArgs e)
        {
            gridBind();
        }

        protected void gridEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridData.PageIndex = e.NewPageIndex;
            gridBind();
        }

        protected void gridEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int strId = Int32.Parse(e.CommandArgument.ToString());
            HDS_TypeQuestion obj = new HDS_TypeQuestion();
            switch (e.CommandName)
            {
                case "cmdEdit":
                    pnlAddnew.Visible = true;
                    pnlData.Visible = false;
                    pnlMessage.Visible = true;
                    obj = HDS_TypeQuestionBL.getById(strId);
                    txtid.Text = strId.ToString();
                    txtType.Text = obj.Typ_Name;
                    txtdes.Text = obj.Typ_Description;
                    break;
                case "cmdView":
                    pnlAddnew.Visible = true;
                    pnlData.Visible = false;
                    pnlMessage.Visible = true;
                    obj = HDS_TypeQuestionBL.getById(strId);
                    txtid.Text = strId.ToString();
                    txtType.Text = obj.Typ_Name;
                    txtdes.Text = obj.Typ_Description;
                    break;
                case "cmdDelete":
                    string cusrent_user = Session["ad_user"].ToString();
                    string cusrent_role = Session["ad_role"].ToString();
                    if (HDS_TypeQuestionBL.Delete(strId, cusrent_role))
                    {
                        ShowMessage(1, "Data deleted successfully ! ");
                        gridBind();
                    }
                    else
                    {
                        ShowMessage(0, "Data deleted fail : " + HDS_TypeQuestionBL.errMsg);
                    }
                    break;
                default:
                    break;
            }
        }

        protected void gridEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                ((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onClick", "SelectAllClick(this)");
            if (e.Row.RowType == DataControlRowType.DataRow)
                ((CheckBox)e.Row.FindControl("chkSelect")).Attributes.Add("onClick", "SelectClick(this)");
        }
    }
}