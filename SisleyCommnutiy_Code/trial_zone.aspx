<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trial_zone.aspx.cs" Inherits="trial_zone" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 试用中心</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
<link href="css/skin2.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript" src="js/scroll.js"></script>
<script type="text/javascript">
    function trialTab() {
        $(".trialZone .tab ul li:first a").addClass("curr");
        $(".trialZone .deta:first").show();
        $(".trialZone .tab ul li").mouseover(function () {
            $_this = $(".trialZone .tab ul li").index(this);
            $(".trialZone .tab ul li .curr").removeClass('curr');
            $(".trialZone .tab ul li:eq(" + $_this + ") a").addClass('curr');
            $(".trialZone .deta").hide();
            $(".trialZone .deta:eq(" + $_this + ")").show();
        }).mouseout(function () {
        }).click(function () {
            return false;
        });
    }
    var notice = {};
    notice.intro = {
        start: function () {
            if ($('#notice').length) notice.intro.iniScr();
        }
	,
        iniScr: function () {
            var scroller = null;
            var scrollbar = null;
            scroller = new Scrolling.Scroller(document.getElementById('dv_scroll'), 300, 320);
            scrollbar = new Scrolling.Scrollbar(document.getElementById('dv_scroll_bar'), scroller, new Scrolling.ScrollTween());
        }
    };
    $(document).ready(function () {
        trialTab();
        notice.intro.start();
    });
</script>
</head>

