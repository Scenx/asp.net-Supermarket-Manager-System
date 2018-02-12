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
    /// GoodCartInfoModel 的摘要说明:员工销售商品购物车信息模型类,对应于数据库中的员工商品购物车信息表
    /// </summary>
    public class GoodCartInfoModel
    {
        /*购物车信息表
        CREATE TABLE [dbo].[goodCartInfo] (
	        [goodCartId] [int] IDENTITY (1, 1) NOT NULL ,				    //系统记录编号
	        [employeeNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//员工编号
	        [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//商品编号
	        [goodCount] [int] NULL 							                //商品数量
        ) ON [PRIMARY]
         */
        private int goodCartId; /*系统记录编号*/
        public int GoodCartId
        {
            set { this.goodCartId = value; }
            get { return this.goodCartId; }
        }
        private string employeeNo;  /*员工编号*/
        public string EmployeeNo
        {
            set { this.employeeNo = value; }
            get { return this.employeeNo; }
        }
        private string goodNo;  /*商品编号*/
        public string GoodNo
        {
            set { this.goodNo = value; }
            get { return this.goodNo; }
        }
        private int goodCount;  /*商品数量*/
        public int GoodCount
        {
            set { this.goodCount = value; }
            get { return this.goodCount; }
        }
        public GoodCartInfoModel()
        {
            this.goodCartId = this.goodCount = 0;
            this.goodNo = this.employeeNo = "";
        }
    }

}
