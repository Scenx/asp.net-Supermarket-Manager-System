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

public partial class Admin_SupplierManage : System.Web.UI.Page
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
        SupplierInfoModel supplierInfoModel = new SupplierInfoModel();
        supplierInfoModel.SupplierName = this.NewSupplierName.Text;
        supplierInfoModel.SupplierLawyer = this.NewSupplierLawyer.Text;
        supplierInfoModel.SupplierTelephone = this.NewSupplierTelephone.Text;
        supplierInfoModel.SupplierAddress = this.NewSupplierAddress.Text;
        SupplierLogic supplierLogic = new SupplierLogic();
        if (supplierLogic.AddSupplierInfo(supplierInfoModel))
        {
            Response.Write("<script>alert('供应商信息登记成功!');location.href='SupplierManage.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('" + supplierLogic.ErrMessage + "');location.href='SupplierManage.aspx';</script>");
        }
    }
}
