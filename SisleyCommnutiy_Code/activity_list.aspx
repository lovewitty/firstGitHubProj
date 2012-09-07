<%@ Page Language="C#" AutoEventWireup="true" CodeFile="activity_list.aspx.cs" Inherits="activity_list" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 活动分享</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
<link href="css/skin3.css" rel="stylesheet" type="text/css" />
<link href="css/easydialog.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.jcarousel.pack.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery('#mycarousel').jcarousel({
            vertical: false,
            auto: 5,
            wrap: 'last',
            /*initCallback: mycarousel_initCallback,*/
            scroll: 1
        });
    }); 
</script>
</head>

<body>
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    
    <div class="content" style="padding-top:7px;">
        <div class="crumbs">
          <p>当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="KOL-share.aspx">达人分享</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="activity_list.aspx">活动分享</a></p>
          <p>&nbsp;</p>
    </div>
  		<div class="KOLshare">
   	    <div class="KOLshare_l">
        	<div class="box_c">
            	<div class="title_pic"><img src="images/title_calendar.jpg" alt="calendar" /></div>
            	<div class="calendar">
               	  <div class="date">
                  		<div class="year">2012.08</div>
                        <div class="week">
                        <ul>
                        	<li>日</li>
                        	<li>一</li>
                        	<li>二</li>
                        	<li>三</li>
                        	<li>四</li>
                        	<li>五</li>
                        	<li>六</li>
                            <br class="clr" />
                        </ul>
                        </div>
                        <div class="days">
                        <ul>
                        	<li><a href="#">1</a></li>
                        	<li><a href="#">2</a></li>
                        	<li><a href="#">3</a></li>
                        	<li><a href="#">4</a></li>
                        	<li><a href="#">5</a></li>
                        	<li><a href="#">6</a></li>
                        	<li><a href="#">7</a></li>
                        	<li><a href="#">8</a></li>
                        	<li><a href="#">9</a></li>
                        	<li><a href="javascript:void(0)" id="dayBtn">10</a></li>
                        	<li><a href="#">11</a></li>
                        	<li><a href="#">12</a></li>
                        	<li><a href="#">13</a></li>
                        	<li><a href="#">14</a></li>
                        	<li><a href="#">15</a></li>
                        	<li><a href="#">16</a></li>
                        	<li><a href="#">17</a></li>
                        	<li><a href="#">18</a></li>
                        	<li><a href="#">19</a></li>
                        	<li><a href="#">20</a></li>
                        	<li><a href="#">21</a></li>
                        	<li><a href="#">22</a></li>
                        	<li><a href="#">23</a></li>
                        	<li><a href="#">24</a></li>
                        	<li><a href="#">25</a></li>
                        	<li><a href="#">26</a></li>
                        	<li><a href="#">27</a></li>
                        	<li><a href="#">28</a></li>
                        	<li><a href="#">29</a></li>
                        	<li><a href="#">30</a></li>
                        	<li><a href="#">31</a></li>
                            <br class="clr" />
                        </ul>
                        </div>
                    </div>
                    <div class="persons">
                    	<ul id="mycarousel" class="jcarousel jcarousel-skin-persons"> <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>美肌专家</p>
                    </li>
			<!--
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>ABCDEFG</p>
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>某某某某</p>
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>ABCDEFG</p>
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>某某某某</p>
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>ABCDEFG</p>
                    </li> -->
                </ul>
                    </div>
                </div>
            </div>
            <div class="btn_publ"><a href="#"><img src="images/btn_publish.jpg" alt="发表分享" /></a></div>
        	<div class="box_c">
           	  <div class="title_pic"><img src="images/title_protest.jpg" alt="产品测评" /></div>
           	  <div class="protest">
                	<ul>
                    	<li style="margin-bottom:12px;"> <a href="#"><img src="images/avatar_122_118.jpg" alt="" /></a>
                            <p><span>小美老师</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位</p>
							<br class="clr" />
                        </li>
                   	  <li> <a href="#"><img src="images/avatar_122_118.jpg" alt="" /></a>
                        <p><span>小美老师</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位</p>
							<br class="clr" />
                        </li>
                    </ul>
                </div>
                <div class="more1"><a href="#">查看更多&gt;&gt;</a></div>
            </div>
            <div class="box_c">
           	  <div class="title_pic"><img src="images/title_newtrail.jpg" alt="最新试用" /></div>
           	  <div class="newtrail">
                	<ul>
                    	<li style="margin-bottom:12px;"> <a href="#"><img src="images/pic_100_100.jpg" alt="" /></a>
                            <p><span>焕白亮泽保湿乳</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位<br />
