<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodStockCount.aspx.cs" Inherits="GoodStockInfo_GoodStockCount" %>

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
          <img src="../images/list.gif" width=14px height=14px>商品库存管理--&gt;库存盘点</td>
        </tr>
        <tr>
          <td style="height: 37px; width: 605px;">
              开始时间:<asp:TextBox ID="StartTime" runat="server" Width="78px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('StartTime')" style="width: 30px"
                  type="button" value="选择" id="Button1" />
              结束时间:<asp:TextBox ID="EndTime" runat="server" Width="82px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('EndTime')" style="width: 30px"
                  type="button" value="选择" id="Button2" />
       <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />
              <br />
              在本时间内进货总金额为：
              <asp:Label ID="BuyTotalPrice" runat="server" Text="Label"></asp:Label>
              元<br />
              <br />
              在本时间内进货退货总金额为：
              <asp:Label ID="BuyBackTotalPrice" runat="server" Text="Label"></asp:Label>
              元<br />
              <br />
              在本时间内销售总金额为：
              <asp:Label ID="SellTotalPrice" runat="server" Text="Label"></asp:Label>
              元<br />
              <br />
              在本时间内顾客退货总金额为：
              <asp:Label ID="SellBackTotalPrice" runat="server" Text="Label"></asp:Label>
              元<br />
              <br />
              在本时间内超市利润为：
              <asp:Label ID="Profits" runat="server" Text="Label"></asp:Label>
              元</td>
      </tr>
    </table>
  </form>
</body>
</html>