<body>
<form  id="myForm" runat="server">
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    <div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="trial-zone.html">试用中心</a></div>
    <div class="content">
    	<div class="trialZone">
          	<div class="trialDeta outMore">
            	<!--<div class="trialSearch">
                	<ul class="clear">
                    	<li class="t1">热门关键字</li>
                        <li class="t2"><a href="#">美白</a></li>
                        <li class="t2"><a href="#">防晒</a></li>
                        <li class="t2"><a href="#">保湿</a></li>
                        <li class="t2"><a href="#">祛斑</a></li>
                        <li class="t2"><a href="#">抗老</a></li>
                        <li class="t2"><a href="#">香水</a></li>
                    	<li class="t3">试用搜索</li>
                        <li class="b1"><input type="text" class="inputTrail" value="全能乳液" /></li>
                        <li class="b1"><input type="button" class="btnSearch" value="搜索" /></li>
                        <li class="b1"><a href="#"><img src="images/btn_historytrail.jpg" alt="历史试用" /></a></li>
                    </ul>
                </div>-->
                <!--
                   以隐藏更多信息和关键字搜索，步骤为：
                   1、 <div class="trialDeta"> 这个样式里加上outMore样式，改为：<div class="trialDeta outMore">
                   2、 <div class="trialSearch"></div>整个标签注释掉
                -->
                <div class="details clear">
                	<div class="Sl">
                    	<div class="tab">
                        	<ul class="clear">
                            	<li class="n1"><a href="###" class="curr">正在进行的试用</a></li>
                                <li class="n2"><a href="###">试用报告分析</a></li>
                               <!-- <li class="n3"><a href="###">往期试用</a></li> -->
                            </ul>
                        </div>
                        <div class="deta">
                        	<div style="width:605px;height:647px;overflow:hidden;background:url('images/trial_img01.jpg') no-repeat;position:relative;">
                            	<a href="product2.aspx" target="_blank" title="美丽试用" style="display:block;width:115px;height:30px;overflow:hidden;text-indent:-999999px;position:absolute;left:433px;top:269px;">美丽试用</a>
                                <a href="#" target="_blank" style="display:block;width:19px;height:18px;overflow:hidden;text-indent:-999999px;position:absolute;left:444px;top:453px;">新浪微博</a>
                                <a href="#" target="_blank" style="display:block;width:16px;height:16px;overflow:hidden;text-indent:-999999px;position:absolute;left:469px;top:454px;">腾讯微博</a>
                                <a href="#" target="_blank" style="display:block;width:20px;height:19px;overflow:hidden;text-indent:-999999px;position:absolute;left:490px;top:452px;">开心网</a>
                                <ul style="clear:both;font-family:Microsoft YaHei,'宋体',SimSun,sans-serif,Arial;color:#BA7EA0;position:absolute;right:242px;top:551px;">
                                	<li style="padding:0 10px;line-height:18px;float:left;_diplay:inline;border:1px dotted #999;">剩余<br /><b>20</b><strong>份</strong></li>
                                    <li style="margin:0 0 0 7px;padding:0 10px;line-height:18px;float:left;_diplay:inline;border:1px dotted #999;">人气<br /><b>196853</b></li>
                                </ul>
                            </div>
                        </div>
                        <div class="deta">
                        	<iframe src="trial_tab2.aspx" frameborder="0" scrolling="no" width="570" height="546" />trial_tab2.aspx</iframe>
                        </div>
                        <div class="deta">
                        	<iframe src="trial_tab3.aspx" frameborder="0" scrolling="no" width="590" height="634" />trial_tab3.aspx</iframe>
                        </div>
                    </div>
                    <div class="Sr">


                    	<div class="trialLogin" >
                              	<!-- 登陆前代码 -->
                        	<%if (!HasLogined())
                           {%>
                            <ul>
                            	<li class="clear"><label for="usr">邮箱：</label><input type="text" name="txtEmail" id="txtEmail" class="inputs" runat="server" /></li>
                                <li class="clear"><label for="pwd">密码：</label><input type="password" name="txtPwd"  id="txtPwd" class="inputs"  runat="server" /></li>
                                <li class="clear"><label></label>
                                    <asp:Button ID="btnLogin" runat="server" Text="登录"  class="btnSubmit" 
                                        onclick="btnLogin_Click" />
                             </li>
                            </ul>
                          <%}
                           else
                           { %>
                          
                            	<!-- 登陆后代码 -->
                            <ul class="trialLoginAfter">
                            	<li class="logout"><a href="logout.aspx" target="_top">| 退出</a></li>
                                <li>您好：<%=GetRealName()%></li>
                                <li>[<a href="personalInfo.aspx" target="_top">个人信息</a>/<a href="fexchange_record.aspx"  target="_top">查看积分</a>]</li>
                            </ul>
                        <%} %>
                        </div>
                      

                        <div class="trialNotice">
                        	<div id="notice" class="notice" >
                                <div id="dv_scroll" class="dv_scroll" >
                                    <div id="dv_scroll_text" class="Scroller-Container" >
                                        <img src="images/notice_tit01.gif" alt="" />
                                        <p>1. 每位用户，相同个人信息（姓名、手机号码、地址）每款产品只有一次申请机会，申请状态请注意社区站内信提示。</p>
                                        <p>2. 试用产品将在申请成功后15个工作日内以快递的方式寄出。</p>
                                        <p>3. 请务必完善您的个人信息（姓名、手机、地址），以便产品成功送达，如因个人信息缺失或错误，将视为自动放弃本次申请。</p>
                                        <img src="images/notice_tit02.gif" align="" />
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                        <p>Q：获得的试用产品什么时候邮寄呢？</p>
                                        <p>A：活动结束后我们将所用产品一并寄出。所以请不清楚的网友看清活动截止日期。</p>
                                    </div>
                                </div>    
                                <!--=======================================================-->
                                <div id="dv_scroll_bar" class="dv_scroll_bar">
                                    <div class="Scrollbar-Up"></div>
                                    <div id="dv_scroll_track" class="Scrollbar-Track">
                                        <div id="dv_scroll_slider" class="Scrollbar-Handle"></div>
                                    </div>
                                    <div class="Scrollbar-Down"></div>
                                </div>
                                <!--=======================================================-->
                            </div>
                        </div>
                    </div>
                </div>
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
