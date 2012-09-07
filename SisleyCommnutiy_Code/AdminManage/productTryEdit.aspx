<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productTryEdit.aspx.cs" Inherits="AdminManage_productTryEdit" %>

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
                    当前位置: 产品测试编辑</td>
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
                    试用产品标题： 
                </td>
                <td style="color: #880000" align="left">
                   
                    <asp:TextBox ID="ProductTitle" runat="server" Width="294px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="ProductTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
            </tr>
          
            <tr >
                <td align="right" valign="top" >
                    产品图片：</td>
                <td style="color: #880000" align="left">
                   
                    <asp:FileUpload ID="myFileUpload" runat="server" />
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="81px" Visible="False" 
                        Width="164px" />
                  
                    <asp:HiddenField ID="hiddenFileName" runat="server" />
                  
                </td>
            </tr>
          
            <tr>
                <td align="right">产品图片2：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:FileUpload ID="myFileUpload2" runat="server" />
                    <br />
                    <asp:Image ID="Image2" runat="server" Height="81px" Visible="False" 
                        Width="164px" />
                  
                    <asp:HiddenField ID="hiddenFileName2" runat="server" />
                  
                </td>
            </tr>
          
            <tr>
                <td align="right">产品图片3：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:FileUpload ID="myFileUpload3" runat="server" />
                    <br />
                    <asp:Image ID="Image3" runat="server" Height="81px" Visible="False" 
                        Width="164px" />
                  
                    <asp:HiddenField ID="hiddenFileName3" runat="server" />
                  
                </td>
            </tr>
          
            <tr>
                <td align="right">产品图片4：</td>
                <td style="color: #880000" align="left">
                  
                    <asp:FileUpload ID="myFileUpload4" runat="server" />
                    <br />
                    <asp:Image ID="Image4" runat="server" Height="81px" Visible="False" 
                        Width="164px" />
                  
                    <asp:HiddenField ID="hiddenFileName4" runat="server" />                  
                </td>
            </tr>
          
            <tr>
                <td align="right">产品描述：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="ProductDescription" runat="server" Width="316px" Height="93px" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="ProductDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
            <tr>
                <td align="right">&nbsp;总数量：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="TotalCount" runat="server" Width="124px">30</asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">剩余输入：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="LeftCount" runat="server" Width="123px">30</asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td align="right">当前期刊：</td>
                <td style="color: #880000">
                  
                    <asp:DropDownList ID="currentBool" runat="server">
                        <asp:ListItem>no</asp:ListItem>
                        <asp:ListItem>yes</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
          
            <tr>
                <td align="right">创建日期：</td>
                <td style="color: #880000">
                  
                    <asp:TextBox ID="DateCreated" runat="server" Width="232px"></asp:TextBox>
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
                  
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


