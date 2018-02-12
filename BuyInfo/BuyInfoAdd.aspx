<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyInfoAdd.aspx.cs" Inherits="BuyInfo_BuyInfoAdd" %>

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
	  <td style="height: 14px">
          <img src="../images/ADD.gif" width=14px height=14px>商品进货管理--&gt;商品进货登记</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          选择供应商:
          <asp:DropDownList ID="SupplierName" runat="server" DataSourceID="SupplierDataSource"
              DataTextField="supplierName" DataValueField="supplierName">
          </asp:DropDownList>
          <br />
          <br />
          输入商品编号:
          <asp:TextBox ID="GoodNo" runat="server" Width="117px"></asp:TextBox>&nbsp;<asp:Button
              ID="Btn_GetGoodInfo" runat="server" Text="获取商品信息" OnClick="Btn_GetGoodInfo_Click" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GoodNo"
              ErrorMessage="请输入商品编号!"></asp:RequiredFieldValidator><br />
          <br />
          <asp:Panel ID="GoodInfoPanel" runat="server" Height="50px" Width="350px" Visible="False">
              商品名称:
              <asp:Label ID="GoodName" runat="server" Text="Label" Width="175px"></asp:Label><br />
              商品型号:
              <asp:Label ID="GoodModel" runat="server" Text="Label" Width="184px"></asp:Label><br />
              商品规格:
              <asp:Label ID="GoodSpecs" runat="server" Text="Label" Width="244px"></asp:Label><br />
              商品产地:
              <asp:Label ID="GoodPlace" runat="server" Text="Label" Width="244px"></asp:Label></asp:Panel>
          <br />
          进货价格:
          <asp:TextBox ID="Price" runat="server" Width="96px" OnTextChanged="Price_TextChanged" AutoPostBack="True">0.0</asp:TextBox>
          元 &nbsp; &nbsp;&nbsp; 进货数量:
          <asp:TextBox ID="Number" runat="server" Width="95px" OnTextChanged="Number_TextChanged" AutoPostBack="True">0</asp:TextBox><br />
          <br />
          进货总价:
          <asp:TextBox ID="TotalPrice" runat="server" Width="94px">0.0</asp:TextBox>
          元<br />
          <br />
          进货日期:
          <asp:TextBox ID="BuyDate" runat="server" Width="108px"></asp:TextBox><input class="submit" name="Button" onclick="seltime('BuyDate')" style="width: 30px"
                  type="button" value="选择" id="Button1" /><br />
          <br />
      </td>
	</tr>
          <tr>
              <td style="height: 24px">
                  <asp:Button
                      ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="进货登记" />&nbsp;<input type=button value="取消" onclick="javascript:location.href='BuyInfoAdd.aspx';" /></td>
          </tr>
         
      </table>
       &nbsp;&nbsp;&nbsp;
       <asp:SqlDataSource ID="SupplierDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
           ProviderName="System.Data.SqlClient" SelectCommand="SELECT [supplierName] FROM [supplierInfo]">
       </asp:SqlDataSource>
    </form>
</body>
</html>

