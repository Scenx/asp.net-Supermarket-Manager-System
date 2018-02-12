<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodInfoDetails.aspx.cs" Inherits="GoodInfo_GoodInfoDetails" %>

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
          <img src="../images/ADD.gif" width=14px height=14px>商品信息管理--&gt;商品详细信息</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          商品编号:
          <asp:Label ID="GoodNo" runat="server" Text="Label"></asp:Label>
          <br />
          <br />
          商品类别:
          <asp:Label ID="GoodClassName" runat="server" Text="Label"></asp:Label>&nbsp;<br />
          <br />
          商品名称:
          <asp:Label ID="GoodName" runat="server" Text="Label"></asp:Label><br />
          <br />
          商品单位:
          <asp:Label ID="GoodUnit" runat="server" Text="Label"></asp:Label><br />
          <br />
          商品型号:
          <asp:Label ID="GoodModel" runat="server" Text="Label"></asp:Label><br />
          <br />
          商品规格:
          <asp:Label ID="GoodSpecs" runat="server" Text="Label"></asp:Label><br />
          <br />
          商品售价:
          <asp:Label ID="GoodPrice" runat="server" Text="Label"></asp:Label>元&nbsp;
          <br />
          <br />
          商品产地:<asp:Label ID="GoodPlace" runat="server" Text="Label"></asp:Label><br />
          <br />
          附加信息:<asp:Label ID="GoodMemo" runat="server" Text="Label"></asp:Label><br />
      </td>
	</tr>
          <tr>
              <td style="height: 25px">
                  &nbsp;&nbsp;
                  <input type=button value='返回' onclick="javascript:location.href='GoodInfoQuery.aspx';" />
                  </td>
          </tr>
         
      </table>
       &nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
