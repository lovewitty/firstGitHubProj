<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QATypeAdd.aspx.cs" Inherits="AdminManage_QATypeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr height="28">
            <td background="images/title_bg1.jpg">
                当前位置: 添加问题类别
            </td>
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
    <table cellspacing="0" cellpadding="2" width="95%" align="center" border="0" style="line-height: 25px;">
        <tr>
            <td align="right" width="160">
                问题类别 [大类]：
            </td>
            <td style="color: #880000">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="VerfiyAdmin"
                    SelectMethod="GetQAMainType"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="VerfiyAdmin"
                    SelectMethod="GetQASubType">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="QATtype" Name="idx" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:DropDownList ID="QATtype" runat="server" DataSourceID="ObjectDataSource1" DataTextField="QaTypeName"
                    DataValueField="Idx" OnSelectedIndexChanged="QATtype_SelectedIndexChanged" OnDataBound="QATtype_DataBound"
                    AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="删除所选类别[大类]" OnClick="Button2_Click"
                    OnClientClick="return confirm('确定要删除吗?');" Visible="False" />
                &nbsp;&nbsp;
                <asp:TextBox ID="txtQAMType" runat="server"></asp:TextBox>
                排序:<asp:TextBox ID="txtMSort" runat="server" Width="26px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="添加问题类别 [大类]" OnClick="Button1_Click" />
                &nbsp;<asp:Button ID="Button4" runat="server" Text="保存修改" 
                    onclick="Button4_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="right">
                问题类别 [子类]：
            </td>
            <td style="color: #880000">
                <asp:TextBox ID="txtSType" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="Button5" runat="server" Text="添加问题类别[子类]" OnClick="Button5_Click" />
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2"
                    DataTextField="QaSubTypeName" DataValueField="Idx" AutoPostBack="True" OnDataBound="DropDownList1_DataBound"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button3" runat="server" Text="删除所选类别[子类]" 
                    OnClick="Button3_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td style="color: #880000">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须选择问题类别[大类]"
                    ControlToValidate="QATtype" Enabled="false"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td style="color: #880000">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
