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

public partial class GoodInfo_GoodInfoAdd : System.Web.UI.Page
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
    protected void Btn_Add_Click(object sender, EventArgs e)
    {
        /*建立商品信息模型并从界面中搜集管理员输入的商品信息*/
        GoodInfoModel goodInfoModel = new GoodInfoModel();
        goodInfoModel.GoodNo = this.GoodNo.Text;
        goodInfoModel.GoodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        goodInfoModel.GoodName = this.GoodName.Text;
        goodInfoModel.GoodUnit = this.GoodUnit.Text;
        goodInfoModel.GoodModel = this.GoodModel.Text;
        goodInfoModel.GoodSpecs = this.GoodSpecs.Text;
        goodInfoModel.GoodPrice = Convert.ToSingle(this.GoodPrice.Text);
        goodInfoModel.GoodPlace = this.GoodPlace.Text;
        goodInfoModel.GoodMemo = this.GoodMemo.Text;
        goodInfoModel.GoodAddTime = DateTime.Now;
        /*调用业务层执行商品信息的加入操作*/
        GoodLogic goodLogic = new GoodLogic();
        if (goodLogic.AddGoodInfo(goodInfoModel))
            Response.Write("<script>alert('商品信息添加成功!');location.href='GoodInfoAdd.aspx';</script>");
        else
            Response.Write("<script>alert('" + goodLogic.ErrMessage + "');location.href='GoodInfoAdd.aspx';</script>");
    }
}
