using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using SuperMarket.Model;
using SuperMarket.Utility;
using System.Collections;

namespace SuperMarket.Logic
{
    /// <summary>
    ///AdminLogic 的摘要说明：关于管理员信息的业务操作
    /// </summary>
    public class AdminLogic
    {
        /*查找系统中是否存在管理员帐号信息的sql语句*/
        private const string SQL_SELECT_IS_EXIST_ADMIN_USERNAME = "select adminPassword from [admin] where adminUsername=@adminUsername";
        /*各种sql语句的参数常量字符串*/
        private const string PARM_ADMIN_USERNAME = "@adminUsername";

        /*业务处理错误信息*/
        private string errMessage;
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }

        /*查找系统管理员表中是否有该管理员的信息*/
        public bool IsExistAdminInfo(AdminModel adminModel)
        {
            /*首先初始化查询sql语句的参数信息*/
            SqlParameter[] parms = this.GetIsExistAdminInfoParms();
            parms[0].Value = adminModel.AdminUsername;
            /*得到该管理员的记录信息*/
            DataSet adminDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_IS_EXIST_ADMIN_USERNAME, parms);
            if (adminDs.Tables[0].Rows.Count == 0) {
                this.errMessage = "对不起，不存在该管理员的帐号信息!";
                return false;
            } else {
                if(adminDs.Tables[0].Rows[0]["adminPassword"].ToString() != adminModel.AdminPassword)
                {
                    this.errMessage = "对不起，管理员的密码不正确!";
                    return false;
                }
            }
            return true;
        }
        private SqlParameter[] GetIsExistAdminInfoParms()
        {
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_SELECT_IS_EXIST_ADMIN_USERNAME);
            if (parms == null)
            {
                parms = new SqlParameter[]{
											  new SqlParameter(PARM_ADMIN_USERNAME,SqlDbType.VarChar) 
										  };
                DBOperation.CacheParameters(SQL_SELECT_IS_EXIST_ADMIN_USERNAME, parms);
            }
            return parms;
        }

        //修改登陆密码
        public bool ChangePassword(AdminModel adminModel)
        {
            string updateString = "update admin set adminPassword='" + adminModel.AdminPassword;
            updateString += "' where adminUsername='" + adminModel.AdminUsername + "'";
            if(DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,updateString,null)<0)
                return false;
            return true;
        }
    }
}
