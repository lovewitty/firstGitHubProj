<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="ArticleSisleyEdit.aspx.cs" Inherits="AdminManage_ArticleSisleyEdit" %>

<%@ Register assembly="CKFinder" namespace="CKFinder" tagprefix="CKFinder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
    <script src="Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

    <script src="Js/jquery-1.6.1.min.js" type="text/javascript"></script>

    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../ckfinder/ckfinder.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr height="28">
                <td background="images/title_bg1.jpg">
                    当前位置:
                    文章记录添加</td>
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
                    标题：
                </td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="Title" runat="server" Width="178px" MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="Title" Display="Dynamic" 
                        ErrorMessage="请输入 (max:80)"></asp:RequiredFieldValidator>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    首页预览图片：</td>
                <td style="color: #880000" align="left">
                    <asp:FileUpload ID="myFileUpload" runat="server" />
                    * 上传请使用英文名称<br />
                    <asp:Image ID="Image1" runat="server" Height="64px" Width="124px" />
                    <asp:HiddenField ID="hiddenFileName" runat="server" />
                </td>
            </tr>
          
            <tr>
                <td align="right" valign="top">
                    内容：</td>
                <td style="color: #880000" align="left" width="800px;">
                        <asp:TextBox ID="fck" runat="server" TextMode="MultiLine" Height="351px"  
                            Width="502px"></asp:TextBox> 
                        <script type="text/javascript">                            CKEDITOR.replace('<%= fck.ClientID %>', { skin: 'office2003' }); //skin: 'office2003','v2'</script>       
                </td>
            </tr>
          
            <tr>
                <td align="right">发布日期：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="ReleaseDate" onClick="WdatePicker()" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">显示首页：</td>
                <td style="color: #880000">
                  
                    <asp:DropDownList ID="HomeShowsBool" runat="server">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                        onclick="btnAddNew_Click" Width="92px" />
                  
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



