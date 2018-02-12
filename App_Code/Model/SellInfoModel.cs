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
    /// SellInfoModel 的摘要说明:商品销售信息模型，对应于数据库中的商品销售信息表
    /// </summary>
    public class SellInfoModel
    {
        /*销售信息表
        CREATE TABLE [dbo].[sellInfo] (
	        [sellInfoId] [int] IDENTITY (1, 1) NOT NULL ,				//系统记录编号
	        [sellNo] [varchar] (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,//销售单据编号
	        [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//商品编号
	        [price] [float] NULL ,							            //销售单价
	        [number] [int] NULL ,							            //销售数量
	        [totalPrice] [float]  NULL ,                                 //销售总价
	        [sellTime] [datetime] NULL ,						        //销售时间
	        [employeeNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,//销售的员工编号
        ) ON [PRIMARY]
         */
        private int sellInfoId; /*系统记录编号*/
        public int SellInfoId
        {
            set { this.sellInfoId = value; }
            get { return this.sellInfoId; }
        }
        private string sellNo;  /*销售单据编号*/
        public string SellNo
        {
            set { this.sellNo = value; }
            get { return this.sellNo; }
        }
        private string goodNo;  /*商品编号*/
        public string GoodNo
        {
            set { this.goodNo = value; }
            get { return this.goodNo; }
        }
        private float price;    /*销售单价*/
        public float Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        private int number;     /*销售数量*/
        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }
        private float totalPrice;   /*销售总价*/
        public float TotalPrice
        {
            set { this.totalPrice = value; }
            get { return this.totalPrice; }
        }
        private DateTime sellTime;  /*销售加入时间*/
        public DateTime SellTime
        {
            set { this.sellTime = value; }
            get { return this.sellTime; }
        }
        private string employeeNo;  /*销售的员工编号*/
        public string EmployeeNo
        {
            set { this.employeeNo = value; }
            get { return this.employeeNo; }
        }
        public SellInfoModel()
        {
            this.sellInfoId = this.number = 0;
            this.sellNo = this.goodNo = this.employeeNo = "";
            this.price = this.totalPrice = 0.0f;
            this.sellTime = DateTime.Now;
        }
    }

}
