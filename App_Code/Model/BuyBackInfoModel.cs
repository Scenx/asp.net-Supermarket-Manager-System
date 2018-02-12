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
    /// BuyBackInfoModel 的摘要说明:进货退货信息模型，对应于数据库中的进货退货退货信息表
    /// </summary>
    public class BuyBackInfoModel
    {
        /*进货退货信息表
        CREATE TABLE [dbo].[buyBackInfo] (
	        [buyBackId] [int] IDENTITY (1, 1) NOT NULL ,				    //系统记录编号
	        [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//商品编号
	        [supplierName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,	//供应商
	        [price] [float] NULL ,							                //退货单价
	        [number] [int] NULL ,							                //退货数量
	        [totalPrice] [float] NULL ,						                //退货总金额
	        [buyBackDate] [datetime] NULL ,						            //退货日期
	        [buyBackReason] [text] COLLATE Chinese_PRC_CI_AS NULL ,			//退货原因
	        [buyBackAddTime] [datetime] NULL 					            //退货信息录入时间
        ) ON [PRIMARY]
         */
        private int buyBackId;          /*系统记录编号*/
        public int BuyBackId
        {
            set { this.buyBackId = value; }
            get { return this.buyBackId; }
        }
        private string goodNo;          /*商品编号*/
        public string GoodNo
        {
            set { this.goodNo = value; }
            get { return this.goodNo; }
        }
        private string supplierName;    /*供应商*/
        public string SupplierName
        {
            set { this.supplierName = value; }
            get { return this.supplierName; }
        }
        private float price;            /*退货单价*/
        public float Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        private int number;             /*退货数量*/
        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }
        private float totalPrice;       /*退货总价*/
        public float TotalPrice
        {
            set { this.totalPrice = value; }
            get { return this.totalPrice; }
        }
        private DateTime buyBackDate;   /*退货日期*/
        public DateTime BuyBackDate
        {
            set { this.buyBackDate = value; }
            get { return this.buyBackDate; }
        }
        private string buyBackReason;   /*退货原因*/
        public string BuyBackReason
        {
            set { this.buyBackReason = value; }
            get { return this.buyBackReason; }
        }
        private DateTime buyBackAddTime;/*退货信息录入时间*/
        public DateTime BuyBackAddTime
        {
            set { this.buyBackAddTime = value; }
            get { return this.buyBackAddTime; }
        }
        public BuyBackInfoModel()
        {
            this.buyBackId = 0;
            this.goodNo = "";
            this.supplierName = "";
            this.price = 0.0f;
            this.number = 0;
            this.totalPrice = 0.0f;
            this.buyBackDate = DateTime.Now.Date;
            this.buyBackReason = "";
            this.buyBackAddTime = DateTime.Now;
        }
    }

}
