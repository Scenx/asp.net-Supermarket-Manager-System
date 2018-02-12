<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellBackInfoAdd.aspx.cs" Inherits="SellBackInfo_SellBackInfoAdd" %>

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
          <img src="../images/ADD.gif" width=14px height=14px>商品销售管理--&gt;顾客退货登记</td>
        </tr>
            <tr><td>
                <br />
                销售单据：<asp:TextBox ID="SellNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SellNo"
                    ErrorMessage="销售单据输入不能为空!"></asp:RequiredFieldValidator><br />
                <br />
                商品编号：<asp:TextBox ID="GoodNo" runat="server" Width="136px"></asp:TextBox>&nbsp;<asp:Button
                    ID="Btn_GetGoodInfo" runat="server" OnClick="Btn_GetGoodInfo_Click" Text="获取商品信息" /><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GoodNo"
                    ErrorMessage="商品编号输入不能为空!"></asp:RequiredFieldValidator><br />
                <asp:Panel ID="GoodInfoPanel" runat="server" Height="50px" Visible="False" Width="350px">
                    商品名称:
                    <asp:Label ID="GoodName" runat="server" Text="Label" Width="175px"></asp:Label><br />
                    商品型号:
                    <asp:Label ID="GoodModel" runat="server" Text="Label" Width="184px"></asp:Label><br />
                    商品规格:
                    <asp:Label ID="GoodSpecs" runat="server" Text="Label" Width="244px"></asp:Label><br />
                    商品产地:
                    <asp:Label ID="GoodPlace" runat="server" Text="Label" Width="244px"></asp:Label></asp:Panel>
                <br />
                退货单价：<asp:TextBox ID="Price" runat="server" Width="83px"></asp:TextBox>
                元<br />
                <br />
                退货数目：<asp:TextBox ID="Number" runat="server" Width="84px"></asp:TextBox><br />
                <br />
                退货原因：<asp:TextBox ID="SellBackReason" runat="server" Width="299px"></asp:TextBox><br />
                <br />
                商品是否完好：<asp:DropDownList ID="IsGood" runat="server">
                    <asp:ListItem Value="1">完好</asp:ListItem>
                    <asp:ListItem Value="0">已坏</asp:ListItem>
                </asp:DropDownList><br />
                <br />
                <asp:Button ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="退货登记" />
                </td></tr>
       &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>


