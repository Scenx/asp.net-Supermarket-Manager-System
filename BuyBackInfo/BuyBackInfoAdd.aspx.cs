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

public partial class BuyInfo_BuyBackInfoAdd : System.Web.UI.Page
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
    protected void Btn_GetGoodInfo_Click(object sender, EventArgs e)
    {
        /*根据商品编号查询商品信息*/
        string goodNo = this.GoodNo.Text;
        GoodInfoModel goodInfoModel = GoodLogic.GetGoodInfoByNo(goodNo);
        if (goodInfoModel == null)
            Response.Write("<script>alert('不存在该商品的信息!');</script>");
        else
        {
            /*将该商品的详细信息显示在界面上供管理员确认无错误*/
            this.GoodName.Text = goodInfoModel.GoodName;
            this.GoodModel.Text = goodInfoModel.GoodModel;
            this.GoodSpecs.Text = goodInfoModel.GoodSpecs;
            this.GoodPlace.Text = goodInfoModel.GoodPlace;
            this.GoodInfoPanel.Visible = true;
        }
    }
    protected void Btn_Add_Click(object sender, EventArgs e)
    {
        if (this.BuyBackDate.Text == "")
        {
            Response.Write("<script>alert('请选择商品进货退货日期!');<script>");
            return;
        }
        /*建立商品进货退货信息模型并搜集各个信息*/
        BuyBackInfoModel buyBackInfoModel = new BuyBackInfoModel();
        buyBackInfoModel.SupplierName = this.SupplierName.Text;
        buyBackInfoModel.GoodNo = this.GoodNo.Text;
        buyBackInfoModel.Price = Convert.ToSingle(this.Price.Text);
        buyBackInfoModel.Number = Convert.ToInt32(this.Number.Text);
        buyBackInfoModel.TotalPrice = buyBackInfoModel.Price * buyBackInfoModel.Number;
        buyBackInfoModel.BuyBackDate = Convert.ToDateTime(this.BuyBackDate.Text).Date;
        buyBackInfoModel.BuyBackReason = this.BuyBackReason.Text;
        buyBackInfoModel.BuyBackAddTime = DateTime.Now;
        /*调用业务层执行新的商品退货业务的处理,成功返回true*/
        BuyBackInfoLogic buyBackInfoLogic = new BuyBackInfoLogic();
        if (buyBackInfoLogic.AddBuyBackInfo(buyBackInfoModel))
            Response.Write("<script>alert('商品进货退货登记成功!');location.href='BuyBackInfoAdd.aspx';</script>");
        else
            Response.Write("<script>alert('" + buyBackInfoLogic.ErrMessage + "');</script>");
    }
    protected void Price_TextChanged(object sender, EventArgs e)
    {
        float price = Convert.ToSingle(this.Price.Text);
        int number = Convert.ToInt32(this.Number.Text);
        float totalPrice = price * number;
        this.TotalPrice.Text = totalPrice.ToString();
    }
    protected void Number_TextChanged(object sender, EventArgs e)
    {
        float price = Convert.ToSingle(this.Price.Text);
        int number = Convert.ToInt32(this.Number.Text);
        float totalPrice = price * number;
        this.TotalPrice.Text = totalPrice.ToString();
    }
}
