<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 活动导航</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function GetImgCode() {
        var getimagecode = document.getElementById("imgViladCode");
        var myDate = new Date();
        var rdn = myDate.getMilliseconds();
        getimagecode.src = "Ascx/VerifyCode.aspx?rdn=" + rdn;
    }
     
    function GoLogin() {
        var UserEmail = $("#txtEmail").val();
        var Password = $("#txtPwd").val();
        var ViladCode = $("#txtValidCode").val();

        if (UserEmail == "") {
            alert("请输入电子邮箱");
            $("#txtEmail").focus();
            return false;
        }

        if (Password == "") {
            alert("请输入您的密码");
            $("#txtPwd").focus();
            return false;
        }

        /*
        $.ajax(
        {
        type: "POST",
        url: "Ascx/DealAjax.aspx",
        data: String.format("rep=homeLogin&UserEmail={0}&Password={1}&viladCode={2}", UserEmail, Password, viladCode),
        success: function (msg) {
        alert(msg);
        //location.href = "rLogin.aspx?t=sina";
        }
        });
        */
    }
</script>
</head>

<body>
<form runat="server" id="myForm" defaultbutton="lnkLogin">
<div class="wrap">
<div class="flower"><img src="images/flower.jpg" /></div>
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    <div class="content" style="padding-top:7px;">
        <div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="login.html">登录</a></div>
  		<div class="LoginBox">
	<div class="close_box"></div>
    <ul class="login_l">
    	<li>
    	  <label for="textfield">电子邮箱：</label>
            <asp:TextBox ID="txtEmail" runat="server" class="input_login"></asp:TextBox>
    	</li>
   	  <li>
   	    <label for="textfield2">密码：</label>
           <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" class="input_login" ></asp:TextBox>
  
    	</li>
   	  <li>
   	    <label for="textfield3">验证码：</label>
   	     <asp:TextBox ID="txtValidCode" runat="server" class="input_login"></asp:TextBox>
    	</li>
        <li class="ver">
        <img  src="Ascx/VerifyCode.aspx" id="imgViladCode"  runat="server"  /> <span>看不清？<a href="javascript:GetImgCode()">换一张</a></span>
        </li>
      <li class="ver">
      <input name="" type="checkbox" value="yes" id="ChkRemeberLogined" runat="server" />
        记住登录状态&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" style="text-decoration:underline">忘记密码?</a></li>
      <li class="ver">
       <asp:LinkButton ID="lnkLogin" runat="server"  OnClientClick="return GoLogin()" 
              onclick="lnkLogin_Click"><img src="images/btn_login.jpg" alt="登录" /></asp:LinkButton>
         
      </li>
    </ul>
    <ul class="login_r">
    	<li>您是第一次进入希思黎官方网站？</li>
        <li><a href="register.aspx"><img src="images/btn_regnow.jpg" alt="立即注册" /></a></li>
    	<li>使用其他网站帐号登录：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a></li>
    </ul>
</div>
	   <br class="clr" />
    </div>
    <uc2:footer ID="footer1" runat="server" />
</div>

</form>
</body>
</html>
