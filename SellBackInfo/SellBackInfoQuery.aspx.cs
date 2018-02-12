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

public partial class SellBackInfo_SellBackInfoQuery : System.Web.UI.Page
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
            this.GridView1.DataSource = SellBackLogic.QuerySellBackInfo("","", "", "");
            this.GridView1.DataBind();
            this.TotalPrice.Text = SellBackLogic.QuerySellBackTotalPrice("", "","", "").ToString();
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        string goodNo = this.GoodNo.Text;
        string startTime = this.StartTime.Text;
        string endTime = this.EndTime.Text;
        string sellNo = this.SellNo.Text; 

        this.GridView1.DataSource = SellBackLogic.QuerySellBackInfo(goodNo,sellNo, startTime, endTime);
        this.GridView1.PageIndex = 0;
        this.GridView1.DataBind();
        this.TotalPrice.Text = SellBackLogic.QuerySellBackTotalPrice(goodNo,sellNo, startTime, endTime).ToString(); ;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string goodNo = this.GoodNo.Text;
        string startTime = this.StartTime.Text;
        string endTime = this.EndTime.Text;
        string sellNo = this.SellNo.Text;
        this.GridView1.DataSource = SellBackLogic.QuerySellBackInfo(goodNo,sellNo, startTime, endTime);
        this.GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataBind();
        this.TotalPrice.Text = SellBackLogic.QuerySellBackTotalPrice(goodNo,sellNo, startTime, endTime).ToString(); ;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标选择某行时变颜色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            string sellBackReason = e.Row.Cells[5].Text;
            if (sellBackReason.Length > 10)
                e.Row.Cells[5].Text = sellBackReason.Substring(0, 10);
            DateTime sellTime = Convert.ToDateTime(e.Row.Cells[6].Text);
            e.Row.Cells[6].Text = sellTime.ToLongDateString() + " " + sellTime.ToLongTimeString();
        }
    }
}
