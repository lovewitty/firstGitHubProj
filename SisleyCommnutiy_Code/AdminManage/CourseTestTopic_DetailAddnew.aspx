<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseTestTopic_DetailAddnew.aspx.cs" Inherits="AdminManage_CourseTestTopic_DetailAddnew" %>

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
                    当前位置:
                    课件测试题目添加</td>
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
                    课件：</td>
                <td style="color: #880000">
                   
                    <asp:DropDownList ID="ddlCourse" runat="server">
                    </asp:DropDownList>
                    </td>
            </tr>
          
            
          
            <tr>
                <td align="right" width="100">
                    题目： 
                </td>
                <td style="color: #880000" align="left">
                   
                    <asp:TextBox ID="QuestionText" runat="server" Width="294px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="QuestionText" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    选项A：</td>
                <td style="color: #880000" align="left">
                   
                    <asp:TextBox ID="Aquestion" runat="server" Width="232px">A. </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="Aquestion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
          
            <tr>
                <td align="right">选项B：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="Bquestion" runat="server" Width="232px">B. </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="Bquestion" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right">选项C：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="Cquestion" runat="server" Width="232px">C. </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="Cquestion" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right">选项D：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="Dquestion" runat="server" Width="232px">D. </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="Dquestion" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right">答案：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="Answer" runat="server" Width="232px">A</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="Answer" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;</td>
                <td style="color: #880000">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                       Width="92px" onclick="btnSubmit_Click" />
                  
                &nbsp;</td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000" align="left">
                  
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                  
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


