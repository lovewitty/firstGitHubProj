<%@ Page Language="C#" AutoEventWireup="true" CodeFile="medal_rule.aspx.cs" Inherits="medal_rule" %>

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
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    function showTips() {
        $(".medals .deta a").mouseover(function () {
            $_this = $(".medals .deta a").index(this);
            $(".medals .deta .tips:eq(" + $_this + ")").show();
        }).mouseout(function () {
            $(".medals .deta .tips").hide();
        }).click(function () {
            return false;
        });
    }
    $(document).ready(function () {
        showTips();
    });
</script>
</head>

<body>
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header id="header1" runat="server">
</uc1:header>
    <!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="#">个人信息</a> &gt; <a href="#">社区足迹</a> &gt; <a href="#">勋章机制</a></div>
        <div class="medalRule">
        	<div class="titlePic"><img src="images/rule_medal.jpg" alt="" /></div>
            <div class="details">
                <div class="txt">
                    <h3>通过不同途径获得勋章 <img src="images/medal_1.jpg" alt="" align="absbottom" /> <img src="images/medal_2.jpg" alt="" align="absbottom" /> <img src="images/medal_3.jpg" alt="" align="absbottom" /> ，可兑换礼品。</h3>
                    <h3>勋章获取途径</h3>
                </div>
                <div class="medals">
                	<div class="deta">
                    	<a href="###" class="links t1">钻勋章</a>
                        <a href="###" class="links t2">金勋章</a>
                        <a href="###" class="links t3">银勋章</a>
                        <div class="tips n1">
                            <div class="tit1"><div class="arrow"></div>一、注册登录</div>
                        	<div class="mbg">
                                <div class="bbg">
                                    <p>1、成功注册社区账号</p>
                                    <p>2、一周内累计邀请3位好友进入社区</p>
                                    <p>3、分享社区注册成功喜讯<p>
                                    <div class="tit2">二、活动导航</div>
                                    <p>1、成功累计10次不同社区活动申请(包括微博活动)</p>
                                    <div class="tit2">三、达人分享</div>
                                    <p>1、每日论坛打卡获银牌机制（连续10天打卡可获银牌，中间若断掉，则重新开始累计天数）</p>
                                    <p>2、分享试用中心试用信息至社交平台</p>
                                    <p>3、分享学院测试通过的喜讯至社交平台</p>
                                    <p>4、分享评论他人测评（字数需超过20字以上，以防灌水帖）留下自己对产品的评分</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="tips n2">
                            <div class="tit1"><div class="arrow"></div>一、注册登录</div>
                        	<div class="mbg">
                                <div class="bbg">
                                    <p>1、成功注册社区账号</p>
                                    <p>2、一周内累计邀请3位好友进入社区</p>
                                    <p>3、分享社区注册成功喜讯<p>
                                    <div class="tit2">二、活动导航</div>
                                    <p>1、成功累计10次不同社区活动申请(包括微博活动)</p>
                                    <div class="tit2">三、达人分享</div>
                                    <p>1、每日论坛打卡获银牌机制（连续10天打卡可获银牌，中间若断掉，则重新开始累计天数）</p>
                                    <p>2、分享试用中心试用信息至社交平台</p>
                                    <p>3、分享学院测试通过的喜讯至社交平台</p>
                                    <p>4、分享评论他人测评（字数需超过20字以上，以防灌水帖）留下自己对产品的评分</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="tips n3">
                            <div class="tit1"><div class="arrow"></div>一、注册登录</div>
                        	<div class="mbg">
                                <div class="bbg">
                                    <p>1、成功注册社区账号</p>
                                    <p>2、一周内累计邀请3位好友进入社区</p>
                                    <p>3、分享社区注册成功喜讯<p>
                                    <div class="tit2">二、活动导航</div>
                                    <p>1、成功累计10次不同社区活动申请(包括微博活动)</p>
                                    <div class="tit2">三、达人分享</div>
                                    <p>1、每日论坛打卡获银牌机制（连续10天打卡可获银牌，中间若断掉，则重新开始累计天数）</p>
                                    <p>2、分享试用中心试用信息至社交平台</p>
                                    <p>3、分享学院测试通过的喜讯至社交平台</p>
                                    <p>4、分享评论他人测评（字数需超过20字以上，以防灌水帖）留下自己对产品的评分</p>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <h4>**参与每季主打活动并达到指定条件，可获得特别勋章</h4>
                </div>
                <div class="txt">
                    <h3>双倍常规奖励</h3>
                    <p>每日抓取勋章获取途径中的一个任务（去除注册等一次性途径）</p>
                    <h3>勋章兑换</h3>
                    <p>集齐勋章数量可自动跳出可兑换的礼品，进入兑换页面即可兑换</p>
                    <h3>查询勋章</h3>
                    <p>进入个人信息页面，可查询个人勋章情况</p>
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
        <li><a href="register.html"><img src="images/btn_regnow.jpg" alt="立即注册" /></a></li>
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

</body>
</html>
