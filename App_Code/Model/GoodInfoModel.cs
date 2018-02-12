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
    /// GoodModel 的摘要说明：关于商品信息的模型类，对应数据库中的商品信息表(goodInfo表)
    /// </summary>
    public class GoodInfoModel
    {
        /*商品信息表
        CREATE TABLE [dbo].[goodInfo] (
            [goodNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,		//商品编号 
	        [goodClassId] [int] NULL ,                                          //商品类别编号
            [goodName] [nvarchar] (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,		//商品名称
            [goodUnit] [nvarchar] (2) COLLATE Chinese_PRC_CI_AS NULL ,		    //商品单位
            [goodModel] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//商品型号
            [goodSpecs] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//商品规格
            [goodPrice] [float] NULL ,						                    //商品出售单价
            [goodPlace] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,		//商品生产地
            [goodMemo] [char] (10) COLLATE Chinese_PRC_CI_AS NULL ,			    //商品附加信息
            [goodAddTime] [datetime] NULL 						                //商品加入时间
        ) ON [PRIMARY]*/
        private string goodNo;      /*商品编号*/
        public string GoodNo
        {
            set { this.goodNo = value; }
            get { return this.goodNo; }
        }
        private int goodClassId;    /*商品类别编号*/
        public int GoodClassId
        {
            set { this.goodClassId = value; }
            get { return this.goodClassId; }
        }
        private string goodName;    /*商品名称*/
        public string GoodName
        {
            set { this.goodName = value; }
            get { return this.goodName; }
        }
        private string goodUnit;    /*商品单位*/
        public string GoodUnit
        {
            set { this.goodUnit = value; }
            get { return this.goodUnit; }
        }
        private string goodModel;   /*商品型号*/
        public string GoodModel
        {
            set { this.goodModel = value; }
            get { return this.goodModel; }
        }
        private string goodSpecs;   /*商品规格*/
        public string GoodSpecs
        {
            set { this.goodSpecs = value; }
            get { return this.goodSpecs; }
        }
        private float goodPrice;    /*商品售价*/
        public float GoodPrice
        {
            set { this.goodPrice = value; }
            get { return this.goodPrice; }
        }
        private string goodPlace;   /*商品产地*/
        public string GoodPlace
        {
            set { this.goodPlace = value; }
            get { return this.goodPlace; }
        }
        private string goodMemo;    /*商品附加信息*/
        public string GoodMemo
        {
            set { this.goodMemo = value; }
            get { return this.goodMemo; }
        }
        private DateTime goodAddTime;   /*商品加入时间*/
        public DateTime GoodAddTime
        {
            set { this.goodAddTime = value; }
            get { return this.goodAddTime; }
        }
        public GoodInfoModel()
        {
            this.goodNo = "";
            this.goodClassId = 0;
            this.goodName = "";
            this.goodUnit = "";
            this.goodModel = "";
            this.goodSpecs = "";
            this.goodPrice = 0.0f;
            this.goodPlace = "";
            this.goodMemo = "";
            this.goodAddTime = DateTime.Now;
        }
    }

}
