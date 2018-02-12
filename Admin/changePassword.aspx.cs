using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SuperMarket.Model;
using SuperMarket.Logic;

public partial class Admin_changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*验证是否登陆了系统*/
            if (Session["adminFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
        }
    }
    protected void Btn_ChangePassword_Click(object sender, EventArgs e)
    {
        AdminModel adminModel = new AdminModel();
        adminModel.AdminUsername = Session["adminUsername"].ToString();
        adminModel.AdminPassword = this.NewPassword.Text.ToString();
        AdminLogic adminLogic = new AdminLogic();
        if (adminLogic.ChangePassword(adminModel))
            this.ErrMessage.Text = "<font color=red>密码修改成功!</font>";
        else
            this.ErrMessage.Text = "<font color=red>密码修改失败!</font>";
    }
}
