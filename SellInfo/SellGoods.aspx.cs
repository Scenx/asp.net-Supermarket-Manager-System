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
using SuperMarket.Model;

public partial class SellInfo_SellGoods : System.Web.UI.Page
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
            InitGoodCartInfo();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        InitGoodCartInfo();
    }
    /*初始化当前员工的销售商品购物车*/
    protected void InitGoodCartInfo()
    {
        string employeeNo = Session["employeeNo"].ToString();
        /*查询该员工的商品销售购物车并绑定到gridview控件*/
        DataSet goodCartInfoDs = GoodCartLogic.QueryGoodCartInfo(employeeNo);
        GridView1.DataSource = goodCartInfoDs;    
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标选择某行时变颜色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00ffee';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        /*取得该记录编号和要修改的销售数目*/
        int goodCartId = Int32.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
        int goodCount = Int32.Parse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("GoodCount")).Text);
        /*调用业务层执行更新操作*/
        GoodCartLogic goodCartLogic = new GoodCartLogic();
        if(goodCartLogic.UpdateGoodCartInfo(goodCartId,goodCount))
        {
            Response.Write("<script language=javascript>alert('修改成功!');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('" + goodCartLogic.ErrMessage + "');</script>");
        }
        GridView1.EditIndex = -1;
        InitGoodCartInfo();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        /*取得该记录编号*/
        int goodCartId = Int32.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString()); 
        GoodCartLogic goodCartLogic = new GoodCartLogic();
        if(goodCartLogic.DeleteGoodCartInfo(goodCartId))
        {
            Response.Write("<script language=javascript>alert('成功删除商品购物车信息！');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('" + goodCartLogic.ErrMessage + "');</script>");
        }
        GridView1.EditIndex = -1;
        InitGoodCartInfo();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        InitGoodCartInfo();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;  //GridView编辑项索引等于单击行的索引
        InitGoodCartInfo();
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
        /*建立商品销售购物车模型取得商品销售信息*/
        GoodCartInfoModel goodCartInfoModel = new GoodCartInfoModel();
        goodCartInfoModel.GoodNo = this.GoodNo.Text;
        try
        {
            goodCartInfoModel.GoodCount = Int32.Parse(this.GoodCount.Text);
        }
        catch(Exception exception)
        {
            Response.Write("<script>alert('请输入正确的数字!');</script>");
            return;
        }
        goodCartInfoModel.EmployeeNo = Session["employeeNo"].ToString();
        /*调用业务层执行商品销售信息的加入操作*/
        GoodCartLogic goodCartLogic = new GoodCartLogic();
        if (goodCartLogic.AddGoodCartInfo(goodCartInfoModel))
            Response.Write("<script>alert('商品销售信息添加成功!');location.href='SellGoods.aspx';</script>");
        else
            Response.Write("<script>alert('" + goodCartLogic.ErrMessage + "');location.href='SellGoods.aspx';</script>");
    }
    protected void Btn_Finished_Click(object sender, EventArgs e)
    {
        Response.Redirect("SellGoodsFinished.aspx");
    }
}
