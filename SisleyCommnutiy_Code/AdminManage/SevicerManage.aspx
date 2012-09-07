<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SevicerManage.aspx.cs" Inherits="AdminManage_SevicerManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr height="28">
            <td background="images/title_bg1.jpg">
                当前位置: 达人管理</td>
        </tr>
        <tr>
            <td bgcolor="#b1ceef" height="1">
                &nbsp;
            </td>
        </tr>
        <tr height="20">
            <td background="images/shadow_bg.jpg">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectCountMethod="GetAllDarenCount" TypeName="VerfiyAdmin" 
        SelectMethod="GetDaren" onselecting="ObjectDataSource1_Selecting">
        <SelectParameters>
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="StartRecordIndex" DefaultValue="1"
                    Name="startRowIndex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10"
                    Name="maximumRows" Type="Int32" />
                    </SelectParameters>
    </asp:ObjectDataSource>
    <TABLE cellSpacing=0 cellPadding=2 width="95%" align=center border=0>
  <TR>
    <TD align=left>
    <asp:Repeater ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" 
            onitemcommand="DataList1_ItemCommand" >
        <HeaderTemplate>
         <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#6699ff" bordercolordark="#6699ff" class="tbShow" id="tablePrint" style="line-height:2;width:100%;">
            <tr class="th">
                               			 					
                    <td nowrap>达人姓名</td>      
                    <td nowrap>头像</td>      
                     <td nowrap>头衔</td>      
                     <td nowrap>美容履历</td>
                    <td nowrap>美丽分享</td>  
                      <td nowrap>分享内容</td> 
                     <td nowrap> 当前坐镇否</td> 
                    <td nowrap>创建日期</td>
                    <%-- <td nowrap>发布日期</td>--%>
                    <td>操作</td>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">                
                 <td nowrap><%#Eval("DarenName")%></td>                     		
                <td nowrap><img src="../upload/Daren/<%#Eval("HeaderImg")%>" width="50px" height="30px" /></td>
                <td nowrap><%#Eval("Title")%></td>               
                  <td nowrap><%#Eval("BeautyResume")%></td>
                  <td nowrap><%#Eval("BeautyShare")%></td>
                  <td nowrap><%#Eval("SinaShareContent")%></td>
                <td nowrap><%#Eval("showPageBool")%></td>
                <td nowrap><%#Eval("CreatedDate")%></td>
                
                   <td nowrap>
                      <asp:Button ID="btnEdit" runat="server" Text="编辑" title='<%#Eval("Idx")%>'  CommandName="editDeal" CommandArgument='<%#Eval("Idx")%>' />
                    <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="return confirm('您确定要删除吗？');" CommandName="deleteDeal" CommandArgument='<%#Eval("Idx")%>' />
                  </td>          
              </tr>
        </ItemTemplate>
        <FooterTemplate>           
          </table></td>
        </tr>
      </table>
      </td>
    </tr>
  </table>
        </FooterTemplate>
        </asp:Repeater>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Left" 
        PageSize="10" ShowFirstLast="False">
    </webdiyer:AspNetPager>
      </TD>
  </TR>        
</TABLE>
   
    </form>
</body>
</html>
