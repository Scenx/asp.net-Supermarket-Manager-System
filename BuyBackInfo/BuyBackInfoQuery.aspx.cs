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

public partial class BuyInfo_BuyBackInfoQuery : System.Web.UI.Page
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
            /*查询所有商品类别，初始化商品类别信息下拉框控件*/
            DataSet goodClassDs = GoodClassLogic.QueryAllGoodClassInfo();
            this.GoodClassId.Items.Add(new ListItem("请选择商品类别", "0"));
            for (int i = 0; i < goodClassDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodClassDs.Tables[0].Rows[i];
                this.GoodClassId.Items.Add(new ListItem(dr["goodClassName"].ToString(), dr["goodClassId"].ToString()));
            }
            this.GridView1.DataSourceID = null;
            this.GridView1.DataSource = BuyBackInfoLogic.QueryBuyBackInfo("", "", 0, "", "");
            this.GridView1.DataBind();
            this.TotalPrice.Text = BuyBackInfoLogic.QueryBuyBackTotalMoney("", "", 0, "", "").ToString(); ;
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        /*取得查询参数信息*/
        string goodNo = this.GoodNo.Text;
        string goodName = this.GoodName.Text;
        int goodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        string startTime = this.StartTime.Text;
        string endTime = this.EndTime.Text;
        /*调用业务层执行商品进货退货信息的查询并重新绑定到GridView控件*/
        DataSet buyBackInfoDs = BuyBackInfoLogic.QueryBuyBackInfo(goodNo, goodName, goodClassId, startTime, endTime);
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = buyBackInfoDs;
        this.GridView1.PageIndex = 0;
        this.GridView1.DataBind();
        this.TotalPrice.Text = BuyBackInfoLogic.QueryBuyBackTotalMoney(goodNo, goodName, goodClassId, startTime, endTime).ToString();
    }
    protected void Btn_Delete_Click(object sender, EventArgs e)
    {
        int selectCount = 0;　//要删除的进货退货记录总数
        string buyBackIds = ""; //保存要删除的记录编号
        int oneBuyBackId; //保存某行记录的进货编号
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CB_Select");
            if (chk.Checked) //如果要删除该商品进货记录
            {
                oneBuyBackId = Convert.ToInt32(GridView1.DataKeys[gr.RowIndex].Values[0]);
                if (0 == selectCount)
                    buyBackIds = "" + oneBuyBackId + "";
                else
                    buyBackIds = buyBackIds + "," + oneBuyBackId;
                selectCount++;

            }
        }
        if (0 == selectCount) //如果用户没有选择记录
            Response.Write("<script>alert('对不起，你没有选择进货退货信息记录!');</script>");
        else
        {
            /*如果选择了进货记录就执行调用业务层进行该些进货记录信息的删除*/
            if (BuyBackInfoLogic.DeleteBuyBackInfo(buyBackIds))
                Response.Write("<script>alert('删除信息成功!');location.href='BuyBackInfoQuery.aspx';</script>");
            else
                Response.Write("<script>alert('删除信息失败!');location.href='BuyBackInfoQuery.aspx';</script>");
        }
    }
    protected void CB_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            GridViewRow gr = this.GridView1.Rows[i];
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CB_Select");
            chk.Checked = this.CB_SelectAll.Checked; //跟随全选按扭的状态变化;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        /*取得查询参数信息*/
        string goodNo = this.GoodNo.Text;
        string goodName = this.GoodName.Text;
        int goodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        string startTime = this.StartTime.Text;
        string endTime = this.EndTime.Text;
        /*调用业务层执行商品进货退货信息的查询并重新绑定到GridView控件*/
        DataSet buyBackInfoDs = BuyBackInfoLogic.QueryBuyBackInfo(goodNo, goodName, goodClassId, startTime, endTime);
        this.GridView1.DataSourceID = null;
        this.GridView1.DataSource = buyBackInfoDs;
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
            e.Row.Cells[8].Text = Convert.ToDateTime(e.Row.Cells[8].Text).ToShortDateString();
        }
    }
}