<span style="color:#a96397; font-size:12px;">人气：235 剩余：20</span></p>
				<p style="padding-top:0;"><a href="#"><img src="images/btn_trail4.jpg" alt="申请试用" class="btn_trail1" /></a></p>
							<br class="clr" />
                      </li>
                    	<li> <a href="#"><img src="images/pic_100_100.jpg" alt="" /></a>
                            <p><span>焕白亮泽保湿乳</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位<br />
<span style="color:#a96397; font-size:12px;">人气：235 剩余：20</span></p>
				<p style="padding-top:0;"><a href="#"><img src="images/btn_trail4.jpg" alt="申请试用" class="btn_trail1" /></a></p>
							<br class="clr" />
                      </li>
                    </ul>
              </div>
                <div class="more1"><a href="#">查看更多&gt;&gt;</a></div>
            </div>
   	    </div>
        	<div class="KOLshare_r">
        	  	<div class="cosmplan">
                	<div class="cosmplan_title">活动分享</div>
<div class="share_content3">
                	  <div class="share_content_l2"><img src="images/pic_200_150.jpg" width="200" height="150" alt="" /></div>
                	  <div class="share_content_r2">
                	    <div class="share_content_name2">玫瑰玫瑰我爱你<span></span></div>
                	    <div class="share_content_intro2"> 集多种珍贵植物精粹配方，畅销30年，希思黎殿堂级保养经典！
为肌肤提供每日所需，带来缜密完善呵护，重塑肌肤光采、柔嫩。 </div>
                	    <div class="share_content_more"><a href="#">查看更多 &gt;&gt;</a></div>
              	    </div>
                	  <div class="clr"></div>
              	  </div>
                  <div class="darenshare" style="border-top:1px #f0f0f0 solid;">
                    <ul>
                    	<li>
                        <dl>
                        	<dt><img src="images/avatar_136_136.jpg" width="136" height="136" alt="" /></dt>
                            <dd>
                            <p class="s1">殿堂级的保养经典</p>
                            <p class="s2">至臻坊社区发表于2012-05-31 13:59</p>
                            <p class="s3">夏天越来越近了，就我个人而言我不太喜欢脸上负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</p>
                            <ul class="s4">
                            <li class="o1">已有<span>908</span>人阅读过本人</li>
                            <li class="o2">目前<span>18</span>人回复</li>
                            <li class="o3">分享至 <a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a></li>
                            <br class="clr" />
                            </ul>
                            </dd>
                        </dl>
                        </li>
                        <li>
                        <dl>
                        	<dt><img src="images/avatar_136_136.jpg" width="136" height="136" alt="" /></dt>
                            <dd>
                            <p class="s1">殿堂级的保养经典</p>
                            <p class="s2">至臻坊社区发表于2012-05-31 13:59</p>
                            <p class="s3">夏天越来越近了，就我个人而言我不太喜欢脸上负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</p>
                            <ul class="s4">
                            <li class="o1">已有<span>908</span>人阅读过本人</li>
                            <li class="o2">目前<span>18</span>人回复</li>
                            <li class="o3">分享至 <a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a></li>
                            <br class="clr" />
                            </ul>
                            </dd>
                        </dl>
                        </li>
                        <li>
                        <dl>
                        	<dt><img src="images/avatar_136_136.jpg" width="136" height="136" alt="" /></dt>
                            <dd>
                            <p class="s1">殿堂级的保养经典</p>
                            <p class="s2">至臻坊社区发表于2012-05-31 13:59</p>
                            <p class="s3">夏天越来越近了，就我个人而言我不太喜欢脸上负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</p>
                            <ul class="s4">
                            <li class="o1">已有<span>908</span>人阅读过本人</li>
                            <li class="o2">目前<span>18</span>人回复</li>
                            <li class="o3">分享至 <a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a></li>
                            <br class="clr" />
                            </ul>
                            </dd>
                        </dl>
                        </li>
                        <li>
                        <dl>
                        	<dt><img src="images/avatar_136_136.jpg" width="136" height="136" alt="" /></dt>
                            <dd>
                            <p class="s1">殿堂级的保养经典</p>
                            <p class="s2">至臻坊社区发表于2012-05-31 13:59</p>
                            <p class="s3">夏天越来越近了，就我个人而言我不太喜欢脸上负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</p>
                            <ul class="s4">
                            <li class="o1">已有<span>908</span>人阅读过本人</li>
                            <li class="o2">目前<span>18</span>人回复</li>
                            <li class="o3">分享至 <a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a></li>
                            <br class="clr" />
                            </ul>
                            </dd>
                        </dl>
                        </li>
                        <li class="bot">
                        <dl>
                        	<dt><img src="images/avatar_136_136.jpg" width="136" height="136" alt="" /></dt>
                            <dd>
                            <p class="s1">殿堂级的保养经典</p>
                            <p class="s2">至臻坊社区发表于2012-05-31 13:59</p>
                            <p class="s3">夏天越来越近了，就我个人而言我不太喜欢脸上负重，变得油腻不舒服，所以每天的护肤流程被我简化为三步。</p>
                            <ul class="s4">
                            <li class="o1">已有<span>908</span>人阅读过本人</li>
                            <li class="o2">目前<span>18</span>人回复</li>
                            <li class="o3">分享至 <a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a></li>
                            <br class="clr" />
                            </ul>
                            </dd>
                        </dl>
                        </li>
                        <br class="clr" />
                    </ul>
                    <div class="darenpage"><a href="#">&lt;</a> 1 <a href="#">2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">&gt;</a></div>
                  </div>
                	<div class="share_ctrl">
                	  分享至：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a>
                  </div>
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
                            	<div class="share_replylist_t">个豆腐干豆腐干的豆豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方<br />
