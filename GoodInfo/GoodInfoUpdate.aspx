<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodInfoUpdate.aspx.cs" Inherits="GoodInfo_GoodInfoUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
   <form method="post" id="frmAnnounce" runat="server">
      <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px">
          <img src="../images/ADD.gif" width=14px height=14px>商品信息管理--&gt;商品信息更新</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          商品编号:
          <asp:Label ID="GoodNo" runat="server" Text="Label"></asp:Label>
          <br />
          <br />
          商品类别:
          <asp:DropDownList ID="GoodClassId" runat="server" Width="151px">
          </asp:DropDownList>&nbsp;<br />
          <br />
          商品名称:
          <asp:TextBox ID="GoodName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GoodName"
              ErrorMessage="请输入商品名称信息!"></asp:RequiredFieldValidator><br />
          <br />
          商品单位:
          <asp:TextBox ID="GoodUnit" runat="server"></asp:TextBox><br />
          <br />
          商品型号:
          <asp:TextBox ID="GoodModel" runat="server"></asp:TextBox><br />
          <br />
          商品规格:
          <asp:TextBox ID="GoodSpecs" runat="server"></asp:TextBox><br />
          <br />
          商品售价:
          <asp:TextBox ID="GoodPrice" runat="server" Width="97px"></asp:TextBox>
          元&nbsp;
          <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="GoodPrice"
              ErrorMessage="请输入正确的价格!" Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator><br />
          <br />
          商品产地:<asp:TextBox ID="GoodPlace" runat="server" Width="359px"></asp:TextBox><br />
          <br />
          附加信息:<asp:TextBox ID="GoodMemo" runat="server" Height="51px" TextMode="MultiLine"
              Width="358px"></asp:TextBox><br />
      </td>
	</tr>
          <tr>
              <td style="height: 25px">
                  &nbsp;<asp:Button
                      ID="Btn_Update" runat="server" OnClick="Btn_Update_Click" Text="更新" />&nbsp;
                  <input type=button value='返回' onclick="javascript:location.href='GoodInfoManage.aspx';" />
                  </td>
          </tr>
         
      </table>
       &nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
