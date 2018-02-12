<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellGoodsFinished.aspx.cs" Inherits="SellInfo_SellGoodsFinished" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <LINK href="../css/style.css" type="text/css" rel="stylesheet">
    <script language=javascript>
function printSellInfo() { 
bdhtml=window.document.body.innerHTML; 
sprnstr="<!--startprint-->"; 
eprnstr="<!--endprint-->"; 
prnhtml=bdhtml.substr(bdhtml.indexOf(sprnstr)+17); 
prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr)); 
window.document.body.innerHTML=prnhtml; 
window.print(); 
window.document.body.innerHTML=bdhtml; 
return true;
         }
</script>
</head>
<body>
   <form method="post" id="frmAnnounce" runat="server">
   <!--startprint-->
   　　<table width=550 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px">
          <img src="../images/ADD.gif" width=14px height=14px>商品销售管理--&gt;商品销售结帐</td>
        </tr>
        </table><br />
      <table width=550 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px;"><center><font size=4 color=red>欢迎光临双鱼林超市</font></center><br />
          你的小票号是<asp:Label ID="SellNo" runat="server" Text="Label"></asp:Label>,请妥善保管，7天内凭此办理退货.</td>
        </tr><tr>
	  <td style="height: 26px; width: 426px;">
          <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="goodCartId" 
                  ForeColor="#333333" GridLines="None" Width="546px" OnRowDataBound="GridView1_RowDataBound" PageSize="8">
                  <FooterStyle BackColor="Green" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" ReadOnly=True SortExpression="goodName" />
                      <asp:BoundField DataField="goodPrice" HeaderText="商品单价" ReadOnly=True SortExpression="goodPrice" />
                      <asp:BoundField DataField="goodCount" HeaderText="商品数量" ReadOnly=True SortExpression="goodCount" />
                      <asp:TemplateField HeaderText="商品总价">
                          <ItemTemplate>
                             <asp:Label ID="GoodTotalPrice" runat="server"></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <EmptyDataTemplate>
                      对不起，当前没有商品销售信息!
                  </EmptyDataTemplate>
                  <EditRowStyle BackColor="#999999" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              </asp:GridView>
              </td>
            </tr>
            <tr><td align=right style="width: 426px; height: 14px;"> 
                              合计： 商品总数量：<asp:Label ID="TotalGoodCount" runat="server" Text="Label"></asp:Label>&nbsp;
                              商品总价格：<asp:Label ID="TotalPrice" runat="server" Text="Label"></asp:Label>
                </td></tr>
            </table>
             <!--endprint-->
            <table width=550 border=0 cellpadding=0 cellspacing=0 align="center">
            <tr>
            <td align=right><input id="Btn_Print" type="button" onclick="printSellInfo();" value="打印购物清单" /></td></tr></table>
            <table width=550 border=0 cellpadding=0 cellspacing=0 align="center">
            <tr><td style="height: 14px; width: 426px;">
                应付金额：<asp:Label ID="ShouldGiveMoney" runat="server" Text="Label"></asp:Label>元<br />
                <br />
                实付金额：<asp:TextBox ID="RealGiveMoney" runat="server" Width="72px"></asp:TextBox>元
                <asp:Button ID="Btn_Calculate" runat="server" Text="计算" OnClick="Btn_Calculate_Click" />
                <br />
                <br />
                应找零：
                <asp:Label ID="GiveBackMoney" runat="server"></asp:Label>元<br />
                <br />
                <asp:Button ID="Btn_SaveSellInfo" runat="server" Text="完成" OnClick="Btn_SaveSellInfo_Click" /></td></tr>
       &nbsp;&nbsp;&nbsp;
       </table>
    </form>
</body>
</html>


