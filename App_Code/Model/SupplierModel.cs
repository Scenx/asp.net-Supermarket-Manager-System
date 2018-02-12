using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SuperMarket.Model
{
    /// <summary>
    /// SupplierModel 的摘要说明:关于商品进货供应商的信息模型，对应数据库中的供应商信息表
    /// </summary>
    public class SupplierModel
    {
        /*供应商信息表
        CREATE TABLE [dbo].[supplierInfo] (
	        [supplierName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,	//供应商公司名称
	        [supplierLawyer] [nvarchar] (4) COLLATE Chinese_PRC_CI_AS NULL ,	//供应商法人代表
	        [supplierTelephone] [varchar] (11) COLLATE Chinese_PRC_CI_AS NULL ,	//供应商电话
	        [supplierAddress] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL 	//供应商地址
        ) ON [PRIMARY]
         */
        private string supplierName;        /*供应商公司名称*/
        public string SupplierName
        {
            set { this.supplierName = value; }
            get { return this.supplierName; }
        }
        private string supplierLawyer;      /*供应商法人代表*/
        public string SupplierLayer
        {
            set { this.supplierLawyer = value; }
            get { return this.supplierLawyer; }
        }
        private string supplierTelephone;   /*供应商电话*/
        public string SupplierTelephone
        {
            set { this.supplierTelephone = value; }
            get { return this.supplierTelephone; }
        }
        private string supplierAddress;     /*供应商地址*/
        public string SupplierAddress
        {
            set { this.supplierAddress = value; }
            get { return this.supplierAddress; }
        }
        public SupplierModel()
        {
            this.supplierName = this.supplierLawyer = this.supplierTelephone = this.supplierAddress = "";
        }
    }

}
