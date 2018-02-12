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
    /// GoodClassLogic 的摘要说明:关于商品类别信息处理的业务类
    /// </summary>
    public class GoodClassLogic
    {
        private string errMessage;  /*保存业务处理错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*根据商品类型模型对象执行添加操作*/
        public bool AddGoodClassInfo(GoodClassModel goodClassModel)
        {
            /*首先查询该商品类别名称在系统中是否已经存在*/
            string sqlString = "select * from [goodClassInfo] where goodClassName='" + goodClassModel.GoodClassName + "'";
            if (DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).Read())
            {
                this.errMessage = "该商品类别名称已经存在!";
                return false;
            }
            /*执行新的商品类别信息的加入操作*/
            sqlString = "insert into [goodClassInfo] (goodClassName) values ('" + goodClassModel.GoodClassName + "')";
            if(DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,sqlString,null) <= 0)
            {
                this.errMessage = "添加商品类别时发生了错误!";
                return false;
            }
            return true;
        }
        /*查询所有的商品类别信息并返回DataSet*/
        public static DataSet QueryAllGoodClassInfo()
        {
            string sqlString = "select * from [goodClassInfo]";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据类别编号得到类别名称*/
        public static string GetGoodClassNameById(int goodClassId)
        {
            string sqlString = "select goodClassName from [goodClassInfo] where goodClassId=" + goodClassId;
            return DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).ToString();
        }
        public GoodClassLogic()
        {
            this.errMessage = "";
        }
    }
}

