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
using SuperMarket.Model;

namespace SuperMarket.Logic
{
    /// <summary>
    /// EmployeeLogic 的摘要说明：关于员工信息的业务操作
    /// </summary>
    public class EmployeeLogic
    {
        /*保存业务处理的错误信息*/
        private string errMessage;
        public string ErrMessage
        {
            set { this.errMessage = value; }
            get { return this.errMessage; }
        }
        /*执行员工信息加入的sql语句*/
        private const string SQL_INSERT_EMPLOYEE_INFO = "insert into employeeInfo(employeeNo,employeeName,employeePassword,employeeSex,employeeBirthday,employeeEducationId,employeeHomeTel,employeeMobile,employeeCard,employeeEmail,employeeAddress) values (@employeeNo,@employeeName,@employeePassword,@employeeSex,@employeeBirthday,@employeeEducationId,@employeeHomeTel,@employeeMobile,@employeeCard,@employeeEmail,@employeeAddress)";
        /*查询是否已经存在了该员工编号的员工信息*/
        private const string SQL_SELECT_IS_EXIST_EMPLOYEE_NO = "select * from [employeeInfo] where employeeNo=@employeeNo";
        /*根据查询条件从员工信息视图中查询符合条件的员工信息的sql语句*/
        //private const string SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW = "select * from [employeeInfo] where employeeNo like '%@employeeNo%' or employeeName like '%@employeeName%' or departmentName like '%@departmentName%' or workTypeName like '%@workTypeName%'";
        private string SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW = "select * from [employeeInfo] where 1=1";
        /*根据员工编号集合执行员工信息删除的sql语句*/
        private const string SQL_DELETE_EMPLOYEE_INFO_BY_NOS = "delete from [employeeInfo] where employeeNo in (@employeeNos)";
        /*根据员工编号得到员工信息的sql语句*/
        private const string SQL_SELECT_EMPLOYEE_INFO_BY_NO = "select * from [employeeInfo] where employeeNo=@employeeNo";
        /*实现员工信息更新的sql语句*/
        private const string SQL_UPDATE_EMPLOYEE_INFO_BY_NO = "update [employeeInfo] set employeeName=@employeeName,employeePassword=@employeePassword,employeeSex=@employeeSex,employeeBirthday=@employeeBirthday,employeeEducationId=@employeeEducationId,employeeHomeTel=@employeeHomeTel,employeeMobile=@employeeMobile,employeeCard=@employeeCard,employeeEmail=@employeeEmail,employeeAddress=@employeeAddress where employeeNo=@employeeNo";
        
        /*各种sql语句的参数常量字符串*/
        private const string PARM_EMPLOYEE_NO = "@employeeNo";
        private const string PARM_EMPLOYEE_NAME = "@employeeName";
        private const string PARM_EMPLOYEE_PASSWORD = "@employeePassword";
        private const string PARM_EMPLOYEE_SEX = "@employeeSex";
        private const string PARM_EMPLOYEE_BIRTHDAY = "@employeeBirthday";
        private const string PARM_EMPLOYEE_EDUCATION_ID = "@employeeEducationId";
        private const string PARM_EMPLOYEE_HOME_TEL = "@employeeHomeTel";
        private const string PARM_EMPLOYEE_MOBILE = "@employeeMobile";
        private const string PARM_EMPLOYEE_CARD = "@employeeCard";
        private const string PARM_EMPLOYEE_EMAIL = "@employeeEmail";
        private const string PARM_EMPLOYEE_ADDRESS = "@employeeAddress";
        private const string PARM_DEPARTMENT_NAME = "@departmentName";
        private const string PARM_WORKTYPE_NAME = "@workTypeName";
        private const string PARM_EMPLOYEE_NOS = "@employeeNos";
       
