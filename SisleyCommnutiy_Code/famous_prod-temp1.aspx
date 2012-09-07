<%@ Page Language="C#" AutoEventWireup="true" CodeFile="famous_prod-temp1.aspx.cs" Inherits="famous_prod_temp1" %>


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
<link href="css/page.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript" src="js/jquery.masonry.min.js"></script>
<script type="text/javascript">
    function showTab() {
        $(".info .tab ul li:first a").addClass("curr");
        $(".info .deta .txt:first").show();
        $(".info .tab ul li").mouseover(function () {
            $_this = $(".info .tab ul li").index(this);
            $(".info .tab ul li .curr").removeClass('curr');
            $(".info .tab ul li:eq(" + $_this + ") a").addClass('curr');
            $(".info .deta .txt").hide();
            $(".info .deta .txt:eq(" + $_this + ")").show();
        }).mouseout(function () {
        }).click(function () {
            return false;
        });
    }
    $(document).ready(function () {
        showTab();
        var $weibox = $('.weiBo');
        $weibox.imagesLoaded(function () {
            $weibox.masonry({
                itemSelector: '.deta'
            });
        });
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
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">产品家族</a> &gt; <a href="#">明星产品</a></div>
        <div class="famousProd">
        	<div class="prod" style="background:url('images/famous_prod-temp1.jpg') no-repeat;border:1px solid #DFDFDF;">
            	<div class="info">
                	<div class="tab">
                    	<ul>
                        	<li class="n1"><a href="###">产品功效</a></li>
                            <li class="n2"><a href="###">活性成分</a></li>
                            <li class="n3"><a href="###">使用方法</a></li>
                        </ul>
                    </div>
                    <div class="deta">
                       
                    </div>
                </div>
            </div>
            <div class="testProd">
            	<div class="titlePic"><img src="images/famous_cp.jpg" alt="" /></div>
                <div class="details">
                	<div class="daRen clear">
                    	
                        <div class="deta">
                        	<div class="desc clear">
                            	<div class="Sl">
                                	<div class="pic"><img src="images/daren.jpg" alt="" /></div>
                                </div>
                                <div class="Sr">
                                  <h3>新浪微博达人 秋秋</h3>
                                  <h5>至臻坊社区发表于2012-05-31 13:59</h5>
                                  <h4><a href="#" target="_blank">殿堂级的保养经典</a></h4>
                                  <p><a href="#" target="_blank">夏天越来越近了，就我个人而言我不太喜欢脸上有过多负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</a></p>
                                </div>
                            </div>
                            <div class="share">
                            	<ul class="clear">
                                	<li class="n1"><img src="images/f_people.gif" align="absmiddle" alt="" /> 已有<span>908</span>人阅读过本文</li>
                                    <li class="n2"><img src="images/f_comm.gif" align="absmiddle" alt="" /> 目前<span>1</span>人回复</li>
                                    <li class="n3">分享至：<a href="#"><img src="images/f_weibo.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_renren.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_kaixin.jpg" align="absmiddle" alt="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        
                        <div class="deta">
                        	<div class="desc clear">
                            	<div class="Sl">
                                	<div class="pic"><img src="images/daren.jpg" alt="" /></div>
                                </div>
                                <div class="Sr">
                                  <h3>新浪微博达人 秋秋</h3>
                                  <h5>至臻坊社区发表于2012-05-31 13:59</h5>
                                  <h4><a href="#" target="_blank">殿堂级的保养经典</a></h4>
                                  <p><a href="#" target="_blank">夏天越来越近了，就我个人而言我不太喜欢脸上有过多负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</a></p>
                                </div>
                            </div>
                            <div class="share">
                            	<ul class="clear">
                                	<li class="n1"><img src="images/f_people.gif" align="absmiddle" alt="" /> 已有<span>908</span>人阅读过本文</li>
                                    <li class="n2"><img src="images/f_comm.gif" align="absmiddle" alt="" /> 目前<span>1</span>人回复</li>
                                    <li class="n3">分享至：<a href="#"><img src="images/f_weibo.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_renren.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_kaixin.jpg" align="absmiddle" alt="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        
                        <div class="deta">
                        	<div class="desc clear">
                            	<div class="Sl">
                                	<div class="pic"><img src="images/daren.jpg" alt="" /></div>
                                </div>
                                <div class="Sr">
                                  <h3>新浪微博达人 秋秋</h3>
                                  <h5>至臻坊社区发表于2012-05-31 13:59</h5>
                                  <h4><a href="#" target="_blank">殿堂级的保养经典</a></h4>
                                  <p><a href="#" target="_blank">夏天越来越近了，就我个人而言我不太喜欢脸上有过多负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</a></p>
                                </div>
                            </div>
                            <div class="share">
                            	<ul class="clear">
                                	<li class="n1"><img src="images/f_people.gif" align="absmiddle" alt="" /> 已有<span>908</span>人阅读过本文</li>
                                    <li class="n2"><img src="images/f_comm.gif" align="absmiddle" alt="" /> 目前<span>1</span>人回复</li>
                                    <li class="n3">分享至：<a href="#"><img src="images/f_weibo.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_renren.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_kaixin.jpg" align="absmiddle" alt="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        
                        <div class="deta">
                        	<div class="desc clear">
                            	<div class="Sl">
                                	<div class="pic"><img src="images/daren.jpg" alt="" /></div>
                                </div>
                                <div class="Sr">
                                  <h3>新浪微博达人 秋秋</h3>
                                  <h5>至臻坊社区发表于2012-05-31 13:59</h5>
                                  <h4><a href="#" target="_blank">殿堂级的保养经典</a></h4>
                                  <p><a href="#" target="_blank">夏天越来越近了，就我个人而言我不太喜欢脸上有过多负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</a></p>
                                </div>
                            </div>
                            <div class="share">
                            	<ul class="clear">
                                	<li class="n1"><img src="images/f_people.gif" align="absmiddle" alt="" /> 已有<span>908</span>人阅读过本文</li>
                                    <li class="n2"><img src="images/f_comm.gif" align="absmiddle" alt="" /> 目前<span>1</span>人回复</li>
                                    <li class="n3">分享至：<a href="#"><img src="images/f_weibo.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_renren.jpg" align="absmiddle" alt="" /></a> <a href="#"><img src="images/f_kaixin.jpg" align="absmiddle" alt="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
            <div class="commProd">
            	<div class="titlePic"><img src="images/famous_ryfx.jpg" alt="" /></div>
                <div class="details">
                	<div class="weiBo">
                    
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕粉嫩的颜色适合过七夕粉嫩的颜色适合过七夕粉嫩的颜色适合过七夕粉嫩的颜色适合过七夕粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="pic"><img src="images/comm_pic.jpg" alt="" /></div>
                            <div class="txt">
                                <p>暖暖-serena：粉嫩的颜色适合过七夕<img src="images/icon_love.gif" alt="" /><img src="images/icon_love.gif" alt="" /><p>
                                <p class="tip">3分钟前 来自iPhone客户端<p>
                            </div>
                        </div>
                    
                    </div>
                </div>
            </div>
            	<!-- 添加评论 -->
            	<div style="padding:50px 0 0 140px;">
                    <div class="share_reply">
                    	<dl>
                        	<dt>回复：</dt>
                            <dd><textarea name="textarea" id="textarea" cols="" rows="" class="input_reply"></textarea></dd>
                            <dd class="btn_replay"><a href="#"><img src="images/btn_submit.jpg" alt="提交" /></a></dd>
                            <br class="clr" />
                        </dl>
                    </div>
                    <div class="share_replylist">
                    	<dl>
                        	<dt><img src="images/avatar_39_39.jpg" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t">个豆腐干豆腐<br />
<br />
2012.7.28 15:20</div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                        <dl>
                        	<dt><img src="images/avatar_39_39.jpg" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t">个豆腐<br />
<br />
2012.7.28 15:20</div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                        <dl>
                        	<dt><img src="images/avatar_39_39.jpg" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t">个豆腐干豆腐干的<br />
<br />
2012.7.28 15:20</div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                    </div>
                    <div class="pageNum3">
                    	<ul>
                        	<li>当前第1页/总共9页</li><li><span>首页</span></li><li><span>上一页</span></li><li><a href="#">下一页</a></li><li><a href="#">末页</a></li><li><label>跳转到</label><input type="text" value="" class="nums" /><input type="button" value="Go" class="btnGo" /></li>
                        </ul>
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
