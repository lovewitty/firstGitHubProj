<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testUBB_Editor.aspx.cs" Inherits="testUBB_Editor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:600px;">
    <textarea name="UBBTextBox1" id="UBBTextBox1" style='display:none' runat="server"></textarea>
    <iframe SRC="ubb/editor.html?id=UBBTextBox1&TextHeight=260"  name="UBBTextBox1_TempFrame" id="UBBTextBox1_TempFrame" style="height:260px;width:100%" frameBorder='0' marginHeight='0' marginWidth='0' scrolling='No'></iframe>
    </div>
    <div>
    <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
