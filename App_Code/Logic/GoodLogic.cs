using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SuperMarket.Utility;
using SuperMarket.Model;

namespace SuperMarket.Logic
{
    /// <summary>
    /// GoodLogic 的摘要说明：关于商品信息操作的业务处理类
    /// </summary>
    public class GoodLogic
    {
        private string errMessage;  /*保存业务处理错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*根据商品信息模型对象执行新商品信息的加入操作*/
        public bool AddGoodInfo(GoodInfoModel goodInfoModel)
        {
            /*查询该商品编号是否已经存在*/
            string sqlString = "select * from [goodInfo] where goodNo='" + goodInfoModel.GoodNo + "'";
            if (DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).Read())
            {
                this.errMessage = "你输入的商品编号已经存在!";
                return false;
            }
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
           　/*下面构造添加商品信息的sql语句*/
            sqlString = "insert into [goodInfo] (goodNo,goodClassId,goodName,goodUnit,goodModel,goodSpecs,goodPrice,goodPlace,goodMemo,goodAddTime) values ('";
            sqlString += goodInfoModel.GoodNo + "',";
            sqlString += goodInfoModel.GoodClassId + ",'";
            sqlString += goodInfoModel.GoodName + "','";
            sqlString += goodInfoModel.GoodUnit + "','";
            sqlString += goodInfoModel.GoodModel + "','";
            sqlString += goodInfoModel.GoodSpecs + "',";
            sqlString += goodInfoModel.GoodPrice + ",'";
            sqlString += goodInfoModel.GoodPlace + "','";
            sqlString += goodInfoModel.GoodMemo + "','";
            sqlString += goodInfoModel.GoodAddTime + "')";
            /*调用数据层执行加入操作,成功返回一个大于０的数*/
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "添加商品信息时发生了错误!";
                return false;
            }
            /*下面将新商品的库存设置为0并加入到库存信息表中*/
            sqlString = "insert into [goodStockInfo] (goodNo,goodCount) values ('" + goodInfoModel.GoodNo + "',0)";
            if(DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null) <= 0)
            {
                this.errMessage = "设置新商品的库存时发生了错误!";
                return false;
            }
            return true;
        }
        /*根据查询条件实现对商品信息的查询操作*/
        public static DataSet QueryGoodInfo(string goodNo, string goodName, int goodClassId)
        {
            string sqlString = "select * from [goodInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId = " + goodClassId;
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据商品编号得到该商品的信息并保存在模型对象中返回*/
        public static GoodInfoModel GetGoodInfoByNo(string goodNo)
        {
            string sqlString = "select * from [goodInfo] where goodNo='" + goodNo + "'";
            DataSet goodInfoDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            if (goodInfoDs.Tables[0].Rows.Count == 0) return null;
            DataRow dr = goodInfoDs.Tables[0].Rows[0];  /*取得该商品记录所在行*/
            GoodInfoModel goodInfoModel = new GoodInfoModel();
            goodInfoModel.GoodNo = goodNo;
            goodInfoModel.GoodClassId = Convert.ToInt32(dr["goodClassId"]);
            goodInfoModel.GoodName = dr["goodName"].ToString();
            goodInfoModel.GoodUnit = dr["goodUnit"].ToString();
            goodInfoModel.GoodModel = dr["goodModel"].ToString();
            goodInfoModel.GoodSpecs = dr["goodSpecs"].ToString();
            goodInfoModel.GoodPrice = Convert.ToSingle(dr["goodPrice"]);
            goodInfoModel.GoodPlace = dr["goodPlace"].ToString();
            goodInfoModel.GoodMemo = dr["goodMemo"].ToString();
            goodInfoModel.GoodAddTime = Convert.ToDateTime(dr["goodAddTime"]);

            return goodInfoModel;
        }
        /*传入商品信息模型对象，根据该对象中的商品编号实现更新操作*/
        public static bool UpdateGoodInfo(GoodInfoModel goodInfoModel)
        {
            /*构造更新的sql语句*/
            string sqlString = "update [goodInfo] set goodClassId=";
            sqlString += goodInfoModel.GoodClassId + ",goodName='";
            sqlString += goodInfoModel.GoodName + "',goodUnit='";
            sqlString += goodInfoModel.GoodUnit + "',goodModel='";
            sqlString += goodInfoModel.GoodModel + "',goodSpecs='";
            sqlString += goodInfoModel.GoodSpecs + "',goodPrice=";
            sqlString += goodInfoModel.GoodPrice + ",goodPlace='";
            sqlString += goodInfoModel.GoodPlace + "',goodMemo='";
            sqlString += goodInfoModel.GoodMemo + "' where goodNo='" + goodInfoModel.GoodNo + "'";
            /*调用数据层执行更新操作*/
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                return false;
            return true;
        }
        public GoodLogic()
        {
            this.errMessage = "";
        }
    }
}

