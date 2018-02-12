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
    /// BuyInfoLogic 的摘要说明：关于商品进货信息的业务处理逻辑类
    /// </summary>
    public class BuyInfoLogic
    {
        private string errMessage;  /*保存业务处理时的逻辑错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*传入商品进货信息模型对象，实现商品进货信息的加入操作*/
        public bool AddBuyInfo(BuyInfoModel buyInfoModel)
        {
            /*首先验证管理员输入的商品编号在系统中是否存在*/
            string sqlString = "select * from [goodInfo] where goodNo='" + buyInfoModel.GoodNo + "'";
            if(!DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null).Read())
            {
                this.errMessage = "你输入的商品不存在！";
                return false;
            }
            /*构造sql语句实现进货信息的加入操作*/
            sqlString = "insert into [buyInfo] (goodNo,supplierName,price,number,totalPrice,buyDate,addTime) values ('";
            sqlString += buyInfoModel.GoodNo + "','";
            sqlString += buyInfoModel.SupplierName + "',";
            sqlString += buyInfoModel.Price + ",";
            sqlString += buyInfoModel.Number + ",";
            sqlString += buyInfoModel.TotalPrice + ",'";
            sqlString += buyInfoModel.BuyDate + "','";
            sqlString += buyInfoModel.AddTime + "')";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "添加商品进货信息时发生了错误!";
                return false;
            }
            /*增加对应商品的库存*/
            sqlString = "update [goodStockInfo] set goodCount = goodCount + " + buyInfoModel.Number + " where goodNo='" + buyInfoModel.GoodNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "登记进货时修改商品库存失败!";
                return false;
            }
            return true;
        }
        /*根据查询条件执行商品进货信息的查询*/
        public static DataSet QueryBuyInfo(string goodNo, string goodName, int goodClassId, string startTime, string endTime)
        {
            /*根据查询条件构造sql语句*/
            string sqlString = "select * from [buyInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId=" + goodClassId;
            if (startTime != "")
                sqlString += " and buyDate>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and buyDate<='" + Convert.ToDateTime(endTime) + "'";
            /*调用数据层执行查询并返回结果集*/
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据查询条件执行商品进货总金额的查询*/
        public static float QueryBuyInfoTotalPrice(string goodNo, string goodName, int goodClassId, string startTime, string endTime)
        {
            /*根据查询条件构造sql语句*/
            string sqlString = "select SUM(totalPrice) as TotalPrice from [buyInfoView] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId=" + goodClassId;
            if (startTime != "")
                sqlString += " and buyDate>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and buyDate<='" + Convert.ToDateTime(endTime) + "'";
            /*调用数据层执行查询并返回总金额*/
            try
            {
                return Convert.ToSingle(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            }
            catch (Exception exp)
            {
                return 0.0f;
            }
         }
        /*根据商品进货编号集合实现对相关信息的删除操作*/
        public static bool DeleteBuyInfo(string buyIds)
        {
            string sqlString = "delete from [buyInfo] where buyId in (" + buyIds + ")";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                return false;
            return true;
        }
        public BuyInfoLogic()
        {
            this.errMessage = "";
        }
    }

}
