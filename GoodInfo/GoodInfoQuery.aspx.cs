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

public partial class GoodInfo_GoodInfoQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*判断员工是否已经登陆了系统*/
            if (Session["employeeFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
            this.GoodClassId.Items.Clear();
            this.GoodClassId.Items.Add(new ListItem("请选择类别", "0"));
            DataSet goodClassDs = GoodClassLogic.QueryAllGoodClassInfo();
            for (int i = 0; i < goodClassDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodClassDs.Tables[0].Rows[i];
                this.GoodClassId.Items.Add(new ListItem(dr["goodClassName"].ToString(), dr["goodClassId"].ToString()));
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        /*取得查询参数*/
        string goodNo = this.GoodNo.Text;
        string goodName = this.GoodName.Text;
        int goodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        /*调用业务层进行查询，返回dataset,重新绑定*/
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = GoodLogic.QueryGoodInfo(goodNo, goodName, goodClassId);
        this.GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标选择某行时变颜色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        /*取得查询参数*/
        string goodNo = this.GoodNo.Text;
        string goodName = this.GoodName.Text;
        int goodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        /*调用业务层进行查询，返回dataset,重新绑定*/
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = GoodLogic.QueryGoodInfo(goodNo, goodName, goodClassId);
        this.GridView1.PageIndex = 0;
        this.GridView1.DataBind();
    }
}
