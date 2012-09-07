<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Order2_GiftManage.aspx.cs" Inherits="AdminManage_Order2_GiftManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="css/admin.css" type="text/css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../ckfinder/ckfinder.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <div>
        <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" style="width: 100%; padding: 0;
            margin: 0" align="center" border="0">
            <tr height="28">
                <td background="images/title_bg1.jpg">
                    ��ǰλ��:��Ʒ����
                </td>
            </tr>
            <tr>
                <td bgcolor="#b1ceef" height="1">
                </td>
            </tr>
            <tr height="20">
                <td background="images/shadow_bg.jpg">
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Visible="False">

         <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#6699ff" bordercolordark="#6699ff" class="tbShow" id="tablePrint" style="line-height:2;width:50%;">
                
                <tr class="th">
                    <td colspan="2" align="left" nowrap>
                        &nbsp;&nbsp;<b runat="server" id="opTitle">���</b>
                    </td>
                </tr>
                <tr>
                    <td  nowrap>
                        ��Ʒ��ţ�
                    </td>
                    <td  nowrap>
                        <asp:TextBox ID="GiftNumber" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        ��Ʒ���ƣ�
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="GiftName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        ͼƬ&nbsp;��
                    </td>
                    <td nowrap>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:Image ID="Image1" runat="server" Height="49px" Width="141px" />
                        <asp:HiddenField ID="HiddenFieldImg" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        ������
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="330px" Width="500px"></asp:TextBox>
                        <script type="text/javascript">                            CKEDITOR.replace('<%= txtContent.ClientID %>', { skin: 'office2003' }); //skin: 'office2003','v2'</script>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        ������֣�
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="NeedPoint" runat="server">10</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        ״̬��
                    </td>
                    <td nowrap align="left">
                        <asp:RadioButtonList ID="GifShowBool" runat="server" RepeatDirection="Horizontal"
                            Width="20%">
                            <asp:ListItem Selected="True" Value="yes">��ʾ</asp:ListItem>
                            <asp:ListItem Value="no">����</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        �������ڣ�
                    </td>
                    <td nowrap>
                        <asp:TextBox ID="ExpirationDate" runat="server" onClick="WdatePicker()" 
                            Width="125px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap>&nbsp;
                        
                    </td>
                    <td nowrap>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="�ύ" 
                            Width="83px" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="ȡ��" 
                            Width="73px" />
                        <asp:HiddenField ID="HiddenFOperation" runat="server" />
                    </td>
                </tr>
            </table>
            <hr />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tr>
                    <td height="10" align="center">
                        �ؼ���:<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
                        ��ʼ����:<asp:TextBox ID="txtBeginDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
                        ��������:<asp:TextBox ID="txtEndDate" runat="server" onClick="WdatePicker()"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnQuery" runat="server" Text="��ѯ" OnClick="btnQuery_Click" />
                        <asp:Button ID="BtnAdd" runat="server" Text="���" OnClick="BtnAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" width="100%" align="center" border="0">
                <tr>
                    <td align="left">
                    <asp:Repeater ID="DataList1" runat="server" 
            onitemcommand="DataList1_ItemCommand" 
            onitemdatabound="DataList1_ItemDataBound" >
        <HeaderTemplate>
         <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#6699ff" bordercolordark="#6699ff" class="tbShow" style="line-height:2;width:100%; ">
            <tr class="th">
                <td nowrap>���</td>                			 					
                <td nowrap>��Ʒ���</td>                 
                <td nowrap>��Ʒ����</td>
                <td nowrap>��ƷͼƬ</td>
                <td nowrap>�������</td>  
                <td nowrap>��ʾ״̬</td> 
                <td nowrap>��������</td> 
                <td>����</td>
              </tr>
        </HeaderTemplate>
        <ItemTemplate>

        
         <tr id="trIdrep" runat="server" onMouseOver="this.bgColor='#C4DFF7'" onMouseOut="this.bgColor='#ffffff'">
                <td nowrap><%#Container.ItemIndex+1%> </td>   
                <td nowrap><%#Eval("GiftNumber")%></td>  
                 <td nowrap><%#Eval("GiftName")%></td>              			 					
                <td nowrap><img src="../upload/order/<%#Eval("GiftImgBig")%>" width="60px" height="40px" /></td>
                <td nowrap><%#Eval("NeedPoint")%></td>               
                <td nowrap><%#Eval("GifShowBool")%></td>
                <td nowrap><%#Eval("CreatedDate")%></td>
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



                     
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr align="right">
                    <td>
                        ��ѡ��ҳ��
                        <asp:DropDownList ID="ddlPageCount" AutoPostBack="true" OnTextChanged="PageIndex"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
        </form>
    </div>
</body>
</html>

