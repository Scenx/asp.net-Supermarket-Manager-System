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
    /// SupplierLogic 的摘要说明:关于供应商信息的业务处理类
    /// </summary>
    public class SupplierLogic
    {
        private string errMessage; /*保存业务处理错误信息*/
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*传入供应商信息模型对象，实现供应商信息的添加操作*/
        public bool AddSupplierInfo(SupplierInfoModel supplierInfoModel)
        {
            /*首先查询该供应商名称是否存在*/
            string sqlString = "select * from [supplierInfo] where supplierName='" + supplierInfoModel.SupplierName + "'";
            if (DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).Read())
            {
                this.errMessage = "该供应商名称信息已经存在!";
                return false;
            }
            /*构造sql语句，实现新的供应商信息的加入*/
            sqlString = "insert into [supplierInfo] (supplierName,supplierLawyer,supplierTelephone,supplierAddress) values ('";
            sqlString += supplierInfoModel.SupplierName + "','";
            sqlString += supplierInfoModel.SupplierLawyer + "','";
            sqlString += supplierInfoModel.SupplierTelephone + "','";
            sqlString += supplierInfoModel.SupplierAddress + "')";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) <= 0)
            {
                this.errMessage = "添加供应商信息时发生了错误!";
                return false;
            }
            return true;
        }
        public SupplierLogic()
        {
            this.errMessage = "";
        }
    }

}
