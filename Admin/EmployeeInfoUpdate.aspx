<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeInfoUpdate.aspx.cs" Inherits="Admin_EmployeeInfoUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
 <LINK href="../css/style.css" type="text/css" rel="stylesheet">
   <script language=javascript>
     function seltime(inputName)
     {
	window.open('seltime.aspx?InputName='+inputName+'','','width=250,height=220,left=360,top=250,scrollbars=yes');  
     }
  
   </script>
</head>
<body>
    <form method="post" id="frmAnnounce" runat="server">
      <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px">
          <img src="../images/Edit.gif" width=14px height=14px>员工信息管理--&gt;员工信息更新</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          <br />
          员工编号:<asp:TextBox ID="EmployeeNo" runat="server" Width="89px" EnableTheming="False"></asp:TextBox>&nbsp;&nbsp;
          &nbsp; &nbsp;&nbsp;
          员工姓名:<asp:TextBox ID="EmployeeName" runat="server" Width="83px"></asp:TextBox>&nbsp;&nbsp;
          &nbsp; &nbsp;&nbsp;<br />
          <br />
          性别:<asp:DropDownList ID="EmployeeSex" runat="server">
              <asp:ListItem>男</asp:ListItem>
              <asp:ListItem>女</asp:ListItem>
          </asp:DropDownList>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
          &nbsp; &nbsp; &nbsp;&nbsp;学历层次:<asp:DropDownList ID="EmployeeEducation" runat="server"
               DataTextField="educationName" DataValueField="educationId">
          </asp:DropDownList>&nbsp;<br />
          &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
          生日:<asp:TextBox ID="EmployeeBirthday" runat="server" Width="77px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('EmployeeBirthday')" style="width: 30px"
                  type="button" value="选择" />
          &nbsp; &nbsp; &nbsp;&nbsp;
          登陆密码:<asp:TextBox ID="EmployeePassword" runat="server" Width="88px"></asp:TextBox><br />
          <br />
          家庭电话:<asp:TextBox ID="EmployeeHomeTel" runat="server" Width="194px"></asp:TextBox>
          &nbsp; &nbsp; 手机:<asp:TextBox ID="EmployeeMobile" runat="server"
              Width="167px"></asp:TextBox><br />
          <br />
          身份证件:<asp:TextBox ID="EmployeeCard" runat="server" Width="197px"></asp:TextBox>
          邮件地址:<asp:TextBox ID="EmployeeEmail" runat="server"></asp:TextBox><br />
          <br />
          居住地址:<asp:TextBox ID="EmployeeAddress" runat="server" Width="488px"></asp:TextBox></td>
	</tr>
          <tr>
              <td style="height: 26px" align="center">
                  <asp:Button ID="Btn_Update" runat="server" OnClick="Btn_Update_Click" Text="更新" />&nbsp;
                  <asp:Button ID="Btn_Cancle" runat="server" OnClick="Btn_Cancle_Click" Text="返回" /></td>
          </tr>
         
      </table>
        &nbsp;&nbsp;
    </form>
</body>
</html>