<br />
2012.7.28</div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                        <dl>
                        	<dt><img src="images/avatar_39_39.jpg" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t">个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方<br />
<br />
2012.7.28</div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                        <dl>
                        	<dt><img src="images/avatar_39_39.jpg" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t">个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方个豆腐干豆腐干的豆腐干豆腐干豆腐干大概豆腐干豆腐干豆腐干豆腐干豆腐干豆腐干地方<br />
<br />
2012.7.28</div>
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
            <div class="clr"></div>
       </div>
    </div>
    <uc2:footer ID="footer1" runat="server" />
</div>
<script type="text/javascript" src="js/easydialog.js"></script>
<script>

    var JQRY = function () {
        return document.getElementById(arguments[0]);
    };

    JQRY('dayBtn').onclick = function () {
        easyDialog.open({
            container: 'newsBox',
            //autoClose : 2000,
            follow: 'dayBtn',
            followX: 40,
            followY: 20,
            fixed: false
        });
    };

    JQRY('Loginbtn').onclick = function () {
        easyDialog.open({
            container: 'LoginBox',
            overlay: true,
            fixed: false
        });
    };

</script>
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
<div id="newsBox">
	<div class="close2"><a href="javascript:;" onClick="easyDialog.close();"><img src="images/icon_close2.gif" alt="关闭" /></a></div>
	<div class="title2">最新动态</div>
    <div class="box_a">
    <ul>
    	<li><p><img src="images/eventpic_1.jpg" alt="" /></p>
		<p><a href="#"><img src="images/btn_apply.gif" alt="立即申请" /></a></p></li>
    	<li><p><img src="images/eventpic_2.jpg" alt="" /></p>
		<p><a href="#"><img src="images/btn_look.gif" alt="立即查看" /></a></p></li>
    	<li><p><img src="images/eventpic_1.jpg" alt="" /></p>
		<p><a href="#"><img src="images/btn_apply.gif" alt="立即申请" /></a></p></li>
    </ul>
    </div>
</div>
</body>
</html>
