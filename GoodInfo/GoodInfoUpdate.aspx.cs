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

public partial class GoodInfo_GoodInfoUpdate : System.Web.UI.Page
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
            DataSet goodClassDs = GoodClassLogic.QueryAllGoodClassInfo();
            for (int i = 0; i < goodClassDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodClassDs.Tables[0].Rows[i];
                this.GoodClassId.Items.Add(new ListItem(dr["goodClassName"].ToString(),dr["goodClassId"].ToString()));
            }
            /*取得更新商品的商品编号*/
            string goodNo = Request.QueryString["goodNo"];
            /*调用业务层根据商品编号得到商品的信息并保存在模型中*/
            GoodInfoModel goodInfoModel = GoodLogic.GetGoodInfoByNo(goodNo);
            /*显示该商品的各个信息*/
            this.GoodNo.Text = goodInfoModel.GoodNo;
            this.GoodClassId.SelectedValue = goodInfoModel.GoodClassId.ToString();
            this.GoodName.Text = goodInfoModel.GoodName;
            this.GoodUnit.Text = goodInfoModel.GoodUnit;
            this.GoodModel.Text = goodInfoModel.GoodModel;
            this.GoodSpecs.Text = goodInfoModel.GoodSpecs;
            this.GoodPrice.Text = goodInfoModel.GoodPrice.ToString();
            this.GoodPlace.Text = goodInfoModel.GoodPlace;
            this.GoodMemo.Text = goodInfoModel.GoodMemo;
        }
    }
    protected void Btn_Update_Click(object sender, EventArgs e)
    {
        /*建立商品信息模型，搜集该商品的各个信息*/
        GoodInfoModel goodInfoModel = new GoodInfoModel();
        goodInfoModel.GoodNo = Request.QueryString["goodNo"];
        goodInfoModel.GoodClassId = Int32.Parse(this.GoodClassId.SelectedValue);
        goodInfoModel.GoodName = this.GoodName.Text;
        goodInfoModel.GoodUnit = this.GoodUnit.Text;
        goodInfoModel.GoodModel = this.GoodModel.Text;
        goodInfoModel.GoodSpecs = this.GoodSpecs.Text;
        goodInfoModel.GoodPrice = Convert.ToSingle(this.GoodPrice.Text);
        goodInfoModel.GoodPlace = this.GoodPlace.Text;
        goodInfoModel.GoodMemo = this.GoodMemo.Text;
        /*调用业务层执行该商品信息的更新操作*/
        if (GoodLogic.UpdateGoodInfo(goodInfoModel))
            Response.Write("<script>alert('商品信息更新成功!');location.href='GoodInfoUpdate.aspx?goodNo=" + goodInfoModel.GoodNo + "';</script>");
        else
            Response.Write("<script>alert('商品信息更新失败!');location.href='GoodInfoUpdate.aspx?goodNo=" + goodInfoModel.GoodNo + "';</script>");
    }
}
