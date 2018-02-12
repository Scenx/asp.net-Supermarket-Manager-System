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

public partial class GoodStockInfo_GoodStockCount : System.Web.UI.Page
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
        float buyTotalPrice = BuyInfoLogic.QueryBuyInfoTotalPrice("", "", 0, "", "");
        float buyBackTotalPrice = BuyBackInfoLogic.QueryBuyBackTotalMoney("", "", 0, "", "");
        float sellTotalPrice = SellLogic.QuerySellTotalPrice("", "","", "");
        float sellBackTotalPrice = SellBackLogic.QuerySellBackTotalPrice("","", "", "");
        float profits = sellTotalPrice + buyBackTotalPrice - buyTotalPrice - sellBackTotalPrice;

        this.BuyTotalPrice.Text = buyTotalPrice.ToString();
        this.BuyBackTotalPrice.Text = buyBackTotalPrice.ToString();
        this.SellTotalPrice.Text = sellTotalPrice.ToString();
        this.SellBackTotalPrice.Text = sellBackTotalPrice.ToString();
        this.Profits.Text = sellTotalPrice.ToString() + " + " + buyBackTotalPrice.ToString() + " - " + buyTotalPrice.ToString() + " - " + sellBackTotalPrice.ToString() + " = " + profits.ToString();
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        float buyTotalPrice = BuyInfoLogic.QueryBuyInfoTotalPrice("", "", 0, this.StartTime.Text,this.EndTime.Text);
        float buyBackTotalPrice = BuyBackInfoLogic.QueryBuyBackTotalMoney("", "", 0, this.StartTime.Text,this.EndTime.Text);
        float sellTotalPrice = SellLogic.QuerySellTotalPrice("", "",this.StartTime.Text,this.EndTime.Text);
        float sellBackTotalPrice = SellBackLogic.QuerySellBackTotalPrice("","",this.StartTime.Text,this.EndTime.Text);
        float profits = sellTotalPrice + buyBackTotalPrice - buyTotalPrice - sellBackTotalPrice;

        this.BuyTotalPrice.Text = buyTotalPrice.ToString();
        this.BuyBackTotalPrice.Text = buyBackTotalPrice.ToString();
        this.SellTotalPrice.Text = sellTotalPrice.ToString();
        this.SellBackTotalPrice.Text = sellBackTotalPrice.ToString();
        this.Profits.Text = sellTotalPrice.ToString() + " + " + buyBackTotalPrice.ToString() + " - " + buyTotalPrice.ToString() + " - " + sellBackTotalPrice.ToString() + " = " + profits.ToString();
    }
}
