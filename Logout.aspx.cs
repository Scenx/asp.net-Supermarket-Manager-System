using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace KaoQin
{
	/// <summary>
	/// Logout 的摘要说明。
	/// </summary>
	public partial class Logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
            Session.Abandon();
            Response.Redirect("login.aspx");
		}
		
	}
}
