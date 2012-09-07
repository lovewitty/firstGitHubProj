﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register_success.aspx.cs" Inherits="register_success" %>


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
<script src="js/myOpenShare.js" type="text/javascript"></script>
<script src="js/jsStringFormat.js" type="text/javascript"></script>
<script type="text/javascript">
    function AddMedalLog(eventName) {
        $.ajax(
                {
                    type: "POST",
                    url: "Ascx/DealAjax.aspx",
                    data: String.format("req=AddMedal&EventName={0}", "Click "+eventName),
                    success: function (msg) {
                        //alert(msg);
                    }
                });
    }    
</script>

</head>

<body>
    <form id="form1" runat="server">
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server">
    </uc1:header>
    <!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">
   	<!--当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="register.aspx">用户注册</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="register2.html">非会员注册</a>--></div>
    <div class="register" style="padding-top:91px; _height:400px; min-height:400px;">
        	<div class="reg_success">
            	<ul>
                	<li><a href="#" onclick="AddMedalLog('sinaShare');shareLink('sinaShare')"><img src="images/icon_weibo3.jpg" alt="新浪微博" /></a></li>
                	<li><a href="#" onclick="AddMedalLog('qqShare');shareLink('qqShare')"><img src="images/icon_tqq3.jpg" alt="腾讯微博" /></a></li>
                	<li><a href="#" onclick="AddMedalLog('kaixinShare');shareLink('kaixinShare')"><img src="images/icon_kaixin3.jpg" alt="开心网" /></a></li>
                    <br class="clr" />
                </ul>

                <!--
                <div class="reg_tips">分享即可获得社区至臻勋章</div>
                -->
      </div>
        </div>
    </div>
    <uc2:footer id="footer1" runat="server">
</uc2:footer>
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
