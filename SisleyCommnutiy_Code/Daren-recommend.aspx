﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Daren-recommend.aspx.cs" Inherits="Daren_recommend" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 达人分享</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
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
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="#">希享会俱乐部</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="#">往期活动</a></div>
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
        	<div class="box_c">
           	  <div class="title_pic"><img src="images/title_prom.jpg" alt="最新活动" /></div>
           	  <div class="newProm">
				<div class="promImg" style="background:url('images/prom_img.jpg') no-repeat;">
                	 <ul class="clear"><li class="surplus">20<span>份</span></li><li class="focus">196853</li></ul>
                </div>
                <a href="#" target="_blank" class="btnTest">即刻试用</a>
              </div>
            </div>
            
          </div>
        	<div class="KOLshare_r">
                <div class="titlePic"><img src="images/title_recom.jpg" alt="最新达人推荐" /></div>
                <div class="newDaren">
                    <div class="daRen">
                        
                        <div class="deta clear">
                            <div class="Sl">
                                <div class="pic"><a href="#" target="_blank"><img src="images/trial_pic.jpg" alt="" /></a></div>
                                <div class="nickName"><a href="#" target="_blank">popdo</a></div>
                            </div>
                            <div class="Sr">
                                <div class="txt">
                                    <ul class="clear">
                                        <li>总评分：<em>4.4</em>/5分</li>
                                        <li><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_g.jpg" alt="" align="absmiddle" /></li>
                                    </ul>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="Sl">
                                <div class="pic"><a href="#" target="_blank"><img src="images/trial_pic.jpg" alt="" /></a></div>
                                <div class="nickName"><a href="#" target="_blank">popdo</a></div>
                            </div>
                            <div class="Sr">
                                <div class="txt">
                                    <ul class="clear">
                                        <li>总评分：<em>4.4</em>/5分</li>
                                        <li><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_g.jpg" alt="" align="absmiddle" /></li>
                                    </ul>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="Sl">
                                <div class="pic"><a href="#" target="_blank"><img src="images/trial_pic.jpg" alt="" /></a></div>
                                <div class="nickName"><a href="#" target="_blank">popdo</a></div>
                            </div>
                            <div class="Sr">
                                <div class="txt">
                                    <ul class="clear">
                                        <li>总评分：<em>4.4</em>/5分</li>
                                        <li><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_g.jpg" alt="" align="absmiddle" /></li>
                                    </ul>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="Sl">
                                <div class="pic"><a href="#" target="_blank"><img src="images/trial_pic.jpg" alt="" /></a></div>
                                <div class="nickName"><a href="#" target="_blank">popdo</a></div>
                            </div>
                            <div class="Sr">
                                <div class="txt">
                                    <ul class="clear">
                                        <li>总评分：<em>4.4</em>/5分</li>
                                        <li><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_g.jpg" alt="" align="absmiddle" /></li>
                                    </ul>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="deta clear">
                            <div class="Sl">
                                <div class="pic"><a href="#" target="_blank"><img src="images/trial_pic.jpg" alt="" /></a></div>
                                <div class="nickName"><a href="#" target="_blank">popdo</a></div>
                            </div>
                            <div class="Sr">
                                <div class="txt">
                                    <ul class="clear">
                                        <li>总评分：<em>4.4</em>/5分</li>
                                        <li><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_c.jpg" alt="" align="absmiddle" /><img src="images/star_g.jpg" alt="" align="absmiddle" /></li>
                                    </ul>
                                    <p>这款细腻清爽的乳液不仅能够令肤色晶莹白皙，更能防止肌肤缺水，令肌肤柔软而富有弹性。用后肌肤能持久光滑、滋润、纯净、明亮，如丝般细腻。</p>
                                </div>
                            </div>
                        </div>
                        
                        <div class="pageNum">
                            <ul>
                                <li>当前第1页/总共9页</li><li><span>首页</span></li><li><span>上一页</span></li><li><a href="#">下一页</a></li><li><a href="#">末页</a></li><li><label>跳转到</label><input type="text" value="" class="nums" /><input type="button" value="Go" class="btnGo" /></li>
                            </ul>
                        </div>
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

