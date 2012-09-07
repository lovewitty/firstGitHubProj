<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmartPerson_QA_Edit.aspx.cs" Inherits="AdminManage_SmartPerson_QA_Edit" %>

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
                    当前位置: 贴身达人 - Q&amp;A 回答</td>
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
                    问题类别：</td>
                <td style="color: #880000" align="left">
                   
                    <asp:Label ID="AskTypeName" runat="server"></asp:Label>
                    </td>
            </tr>
          
            
          
            <tr>
                <td align="right" width="100">
                    提问人：
                </td>
                <td style="color: #880000" align="left">
                   
                    <asp:Label ID="UserEmail" runat="server" Text="Label"></asp:Label>
                    </td>
            </tr>
                      <tr>
                <td align="right" valign="top">
                    提问日期：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:Label ID="QuestionDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr >
                <td align="right" valign="top" >
                    提问内容：</td>
                <td style="color: #880000" align="left">
                    <asp:TextBox ID="QuestionContent" runat="server" Height="46px" 
                        TextMode="MultiLine" Width="283px"></asp:TextBox>
                </td>
            </tr>
          

          
          
          
            <tr>
                <td align="right" valign="top">回答内容：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:TextBox ID="AnswerContent" runat="server" Width="285px" Height="99px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">贴身达人：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:Image ID="Image1" runat="server" Height="73px" Width="65px" />
                    <br />
                    <asp:Label ID="DarenName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">显示：</td>
                <td style="color: #880000" align="left">                  
                    <asp:DropDownList ID="StateBool" runat="server">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>          
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000" align="left">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                       Width="92px" onclick="btnSubmit_Click" />
                  
                &nbsp;</td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000" align="left">&nbsp;
                  
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


