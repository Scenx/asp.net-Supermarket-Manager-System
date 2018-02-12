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
    /// GoodStockLogic 的摘要说明:关于商品库存操作处理的业务类
    /// </summary>
    public class GoodStockLogic
    {
        private string errMessage; /*保存业务处理错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*根据查询条件实现商品库存信息的查询*/
        public static DataSet QueryGoodStockInfo(string goodNo, string goodName, int goodClassId)
        {
            string sqlString = "select * from [goodStockInfo] where 1=1";
            if (goodNo != "")
                sqlString += " and goodNo like '%" + goodNo + "%'";
            if (goodName != "")
                sqlString += " and goodName like '%" + goodName + "%'";
            if (goodClassId != 0)
                sqlString += " and goodClassId = " + goodClassId;
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*查询商品库存过多或过少的商品库存信息*/
        public static DataSet QueryGoodStockWarningInfo(string goodNo, string goodName, int goodClassId)
        {
            string sqlString = "select * from [goodStockInfo] where goodCount>200 or goodCount<20";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        public GoodStockLogic()
        {
            this.errMessage = "";
        }
    }

}
