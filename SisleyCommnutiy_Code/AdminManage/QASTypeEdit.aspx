<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QASTypeEdit.aspx.cs" Inherits="AdminManage_QASTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr height="28">
            <td background="images/title_bg1.jpg">
                当前位置: QA子类别编辑</td>
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

    <table cellspacing="0" cellpadding="2" width="95%" align="center" border="0" 
            style="line-height: 25px;">
                      
            
          
            
          
            <tr>
                <td align="right" valign="top">
                    所属大类：</td>
                <td style="color: #880000">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtName" ErrorMessage="必须存在"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right" valign="top">
                    名称：</td>
                <td style="color: #880000">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtTitle" ErrorMessage="类别名称不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>            
            <tr>
                <td align="right" valign="top">
                    &nbsp;</td>
                <td style="color: #880000">
                                        <asp:Button ID="Button2" runat="server" Text="提交" Width="97px" 
                                            onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
