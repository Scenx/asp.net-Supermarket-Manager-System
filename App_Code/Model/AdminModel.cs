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
    /// Admin 的摘要说明:本模型对应数据库中的管理员帐号信息表admin表
    /// </summary>
    public class AdminModel
    {
        /*管理员信息表 
        CREATE TABLE [dbo].[admin] (
	        [adminUsername] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,		//管理员帐号
            [adminPassword] [varchar] (32) COLLATE Chinese_PRC_CI_AS NULL 			//管理员密码
        ) ON [PRIMARY]*/
        private string adminUsername;
        private string adminPassword;
        public string AdminUsername
        {
            set { this.adminUsername = value; }
            get { return this.adminUsername; }
        }
        public string AdminPassword
        {
            set { this.adminPassword = value; }
            get { return this.adminPassword; }
        }
        public AdminModel()
        {
            this.adminUsername = "";
            this.adminPassword = "";
        }
    }

}
