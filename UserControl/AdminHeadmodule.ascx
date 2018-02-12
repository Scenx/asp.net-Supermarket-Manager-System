<%@ Control Language="c#" Inherits="Library.UserControl.AdminHeadmodule" CodeFile="AdminHeadmodule.ascx.cs" %>
<!--BEGIN HEADER MODULE-->
<script>
	var linksrcTop;
	var linksrcLeft;
	var linksrcH;
	var linksrcW;
	var isShow = false;
	var mArray;
	var mArrayURL;

	function showMenu(menu,tableW)
	{
		switch (menu)
		{
			case '1' :mArray = new Array('');mArrayURL = new Array('');break;
			case '2' :mArray = new Array('添加商品类别','添加商品信息','商品信息维护');mArrayURL = new Array('<%# UrlBase + "/GoodInfo/GoodClassAdd.aspx"%>','<%# UrlBase + "/GoodInfo/GoodInfoAdd.aspx"%>','<%# UrlBase + "/GoodInfo/GoodInfoManage.aspx"%>');break;
			case '3' :mArray = new Array('添加员工信息','员工信息维护');mArrayURL = new Array('<%# UrlBase + "/Admin/EmployeeInfoAdd.aspx"%>','<%# UrlBase + "/Admin/EmployeeManage.aspx"%>');break;
			case '4' :mArray = new Array('商品进货登记','商品进货查询','进货退货登记','进货退货查询');mArrayURL = new Array('<%# UrlBase + "/BuyInfo/BuyInfoAdd.aspx"%>','<%# UrlBase + "/BuyInfo/BuyInfoQuery.aspx"%>','<%# UrlBase + "/BuyBackInfo/BuyBackInfoAdd.aspx"%>','<%# UrlBase + "/BuyBackInfo/BuyBackInfoQuery.aspx"%>');break;
			case '5' :mArray = new Array('商品销售查询','员工业绩查询','顾客退货办理','商品退货查询');mArrayURL = new Array('<%# UrlBase + "/SellInfo/SellInfoQuery.aspx"%>','<%# UrlBase + "/SellInfo/EmployeeSellResult.aspx"%>','<%# UrlBase + "/SellBackInfo/SellBackInfoAdd.aspx"%>','<%# UrlBase + "/SellBackInfo/SellBackInfoQuery.aspx"%>');break;
			case '6' :mArray = new Array('商品库存查询','商品库存盘点','商品库存报警');mArrayURL = new Array('<%# UrlBase + "/GoodStockInfo/GoodStockQuery.aspx"%>','<%# UrlBase + "/GoodStockInfo/GoodStockCount.aspx"%>','<%# UrlBase + "/GoodStockInfo/GoodStockWarning.aspx"%>');break;
			case '7' :mArray = new Array('供应商管理','修改密码','关于系统');mArrayURL = new Array('<%# UrlBase + "/Admin/SupplierManage.aspx"%>','<%# UrlBase + "/Admin/changePassword.aspx"%>','<%# UrlBase + "/about.html"%>');break;
		}
		
		if( mArray !=null )
		{
			var linksrc = window.event.srcElement;
			linksrcTop = linksrc.offsetTop;
			linksrcLeft = linksrc.offsetLeft;
			linksrcH = linksrc.offsetHeight;
			linksrcW = linksrc.offsetWidth;
			linksrcParent = linksrc.offsetParent;
			while(linksrcParent.tagName.toUpperCase()!="BODY")
			{
				linksrcTop += parseInt(linksrcParent.offsetTop);
				linksrcLeft += parseInt(linksrcParent.offsetLeft);
				linksrcParent = linksrcParent.offsetParent;
			}
			mdiv = document.all.menuDiv;
			mdiv.style.left = linksrcLeft + 8;
			mdiv.style.top = linksrcTop + linksrcH; 

			text ="<table width='96' border='0' cellpadding='3' cellspacing='0' bgcolor='e8e8e8' class='tbl'>";
			for(var i=0;i<mArray.length;i++)
			{
				text += "<tr>";
				if(i==mArray.length-1)
				{
					text += "<td align='center'>";
				}
				else
				{
					text += "<td align='center' class='bottom'>";
				}
				if (menu == "7" && i == 1)
				{
					text+="<a href='#' onclick=MM_CenterWindow('" +  mArrayURL[i] + "',400,250)>" + mArray[i];
				}
				else
				{
					text+="<a href='" + mArrayURL[i] + "' target='ContentFrame'>" + mArray[i];
				}
				text+="</a></td></tr>";
			}
			text +="</table>"; 
			mdiv.innerHTML = text;
			mdiv.style.visibility="visible";
			isShow = true;
		}
	}

	function hiddenMenu()
	{
		if (isShow == true)
		{
			var mx = document.body.scrollLeft + window.event.clientX;
			var my = document.body.scrollTop + window.event.clientY;
			mdiv=document.all.menuDiv;
			mdivT = parseInt(mdiv.style.top);
			mdivL = parseInt(mdiv.style.left);
			mdivH = parseInt(mdiv.offsetHeight);
			mdivW = parseInt(mdiv.offsetWidth);
			
			if(mx < mdivL || mx > mdivL + mdivW || my < linksrcTop || my > linksrcTop + linksrcH + mdivH)
			{
				mdiv.style.visibility = "hidden";isShow = false;
			}							
		}
	}	    
</script>
<!--   菜单层   -->
<div id="menuDiv" style="VISIBILITY: hidden; POSITION: absolute">
</div>
<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
</FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
</FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
</FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
</FONT>
<!--   /菜单层   -->
<table class="tbl" id="Table2" cellSpacing="0" cellPadding="0" width="760" border="0">
	<tr>
		<td background='<%# UrlBase + "/images/titl_bg.jpg"%>' height="26" align="right">
			<!--   导航超链接   --> &nbsp;&nbsp; 
			<A href="<%# UrlBase + "/Admin/index.aspx"%>"><font color="#ffffff">首 页</font></A>&nbsp;<font color="#ffffff">┊</font>
			<a onclick="showMenu('2',100)" style="COLOR: black" href="#"><font color="#ffffff">商品信息管理</font></a>&nbsp;<font color="#ffffff">┊</font>&nbsp; 
			<A onclick="showMenu('3',100)" style="COLOR: black" href="#"><font color="#ffffff">员工信息管理</font></A>&nbsp;<font color="#ffffff">┊</font>&nbsp;
			<A onclick="showMenu('4',100)" style="COLOR: black" href="#"><font color="#ffffff">商品进货管理</font></A>&nbsp;<font color="#ffffff">┊</font>&nbsp;
			<A onclick="showMenu('5',100)" style="COLOR: black" href="#"><font color="#ffffff">商品销售管理</font></A>&nbsp;<font color="#ffffff">┊</font>&nbsp;
			<A onclick="showMenu('6',100)" style="COLOR: black" href="#"><font color="#ffffff">商品库存管理</font></A>&nbsp;<font color="#ffffff">┊</font>&nbsp;
			<A onclick="showMenu('7',100)" style="COLOR: black" href="#"><font color="#ffffff">系统管理</font></A>&nbsp;<font color="#ffffff">┊</font>&nbsp; 
			<A style="COLOR: black" href='<%# UrlBase + "/Logout.aspx"%>'><font color="#ffffff">退 出</font></A> &nbsp;&nbsp; 
			<!--   /导航主菜单   --></td>
	</tr>
	<tr>
		<td align="center"><IMG src='<%# UrlBase + "/images/title.jpg"%>'></td>
	</tr>
</table>

