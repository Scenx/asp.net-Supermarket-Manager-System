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

public partial class Admin_EmployeeInfoAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*判断管理员是否已经登陆了系统*/
            if (Session["adminFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
        }
    }

    protected void Btn_Add_Click(object sender, EventArgs e)
    {
        /*首先建立员工对象的模型并将界面上的信息传递给它*/
        EmployeeModel employeeModel = new EmployeeModel();
        employeeModel.EmployeeNo = this.EmployeeNo.Text;
        employeeModel.EmployeeName = this.EmployeeName.Text;
        employeeModel.EmployeePassword = this.EmployeePassword.Text;
        employeeModel.EmployeeSex = this.EmployeeSex.Text;
        if (this.EmployeeBirthday.Text != "")
            employeeModel.EmployeeBirthday = Convert.ToDateTime(this.EmployeeBirthday.Text);
        employeeModel.EmployeeEducationId = Convert.ToInt32(this.EmployeeEducation.SelectedValue);
        employeeModel.EmployeeHomeTel = this.EmployeeHomeTel.Text;
        employeeModel.EmployeeMobile = this.EmployeeMobile.Text;
        employeeModel.EmployeeCard = this.EmployeeCard.Text;
        employeeModel.EmployeeEmail = this.EmployeeEmail.Text;
        employeeModel.EmployeeAddress = this.EmployeeAddress.Text;
        /*然后调用业务层对员工信息进行添加,成功返回true,失败返回false错误信息保存在ErrMessage中*/
        EmployeeLogic employeeLogic = new EmployeeLogic();
        if (employeeLogic.EmployeeInfoAdd(employeeModel))
            Response.Write("<script>alert('员工信息添加成功!');location.href='EmployeeInfoAdd.aspx';</script>");
        else
            Response.Write("<script>alert('"+ employeeLogic.ErrMessage + "');</script>");

    }
    protected void Btn_Cancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeInfoAdd.aspx");
    }
}
