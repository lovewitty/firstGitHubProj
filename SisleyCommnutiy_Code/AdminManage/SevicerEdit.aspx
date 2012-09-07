<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SevicerEdit.aspx.cs" Inherits="AdminManage_SevicerEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr height="28">
            <td background="images/title_bg1.jpg">
                当前位置: 编辑达人</td>
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
                <td align="right" valign="top" class="style1">
                    达人姓名：</td>
                <td style="color: #880000">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtName" ErrorMessage="问题不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right" valign="top" class="style1">
                    头衔：</td>
                <td style="color: #880000">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" class="style1">
                    美容履历:</td>
                     <td style="color: #880000">
                    <asp:TextBox ID="txtResume" runat="server" Height="81px" TextMode="MultiLine" 
                             Width="238px"></asp:TextBox>
                                        </td>
                    </tr>
            <tr>
                <td align="right" valign="top" class="style1">
                    美丽分享:</td>
                     <td style="color: #880000">
                    <asp:TextBox ID="txtShare" runat="server" Height="72px" TextMode="MultiLine" 
                             Width="237px"></asp:TextBox>
                                        </td>
                    </tr>
            <tr>
                <td align="right" valign="top" class="style1">
                    分享内容:</td>
                     <td style="color: #880000">
                    <asp:TextBox ID="txtshareContent" runat="server" Height="77px" TextMode="MultiLine" 
                             Width="239px"></asp:TextBox>
                                        </td>
                    </tr>
            <tr>
                <td align="right" valign="top" class="style1">
                    头像:</td>
                     <td style="color: #880000">
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                    </tr>
          <tr>
                <td align="right" valign="top" class="style1">
                    是否当前坐镇</td>
                <td style="color: #880000">
                                       
                                            
                    <asp:CheckBox ID="chkShowPage" runat="server" Text="是否当前坐镇" />
                                       
                                            
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" class="style1">
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
