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
    /// SellBackInfoModel 的摘要说明:关于顾客退货信息模型，对应于数据库中的商品退货信息表
    /// </summary>
    public class SellBackInfoModel
    {
        /*顾客退货信息表
        CREATE TABLE [dbo].[sellBackInfo] (
	        [sellBackId] [int] IDENTITY (1, 1) NOT NULL ,				//系统记录编号
	        [sellNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//销售小票号
	        [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//商品编号
	        [price] [float] NULL ,							            //退货单价
	        [number] [int] NULL ,							            //退货数量
	        [totalPrice] [float] NULL ,						            //退货总价
	        [sellBackReason] [text] COLLATE Chinese_PRC_CI_AS NULL ,	//退货原因
	        [sellBackTime] [datetime] NULL 						        //退货时间
        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
         */
        private int sellBackId; /*系统记录编号*/
        public int SellBackId
        {
            set { this.sellBackId = value; }
            get { return this.sellBackId; }
        }
        private string sellNo;  /*销售收据编号*/
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
        private float price;    /*退货单价*/
        public float Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        private int number;     /*退货数量*/
        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }
        private float totalPrice;   /*退货总价*/
        public float TotalPrice
        {
            set { this.totalPrice = value; }
            get { return this.totalPrice; }
        }
        private string sellBackReason;  /*退货原因*/
        public string SellBackReason
        {
            set { this.sellBackReason = value; }
            get { return this.sellBackReason; }
        }
        private DateTime sellBackTime;  /*退货时间*/
        public DateTime SellBackTime
        {
            set { this.sellBackTime = value; }
            get { return this.sellBackTime; }
        }
        public SellBackInfoModel()
        {
            this.sellBackId = this.number = 0;
            this.sellNo = this.goodNo = this.sellBackReason = "";
            this.price = this.totalPrice = 0.0f;
            this.sellBackTime = DateTime.Now;
        }
    }

}
