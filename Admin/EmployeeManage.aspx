<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeManage.aspx.cs" Inherits="Admin_EmployeeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<LINK href="../css/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form method="post" id="frmAnnounce" runat="server">
      <table width=600 border=0 cellpadding=0 cellspacing=0 align="center">
        <tr style="color:blue;font-size:14px;">
	  <td style="height: 14px">
          <img src="../images/list.gif" width=14px height=14px>员工信息管理--&gt;员工信息维护</td>
        </tr>
        <tr>
          <td style="height: 37px">
        员工编号:<asp:TextBox ID="EmployeeNo" runat="server" Width="66px"></asp:TextBox>
        员工姓名:<asp:TextBox ID="EmployeeName" runat="server" Width="66px"></asp:TextBox>
              &nbsp;
       <asp:Button ID="Btn_Query" runat="server" OnClick="Btn_Query_Click"
            Text="查询" /><br />
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="employeeNo" DataSourceID="EmployeeInfoDataSource"
                  ForeColor="#333333" GridLines="None" Width="603px" OnRowDataBound="GridView1_RowDataBound" PageSize="8" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      <asp:BoundField DataField="employeeNo" HeaderText="员工编号" ReadOnly="True" SortExpression="employeeNo" />
                      <asp:BoundField DataField="employeeName" HeaderText="员工姓名" SortExpression="employeeName" />
                      <asp:BoundField DataField="employeeSex" HeaderText="员工性别" SortExpression="employeeSex" />
                      <asp:BoundField DataField="employeeBirthday" HeaderText="员工生日" SortExpression="employeeBirthday" />
                      <asp:BoundField DataField="educationName" HeaderText="学历层次" SortExpression="educationName" />
                      <asp:HyperLinkField DataNavigateUrlFields="employeeNo" DataNavigateUrlFormatString="EmployeeInfoUpdate.aspx?employeeNo={0}"
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
              <asp:SqlDataSource ID="EmployeeInfoDataSource" runat="server" ConnectionString="Data Source=.;Initial Catalog=supermarketdb;uid=renzhenhua;pwd=123456"
                  SelectCommand="SELECT * FROM [employeeInfo]" ProviderName="System.Data.SqlClient">
              </asp:SqlDataSource>
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
