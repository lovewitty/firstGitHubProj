<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="AdminManage_ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr height="28">
                <td background="images/title_bg1.jpg">
                    当前位置: 添加产品</td>
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
                    产品名称：
                </td>
                <td style="color: #880000">
                   
                    <asp:TextBox ID="txtTitle" runat="server" Width="232px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtTitle" ErrorMessage="产品名称必须填写"></asp:RequiredFieldValidator>
                    
                    </td>
            </tr>
          
            <tr>
                <td align="right">产品编号：</td>
                <td style="color: #880000">                  
                    <asp:TextBox ID="txtProNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">产品类别：</td>
                <td style="color: #880000">                  
                    <asp:DropDownList ID="ddlProType" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="ddlProType" ErrorMessage="产品类别必须选择"></asp:RequiredFieldValidator>
                </td>
            </tr>
          <tr>
                <td align="right">产品图片：</td>
                <td style="color: #880000">                  
                    <asp:FileUpload ID="fileProImg" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">产品说明：</td>
                <td style="color: #880000">                  
                    
                    <asp:TextBox ID="txtDesc" runat="server" Rows="3" TextMode="MultiLine" 
                        Width="186px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;
                    </td>
                <td style="color: #880000">
                  
                    <asp:Button ID="btnSubmit" runat="server"   Text="提交" 
                        onclick="btnEdt_Click" Width="92px" />
                  
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
