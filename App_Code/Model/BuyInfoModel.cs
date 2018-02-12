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
    /// BuyInfoModel 的摘要说明:关于商品进货信息的模型，对应数据库中的商品进货信息表
    /// </summary>
    public class BuyInfoModel
    {
        /*商品进货信息表
        CREATE TABLE [dbo].[buyInfo] (
	        [buyId] [int] IDENTITY (1, 1) NOT NULL ,				        //进货编号
	        [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//商品编号
	        [supplierName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,	//供应商公司名称
	        [price] [float] NULL ,							                //进货单价
	        [number] [int] NULL ,							                //进货数量
	        [totalPrice] [float] NULL ,						                //进货总价格
	        [buyDate] [datetime] NULL ,						                //进货日期
	        [addTime] [datetime] NULL 						                //信息加入时间
        ) ON [PRIMARY]
         */
        private int buyId;  /*进货编号*/
        public int BuyId
        {
            set { this.buyId = value; }
            get { return this.buyId; }
        }
        private string goodNo;  /*商品编号*/
        public string GoodNo
        {
            set { this.goodNo = value; }
            get { return this.goodNo; }
        }
        private string supplierName;    /*供应商名称*/
        public string SupplierName
        {
            set { this.supplierName = value; }
            get { return this.supplierName; }
        }
        private float price;    /*进货单价*/
        public float Price
        {
            set { this.price = value; }
            get { return this.price; }
        }
        private int number; /*进货数量*/
        public int Number
        {
            set { this.number = value; }
            get { return this.number; }
        }
        private float totalPrice;  /*进货总价格*/
        public float TotalPrice
        {
            set { this.totalPrice = value; }
            get { return this.totalPrice; }
        }
        private DateTime buyDate;   /*进货日期*/
        public DateTime BuyDate
        {
            set { this.buyDate = value; }
            get { return this.buyDate; }
        }
        private DateTime addTime;   /*信息加入时间*/
        public DateTime AddTime
        {
            set { this.addTime = value; }
            get { return this.addTime; }
        }
        public BuyInfoModel()
        {
            /*构造函数实现初始化*/
            this.buyId = 0;
            this.goodNo = "";
            this.supplierName = "";
            this.price = 0.0f;
            this.number = 0;
            this.totalPrice = 0.0f;
            this.buyDate = DateTime.Now.Date;
            this.addTime = DateTime.Now;
        }
    }

}
