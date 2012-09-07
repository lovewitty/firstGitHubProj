<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainHeader.aspx.cs" Inherits="Admin_MainHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <LINK href="css/admin.css" type="text/css" rel="stylesheet">
    <script src="css/jquery-1.4.1.min.js" type="text/javascript"></script>
<style type="text/css">
*{ padding:0; margin:0;}
#imgLeft{ padding-top:0; margin-top:0;}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <BODY>
<TABLE cellSpacing=0 cellPadding=0 width="100%" 
background="images/header_bg.jpg" border=0>
  <TR height=56>
    <TD width=260 valign="top"><IMG id="imgLeft" height=56 src="images/header_left.jpg" 
    width=260></TD>
    <TD style=" FONT-WEIGHT: bold; COLOR: #fff; PADDING-TOP: 10px; " 
      align=middle valign=middle>当前用户：<%=loginUserName %> &nbsp;&nbsp; 
      <!--
      <A style="COLOR: #fff" 
      href=""       target=main>修改口令</A> 
      -->
      &nbsp;&nbsp; <A style="COLOR: #fff"      
      href="logout.aspx" target="_top">退出系统</A> 
       
    </TD>
    <TD align=right width=268 valign="top"><IMG height=56 
      src="images/header_right.jpg" width=268></TD></TR></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR bgColor=#1c5db6 height=4>
    <TD></TD></TR></TABLE>
    </div>
    </form>
</body>
</html>

