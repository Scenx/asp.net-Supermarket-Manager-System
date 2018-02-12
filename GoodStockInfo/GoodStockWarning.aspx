<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodStockWarning.aspx.cs" Inherits="GoodInfo_GoodStockWarning" %>

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
          <img src="../images/list.gif" width=14px height=14px>商品库存管理--&gt;商品库存报警</td>
        </tr>
        <tr>
          <td style="height: 37px">
              商品库存报警功能：当商品库存过多(本系统设置为200)时以<font color=yellow>黄色</font>字体显示，过少(低于20)时以<font color=red>红色</font>字体显示。<br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="goodNo" DataSourceID="GoodStockWarningInfoDataSource"
                  ForeColor="#333333" GridLines="None" Width="603px" OnRowDataBound="GridView1_RowDataBound" PageSize="8"  OnPageIndexChanging="GridView1_PageIndexChanging">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" SortExpression="goodName" />
                      <asp:BoundField DataField="goodClassName" HeaderText="商品类别" SortExpression="goodClassName" />
                      <asp:BoundField DataField="goodModel" HeaderText="商品型号" SortExpression="goodModel" />
                      <asp:BoundField DataField="goodSpecs" HeaderText="商品规格" SortExpression="goodSpecs" />
                      <asp:BoundField DataField="goodCount" HeaderText="商品库存" SortExpression="goodCount" />
                      <asp:BoundField DataField="goodUnit" HeaderText="商品单位" SortExpression="goodUnit" />
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
              <asp:SqlDataSource ID="GoodStockWarningInfoDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
                  SelectCommand="SELECT * FROM [goodStockInfo] where goodCount > 200 or goodCount < 20" ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
              &nbsp;
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
