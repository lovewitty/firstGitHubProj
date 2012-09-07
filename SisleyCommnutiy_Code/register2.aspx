<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register2.aspx.cs" Inherits="register2" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 用户注册</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    function ChkForm() {
        var UserEmail = $("#UserEmail").val();
        var Password = $("#Password").val();
        var Password2 = $("#Password2").val();
        var MobilePhone = $("#MobilePhone").val();
        var viladCode = $("#viladCode").val();

        if (UserEmail == "") {
            alert("请输入您的邮箱");
            $("#UserEmail").focus();
            return false;
        }
        else {
            if (!UserEmail.match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                alert("Email格式不正确！请重新输入");
                $("#UserEmail").focus();
                return false;
            }
        }

        if (Password == "") {
            alert("请输入您的密码");
            $("#Password").focus();
            return false;
        }
        else {
            if (Password != Password2) {
                alert("输入的2次密码不相同");
                $("#Password").focus();
                return false;
            }
        }

        if (Password2 == "") {
            alert("请输入'再次登录密码'");
            $("#Password2").focus();
            return false;
        }

        if (MobilePhone == "") {
            alert("请输入您的手机号码");
            $("#MobilePhone").focus();
            return false;
        }
        else {
            if (MobilePhone.length != 11) {
                alert("手机格式不正确！请重新输入");
                $("#MobilePhone").focus();
                return false;
            }
        }

        if (viladCode == "") {
            alert("请输入验证码");
            $("#viladCode").focus();
            return false;
        }

        if ($("input[name='RdoAgreement']:checked").val() != "yes") {
            alert("请勾选同意协议");
            $("#redio_yes").focus();
            return false;
        }

        return true;
    }

    function ChkForm() {
        var UserEmail = $("#UserEmail").val();
        var Password = $("#Password").val();
        var Password2 = $("#Password2").val();
        var VipCardNo = $("#VipCardNo").val();
        var RealName = $("#RealName").val();
        var Province = $("#Province").val();
        var MobilePhone = $("#MobilePhone").val();
        var City = $("#City").val();
        var viladCode = $("#viladCode").val();

        if (VipCardNo == "") {
            alert("请输入您的会员卡号");
            $("#VipCardNo").focus();
            return false;
        }

        if (UserEmail == "") {
            alert("请输入您的邮箱");
            $("#UserEmail").focus();
            return false;
        }
        else {
            if (!UserEmail.match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                alert("Email格式不正确！请重新输入");
                $("#UserEmail").focus();
                return false;
            }
        }

        if (Password == "") {
            alert("请输入您的密码");
            $("#Password").focus();
            return false;
        }
        else {
            if (Password != Password2) {
                alert("输入的2次密码不相同");
                $("#Password").focus();
                return false;
            }
        }

        if (Password2 == "") {
            alert("请输入'再次登录密码'");
            $("#Password2").focus();
            return false;
        }

        if (RealName == "") {
            alert("请输入您的姓名");
            $("#RealName").focus();
            return false;
        }

        if (MobilePhone == "") {
            alert("请输入您的手机号码");
            $("#MobilePhone").focus();
            return false;
        }
        else {
            if (MobilePhone.length != 11) {
                alert("手机格式不正确！请重新输入");
                $("#MobilePhone").focus();
                return false;
            }
        }

        if (Province == "") {
            alert("请选择省");
            $("#Province").focus();
            return false;
        }

        if (City == "") {
            alert("请输入城市");
            $("#City").focus();
            return false;
        }

        if (viladCode == "") {
            alert("请输入验证码");
            $("#viladCode").focus();
            return false;
        }

        if ($("input[name='RdoAgreement']:checked").val() != "yes") {
            alert("请勾选同意协议");
            $("#redio_yes").focus();
            return false;
        }

        return true;
    }

    function GetImgCode() {
        var getimagecode = document.getElementById("imgViladCode");
        var myDate = new Date();
        var rdn = myDate.getMilliseconds();
        getimagecode.src = "Ascx/VerifyCode.aspx?rdn=" + rdn;
    }


</script>
</head>

