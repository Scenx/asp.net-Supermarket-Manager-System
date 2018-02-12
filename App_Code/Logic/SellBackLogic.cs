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
    /// SellBackLogic 的摘要说明:关于顾客退货的业务处理类
    /// </summary>
    public class SellBackLogic
    {
        private string errMessage; /*保存业务处理的逻辑错误*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*传入商品退货信息模型对象，实现顾客退货的业务操作*/
        public bool SellBackInfoAdd(SellBackInfoModel sellBackInfoModel,bool isGood)
        {
            /*查询销售信息表中是否存在该销售单据号*/
            string sqlString = "select COUNT(*) from [sellInfo] where sellNo='" + sellBackInfoModel.SellNo + "'";
            int count = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            if(count == 0)
            {
                this.errMessage = "你输入的销售单据号不存在!";
                return false;
            }
            /*判断该次销售中是否存在该商品的信息*/
            sqlString = "select COUNT(*) from [sellInfo] where sellNo='" + sellBackInfoModel.SellNo + "' and goodNo='" + sellBackInfoModel.GoodNo + "'";
            count = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null));
            if(0 == count)
            {
                this.errMessage = "该次销售没有该商品的信息！";
                return false;
            }
            /*判断退货的商品数量是否正确*/
            sqlString = "select number from [sellInfo] where sellNo='" + sellBackInfoModel.SellNo + "' and goodNo='" + sellBackInfoModel.GoodNo + "'";
            int number = Convert.ToInt32(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null));
            if(sellBackInfoModel.Number > number)
            {
                this.errMessage = "你的退货数量不能大于销售时的数量!";
                return false;
            }
            /*通过验证后执行商品退货信息的加入*/
            sqlString = "insert into [sellBackInfo] (sellNo,goodNo,price,number,totalPrice,sellBackReason,sellBackTime) values ('";
            sqlString += sellBackInfoModel.SellNo + "','";
            sqlString += sellBackInfoModel.GoodNo + "',";
            sqlString += sellBackInfoModel.Price + ",";
            sqlString += sellBackInfoModel.Number + ",";
            sqlString += sellBackInfoModel.TotalPrice + ",'";
            sqlString += sellBackInfoModel.SellBackReason + "','";
            sqlString += sellBackInfoModel.SellBackTime + "')";
            if(DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null) <= 0)
            {
                this.errMessage = "添加商品退货信息时发生了错误!";
                return false;
            }
            /*如果退回的商品是完好的，需要将商品入库*/
            if (isGood)
            {
                sqlString = "update [goodStockInfo] set goodCount = goodCount + " + sellBackInfoModel.Number; ;
                if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                {
                    this.errMessage = "修改商品库存数量时发生了错误!";
                    return false;
                }
            }
            return true;
        }
        /*根据商品编号，销售单据，开始时间和结束时间查询商品退货信息*/
        public static DataSet QuerySellBackInfo(string goodNo,string sellNo, string startTime, string endTime)
        {
            string sqlString = "select * from [sellBackInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (sellNo != "")
                sqlString += " and sellNo like '%" + sellNo + "%'";
            if (startTime != "")
                sqlString += " and sellBackTime >= '" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and sellBackTime <= '" + Convert.ToDateTime(endTime) + "'";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据商品编号，销售单据，开始时间和结束时间查询商品退货总金额信息*/
        public static float QuerySellBackTotalPrice(string goodNo,string sellNo, string startTime, string endTime)
        {
            string sqlString = "select SUM(totalPrice) as TotalPrice from [sellBackInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (sellNo != "")
                sqlString += " and sellNo like '%" + sellNo + "%'";
            if (startTime != "")
                sqlString += " and sellBackTime >= '" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and sellBackTime <= '" + Convert.ToDateTime(endTime) + "'";

            float TotalPrice;
            try
            {
                TotalPrice = Convert.ToSingle(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            }
            catch(Exception exp)
            {
                TotalPrice = 0.0f;
            }
            return TotalPrice;
        }
        public SellBackLogic()
        {
            this.errMessage = "";
        }
    }
}

