<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="Admin_changePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>密码修改</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="Form1" name="form1" method="post" runat=server>
   <table width="80%" border="0" cellpadding="0" cellspacing="2" align="center">
<tr> 
    <td height="21" bgcolor="magenta">&nbsp;<img src="../images/ico29.gif" width="32" height="32" hspace="2" vspace="2" align="absmiddle"><font size="+1"><strong>系统安全密码设置</strong></font></td>
  </tr>
</table>
<table width="80%" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td>
	  <table width="100%" border="0" cellspacing="1" cellpadding="2" align="center" class="TableMenu">
	
      <tr>
        <td  class="a3">重新设置密码</td>
		    <td>
                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="144px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewPassword"
                    ErrorMessage="密码输入不能为空！"></asp:RequiredFieldValidator>&nbsp;&nbsp;
				</td>
      </tr>
		  <tr>
		    <td>再次确认新密码:</td>
			  <td>
                  <asp:TextBox ID="NewPassAgain" runat="server" TextMode="Password" Width="145px"></asp:TextBox>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword"
                      ControlToValidate="NewPassAgain" ErrorMessage="两次密码输入不一致！"></asp:CompareValidator></td>
			</tr>
      <tr bgcolor="#ffffff">
        <td height="30" colspan="4" align="center">
            &nbsp;<asp:Button ID="Btn_ChangePassword" runat="server" OnClick="Btn_ChangePassword_Click"
                Text="修改密码" />
            <br />
            <asp:Literal ID="ErrMessage" runat="server"></asp:Literal></td>
      </tr> 
	  </table>
	</td>
  </tr>	  	    
</table>
 </form>
</body>
</html>
