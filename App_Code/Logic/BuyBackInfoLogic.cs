using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SuperMarket.Model;
using SuperMarket.Utility;

namespace SuperMarket.Logic
{
    /// <summary>
    /// BuyBackInfoLogic 的摘要说明:关于商品进货退货信息的业务处理类
    /// </summary>
    public class BuyBackInfoLogic
    {
        private string errMessage;  /*保存业务处理错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*传入商品退货信息模型，执行商品的退货操作*/
        public bool AddBuyBackInfo(BuyBackInfoModel buyBackInfoModel)
        {
            /*商品查询是否存在该商品编号*/
            string sqlString = "select * from [goodInfo] where goodNo='" + buyBackInfoModel.GoodNo + "'";
            if (!DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).Read())
            {
                this.errMessage = "你输入的商品信息不存在!";
                return false;
            }
            /*查询该商品目前的库存量*/
            sqlString = "select goodCount from [goodStockInfo] where goodNo='" + buyBackInfoModel.GoodNo + "'";
            int goodCount = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            if (buyBackInfoModel.Number > goodCount)
            {
                this.errMessage = "你输入的该商品数量不能大于库存量";
                return false;
            }
            /*将该商品退货信息登记入系统中*/
            sqlString = "insert into buyBackInfo (goodNo,supplierName,price,number,totalPrice,buyBackDate,buyBackReason,buyBackAddTime) values ('";
            sqlString += buyBackInfoModel.GoodNo + "','";
            sqlString += buyBackInfoModel.SupplierName + "',";
            sqlString += buyBackInfoModel.Price + ",";
            sqlString += buyBackInfoModel.Number + ",";
            sqlString += buyBackInfoModel.TotalPrice + ",'";
            sqlString += buyBackInfoModel.BuyBackDate + "','";
            sqlString += buyBackInfoModel.BuyBackReason + "','";
            sqlString += buyBackInfoModel.BuyBackAddTime + "')";
            /*调用数据层执行信息登记操作*/
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "商品进货退货登记时发生了数据错误!";
                return false;
            }
            /*商品退货后需要更新对应商品的库存*/
            sqlString = "update [goodStockInfo] set goodCount = goodCount - " + buyBackInfoModel.Number + " where goodNo='" + buyBackInfoModel.GoodNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "商品进货退货时修改商品库存发生了错误!";
                return false;
            }
            return true;
        }
        /*根据查询条件执行商品进货退货信息的查询*/
        public static DataSet QueryBuyBackInfo(string goodNo, string goodName, int goodClassId, string startTime, string endTime)
        {
            /*根据查询条件构造sql语句*/
            string sqlString = "select * from [buyBackInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId=" + goodClassId;
            if (startTime != "")
                sqlString += " and buyBackDate>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and buyBackDate<='" + Convert.ToDateTime(endTime) + "'";
            /*调用数据层执行查询并返回结果集*/
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据查询条件执行商品进货退货总金额信息的查询*/
        public static float QueryBuyBackTotalMoney(string goodNo, string goodName, int goodClassId, string startTime, string endTime)
        {
            /*根据查询条件构造sql语句*/
            string sqlString = "select SUM(totalPrice) as TotalPrice from [buyBackInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId=" + goodClassId;
            if (startTime != "")
                sqlString += " and buyBackDate>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and buyBackDate<='" + Convert.ToDateTime(endTime) + "'";
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

        /*根据商品进货退货编号集合实现对相关信息的删除操作*/
        public static bool DeleteBuyBackInfo(string buyBackIds)
        {
            string sqlString = "delete from [buyBackInfo] where buyBackId in (" + buyBackIds + ")";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                return false;
            return true;
        }

        public BuyBackInfoLogic()
        {
            this.errMessage = "";
        }
    }

}
