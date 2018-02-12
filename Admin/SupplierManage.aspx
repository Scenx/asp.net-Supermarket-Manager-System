<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierManage.aspx.cs" Inherits="Admin_SupplierManage" %>

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
          <img src="../images/ADD.gif" width=14px height=14px>系统管理--&gt;供应商信息管理</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          <br />
          <table>
            <tr><td>供应商公司名称</td><td>法人代表</td><td>电话</td><td>地址</td></tr>
          <asp:DataList ID="DataList1" runat="server" DataKeyField="supplierName" DataSourceID="SupplierInfoDataSource"
              Width="362px">
              <ItemTemplate>
              　　<tr>
                    <td>
                      <asp:Label ID="SupplierName" runat="server" Text='<%# Eval("supplierName") %>'></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="SupplierLawyer" runat="server" Text='<%# Eval("supplierLawyer") %>'></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="SupplierTelephone" runat="server" Text='<%# Eval("supplierTelephone") %>'></asp:Label>
                    </td>
                    <td>
                      <asp:Label ID="SupplierAddress" runat="server" Text='<%# Eval("supplierAddress") %>'></asp:Label>
                    </td>
                  </tr>
               </ItemTemplate>
          </asp:DataList><asp:SqlDataSource ID="SupplierInfoDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
              ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [supplierInfo]">
          </asp:SqlDataSource>
          </table>
      </td>
	</tr>
          <tr>
              <td style="height: 24px">
                  <br />
                  新的供应商信息添加:<br />
                  <br />
                  供应商公司名称：<asp:TextBox ID="NewSupplierName" runat="server" Width="192px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                      ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewSupplierName"
                      ErrorMessage="供应商名称信息必须填写!"></asp:RequiredFieldValidator><br />
                  供应商法人代表：<asp:TextBox ID="NewSupplierLawyer" runat="server" Width="123px"></asp:TextBox>&nbsp;<br />
                  供应商电话： &nbsp;&nbsp;
                  <asp:TextBox ID="NewSupplierTelephone" runat="server"
                      Width="121px"></asp:TextBox><br />
                  供应商地址： &nbsp;&nbsp;
                  <asp:TextBox ID="NewSupplierAddress" runat="server" Width="337px"></asp:TextBox>
                  <br />
                  <br />
                  <asp:Button
                      ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="保存" /></td>
          </tr>
          <tr>
              <td style="height: 24px">
              </td>
          </tr>
         
      </table>
       &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>

