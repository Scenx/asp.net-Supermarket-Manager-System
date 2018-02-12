<%@ Page language="c#" Inherits="SuperMarket.login" CodeFile="login.aspx.cs" %>

<%@ Register Src="UserControl/WebFootControl.ascx" TagName="WebFootControl" TagPrefix="uc2" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>超市信息管理系统</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/style.css" type="text/css" rel="stylesheet">
		<script src="script/App.js"></script>
		<script language="javascript">
			function check()
			{
				if(document.Form1.txtName.value == "")
				{
					alert("有未输入项目存在");
					document.Form1.txtName.focus();
					return false;
				}
				else if(document.Form1.txtPwd.value == "")
				{
					alert("有未输入项目存在");
					document.Form1.txtPwd.focus();
					return false;
				}
				/*
				if(regQuanJiao(document.Form1.txtName.value) == false)
				{
					alert("请输入全角文字");
					document.Form1.txtName.focus();
					return false;
				}*/
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="80%" border="0" align=center>
				<tr>
					<td style="height: 14px" align="center">
                        <img src="images/title.jpg" /></td>
				</tr>
				<br />
				<TR>
					<TD vAlign="middle" align="center">
						<TABLE class="tbl" id="Table2" cellSpacing="0" cellPadding="4" width="280" align="center"
							bgColor="#d6ebff" border="0">
							<TR>
								<TD class="bottom" align="center" bgColor="#52beef" colSpan="2" height="35">
                                    超市管理系统登陆</TD>
							</TR>
							<TR>
								<TD class="bottom" align="center" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="br" style="HEIGHT: 33px" align="right" width="41%">请输入用户名：</TD>
								<TD class="bottom" style="HEIGHT: 33px" align="left" width="59%"><asp:textbox id="txtName" runat="server" maxLength="12" Width="145"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="br" align="right" width="41%">请输入密码：</TD>
								<TD class="bottom" align="left"><asp:textbox id="txtPwd" runat="server" maxLength="12" Width="145" TextMode="Password"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="br" align="right" width="41%">请选择身份：</TD>
								<TD class="bottom" align="left">
                                    <asp:DropDownList ID="Identify" runat="server">
                                        <asp:ListItem>管理员</asp:ListItem>
                                        <asp:ListItem>员工</asp:ListItem>
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2" height="40">&nbsp;
									<asp:button id="Button1" style="MARGIN-RIGHT: 25px" runat="server" CssClass="searchButton" Text="登陆" onclick="Button1_Click"></asp:button><input class="searchButton" id="btnExit" onclick="window.close();" type="button" value="退出"
										name="btnExit">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<br />
				<tr>
					<td>
                        <uc2:WebFootControl ID="WebFootControl1" runat="server" />
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
