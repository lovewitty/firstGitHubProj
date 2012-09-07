<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QATypeManage.aspx.cs" Inherits="AdminManage_QATypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/Global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr height="28">
            <td background="images/title_bg1.jpg">
                当前位置: 问题类别管理</td>
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

    <TABLE cellSpacing=0 cellPadding=0 width="90%" border=0>
  <TR>
    <TD height=10 >类别名称:<asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnQuery" runat="server" Text="查询" />
      </TD></TR>
  <TR>
    <TD height=10></TD>
  </TR>
</TABLE>
    <TABLE cellSpacing=0 cellPadding=0 width="90%" border=0>
  
  <TR>
    <TD style="padding-left:10px">  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetQAMainType" TypeName="VerfiyAdmin">
        <SelectParameters>
        <asp:Parameter Name="startRowIndex" />
        <asp:Parameter Name="maximumRows" />
        <asp:ControlParameter ControlID="txtKeywords" Name="mtypename" />        
        </SelectParameters>
        </asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tbShow"      
        DataSourceID="ObjectDataSource1" DataKeyNames="Idx" 
        onrowdatabound="GridView1_RowDataBound" Width="564px" AllowPaging="True" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" PageSize="10" Height="291px">
        <Columns>
            <asp:BoundField DataField="QaTypeName" HeaderText="类别名称" 
                SortExpression="QaTypeName" />
            <asp:BoundField DataField="SortNumb" HeaderText="排序" 
                SortExpression="SortNumb" />
            <asp:TemplateField HeaderText="子类别">
                <ItemTemplate>
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource2" 
                        AutoGenerateColumns="False" onrowdatabound="GridView2_RowDataBound"  
                        DataKeyNames="Idx" 
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="QaSubTypeName" HeaderText="子类别名称" />
                            <asp:TemplateField HeaderText="编辑">
                             <ItemTemplate>
                             <a href="QASTypeEdit.aspx?Id=<%# Eval("Idx") %>">编辑</a>
　　                      </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                        TypeName="VerfiyAdmin" SelectMethod="GetQASubType" DeleteMethod="DelQASType" 
                        >
                    <DeleteParameters>
                        <asp:parameter name="Idx" type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                    <asp:Parameter Name="midx" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                 <ItemTemplate>
                     <a href="QAMTypeEdit.aspx?Id=<%# Eval("Idx") %>">编辑</a>&nbsp;
                     <a href="QAMTypeDel.aspx?Id=<%# Eval("Idx") %>" onclick="javascript:return confirm('确定要删除吗?')">删除</a>&nbsp;
                     <a href="QASubAdd.aspx?id=<%# Eval("Idx") %>">添加子类别</a>
　　              </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView></TD>
  </TR>
</TABLE>
  
    </form>
</body>
</html>
