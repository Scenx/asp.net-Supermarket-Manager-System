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

public partial class Employee_changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*验证是否登陆了系统*/
            if (Session["employeeFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
        }
    }
    protected void Btn_ChangePassword_Click(object sender, EventArgs e)
    {
        EmployeeModel employeeModel = new EmployeeModel();
        employeeModel.EmployeeNo = Session["employeeNo"].ToString();
        employeeModel.EmployeePassword = this.NewPassword.Text;
        EmployeeLogic employeeLogic = new EmployeeLogic();
        if(employeeLogic.ChangePassword(employeeModel))
            this.ErrMessage.Text = "<font color=red>密码修改成功!</font>";
        else
            this.ErrMessage.Text = "<font color=red>密码修改失败!</font>";
    }
}
