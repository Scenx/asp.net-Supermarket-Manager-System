using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SuperMarket.Model
{
    /// <summary>
    /// EmployeeModel 的摘要说明：本模型对应数据库中的employeeInfo表(员工信息表)
    /// </summary>
    public class EmployeeModel
    {
        /*员工信息表
        CREATE TABLE [dbo].[employeeInfo] (						
          [employeeNo] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,	//员工编号
          [employeeName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//员工姓名
          [employeePassword] [varchar] (30) COLLATE Chinese_PRC_CI_AS NULL ,	//员工登陆密码
          [employeeSex] [nchar] (1) COLLATE Chinese_PRC_CI_AS NULL ,		//员工性别
          [employeeBirthday] [datetime] NULL ,					//员工生日
          [employeeEducationId] [int] NULL ,					//教育层次编号
          [employeeHomeTel] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//家庭电话
          [employeeMobile] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,	//移动电话
          [employeeCard] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,		//身份证号
          [employeeEmail] [varchar] (30) COLLATE Chinese_PRC_CI_AS NULL ,		//邮件地址
          [employeeAddress] [nvarchar] (80) COLLATE Chinese_PRC_CI_AS NULL 	//居住地址
        ) ON [PRIMARY]*/
        private string employeeNo;
        private string employeeName;
        private string employeePassword;
        private string employeeSex;
        private DateTime employeeBirthday;
        private int employeeEducationId;
        private string employeeHomeTel;
        private string employeeMobile;
        private string employeeCard;
        private string employeeEmail;
        private string employeeAddress;
        public string EmployeeNo
        {
            set { this.employeeNo = value; }
            get { return this.employeeNo; }
        }
        public string EmployeeName 
        {
            set { this.employeeName = value; }
            get { return this.employeeName; }
        }
        public string EmployeePassword 
        {
            set { this.employeePassword = value; }
            get { return this.employeePassword; }
        }
        public string EmployeeSex 
        {
            set { this.employeeSex = value; }
            get { return this.employeeSex; }
        }
        public DateTime EmployeeBirthday 
        {
            set { this.employeeBirthday = value; }
            get { return this.employeeBirthday; }
        }
        public int EmployeeEducationId 
        {
            set { this.employeeEducationId = value; }
            get { return this.employeeEducationId; }
        }
        public string EmployeeHomeTel
        {
            set { this.employeeHomeTel = value; }
            get { return this.employeeHomeTel; }
        }
        public string EmployeeMobile 
        {
            set { this.employeeMobile = value; }
            get { return this.employeeMobile; }
        }
        public string EmployeeCard 
        {
            set { this.employeeCard = value; }
            get { return this.employeeCard; }
        }
        public string EmployeeEmail 
        {
            set { this.employeeEmail = value; }
            get { return this.employeeEmail; }
        }
        public string EmployeeAddress 
        {
            set { this.employeeAddress = value; }
            get { return this.employeeAddress; }
        }
        public EmployeeModel()
        {
            this.employeeBirthday = Convert.ToDateTime("1900-1-1");
        }
    }

}
