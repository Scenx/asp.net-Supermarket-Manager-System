<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodClassAdd.aspx.cs" Inherits="GoodInfo_GoodClassAdd" %>

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
          <img src="../images/ADD.gif" width=14px height=14px>商品信息管理--&gt;商品类别管理</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          <br />
          <table>
            <tr><td>商品类别编号</td><td>商品类别名称</td></tr>
          <asp:DataList ID="DataList1" runat="server" DataKeyField="goodClassId" DataSourceID="GoodClassDataSource"
              Width="362px">
              <ItemTemplate>
              　　<tr>
                    <td>
                      <asp:Label ID="goodClassIdLabel" runat="server" Text='<%# Eval("goodClassId") %>'></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="goodClassNameLabel" runat="server" Text='<%# Eval("goodClassName") %>'></asp:Label>
                    </td>
                  </tr>
               </ItemTemplate>
          </asp:DataList><asp:SqlDataSource ID="GoodClassDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
              ProviderName="System.Data.SqlClient" SelectCommand="SELECT [goodClassId], [goodClassName] FROM [goodClassInfo]">
          </asp:SqlDataSource>
          </table>
      </td>
	</tr>
          <tr>
              <td style="height: 24px">
                  &nbsp;
                  商品类别名称：<asp:TextBox ID="GoodClassName" runat="server" Width="128px"></asp:TextBox>&nbsp;
                  <asp:Button
                      ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="添加" /></td>
          </tr>
         
      </table>
       &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>

