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
    /// GoodClassModel 的摘要说明:关于商品类别信息的数据模型，对应于数据库中的商品类别信息表(goodClassInfo表)
    /// </summary>
    public class GoodClassModel
    {
        /*商品类别信息表
        CREATE TABLE [dbo].[goodClassInfo] (
	        [goodClassId] [int] IDENTITY (1, 1) NOT NULL ,				        //商品类别编号
	        [goodClassName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL 		//商品类别名称
        ) ON [PRIMARY]
         */
        private int goodClassId;    /*商品类别编号*/
        public int GoodClassId
        {
            set { this.goodClassId = value; }
            get { return this.goodClassId; }
        }
        private string goodClassName;   /*商品类别名称*/
        public string GoodClassName
        {
            set { this.goodClassName = value; }
            get { return this.goodClassName; }
        }
        public GoodClassModel()
        {
            this.goodClassId = 0;
            this.goodClassName = "";
        }
    }
}

