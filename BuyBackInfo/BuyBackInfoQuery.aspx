<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyBackInfoQuery.aspx.cs" Inherits="BuyInfo_BuyBackInfoQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
      <table width=700 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px">
          <img src="../images/list.gif" width=14px height=14px>商品进货管理--&gt;进货退货查询</td>
        </tr>
        <tr>
          <td style="height: 37px">
        商品编号:<asp:TextBox ID="GoodNo" runat="server" Width="79px"></asp:TextBox>
        商品名称:<asp:TextBox ID="GoodName" runat="server" Width="79px"></asp:TextBox>
              &nbsp;商品类别:<asp:DropDownList ID="GoodClassId" runat="server" Width="85px">
              </asp:DropDownList>
              <br />
              开始时间:<asp:TextBox ID="StartTime" runat="server" Width="78px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('StartTime')" style="width: 30px"
                  type="button" value="选择" id="Button1" />
              结束时间:<asp:TextBox ID="EndTime" runat="server" Width="82px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('EndTime')" style="width: 30px"
                  type="button" value="选择" id="Button2" />
       <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="buyBackId" DataSourceID="BuyBackInfoDataSource"
                  ForeColor="#333333" GridLines="None" Width="676px" OnRowDataBound="GridView1_RowDataBound" PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      <asp:TemplateField HeaderText="选择">
                          <ItemTemplate>
                              <asp:CheckBox ID="CB_Select" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" SortExpression="goodName" />
                      <asp:BoundField DataField="goodClassName" HeaderText="商品类别" SortExpression="goodClassName" />
                      <asp:BoundField DataField="supplierName" HeaderText="供应商" SortExpression="supplierName" />
                      <asp:BoundField DataField="price" HeaderText="退货单价" SortExpression="price" />
                      <asp:BoundField DataField="number" HeaderText="退货数量" SortExpression="number" />
                      <asp:BoundField DataField="totalPrice" HeaderText="退货总价" SortExpression="totalPrice" />
                      <asp:BoundField DataField="buyBackDate" HeaderText="退货日期" SortExpression="buyBackDate" />
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
              <asp:CheckBox ID="CB_SelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="CB_SelectAll_CheckedChanged"
                  Text="全选" />&nbsp;
              <asp:Button ID="Btn_Delete" runat="server" OnClick="Btn_Delete_Click" Text="删除" /><br />
              <br />
              
        </td>
      </tr>
    </table>
     <table width=700 border=0 cellpadding=0 cellspacing=0 align="center">
    <tr>
    <td align=right style="height: 12px">
        当前查询条件下退货总金额为：<asp:Label ID="TotalPrice" runat="server" Text="Label"></asp:Label>元</td></tr>
    </table>
  </form>
  <asp:SqlDataSource ID="BuyBackInfoDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
                  SelectCommand="SELECT * from [buyBackInfo]" ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
</body>
</html>
