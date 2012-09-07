<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sisleyQA_Edit.aspx.cs" Inherits="AdminManage_sisleyQA_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
     <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>

    <script src="Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr height="28">
                <td background="images/title_bg1.jpg">
                    当前位置: <asp:Literal ID="ltlPageTitle" runat="server">操作标题</asp:Literal></td>
            </tr>
            <tr>
                <td bgcolor="#b1ceef" height="1">&nbsp;
                    </td>
            </tr>
            <tr height="20">
                <td background="images/shadow_bg.jpg">
                    &nbsp;</td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="2" width="95%" align="center" border="0" 
            style="line-height: 25px;">
                      
            
          
            <tr>
                <td align="right" width="100">
                    大类别：</td>
                <td style="color: #880000">
                   
                    <asp:DropDownList ID="QaTypeIdx_Fx" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="QaTypeIdx_Fx_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
          
            
          
            <tr>
                <td align="right" width="100">
                    子类别：</td>
                <td style="color: #880000">
                   
                    <asp:DropDownList ID="QuestionSubTypeIdx_Fx" runat="server">
                    </asp:DropDownList>
                    &nbsp; </td>
            </tr>
          
            
          
            <tr>
                <td align="right" width="100">
                    &nbsp;问题： 
                </td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="ContentQuestion" runat="server" Width="446px" MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="ContentQuestion" Display="Dynamic" 
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    回答：</td>
                <td style="color: #880000" align="left">
                   
                    <asp:TextBox ID="ContentAnswer" runat="server" Width="373px" MaxLength="80" 
                        Height="181px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">发布否：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:TextBox ID="PassBool" runat="server" Width="69px">yes</asp:TextBox>
                    <asp:HiddenField ID="DateAsk" runat="server" />
                </td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                       Width="92px" onclick="btnSubmit_Click" />
                  
                &nbsp;</td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000">&nbsp;
                  
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


