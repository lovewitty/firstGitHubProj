<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Activity_ApplyManage.aspx.cs" Inherits="AdminManage_Activity_ApplyManage" %>

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
    <TD background=images/title_bg1.jpg>当前位置:查看活动信息</TD></TR>
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
                <td nowrap>申请会员</td>                 
                <td nowrap>活动名称</td>
                 <td nowrap>申请状态</td>     
                <td nowrap>申请日期</td> 
                <td>操作</td>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">
                <td nowrap><%#Container.ItemIndex+1%> </td>            			 					
                <td nowrap><%#Eval("UserEmail")%></td>                 
                <td nowrap><%#Eval("ActiveTitle")%></td>
                 <td nowrap><%#Eval("ApprovalStatus")%></td>     
                <td nowrap><%#Eval("DateOfApplication")%></td> 
                <td nowrap>
                      <asp:Button ID="btnEdit" runat="server" Text="编辑" title='<%#Eval("Idx")%>'  CommandName="editDeal" CommandArgument='<%#Eval("Idx")%>' />
                    <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="return confirm('您确定要删除吗？');" CommandName="deleteDeal" CommandArgument='<%#Eval("Idx")%>' />
                  </td>          
              </tr>
        </ItemTemplate>
        <FooterTemplate>
       <tr class="bgc_sum" >
                <td colspan="12">共<%=recordCount%>记录</td>                
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



