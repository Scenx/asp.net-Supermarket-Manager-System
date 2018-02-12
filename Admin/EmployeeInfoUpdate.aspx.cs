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

public partial class Admin_EmployeeInfoUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            /*验证是否登陆了系统*/
            if (Session["adminFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
            /*首先填充各个下拉框的项目*/
            InitControlsData();
            /*取得更新员工的员工编号*/
            string employeeNo = Request.QueryString["employeeNo"];
            /*调用业务层根据员工编号得到员工的信息并保存在模型中*/
            EmployeeLogic employeeLogic = new EmployeeLogic();
            EmployeeModel employeeModel = employeeLogic.GetEmployeeInfo(employeeNo);
            /*然后显示在界面上*/
            this.DataView(employeeModel);
        }

    }

    /*根据员工信息对象模型将相关信息显示在界面上*/
    private void DataView(EmployeeModel employeeModel)
    {
        this.EmployeeNo.Text = employeeModel.EmployeeNo;
        this.EmployeeName.Text = employeeModel.EmployeeName;
        this.EmployeePassword.Text = employeeModel.EmployeePassword;
        this.EmployeeSex.Text = employeeModel.EmployeeSex;
        this.EmployeeBirthday.Text = employeeModel.EmployeeBirthday.ToShortDateString();
        this.EmployeeEducation.SelectedValue = employeeModel.EmployeeEducationId.ToString();
        this.EmployeeHomeTel.Text = employeeModel.EmployeeHomeTel;
        this.EmployeeMobile.Text = employeeModel.EmployeeMobile;
        this.EmployeeCard.Text = employeeModel.EmployeeCard;
        this.EmployeeEmail.Text = employeeModel.EmployeeEmail;
        this.EmployeeAddress.Text = employeeModel.EmployeeAddress;
    }
    protected void Btn_Update_Click(object sender, EventArgs e)
    {
        /*首先建立员工对象的模型并将界面上的信息传递给它*/
        EmployeeModel employeeModel = new EmployeeModel();
        employeeModel.EmployeeNo = Request.QueryString["employeeNo"];
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
        /*调用业务层实现该员工信息的更新*/
        EmployeeLogic employeeLogic = new EmployeeLogic();
        if (employeeLogic.UpdateEmployeeInfo(employeeModel))
            Response.Write("<script>alert('员工信息更新成功!');</script>");
        else
            Response.Write("<script>alert('" + employeeLogic.ErrMessage + "');</script>");
    }
    protected void Btn_Cancle_Click(object sender, EventArgs e)
    {
        /*重回到信息管理页*/
        Response.Redirect("EmployeeManage.aspx");
    }

    /*填充工作类别下拉框,部门信息下拉框，教育层次下拉框的信息*/
    public void InitControlsData()
    {
       
        /*下面对教育层次下拉框信息进行更新*/
        this.EmployeeEducation.DataSource = (new EducationLogic()).GetAllEducationInfo();
        this.EmployeeEducation.DataTextField = "educationName";
        this.EmployeeEducation.DataValueField = "educationId";
        this.EmployeeEducation.DataBind();
    }
}
