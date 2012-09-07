<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  CodeFile="UserArticle_AddNew.aspx.cs" Inherits="AdminManage_UserArticle_AddNew" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="../ckfinder/ckfinder.js" type="text/javascript"></script>

    <script src="Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .style1
        {
            width: 102%;
        }
        .style8
        {
            width: 195px;
        }
        .style9
        {
            width: 106px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr height="28">
                <td background="images/title_bg1.jpg">
                    当前位置: 达人分享</td>
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
                    用户Id：</td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="uId" runat="server" Width="140px" MaxLength="80"></asp:TextBox>
                    &nbsp;</td>
            </tr>
          
            
          
            <tr>
                <td align="right" width="100">
                    文章类别：
                </td>
                <td style="color: #880000" align="left">
                   
                    <asp:RadioButtonList ID="rdType" runat="server" 
                        onselectedindexchanged="rdType_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True">普通文章</asp:ListItem>
                        <asp:ListItem>产品测试</asp:ListItem>
                    </asp:RadioButtonList>
                   <asp:Panel border ID="Panel1" runat="server" Width="473px" Height="146px" 
                        BackColor="#FFFFCC" Visible="False">
                        <table class="style1">
                            <tr>
                                <td  align="right" class="style9">
                                    产品类别:</td>
                                <td align="left" >
                                    <asp:DropDownList ID="ProductCategoryIdx_Fx" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ProductCategoryIdx_Fx_SelectedIndexChanged">
                                    </asp:DropDownList>
                                &nbsp;</td>
                            </tr>
                            <tr>
                                <td  align="right" class="style9">
                                    产品:</td>
                                <td align="left" >
                                    <asp:DropDownList ID="ProductTitle" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ProductTitle_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td  align="right" class="style9">
                                    产品图片</td>
                                <td align="left" >
                                    <asp:Image ID="ProductPictures" runat="server" Height="36px" Width="86px" />
                                </td>
                            </tr>
                            <tr>
                                <td  align="right" class="style9">
                                    产品印象</td>
                                <td align="left" >
                                    <asp:CheckBoxList ID="ProductImpression" runat="server" 
                                        RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td  align="right" class="style9">
                                    评分</td>
                                <td align="left" >
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    文章标题：</td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="wenZhangTitle" runat="server" Width="282px" MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ActiveTitleRep" runat="server" 
                        ControlToValidate="wenZhangTitle" Display="Dynamic" 
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
                    文章内容：</td>
                <td style="color: #880000">
             
                        
                            <asp:TextBox ID="articleContent" runat="server" TextMode="MultiLine" 
                                Height="265px"  Width="500px"></asp:TextBox> 
                            <script type="text/javascript">                                CKEDITOR.replace('<%= articleContent.ClientID %>', { skin: 'office2003' }); //skin: 'office2003','v2'</script>       

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



