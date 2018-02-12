<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodInfoManage.aspx.cs" Inherits="GoodInfo_GoodInfoManage" %>

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
          <img src="../images/list.gif" width=14px height=14px>商品信息管理--&gt;商品信息维护</td>
        </tr>
        <tr>
          <td style="height: 37px">
        商品编号:<asp:TextBox ID="GoodNo" runat="server" Width="66px"></asp:TextBox>
        商品名称:<asp:TextBox ID="GoodName" runat="server" Width="66px"></asp:TextBox>
              &nbsp;商品类别:<asp:DropDownList ID="GoodClassId" runat="server">
              </asp:DropDownList>
              &nbsp;
       <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="goodNo" DataSourceID="GoodInfoDataSource"
                  ForeColor="#333333" GridLines="None" Width="603px" OnRowDataBound="GridView1_RowDataBound" PageSize="8"  OnPageIndexChanging="GridView1_PageIndexChanging">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" SortExpression="goodName" />
                      <asp:BoundField DataField="goodClassName" HeaderText="商品类别" SortExpression="goodClassName" />
                      <asp:BoundField DataField="goodUnit" HeaderText="商品单位" SortExpression="goodUnit" />
                      <asp:BoundField DataField="goodPrice" HeaderText="商品售价" SortExpression="goodPrice" />
                      <asp:HyperLinkField DataNavigateUrlFields="goodNo" DataNavigateUrlFormatString="GoodInfoUpdate.aspx?goodNo={0}"
                          HeaderText="编辑" Text="进入" />
                  </Columns>
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <EmptyDataTemplate>
                      对不起，没有当前的查询记录存在!
                  </EmptyDataTemplate>
                  <EditRowStyle BackColor="#999999" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              </asp:GridView>
              <br />
              <asp:SqlDataSource ID="GoodInfoDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
                  SelectCommand="SELECT * FROM [goodInfo]" ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
              &nbsp;
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
