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

using SuperMarket.Logic;

public partial class Admin_EmployeeManage : System.Web.UI.Page
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
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        /*取得查询的各个参数*/
        string employeeNo = this.EmployeeNo.Text;
        string employeeName = this.EmployeeName.Text;
        /*调用业务层得到查询的结果数据集*/
        EmployeeLogic employeeLogic = new EmployeeLogic();
        DataSet ds = employeeLogic.GetQueryEmployeeInfoView(employeeNo, employeeName);
        /*将查询结果集绑定到gridview控件上*/
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = ds;
        this.GridView1.PageIndex = 0;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标选择某行时变颜色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            e.Row.Cells[3].Text = Convert.ToDateTime(e.Row.Cells[3].Text).ToShortDateString();
        }
    }
   
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        /*取得查询的各个参数*/
        string employeeNo = this.EmployeeNo.Text;
        string employeeName = this.EmployeeName.Text;
        /*调用业务层得到查询的结果数据集*/
        EmployeeLogic employeeLogic = new EmployeeLogic();
        DataSet ds = employeeLogic.GetQueryEmployeeInfoView(employeeNo, employeeName);
        /*将查询结果集绑定到gridview控件上*/
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = ds;
        this.GridView1.PageIndex = e.NewPageIndex;;
        this.GridView1.DataBind();
    }
}
