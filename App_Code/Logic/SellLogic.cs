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
    /// SellLogic 的摘要说明:关于商品销售的业务处理逻辑类
    /// </summary>
    public class SellLogic
    {
        private string errMessage; /*保存业务逻辑错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*传入商品销售信息模型，实现销售信息的登记操作*/
        public static bool AddSellInfo(SellInfoModel sellInfoModel)
        {
            string sqlString = "insert into [sellInfo] (sellNo,goodNo,price,number,totalPrice,sellTime,employeeNo) values ('";
            sqlString += sellInfoModel.SellNo + "','";
            sqlString += sellInfoModel.GoodNo + "',";
            sqlString += sellInfoModel.Price + ",";
            sqlString += sellInfoModel.Number + ",";
            sqlString += sellInfoModel.TotalPrice + ",'";
            sqlString += sellInfoModel.SellTime + "','";
            sqlString += sellInfoModel.EmployeeNo + "')";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
                return false;
            return true;
        }
        /*根据员工编号，销售单据，开始时间和结束时间查询员工的销售业绩信息*/
        public static DataSet QuerySellInfo(string employeeNo,string sellNo, string startTime, string endTime)
        {
            string sqlString = "select * from [sellInfo] where 1=1";
            if (employeeNo != "")
                sqlString += " and employeeNo like '%" + employeeNo + "%'";
            if (sellNo != "")
                sqlString += " and sellNo like '%" + sellNo + "%'";
            if (startTime != "")
                sqlString += " and sellTime>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and sellTime<='" + Convert.ToDateTime(endTime) + "'";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        /*根据员工编号，销售单据，开始时间和结束时间查询员工的销售总价格*/
        public static float QuerySellTotalPrice(string employeeNo,string sellNo, string startTime, string endTime)
        {
            string sqlString = "select sum(totalPrice) as TotalPrice from [sellInfo] where 1=1";
            if (employeeNo != "")
                sqlString += " and employeeNo like '%" + employeeNo + "%'";
            if (sellNo != "")
                sqlString += " and sellNo like '%" + sellNo + "%'";
            if (startTime != "")
                sqlString += " and sellTime>='" + Convert.ToDateTime(startTime) + "'";
            if (endTime != "")
                sqlString += " and sellTime<='" + Convert.ToDateTime(endTime) + "'";
            try
            {
                return Convert.ToSingle(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
            }
            catch (Exception exp)
            {
                return 0.0f;
            }
            
        }
        /*根据开始时间和结束时间查询所有员工的销售业绩信息*/
        public static DataSet QueryEmployeeSellResult(string startTime, string endTime)
        {
            /*首先清空员工销售业绩信息表中的信息(因为要对其进行重新统计*/
            string sqlString = "delete from [employeeSellResult]";
            DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            /*查询所有的员工信息*/
            sqlString = "select employeeNo,employeeName from [employeeInfo]";
            DataSet employeeInfoDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            /*遍历每个员工记录，统计该员工在查询时间类的销售总金额*/
            for (int i = 0; i < employeeInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow employeeInfoRow = employeeInfoDs.Tables[0].Rows[i];
                string employeeNo = employeeInfoRow["employeeNo"].ToString();
                string employeeName = employeeInfoRow["employeeName"].ToString();
                /*查询该员工在指定时间内的销售业绩*/
                sqlString = "select sum(totalPrice) as employeeSellMoney from [sellInfo] where employeeNo='" + employeeNo + "'";
                if (startTime != "")
                    sqlString += " and sellTime >= '" + Convert.ToDateTime(startTime) + "'";
                if (endTime != "")
                    sqlString += " and sellTime <= '" + Convert.ToDateTime(endTime) + "'";
                float employeeSellMoney;
                try
                {
                    employeeSellMoney = Convert.ToSingle(DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null));
                }
                catch (Exception exp)
                {
                    employeeSellMoney = 0.0f;
                }
                /*将该员工该时间内的销售业绩加入到信息表中*/
                sqlString = "insert into [employeeSellResult] (employeeNo,employeeName,employeeSellMoney) values ('";
                sqlString += employeeNo + "','";
                sqlString += employeeName + "',";
                sqlString += employeeSellMoney + ")";
                DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
            }
            /*所有员工在该时间段内的销售业绩计算完毕后就返回该结果集(按销售额排序)*/
            sqlString = "select * from [employeeSellResult] order by employeeSellMoney DESC";
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null);
        }
        public SellLogic()
        {
            this.errMessage = "";
        }
    }

}