<body>
    <form id="form1" runat="server">
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="register.aspx">用户注册</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="register2.html">非会员注册</a></div>
    	<div class="register">
        	<div class="flower_pic"><img src="images/flower_pic.jpg" alt="玫瑰焕采紧致面膜" /></div>
        <div class="reg_content">
            <div><img src="images/title_reg2.jpg" alt="" /></div>
            <ul class="reg2">
                 <li><label><span>*</span> 电子邮箱：</label> <input id="UserEmail" runat="server" name="" type="text" class="input_reg1" /></li>
               	<li><label><span>*</span> 登录密码：</label> <input id="Password" runat="server" name="" type="password" class="input_reg1" /></li>
               	<li><label><span>*</span> 再次输入登录密码：</label> <input id="Password2" runat="server" name="" type="password" class="input_reg1" /></li>
               	<li><label><span>*</span> 手机号码：</label> <input id="MobilePhone" runat="server" name="" type="text" class="input_reg1" /></li>
               	<li><label>验证码：</label> <input id="viladCode" runat="server" name="" type="text" class="input_reg3" /> 
           	    <img src="Ascx/VerifyCode.aspx" align="absmiddle" id="imgViladCode"  runat="server" /> <span style="font-family:'宋体', Arial; color:#b5b5b5;">看不清？<a href="javascript:GetImgCode()">换一张</a></span></li>
           </ul>
      <div class="agreement">
           		<div class="agreement_title">希思黎会员服务协议</div>
           		<div class="agreement_content">希思黎会员服务协议<br />
                <br />
                协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容
                <br />
                <br />
                协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容协议内容
         </div>
           </div>
           	<dl class="agree">
            	<dd><input id="redio_yes"  name="RdoAgreement" type="radio" value="yes" 
                        checked="checked"  /> <label>我同意以上协议</label></dd>
            	<dd><input id="redio_no"  name="RdoAgreement" type="radio" value="no" /> <label>不同意以上协议</label></dd>
                <dt>
                    <asp:LinkButton ID="lnkSubmit" runat="server" onclick="lnkSubmit_Click" OnClientClick="return ChkForm()"><img src="images/btn_submitreg.jpg" alt="提交注册" /></asp:LinkButton>
               </dt>
                <!-- register_success.html -->
                <br class="clr" />
            </dl>
          </div>
        </div>
    </div>
    <uc2:footer ID="footer1" runat="server" />
</div>

<div id="LoginBox">
	<div class="close_box"><a href="javascript:;" onClick="easyDialog.close();"><img src="images/icon_close.gif" alt="关闭" /></a></div>
    <ul class="login_l">
    	<li>
    	  <label for="textfield">会员名：</label>
    	  <input type="text" name="textfield" id="textfield" class="input_login" />
    	</li>
   	  <li>
   	    <label for="textfield2">密码：</label>
   	    <input type="password" name="textfield2" id="textfield2" class="input_login" />
    	</li>
   	  <li>
   	    <label for="textfield3">验证码：</label>
   	    <input type="text" name="textfield3" id="textfield3" class="input_login2" />
    	</li>
        <li class="ver">
        <img src="images/code.jpg" /> <span>看不清？<a href="#">换一张</a></span>
        </li>
      <li class="ver"><input name="" type="checkbox" value="" /> 记住登录状态&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">忘记密码?</a></li>
      <li class="ver"><a href="#"><img src="images/btn_login.jpg" alt="登录" /></a></li>
    </ul>
    <ul class="login_r">
    	<li>您是第一次进入希思黎官方网站？</li>
        <li><a href="register.aspx"><img src="images/btn_regnow.jpg" alt="立即注册" /></a></li>
    	<li>使用其他网站帐号登录：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a></li>
    </ul>
</div>
<script src="js/easydialog.js"></script>
<script>
    var JQRY = function () {
        return document.getElementById(arguments[0]);
    };

    JQRY('Loginbtn').onclick = function () {
        easyDialog.open({
            container: 'LoginBox',
            overlay: true,
            fixed: false
        });
    };
</script>

    </form>

</body>
</html>
