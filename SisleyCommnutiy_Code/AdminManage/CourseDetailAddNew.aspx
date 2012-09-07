<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseDetailAddNew.aspx.cs" Inherits="AdminManage_CourseDetailAddNew" %>

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
                    查看课件详细添加</td>
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
                    多媒体类别： 
                </td>
                <td style="color: #880000" align="left">
                   
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal" AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="img">图片</asp:ListItem>
                        <asp:ListItem Value="video">视频</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
            </tr>
          
            <tr  >
                <td align="right" valign="top" >
                   文件上传：</td>
                <td style="color: #880000" align="left">
                    <asp:FileUpload ID="myFileUpload" runat="server" />
                    * 上传请使用英文名称<br />
                    <asp:Image ID="Image1" runat="server" Height="54px" Width="126px"  />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
          
            <tr>
                <td align="right">视频路径：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="txtVideoPath" runat="server" Width="331px">http://</asp:TextBox>
                    <br />
                    视频请直接上传好，放入路径即可</td>
            </tr>
          
            <tr>
                <td align="right">排序：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="SortNumbers" runat="server" Width="69px">10</asp:TextBox>
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


