<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sisley-academy.aspx.cs" Inherits="sisley_academy" %>

<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 至臻学院</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    function openWindowNew(url) {
        window.open(url,"_blank");
    }

    $(document).ready(function () {
        $("#academynav ul.child").removeClass("child");
        $("#academynav li").has("ul").hover(function () {
            $(this).addClass("current").children("ul").fadeIn();
        }, function () {
            $(this).removeClass("current").children("ul").hide();
        });
    });


    function callCourseware(cmIdx) { 
        
    }


</script>
</head>

<body>
    <form id="form1" runat="server">
<div class="wrap">
	<div class="flower" style=" bottom:48px;"><img src="images/flower.jpg" /></div>
<uc1:header ID="header1" runat="server" />

    <div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="sisley-academy.html">至臻学院</a></div>
    <div class="content2">
        <div class="academy">
                <div class="academy_1">
<div class="academy_1_l" style="display:none">
                    	<div class="academy_1_l_1">当前学分：<span>782</span>分<br />
你已经超越了<span>584</span>名学员</div>
				  <ul class="academy_1_2">
                   	  <li><a href="#"><img src="images/btn_test.jpg" alt="测试" /></a></li>
                   	  <li><a href="#"><img src="images/btn_lookresult.jpg" alt="查看成绩" /></a></li>
                  </ul>
                  <div class="academy_1_3">
                  <a href="javascript:;" id="gethelp"><img src="images/btn_help.jpg" alt="寻求帮助" /></a>
                  <div id="helpBox">
                        <div class="close_box2"><a href="javascript:;" id="helpclose"><img src="images/icon_close2.gif" alt="关闭" /></a></div>
                      <div class="askcontent">
                      <textarea name="a" cols="5" rows="3" class="input_help" id="txtAskcontent"  runat="server"></textarea>
                        </div>
                        <div class="btn_apply">
                            <asp:LinkButton ID="lnkAskContent" runat="server" onclick="lnkAskContent_Click"><img src="images/btn_apply.jpg" alt="立即申请" /></asp:LinkButton>
                     </div>
                    </div>
                  </div>
          <div class="academy_1_4">
          黑玫瑰对对碰<br />
                    正在火热进行中<br />
                <a href="#">&gt;&gt;立即参加</a></div>
                <div class="academy_1_5">分享当前课程至： <a href="#"><img src="images/icon_weibo4.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq4.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin4.jpg" alt="开心网" align="absmiddle" /></a></div>
                </div>
                	<div class="academy_1_r" style="padding-left:0">
                    	<ul id="academynav" style="padding-left:220px; width:820px;">
                            <asp:Literal ID="ltlCourseMain" runat="server">
                            <li><a href="#">品牌故事</a>
                                <ul class="child">
                                    <li><a href="#">品牌故事1</a></li>
                                    <li><a href="#">品牌故事2</a></li>
                                    <li><a href="#">品牌故事3</a></li>
                                    <li><a href="#">品牌故事4</a></li>
                                </ul>
                            </li>
                            <li><a href="#">植物美容学</a>
                                <ul class="child">
                                    <li><a href="#">植物美容学1</a></li>
                                    <li><a href="#">植物美容学2</a></li>
                                    <li><a href="#">植物美容学3</a></li>
                                    <li><a href="#">植物美容学4</a></li>
                                </ul>
                            </li>
                            <li><a href="#">肌肤常识</a>
                                <ul class="child">
                                    <li><a href="#">肌肤常识1</a></li>
                                    <li><a href="#">肌肤常识2</a></li>
                                    <li><a href="#">肌肤常识3</a></li>
                                </ul>
                            </li>
                            <li><a href="#">希思黎基础知识</a>
                            	<ul class="child">
                                    <li><a href="#">希思黎基础知识1</a></li>
                                    <li><a href="#">希思黎基础知识2</a></li>
                                    <li><a href="#">希思黎基础知识3</a></li>
                                </ul>
                            </li>
                            <li><a href="#">明星产品介绍</a>
                            	<ul class="child">
                                    <li><a href="#">明星产品介绍1</a></li>
                                    <li><a href="#">明星产品介绍2</a></li>
                                    <li><a href="#">明星产品介绍3</a></li>
                                </ul>
                            </li>
                            </asp:Literal>

                            <li><a href="#">新品预告</a>
                            </li>

                            <br class="clr" />
                        </ul>
                        <div class="academy_flash" ><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="982" height="521">
    <param name="movie" value="Main.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="transparent" />
    <param name="FlashVars" value="cmIdx=<%=cmIdx %>" />
    <embed src="Main.swf" width="982" height="521" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
  </object></div>
                    </div>
                    <br class="clr" />
                </div>
                <div class="academy_2">
                <div class="title_qa"><img src="images/title_qa.jpg" alt="Q&A" /></div>
                <ul>
                	<li class="question">
                        <a href="qa.aspx" target="_blank"><img src="images/questionAd.jpg" /></a>
                    </li>
<li class="acad">
                    	<div class="subtitle_qa">至臻学院细则</div>
                    <div class="pic_med"><img src="images/icon_medal.jpg" alt="" /></div>
                    <div class="medal_rule">最权威的线上美容护肤知识学习平台，伴随着学习越来越深入即可获得社区独有的玫瑰勋章进行产品小样兑换。<br />
<br />
<span>独一无二的美容达人勋章：每季可获得主打产品试用、参与线下活动时更会获得特别礼品......   　　　　<a href="rule.aspx">查看详细</a></span></div>
					<dl class="darenmedal">
                    	<dt>勋章日志</dt>
                        <dd><img src="images/avatar_50_50.jpg" width="50" height="50" /><p>晓月<br />
2分钟前获得钻石勋章</p></dd>
                        <dd><img src="images/avatar_50_50.jpg" width="50" height="50" /><p>晓月<br />
2分钟前获得钻石勋章</p></dd>

                    </dl>
              
                    </li>
                    <br class="clr" />
                </ul>
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




<script>
    $(document).ready(function () {
        $("#gethelp").click(function () {
            $("#helpBox").show();
            //$("#bg").show().height($(document).height());
        });
        $("#helpclose").click(function () {
            $("#helpBox").hide();
            //$("#bg").hide();
        });
    });
</script>
    </form>
</body>
</html>
