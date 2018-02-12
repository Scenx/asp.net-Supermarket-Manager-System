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

public partial class GoodInfo_GoodClassAdd : System.Web.UI.Page
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
        GoodClassModel goodClassModel = new GoodClassModel();   /*构建商品类型模型*/
        goodClassModel.GoodClassName = this.GoodClassName.Text; /*取得商品类别名称*/
        GoodClassLogic goodClassLogic = new GoodClassLogic();
        if (goodClassLogic.AddGoodClassInfo(goodClassModel))
            Response.Write("<script>alert('商品类别信息添加成功!');location.href='GoodClassAdd.aspx';</script>");
        else
            Response.Write("<script>alert('"+ goodClassLogic.ErrMessage + "');location.href='GoodClassAdd.aspx';</script>");
    }
}