        /*根据员工编号和员工登陆密码判断登陆信息是否正确*/
        public bool CheckLogin(string username, string password)
        {
            string sqlString = "select * from [employeeInfo] where employeeNo=" + SQLString.GetQuotedString(username);
            DataSet employeeInfoDs = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text,sqlString, null);
            if (employeeInfoDs.Tables[0].Rows.Count == 0)
            {
                this.errMessage = "对不起，不存在该员工的帐号信息!";
                return false;
            } else {
                if (employeeInfoDs.Tables[0].Rows[0]["employeePassword"].ToString() != password)
                {
                    this.errMessage = "对不起，员工的密码不正确!";
                    return false;
                }
            }
            return true;
        }
        /*根据员工模型对象执行员工信息的添加业务操作*/
        public bool EmployeeInfoAdd(EmployeeModel employeeModel)
        {
            /*首先验证输入信息格式的合法性*/
            if (this.IsValid(employeeModel) == false) return false;
            /*再验证该员工编号的员工信息是否存在*/
            if (this.IsExistEmployeeNo(employeeModel.EmployeeNo))
            {
                this.errMessage = "该员工编号的员工信息已经存在!";
                return false;
            }
            /*得到进行插入操作的sql语句的参数对象数组*/
            SqlParameter[] parms = this.GetInsertEmployeeInfoParms();
            /*对各个参数进行传值*/
            parms[0].Value = employeeModel.EmployeeNo;
            parms[1].Value = employeeModel.EmployeeName;
            parms[2].Value = employeeModel.EmployeePassword;
            parms[3].Value = employeeModel.EmployeeSex;
            parms[4].Value = employeeModel.EmployeeBirthday;
            parms[5].Value = employeeModel.EmployeeEducationId;
            parms[6].Value = employeeModel.EmployeeHomeTel;
            parms[7].Value = employeeModel.EmployeeMobile;
            parms[8].Value = employeeModel.EmployeeCard;
            parms[9].Value = employeeModel.EmployeeEmail;
            parms[10].Value = employeeModel.EmployeeAddress;
            /*下面调用数据层执行更新操作*/
            if(DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,SQL_INSERT_EMPLOYEE_INFO,parms) < 0)
            {
                this.errMessage = "添加员工信息时发生了数据库错误!";
                return false;
            }
            return true;
        }

        /*验证员工模型个字段的信息的格式的正确性*/
        public bool IsValid(EmployeeModel employeeModel)
        {
            /*验证员工编号输入不能为空*/
            if(employeeModel.EmployeeNo == "")
            {
                this.errMessage = "员工编号字段输入不能为空!";
                return false;
            }
            /*验证员工密码输入不能为空*/
            if (employeeModel.EmployeePassword == "")
            {
                this.errMessage = "员工密码字段输入不能为空!";
                return false;
            }
            /*如果Email输入不为空，则对其进行验证*/
            if (employeeModel.EmployeeEmail != "")
            {
                if (!Common.IsValidEmail(employeeModel.EmployeeEmail))
                {
                    this.errMessage = "你输入的Email地址格式不正确!";
                    return false;
                }
            }
            /*如果家庭电话输入不为空,则对其进行验证*/
            if(employeeModel.EmployeeHomeTel != "")
            {
                if (!Common.IsVaildPhone(employeeModel.EmployeeHomeTel))
                {
                    this.errMessage = "你输入的家庭电话格式不正确!";
                    return false;
                }
            }
            /*如果手机号码输入不为空,则对其进行验证*/
            if (employeeModel.EmployeeMobile != "")
            {
                if (!Common.IsValidMobile(employeeModel.EmployeeMobile))
                {
                    this.errMessage = "你输入的手机号码格式不正确!";
                    return false;
                }
            }
            /*如果身份证号码输入不为空,则对其进行验证*/
            if (employeeModel.EmployeeCard != "")
            {
                if (!Common.IsValidIdCard(employeeModel.EmployeeCard))
                {
                    this.errMessage = "你输入的身份证号码信息格式不正确!";
                    return false;
                }
            }
            return true;
        }

        /*判断该员工编号的员工信息是否已经存在*/
        public bool IsExistEmployeeNo(string emplyeeNo)
        {
            SqlParameter[] parms = this.GetSelectIsExistEmployeeNoParms();
            parms[0].Value = emplyeeNo;
            return DBOperation.ExecuteReader(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_IS_EXIST_EMPLOYEE_NO, parms).Read();
        }

        /*得到查找是否存在该员工编号信息sql语句的参数信息*/
        private SqlParameter[] GetSelectIsExistEmployeeNoParms()
        {
            /*在数据层操作类缓冲区中根据哈希表关键字查找sql参数对象数组是否已经存在*/
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_SELECT_IS_EXIST_EMPLOYEE_NO);
            /*如果不存在就创建sql参数对象数组并加入到数据层缓冲区中*/
            if (parms == null)
            {
                parms = new SqlParameter[]{
                                        new SqlParameter(PARM_EMPLOYEE_NO,SqlDbType.VarChar) 
									  };
                DBOperation.CacheParameters(SQL_SELECT_IS_EXIST_EMPLOYEE_NO, parms);
            }
            return parms;
        }
        /*得到进行员工信息插入sql语句的参数信息*/
        private SqlParameter[] GetInsertEmployeeInfoParms()
        {
            /*在数据层操作类缓冲区中根据哈希表关键字查找sql参数对象数组是否已经存在*/
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_INSERT_EMPLOYEE_INFO);
            /*如果不存在就创建sql参数对象数组并加入到数据层缓冲区中*/
            if (parms == null)
            {
                parms = new SqlParameter[]{
                                        new SqlParameter(PARM_EMPLOYEE_NO,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_NAME,SqlDbType.NVarChar),
                                        new SqlParameter(PARM_EMPLOYEE_PASSWORD,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_SEX,SqlDbType.NChar),
                                        new SqlParameter(PARM_EMPLOYEE_BIRTHDAY,SqlDbType.DateTime),
                                        new SqlParameter(PARM_EMPLOYEE_EDUCATION_ID,SqlDbType.Int),
                                        new SqlParameter(PARM_EMPLOYEE_HOME_TEL,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_MOBILE,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_CARD,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_EMAIL,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_ADDRESS,SqlDbType.NVarChar)
									  };
                DBOperation.CacheParameters(SQL_INSERT_EMPLOYEE_INFO, parms);
            }
            return parms;
        }


        /*根据查询条件从员工信息视图中查询符合条件的记录并返回结果数据集*/
        public DataSet GetQueryEmployeeInfoView(string employeeNo, string employeeName)
        {
            /*取得查询的参数并为各个参数传入值
            SqlParameter[] parms = this.GetQueryEmployeeInfoViewParms();
            parms[0].Value = employeeNo;
            parms[1].Value = employeeName;
            parms[2].Value = departmentName;
            */
            /*如果填写了模糊查询的员工编号*/
            if(employeeNo != "")
                SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW += " and employeeNo like '%" + employeeNo + "%'";
            /*如果填写了模糊查询的员工姓名*/
            if(employeeName != "")
                SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW += " and employeeName like '%" + employeeName + "%'";
            /*执行查询并返回内存结果集*/
            return DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW, null);
        }

        /*得到根据条件从员工信息视图中查找信息的sql语句的参数信息*/
        private SqlParameter[] GetQueryEmployeeInfoViewParms()
        {
            /*在数据层操作类缓冲区中根据哈希表关键字查找sql参数对象数组是否已经存在*/
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW);
            /*如果不存在就创建sql参数对象数组并加入到数据层缓冲区中*/
            if (parms == null)
            {
                parms = new SqlParameter[]{
                                        new SqlParameter(PARM_EMPLOYEE_NO,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_NAME,SqlDbType.NVarChar)
									  };
                DBOperation.CacheParameters(SQL_SELECT_EMPLOYEE_INFO_FROM_VIEW, parms);
            }
            return parms;
        }

        /*根据员工编号执行相关员工信息的删除操作*/
        public bool DeleteEmployeeInfo(string employeeNos)
        {
            
            /*构造删除员工信息的sql语句*/
            string deleteEmployeeString = "delete from [employeeInfo] where employeeNo in (" + employeeNos + ")";
            
            string[] deleteStrings = new string[] { deleteEmployeeString };
            /*调用数据层的存储过程进行信息删除*/
            if (DBOperation.ExecuteStoreProcedure(DBOperation.CONN_STRING_NON_DTC, deleteStrings, null) == false)
            {
                this.errMessage = "删除员工信息时发生了错误!";
                return false;
            }
            return true;
        }

        /*得到根据员工编号集合删除员工信息的sql语句的参数信息*/
        private SqlParameter[] GetDeleteEmployeeInfoParms()
        {
            /*在数据层操作类缓冲区中根据哈希表关键字查找sql参数对象数组是否已经存在*/
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_DELETE_EMPLOYEE_INFO_BY_NOS);
            /*如果不存在就创建sql参数对象数组并加入到数据层缓冲区中*/
            if (parms == null)
            {
                parms = new SqlParameter[]{
                                        new SqlParameter(PARM_EMPLOYEE_NOS,SqlDbType.VarChar)
									  };
                DBOperation.CacheParameters(SQL_DELETE_EMPLOYEE_INFO_BY_NOS, parms);
            }
            return parms;
        }

        
        /*根据员工编号得到员工的信息并保存在模型中返回*/
        public EmployeeModel GetEmployeeInfo(string employeeNo)
        {
            /*构造查询参数*/
            SqlParameter[] parms = new SqlParameter[]{new SqlParameter(PARM_EMPLOYEE_NO,SqlDbType.VarChar)};
            parms[0].Value = employeeNo;
            /*调用数据层获取结果集并保存在ds中*/
            DataSet ds = DBOperation.GetDataSet(DBOperation.CONN_STRING_NON_DTC,CommandType.Text,SQL_SELECT_EMPLOYEE_INFO_BY_NO,parms);
            if(ds.Tables[0].Rows.Count == 0) return null;
            /*如果存在该记录，就将各个字段保存在模型中返回*/
            EmployeeModel employeeModel = new EmployeeModel();
            DataRow dr = ds.Tables[0].Rows[0];
            employeeModel.EmployeeNo = dr["employeeNo"].ToString();
            employeeModel.EmployeeName = dr["employeeName"].ToString();
            employeeModel.EmployeePassword = dr["employeePassword"].ToString();
            employeeModel.EmployeeSex = dr["employeeSex"].ToString();
            employeeModel.EmployeeBirthday = Convert.ToDateTime(dr["employeeBirthday"].ToString());
            employeeModel.EmployeeEducationId = Convert.ToInt32(dr["employeeEducationId"]);
            employeeModel.EmployeeHomeTel = dr["employeeHomeTel"].ToString();
            employeeModel.EmployeeMobile = dr["employeeMobile"].ToString();
            employeeModel.EmployeeCard = dr["employeeCard"].ToString();
            employeeModel.EmployeeEmail = dr["employeeEmail"].ToString();
            employeeModel.EmployeeAddress = dr["employeeAddress"].ToString();

            return employeeModel;
        }

        /*执行员工信息的更新操作*/
        public bool UpdateEmployeeInfo(EmployeeModel employeeModel)
        {
            /*首先验证各个字段信息的合法性*/
            if (this.IsValid(employeeModel) == false) return false;
            /*首先得到更新语句的参数信息*/
            SqlParameter[] parms = this.GetUpdateEmployeeInfoParms();
            /*然后对各个参数传值*/
            parms[0].Value = employeeModel.EmployeeName;
            parms[1].Value = employeeModel.EmployeePassword;
            parms[2].Value = employeeModel.EmployeeSex;
            parms[3].Value = employeeModel.EmployeeBirthday;
            parms[4].Value = employeeModel.EmployeeEducationId;
            parms[5].Value = employeeModel.EmployeeHomeTel;
            parms[6].Value = employeeModel.EmployeeMobile;
            parms[7].Value = employeeModel.EmployeeCard;
            parms[8].Value = employeeModel.EmployeeEmail;
            parms[9].Value = employeeModel.EmployeeAddress;
            parms[10].Value = employeeModel.EmployeeNo;
            /*然后调用数据层实现员工信息的更新*/
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, SQL_UPDATE_EMPLOYEE_INFO_BY_NO, parms) < 0)
            {
                this.errMessage = "执行员工信息更新操作时发生了数据错误！";
                return false;
            }
            return true;
        }

        /*得到更新员工信息的sql语句的参数信息*/
        private SqlParameter[] GetUpdateEmployeeInfoParms()
        {
            /*在数据层操作类缓冲区中根据哈希表关键字查找sql参数对象数组是否已经存在*/
            SqlParameter[] parms = DBOperation.GetCachedParameters(SQL_UPDATE_EMPLOYEE_INFO_BY_NO);
            /*如果不存在就创建sql参数对象数组并加入到数据层缓冲区中*/
            if (parms == null)
            {
                parms = new SqlParameter[]{
                                        new SqlParameter(PARM_EMPLOYEE_NAME,SqlDbType.NVarChar),
                                        new SqlParameter(PARM_EMPLOYEE_PASSWORD,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_SEX,SqlDbType.NChar),
                                        new SqlParameter(PARM_EMPLOYEE_BIRTHDAY,SqlDbType.DateTime),
                                        new SqlParameter(PARM_EMPLOYEE_EDUCATION_ID,SqlDbType.Int),
                                        new SqlParameter(PARM_EMPLOYEE_HOME_TEL,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_MOBILE,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_CARD,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_EMAIL,SqlDbType.VarChar),
                                        new SqlParameter(PARM_EMPLOYEE_ADDRESS,SqlDbType.NVarChar),
                                        new SqlParameter(PARM_EMPLOYEE_NO,SqlDbType.VarChar)
									  };
                DBOperation.CacheParameters(SQL_UPDATE_EMPLOYEE_INFO_BY_NO, parms);
            }
            return parms;
        }


        /*更新员工的密码*/
        public bool ChangePassword(EmployeeModel employeeModel)
        {
            /*首先得到原来正确的密码
            string sqlString = "select employeePassword from [employeeInfo] where employeeNo='" + username + "'";
            string lastPassword = DBOperation.ExecuteScalar(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null).ToString();
            /*比较用户输入的原来的密码是否正确
            if (oldpassword != lastPassword)
            {
                this.errMessage = "你输入的旧密码信息不正确!";
                return false;
            }
            sqlString = "update [employeeInfo] set employeePassword='" + newpassword + "' where employeeNo='" + username + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, sqlString, null) < 0)
            {
                this.errMessage = "密码信息更新失败!";
                return false;
            }
            return true;*/
            string updateString = "update [employeeInfo] set employeePassword='" + employeeModel.EmployeePassword;
            updateString += "' where employeeNo='" + employeeModel.EmployeeNo + "'";
            if (DBOperation.ExecuteNonQuery(DBOperation.CONN_STRING_NON_DTC, CommandType.Text, updateString, null) < 0)
                return false;
            return true;
        }
    }
}
