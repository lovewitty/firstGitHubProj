<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductTypeManage.aspx.cs" Inherits="AdminManage_ProductTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <LINK href="css/admin.css" type="text/css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <TABLE cellSpacing=0 cellPadding=0 width="100%" style="width:100%; padding:0; margin:0" align=center border=0>
  <TR height=28>
    <TD background=images/title_bg1.jpg>当前位置:产品类别管理</TD></TR>
  <TR>
    <TD bgColor=#b1ceef height=1></TD></TR>
  <TR height=20>
    <TD background=images/shadow_bg.jpg></TD></TR></TABLE>
    <TABLE cellSpacing=0 cellPadding=0 width="90%" align=center border=0>
  <TR>
    <TD height=10 align="center">类别名称:<asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
        排序(从1开始的数字）:<asp:TextBox ID="txtOrdSec" runat="server"></asp:TextBox>&nbsp;<asp:Button 
            ID="btnAdd" runat="server" Text="添加类别" onclick="btnAdd_Click" />
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
                    <td nowrap>产品类别</td>      
                     <td nowrap>排序</td>                          
                    <td nowrap>创建日期</td>                    
                    <td>操作</td>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">
                <td nowrap><%#Container.ItemIndex+1%> </td>   
                 <td nowrap><%#Eval("TypeName")%></td>   
                  <td nowrap><%#Eval("OrdSec")%></td>   			                               
                <td nowrap><%#Eval("CreateDate")%></td>
                   <td nowrap>
                      <asp:Button ID="btnEdit" runat="server" Text="编辑" title='<%#Eval("idx")%>'  CommandName="editDeal" CommandArgument='<%#Eval("Idx")%>' />
                    <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="return confirm('您确定要删除吗？');" CommandName="deleteDeal" CommandArgument='<%#Eval("Idx")%>' />
                  </td>          
              </tr>
        </ItemTemplate>
        <FooterTemplate>
       <tr class="bgc_sum" >
                <td colspan="10">共<%=DataList1.Items.Count%>记录</td>                
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
            
          
        </TD>
      </TR>
  </TABLE>
    </form>
</body>
</html>
