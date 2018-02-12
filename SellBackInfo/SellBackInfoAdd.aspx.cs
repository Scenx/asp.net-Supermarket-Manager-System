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

public partial class SellBackInfo_SellBackInfoAdd : System.Web.UI.Page
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
        if (goodNo == "")
        {
            Response.Write("<script>alert('请输入商品编号信息!');</script>");
            return;
        }
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
        SellBackInfoModel sellBackInfoModel = new SellBackInfoModel();
        sellBackInfoModel.SellNo = this.SellNo.Text;
        sellBackInfoModel.GoodNo = this.GoodNo.Text;
        if (this.Price.Text == "" || this.Number.Text == "")
        {
            Response.Write("<script>商品价格或数量信息输入不能为空!</script>");
        }
        try
        {
            sellBackInfoModel.Price = Convert.ToSingle(this.Price.Text);
        }
        catch
        {
            Response.Write("<script>alert('请输入正确的价格信息!');</script>");
            return;
        }
        try
        {
            sellBackInfoModel.Number = Int32.Parse(this.Number.Text);
        }
        catch
        {
            Response.Write("alert('请输入正确的商品数量!');");
        }
        
        sellBackInfoModel.TotalPrice = sellBackInfoModel.Price * sellBackInfoModel.Number;
        sellBackInfoModel.SellBackReason = this.SellBackReason.Text;
        sellBackInfoModel.SellBackTime = DateTime.Now;
        bool isGood =(Int32.Parse(this.IsGood.SelectedValue) == 1)?true:false;
        SellBackLogic sellBackLogic = new SellBackLogic();
        if (sellBackLogic.SellBackInfoAdd(sellBackInfoModel,isGood))
        {
            Response.Write("<script>alert('商品退货成功!');location.href='SellBackInfoAdd.aspx';</script>");
        }
        else
            Response.Write("<script>alert('" + sellBackLogic.ErrMessage + "');</script>");
    }
}
