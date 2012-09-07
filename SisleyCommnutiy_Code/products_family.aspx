<%@ Page Language="C#" AutoEventWireup="true" CodeFile="products_family.aspx.cs" Inherits="star_products" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 明星产品</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#prosnav ul.child").removeClass("child");
        $("#prosnav li").has("ul").hover(function () {
            $(this).addClass("current").children("ul").fadeIn();
        }, function () {
            $(this).removeClass("current").children("ul").hide();
        });
    });
</script>
</head>

<body>
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    
    <div class="content">
        <div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="star-products.html">产品家族</a></div>
    	<div class="productsfamily">
        	<div class="productsfamily_l">
            	<div class="productsfamily_l_nav">
                <ul id="prosnav">
                	<li style="width:150px; margin-right:3px;">最新上市产品</li>
                    <li style="width:159px; margin-right:3px;"><a href="hotboard.aspx" target="_blank">热议排行榜</a></li>
                    <li style="width:157px; margin-right:3px;"><a href="products_star.aspx" target="_blank">明星产品</a></li>
                    <li style="width:157px;"><a href="#">产品大全</a>
                        <ul class="child">
                            <li><a href="http://www.sisley.com.cn/skincare.html" target="_blank">护肤</a></li>
                            <li><a href="http://www.sisley.com.cn/color.html" target="_blank">彩妆</a></li>
                            <li><a href="http://www.sisley.com.cn/perfume.html" target="_blank">香水</a></li>
                        </ul>
                     </li>
                </ul>
                </div>
                <div class="productsfamily_l_content">
                    <div class="productsfamily_pic"><a href="famous_prod.aspx" target="_blank"><img src="images/productsfamily_pic.jpg" width="605" height="667" /></a></div>
                    <div class="productsfamily_l_share">分享到：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a>
                    </div>
                </div>
            </div>
        	<div class="productsfamily_r">
            	<div class="darenrecommend">
                	<div class="title_pic"><img src="images/title_darentj.jpg" alt="达人为您推荐" /></div>
                    <ul>
                    	<li><a href="Daren-recommend.aspx?Idx=2"><img src="images/products_pic_01.jpg" width="160" height="190" /></a></li>
                    	<li><a href="#"><img src="images/products_pic_02.jpg" width="160" height="152" /></a></li>
                    </ul>
                <ul>
                    	<li><a href="famous_prod-temp5.aspx"><img src="images/products_pic_03.jpg" width="139" height="153" /></a></li>
                    	<li><a href="famous_prod-temp1.aspx"><img src="images/products_pic_04.jpg" width="139" height="189" /></a></li>
                    </ul>
                    <br class="clr" />
                </div>
            <div class="trailcenter0">
                	<div class="title_pic"><img src="images/title_trailcenter.jpg" alt="试用中心" /></div>
                    <div class="trailcenter0_content">
                    	<div class="trailcenter0_content_l"><a href="#"><img src="images/pic_90_150.jpg" alt="" width="90" height="150" /></a>
                        </div>
               	  <div class="trailcenter0_content_r">
                        	<div class="trailcenter0_name">玫瑰焕采紧致面膜<br />
<span>Black Rose Cream Mask</span></div>
					<div class="trailcenter0_bg1">100份</div>
				<div class="trailcenter0_bg2">100456</div>
                        </div>
                        <br class="clr" />
                        <div class="trail_info">
                        	<p><img src="images/avatar_44_44.jpg" width="44" height="44" alt="" /><span>透明的风筝领取了玫瑰焕采紧致面膜。</span></p>
                        	<p><img src="images/avatar_44_44.jpg" width="44" height="44" alt="" /><span>透明的风筝领取了玫瑰焕采紧致面膜。</span></p>
                        	<div style="text-align:right ; padding:10px 30px 20px 0;"><a href="#"><img src="images/btn_iwanttrail.jpg" alt="我要试用" /></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <br class="clr" />
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

</body>
</html>
