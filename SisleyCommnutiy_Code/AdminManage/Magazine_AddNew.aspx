<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Magazine_AddNew.aspx.cs" Inherits="AdminManage_MagazineAddNew" %>


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
                    活动添加</td>
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
                    活动标题：
                </td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="ActiveTitle" runat="server" Width="308px" MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ActiveTitleRep" runat="server" 
                        ControlToValidate="ActiveTitle" Display="Dynamic" 
                        ErrorMessage="请输入标题 (max:80)"></asp:RequiredFieldValidator>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    预览图片：</td>
                <td style="color: #880000">
                    <asp:FileUpload ID="myFileUpload" runat="server" />
                    * 上传请使用英文名称</td>
            </tr>
          
            <tr>
                <td align="right" valign="top">
                    规则：</td>
                <td style="color: #880000">
                                        <asp:TextBox ID="Rules"  runat="server" 
                                            Height="67px" TextMode="MultiLine" 
                        Width="398px"></asp:TextBox></td>
            </tr>
          
            <tr>
                <td align="right" valign="top">
                    平台：</td>
                <td style="color: #880000">
                                        <asp:TextBox ID="Platform"  runat="server" 
                                            Height="67px" TextMode="MultiLine" 
                        Width="398px"></asp:TextBox></td>
            </tr>
          
            <tr>
                <td align="right" valign="top">
                    奖品：</td>
                <td style="color: #880000">
                                        <asp:TextBox ID="Prizes"  runat="server" 
                                            Height="67px" TextMode="MultiLine" 
                        Width="398px"></asp:TextBox></td>
            </tr>
          
            <tr>
                <td align="right">显示首页否：</td>
                <td style="color: #880000">                  
                    <asp:DropDownList ID="DisplayHomeBool" runat="server">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>          
            <tr>
                <td align="right">首页预览图：</td>
                <td style="color: #880000">                  
                    <asp:FileUpload ID="myFileUpload2" runat="server" />
                    &nbsp;上传请使用英文名称</td>
            </tr>
          
            <tr>
                <td align="right">开始日期：</td>
                <td style="color: #880000">                  
                    <asp:TextBox ID="ActivityStartDate" onClick="WdatePicker()" runat="server" 
                        Width="122px"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">结束日期：</td>
                <td style="color: #880000">                  
                    <asp:TextBox ID="ActivityEndDate" onClick="WdatePicker()" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                        Width="92px" />
                  
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



