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
namespace SuperMarket
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "return check();";
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*取得帐号密码信息*/
            string userName = this.txtName.Text;
            string password = this.txtPwd.Text;
            string identify = this.Identify.SelectedValue;
            if ("管理员" == identify)
            {
                AdminModel adminModel = new AdminModel();
                adminModel.AdminUsername = userName;
                adminModel.AdminPassword = password;
                AdminLogic adminLogic = new AdminLogic();
                /*如果管理员帐号信息正确*/
                if (adminLogic.IsExistAdminInfo(adminModel))
                {
                    Session["adminFlag"] = true;
                    Session["adminUsername"] = userName;
                    Response.Redirect("Admin/index.aspx");
                }
                /*如果管理员帐号信息不正确*/
                else
                {
                    Response.Write("<script>alert('" + adminLogic.ErrMessage + "');</script>");
                }
            }
            else
            {
                /*如果员工帐号信息正确*/
                EmployeeLogic employeeLogic = new EmployeeLogic();
                if(employeeLogic.CheckLogin(userName,password))
                {
                    Session["employeeFlag"] = true;
                    Session["employeeNo"] = userName;
                    Response.Redirect("Employee/index.aspx");
                }
                /*如果员工帐号信息不正确*/
                else
                {
                    Response.Write("<script>alert('" + employeeLogic.ErrMessage + "');</script>");
                }
            }

        }
}

}
