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
using SuperMarket.Utility;

namespace SuperMarket.Logic
{
    /// <summary>
    /// EducationLogic 的摘要说明:关于教育层次信息管理的业务层
    /// </summary>
    public class EducationLogic
    {
        /*得到所有教育层次信息的sql语句*/
        private const string SQL_SELECT_ALL_EDUCATION_INFO = "select * from [educationInfo] ";
        /*根据教育层次编号得到教育层次名称的sql语句*/
        private const string SQL_SELECT_EDUCATION_NAME_BY_ID = "select educationName from [educationInfo] where educationId=@educationId";
        /*sql语句的参数*/
        private const string PARM_EDUCATION_ID = "@educationId";
        /*根据教育层次id号得到教育层次名称*/
        public string GetEducationNameById(int educationId)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter(PARM_EDUCATION_ID, SqlDbType.Int) };
            parms[0].Value = educationId;
            return DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_EDUCATION_NAME_BY_ID, parms).ToString();
        }
        /*得到所有的教育层次并返回结果集*/
        public DataSet GetAllEducationInfo()
        {
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_ALL_EDUCATION_INFO, null);
        }

    }

}
