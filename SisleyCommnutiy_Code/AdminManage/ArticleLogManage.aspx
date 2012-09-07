﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleLogManage.aspx.cs" Inherits="AdminManage_ArticleLogManage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <LINK href="css/admin.css" type="text/css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>

    <div >
    <form id="form1" runat="server">
      
  <TABLE cellSpacing=0 cellPadding=0 width="100%" style="width:100%; padding:0; margin:0" align=center border=0>
  <TR height=28>
    <TD background=images/title_bg1.jpg>当前位置:查看希思黎的文章-阅读记录</TD></TR>
  <TR>
    <TD bgColor=#b1ceef height=1></TD></TR>
  <TR height=20>
    <TD background=images/shadow_bg.jpg></TD></TR></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="90%" align=center border=0>
  <TR>
    <TD height=10 align="center">关键字:<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
        开始日期:<asp:TextBox ID="txtBeginDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
        结束日期:<asp:TextBox ID="txtEndDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
        &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
      </TD></TR>
  <TR>
    <TD height=10></TD>
  </TR>
</TABLE>

<TABLE cellSpacing=0 cellPadding=2 width="95%" align=center border=0>
  <TR>
    <TD align=left>

        <asp:Repeater ID="DataList1" runat="server" 
            onitemcommand="DataList1_ItemCommand" 
            onitemdatabound="DataList1_ItemDataBound" >
        <HeaderTemplate>
         <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#6699ff" bordercolordark="#6699ff" class="tbShow" id="tablePrint" style="line-height:2;width:100%;">
            <tr class="th">
                    <td nowrap>序号</td>                			 					
                    <td nowrap>文章标题</td>    
                     <td nowrap>访问的用户</td>                    
                       <td nowrap>IP地址</td>  
                    <td nowrap>阅读日期</td>
    
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">
                        <td nowrap><%#Container.ItemIndex+1%> </td>   
                        <td nowrap><%#Eval("Title")%></td>              			 					
                        <td nowrap><%#Eval("UserEmail")%></td>
          
                        <td nowrap><%#Eval("IpAddress")%></td>
                        <td nowrap><%#Eval("DateCreated")%></td>
                  
              </tr>
        </ItemTemplate>
        <FooterTemplate>
       <tr class="bgc_sum" >
                <td colspan="5">共<%=recordCount%>记录</td>                
              </tr>       
          </table></td>
        </tr>
      </table>
      
      </td>
    </tr>
  </table>
        </FooterTemplate>
        </asp:Repeater>
      </TD>
  </TR>
      <TR style="text-align:right;">
        <TD style="text-align:right;">
            
            <asp:LinkButton ID="LinkButtonPrev" runat="server" Font-Bold="True" 
                onclick="LinkButtonPrev_Click">上页</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButtonNext" runat="server" Font-Bold="True" 
                onclick="LinkButtonNext_Click">下页</asp:LinkButton>

                当前页<asp:label id="lblCurrentPage" runat="server" ForeColor="Maroon"></asp:label> /
                <asp:label id="lblTotalPage" runat="server" ForeColor="#993333"></asp:label>
            
             请选择页数
            <asp:DropDownList  ID="ddlPageCount" AutoPostBack="true" 
                OnTextChanged="PageIndex" runat="server"></asp:DropDownList>
        </TD>
      </TR>
</TABLE>
    </div>
    </form>
</body>
</html>



