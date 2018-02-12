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
//该源码下载自www.51aspx.com(５１ａsｐｘ．ｃｏｍ)

public partial class BuyInfo_BuyInfoAdd : System.Web.UI.Page
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
        if (this.BuyDate.Text == "")
        {
            Response.Write("<script>alert('请选择进货日期!');</script>");
            return;
        }
        /*建立进货信息模型并取得各个信息*/
        BuyInfoModel buyInfoModel = new BuyInfoModel();
        buyInfoModel.SupplierName = this.SupplierName.Text;
        buyInfoModel.GoodNo = this.GoodNo.Text;
        buyInfoModel.Price = Convert.ToSingle(this.Price.Text);
        buyInfoModel.Number = Int32.Parse(this.Number.Text);
        buyInfoModel.TotalPrice = buyInfoModel.Price * buyInfoModel.Number;
        buyInfoModel.BuyDate = Convert.ToDateTime(this.BuyDate.Text).Date;
        buyInfoModel.AddTime = DateTime.Now;
        /*调用业务层实现进货信息的登记*/
        BuyInfoLogic buyInfoLogic = new BuyInfoLogic();
        if (buyInfoLogic.AddBuyInfo(buyInfoModel))
            Response.Write("<script>alert('商品进货信息登记成功!');location.href='BuyInfoAdd.aspx'</script>");
        else
            Response.Write("<script>alert('" + buyInfoLogic.ErrMessage + "');</script>");

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
