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
    /// EducationModel 的摘要说明:对应数据库中的educationInfo的模型
    /// </summary>
    public class EducationModel
    {
        /*教育层次信息表
        CREATE TABLE [dbo].[educationInfo] (
	        [educationId] [int] IDENTITY (1, 1) NOT NULL ,				        //教育层次编号
	        [educationName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL		//教育层次名称
        ) ON [PRIMARY]*/
        private int educationId;
        private string educationName;
        public int EducationID
        {
            set { this.educationId = value; }
            get { return this.educationId; }
        }
        public string EducationName
        {
            set { this.educationName = value; }
            get { return this.educationName; }
        }
        public EducationModel()
        {
            this.educationId = 0;
            this.educationName = "";
        }
    }

}
