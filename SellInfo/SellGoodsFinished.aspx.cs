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

public partial class SellInfo_SellGoodsFinished : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*判断员工(收银员)是否已经登陆了系统*/
            if (Session["employeeFlag"] == null)
            {
                Response.Write("<script>top.location.href='../login.aspx';</script>");
                return;
            }
            /*生成小票号：员工编号+年+月+日+时+分+秒　*/
            string sellNo = Session["employeeNo"].ToString() + DateTime.Now.Year;
            if(DateTime.Now.Month < 10)
                sellNo += "0" + DateTime.Now.Month;
            else
                sellNo += DateTime.Now.Month;
            if(DateTime.Now.Day < 10)
                sellNo += "0" + DateTime.Now.Day;
            else
                sellNo += DateTime.Now.Day;
            if(DateTime.Now.Hour < 10)
                sellNo += "0" + DateTime.Now.Hour;
            else
                sellNo += DateTime.Now.Hour;
            if(DateTime.Now.Minute < 10)
                sellNo += "0" + DateTime.Now.Minute;
            else
                sellNo += DateTime.Now.Minute;
            if(DateTime.Now.Second < 10)
                sellNo += "0" + DateTime.Now.Second;
            else
                sellNo += DateTime.Now.Second;

            this.SellNo.Text = sellNo;
            /*根据员工编号查询购物车并显示购物清单*/
             string employeeNo = Session["employeeNo"].ToString();
            /*查询该员工的商品销售购物车并绑定到gridview控件*/
            DataSet goodCartInfoDs = GoodCartLogic.QueryGoodCartInfo(employeeNo);
            GridView1.DataSource = goodCartInfoDs;
            GridView1.DataBind();
            /*得到该次销售的总的商品数目并显示*/
            this.TotalGoodCount.Text = GoodCartLogic.GetTotalGoodCountInCart(Session["employeeNo"].ToString()).ToString();
            /*得到该次销售的总的销售金额*/
            this.TotalPrice.Text = GoodCartLogic.GetTotalPriceInCart(Session["employeeNo"].ToString()).ToString();
            this.ShouldGiveMoney.Text = GoodCartLogic.GetTotalPriceInCart(Session["employeeNo"].ToString()).ToString();
        }
    }
    protected void Btn_Calculate_Click(object sender, EventArgs e)
    {
        /*取得顾客实际支付的金额*/
        float realGiveMoney;
        try
        {
            realGiveMoney = Convert.ToSingle(this.RealGiveMoney.Text);
        }
        catch (Exception exception)
        {
            Response.Write("<script>alert('请输入正确的money！');</script>");
            return;
        }
        /*计算应当找零的金钱*/
        float giveBackMoney = realGiveMoney - Convert.ToSingle(this.ShouldGiveMoney.Text);
        if (giveBackMoney < 0.0f)
        {
            this.RealGiveMoney.Text = "";
            Response.Write("<script>alert('实际支付金额不够!');</script>");
            return;
        }
        this.GiveBackMoney.Text = giveBackMoney.ToString();

    }
    protected void Btn_SaveSellInfo_Click(object sender, EventArgs e)
    {
        /*取得顾客实际支付的金额*/
        float realGiveMoney;
        try
        {
            realGiveMoney = Convert.ToSingle(this.RealGiveMoney.Text);
        }
        catch (Exception exception)
        {
            Response.Write("<script>alert('请输入正确的money！');</script>");
            return;
        }
        /*计算应当找零的金钱*/
        float giveBackMoney = realGiveMoney - Convert.ToSingle(this.ShouldGiveMoney.Text);
        if (giveBackMoney < 0.0f)
        {
            this.RealGiveMoney.Text = "";
            Response.Write("<script>alert('实际支付金额不够!');</script>");
            return;
        }
        this.GiveBackMoney.Text = giveBackMoney.ToString();

        /*将销售小票号和员工编号传递给业务层执行购物车商品销售信息的登记*/
        string sellNo = this.SellNo.Text;
        string employeeNo = Session["employeeNo"].ToString();
        if (GoodCartLogic.AddGoodSellInfoInCart(sellNo, employeeNo))
            Response.Write("<script>alert('商品销售成功!');location.href='SellGoods.aspx';</script>");
        else
            Response.Write("<script>alert('商品销售发生了错误!');location.href='SellGoods.aspx';</script>");

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            /*计算购物车中每件商品销售总价格信息并显示*/
            float price = Convert.ToSingle(e.Row.Cells[2].Text);
            int number = Convert.ToInt32(e.Row.Cells[3].Text);
            float totalPrice = price * number;
            ((Label)(e.Row.Cells[4].FindControl("GoodTotalPrice"))).Text = totalPrice.ToString();
        }
    }
}
