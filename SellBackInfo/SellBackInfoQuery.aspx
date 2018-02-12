<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellBackInfoQuery.aspx.cs" Inherits="SellBackInfo_SellBackInfoQuery" %>

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
      <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px; width: 605px;">
          <img src="../images/list.gif" width=14px height=14px>商品销售管理--&gt;退货信息查询</td>
        </tr>
        <tr>
          <td style="height: 37px; width: 605px;">
              商品编号:<asp:TextBox ID="GoodNo" runat="server" Width="101px"></asp:TextBox>
              销售单据号:<asp:TextBox ID="SellNo" runat="server"></asp:TextBox><br />
              
              开始时间:<asp:TextBox ID="StartTime" runat="server" Width="78px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('StartTime')" style="width: 30px"
                  type="button" value="选择" id="Button1" />
              结束时间:<asp:TextBox ID="EndTime" runat="server" Width="82px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('EndTime')" style="width: 30px"
                  type="button" value="选择" id="Button2" />
       <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="sellBackId"
                  ForeColor="#333333" GridLines="None" Width="600px" OnRowDataBound="GridView1_RowDataBound" PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      <asp:BoundField DataField="sellNo" HeaderText="单据号" ReadOnly="true" SortExpression="sllNo" />
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" SortExpression="goodName" />
                      <asp:BoundField DataField="price" HeaderText="退货价格" SortExpression="price" />
                      <asp:BoundField DataField="number" HeaderText="退货数量" SortExpression="number" />
                      <asp:BoundField DataField="sellBackReason" HeaderText="退货原因" SortExpression="sellBackReason" />
                      <asp:BoundField DataField="sellBackTime" HeaderText="退货时间" SortExpression="sellBackTime" />
               
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
        </td>
      </tr>
    </table>
    <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
    <tr>
    <td align=right style="height: 12px">
        当前查询条件下退货总金额为：<asp:Label ID="TotalPrice" runat="server" Text="Label"></asp:Label>元</td></tr>
    </table>
  </form>
</body>
</html>

