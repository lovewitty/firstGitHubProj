<%@ Page Language="C#" AutoEventWireup="true" CodeFile="weiboHomeManage.aspx.cs" Inherits="AdminManage_weiboHomeManage" %>

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
    <TD background=images/title_bg1.jpg>��ǰλ��:�鿴��ҳ΢����¼</TD></TR>
  <TR>
    <TD bgColor=#b1ceef height=1></TD></TR>
  <TR height=20>
    <TD background=images/shadow_bg.jpg></TD></TR></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="90%" align=center border=0>
  <TR>
    <TD height=10 align="center">�ؼ���:<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
        ��ʼ����:<asp:TextBox ID="txtBeginDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
        ��������:<asp:TextBox ID="txtEndDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
        &nbsp;<asp:Button ID="btnQuery" runat="server" Text="��ѯ" onclick="btnQuery_Click" />
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
                    <td nowrap>���</td>                			 					
                    <td nowrap>�༭����</td>    
                     <td nowrap>ͷ��</td>                    
                     <td nowrap>����</td>
                            
                      <td nowrap>����</td>  
                       <td nowrap>��ҳ��ʾ��</td>  
                    <td nowrap>��������</td>
                    <td>����</td>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">
                <td nowrap><%#Container.ItemIndex+1%> </td>   
                 <td nowrap><%#Eval("EditName")%></td>              			 					
           <td nowrap><img src='../upload/weiboHome/<%#Eval("HeaderImg")%>' width="50px" height="30px" /></td>
                <td nowrap><%#Cmn.Str.GetStr(Eval("WeiboContent").ToString(),80,true)%></td>
          
                   <td nowrap><%#Eval("SortNo")%></td>
                   <td nowrap><%#Eval("HomeShowBool")%></td>
                <td nowrap><%#Eval("DateCreated")%></td>
                   <td nowrap>
                      <asp:Button ID="btnEdit" runat="server" Text="�༭" title='<%#Eval("Idx")%>'  CommandName="editDeal" CommandArgument='<%#Eval("Idx")%>' />
                    <asp:Button ID="btnDelete" runat="server" Text="ɾ��" OnClientClick="return confirm('��ȷ��Ҫɾ����');" CommandName="deleteDeal" CommandArgument='<%#Eval("Idx")%>' />
                  </td>          
              </tr>
        </ItemTemplate>
        <FooterTemplate>
       <tr class="bgc_sum" >
                <td colspan="8">��<%=recordCount%>��¼</td>                
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
                onclick="LinkButtonPrev_Click">��ҳ</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButtonNext" runat="server" Font-Bold="True" 
                onclick="LinkButtonNext_Click">��ҳ</asp:LinkButton>

                ��ǰҳ<asp:label id="lblCurrentPage" runat="server" ForeColor="Maroon"></asp:label> /
                <asp:label id="lblTotalPage" runat="server" ForeColor="#993333"></asp:label>
            
             ��ѡ��ҳ��
            <asp:DropDownList  ID="ddlPageCount" AutoPostBack="true" 
                OnTextChanged="PageIndex" runat="server"></asp:DropDownList>
        </TD>
      </TR>
</TABLE>
    </div>
    </form>
</body>
</html>


