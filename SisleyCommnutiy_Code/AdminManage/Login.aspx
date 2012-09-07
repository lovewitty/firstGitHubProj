<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr">
<head>
	<title>希思黎社区管理后台</title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<link rel='stylesheet' href='css/wp-admin.css' type='text/css' />
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
	
	<script type="text/javascript">
	    window.onload = focusit;
	    document.onkeydown = processKey;

	    function focusit() {
	        document.getElementById('txtUserName').focus();
	    }

	    function processKey() 
        {
	        if (window.event.keyCode == 13) {
	            document.getElementById("wpsubmit").click();
	            return false;
	        }
	    }	
   </script>
</head>
<body class="login">

<div id="login">
<h1><br /><br /></h1>
    
<form name="loginform" id="loginform"  method="post" runat="server">
	<br>
	<p align="center" class="STYLE1"><!--Tech Document Management System -->
	</p>
	<p>
    <br /><br />
<label>Username:<br />
	  <input type="text" runat="server" name="txtUserName" id="txtUserName" class="input" value="" size="20" tabindex="10" />
	  </label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="请输入用户名" 
            ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
	<p>
		<label>Password:<br />
		<input type="password" runat="server"  name="txtPassword" id="txtPassword" class="input" value="" size="20" tabindex="20" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="请输入密码" 
            ForeColor="Red"></asp:RequiredFieldValidator>
		</label>
	</p>
	<p><label>
	<input name="chkRemember" runat="server"  type="checkbox" id="chkRemember" checked="checked"> 
	Remember me</label></p>
	<p class="submit">
        <asp:Button ID="wpsubmit" runat="server" Text="Login &raquo;" 
            onclick="wpsubmit_Click"/>
		<input type="hidden" name="redirect_to" value="wp-admin/" />
	</p>
</form>
</div>

<ul>
	<li style="display:none;"><a href="#" title="Are you lost?">Back to asksam homepage</a></li>
	<li><a href="#" title="Password Lost and Found">Lost your password?</a></li>
</ul>


</body>
</html>

