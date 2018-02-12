<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellGoods.aspx.cs" Inherits="SellInfo_SellGoods" %>

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
          <img src="../images/ADD.gif" width=14px height=14px>商品销售管理--&gt;商品销售</td>
        </tr>
        <tr>
	  <td style="height: 26px">
          <br />
          你好，当前的商品销售信息如下：<br />
          <br />
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  CellPadding="4" DataKeyNames="goodCartId" 
                  ForeColor="#333333" GridLines="None" Width="603px" OnRowDataBound="GridView1_RowDataBound" PageSize="8"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <Columns>
                      
                      <asp:BoundField DataField="goodNo" HeaderText="商品编号" ReadOnly="True" SortExpression="goodNo" />
                      <asp:BoundField DataField="goodName" HeaderText="商品名称" ReadOnly=true SortExpression="goodName" />
                      <asp:BoundField DataField="goodPrice" HeaderText="商品售价" ReadOnly=true SortExpression="goodPrice" />
                      <asp:TemplateField HeaderText="商品数量">
                         <EditItemTemplate>
                             <asp:TextBox ID="GoodCount" runat="server" Text='<%# Eval("goodCount") %>' Width="80"></asp:TextBox>
                         </EditItemTemplate>
                          <ItemTemplate>
                             <asp:Label ID="Label2" runat="server"><%# Eval("goodCount") %></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>   
                      <asp:CommandField HeaderText="编辑" EditText="修改" UpdateText="更新" ShowEditButton="True" />
                      <asp:TemplateField HeaderText="删除" ShowHeader="False">
                         <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');" 
                                        Text="删除"></asp:LinkButton>
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
            <tr><td>
                <br />
                添加新的商品销售信息：<br />
                <br />
                商品编号：<asp:TextBox ID="GoodNo" runat="server" Width="136px"></asp:TextBox>&nbsp;<asp:Button
                    ID="Btn_GetGoodInfo" runat="server" OnClick="Btn_GetGoodInfo_Click" Text="获取商品信息" /><br />
                <br />
                <asp:Panel ID="GoodInfoPanel" runat="server" Height="50px" Visible="False" Width="350px">
                    商品名称:
                    <asp:Label ID="GoodName" runat="server" Text="Label" Width="175px"></asp:Label><br />
                    商品型号:
                    <asp:Label ID="GoodModel" runat="server" Text="Label" Width="184px"></asp:Label><br />
                    商品规格:
                    <asp:Label ID="GoodSpecs" runat="server" Text="Label" Width="244px"></asp:Label><br />
                    商品产地:
                    <asp:Label ID="GoodPlace" runat="server" Text="Label" Width="244px"></asp:Label></asp:Panel>
                <br />
                商品数目：<asp:TextBox ID="GoodCount" runat="server" Width="84px"></asp:TextBox><br />
                <br />
                <asp:Button ID="Btn_Add" runat="server" OnClick="Btn_Add_Click" Text="添加" />
                <asp:Button ID="Btn_Finished" runat="server" OnClick="Btn_Finished_Click" Text="结帐" /></td></tr>
       &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>

