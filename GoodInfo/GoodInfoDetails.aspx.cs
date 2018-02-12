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

public partial class GoodInfo_GoodInfoDetails : System.Web.UI.Page
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
            /*取得更新商品的商品编号*/
            string goodNo = Request.QueryString["goodNo"];
            /*调用业务层根据商品编号得到商品的信息并保存在模型中*/
            GoodInfoModel goodInfoModel = GoodLogic.GetGoodInfoByNo(goodNo);
            /*显示该商品的各个信息*/
            this.GoodNo.Text = goodInfoModel.GoodNo;
            this.GoodClassName.Text = GoodClassLogic.GetGoodClassNameById(goodInfoModel.GoodClassId);
            this.GoodName.Text = goodInfoModel.GoodName;
            this.GoodUnit.Text = goodInfoModel.GoodUnit;
            this.GoodModel.Text = goodInfoModel.GoodModel;
            this.GoodSpecs.Text = goodInfoModel.GoodSpecs;
            this.GoodPrice.Text = goodInfoModel.GoodPrice.ToString();
            this.GoodPlace.Text = goodInfoModel.GoodPlace;
            this.GoodMemo.Text = goodInfoModel.GoodMemo;
        }
    }
}
