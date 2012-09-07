<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myDefault.aspx.cs" Inherits="myDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="btnKaixin" runat="server" Text="开心登录" 
            onclick="btnKaixin_Click" />
        <asp:Button ID="btnQQ" runat="server" Text="QQ登录" onclick="btnQQ_Click" />
        <asp:Button ID="btnLoginSina" runat="server" Text="新浪登录" 
            onclick="btnLoginSina_Click" />
        <asp:Button ID="btnRenren" runat="server" Text="人人登陆" 
            onclick="btnRenren_Click" />
    </div>
    </form>
</body>
</html>
