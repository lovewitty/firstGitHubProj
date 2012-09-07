<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sisley-service.aspx.cs" Inherits="sisley_service" %>
<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register src="Ascx/productTry3List.ascx" tagname="productTry3List" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="索尼（Sony）在中国网站，全面介绍Sony公司的各项业务.提供丰富的产品信息，包括数码相机，摄像机，笔记本电脑，电视系列，影音产品等以及售后服务和购买服务" />
<meta name="keywords" Content="数码摄像机, 数码相机,Sony数码相机,MP3,sony mp3,记忆棒,vaio,walkman,随身听,液晶电视,Sony彩电,汽车音响,投影机,等离子屏,服务支持,sony中国 ,索尼中国 ,电影,笔记本电脑, 家用电器,影音 产品" />
<title>法国希思黎至臻坊社区 sisley PARIS | 达人分享</title>
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
    function selectType() {
        $(".serv .tab ul li:first a").addClass("curr");
        $(".types").val($(".serv .tab ul li:first a span").text());
        $(".serv .tab ul li").click(function () {
            $_this = $(".serv .tab ul li").index(this);
            $(".types").val($(this).find("span").text());
            $(".serv .tab ul li .curr").removeClass('curr');
            $(".serv .tab ul li:eq(" + $_this + ") a").addClass('curr');
            return false;
        });
    }
    jQuery(document).ready(function () {
        jQuery('#mycarousel').jcarousel({
            vertical: false,
            auto: 5,
            wrap: 'last',
            /*initCallback: mycarousel_initCallback,*/
            scroll: 1
        });
        selectType();
    }); 
</script>
</head>

<body>
    <form id="form1" runat="server">
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header id="header1" runat="server">
</uc1:header>
    <!-- ***********header End***************************-->
    
    <div class="content" style="padding-top:7px;">
        <div class="crumbs">
   	当前位置：<a href="index.html">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="KOL-share.html">达人分享</a></div>
  		<div class="KOLshare">
   	    <div class="KOLshare_l">
        	<div class="box_c">
            	<div class="title_pic"><img src="images/title_calendar.jpg" alt="calendar" /></div>
            	<div class="calendar">
               	  <div class="date">
                  		<div class="year">2012.6</div>
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
                    	<ul id="mycarousel" class="jcarousel jcarousel-skin-persons">
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
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>某某某某</p>
                    </li>
                    <li>
                    	<p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                        <p>ABCDEFG</p>
                    </li>
                </ul>
                    </div>
                </div>
            </div>
        	<div class="box_c">
           	  <div class="title_pic"><img src="images/title_protest.jpg" alt="产品测评" /></div>
           	  <div class="protest">
                    <uc3:productTry3List ID="productTry3List1" runat="server" />
                    
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
                    	<li style="margin-bottom:12px;"> <a href="#"><img src="images/pic_100_100.jpg" alt="" /></a>
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
            	<div class="serv">
                	<div class="intro">
                        <div class="titlePic"><img src="images/title_serv.jpg" alt="" /></div>
                        <div class="details clear">
                            <div class="pic">
                                <img src="images/serv_img.jpg" id="HeaderImg" runat="server" width="140" height="186" alt="" />
                            </div>
                            <div class="txt">
                                <p>达人姓名: 
                                    <asp:Literal ID="DarenName" runat="server">cc</asp:Literal>
                                    <asp:HiddenField ID="hiddenSmartPersonIdx" runat="server" />
                                    <br />
                                    头衔:<asp:Literal ID="Title" runat="server">头衔</asp:Literal><br />
                                    美容履历: <asp:Literal ID="BeautyResume" runat="server">多年经验</asp:Literal><br />
                                <p>今日美容贴士分享:<br /><asp:Literal ID="BeautyShare" runat="server">干性肌肤注意补水哦</asp:Literal><br /></p>
                                <p>分享至: <a href="#"><img src="images/icon_weibo3.jpg" alt="" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="" /></a></p>
                            </div>
                        </div>
                    </div>
                    <div class="ques">
                    	<div class="titlePic"><img src="images/title_ques.jpg" alt="" /></div>
                        <div class="details">
                        	<div class="tab">
                            	<ul class="clear">
                                <script type="text/javascript" >
                                    function SetTypeIdx(vIdx) {
                                        $("#txtTypeIdx").val(vIdx);
                                    }
                                    
                                </script>
                                    <asp:TextBox ID="txtTypeIdx" runat="server" Text="3" style="display:none;"></asp:TextBox>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li><a href="#" <%#GetSelectedCss(Eval("Idx").ToString()) %>><span onclick='SetTypeIdx(<%#Eval("Idx")%>)'><%#Eval("AskTypeName")%></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>                                	
                                   
                                </ul>
                            </div>
                            <div class="deta">
                            	<div class="top"></div>
                                <div class="midd">
                                	<input name="types" type="hidden" value="" class="types" />

                                    <textarea name="QuestionContent" runat = "server" id="QuestionContent"></textarea>
                                </div>
                                <div class="bott"></div>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="提交"  CssClass="btnSubmit"
                                onclick="Button1_Click" />
                           
                        </div>
                    </div>
                    <div class="myQues">
                    	<div class="titlePic"><img src="images/title_myques.jpg" alt="" /></div>
                        <div class="details">
                            <asp:Repeater ID="RepeaterQA" runat="server">
                         <ItemTemplate>
                            <!-- 问 start -->
                            <div class="dvQues">
                                <div class="deta clear">
                                    <div class="Sl">
                                        <div class="arrow"></div>
                                        <div class="pic"><img src="upload/userHearderImg/<%#Eval("askerHeadPhoto")%>" width="40px" alt="" /></div>
                                    </div>
                                    <div class="Sr">
                                        <div class="top"></div>
                                        <div class="txt">
                                            <p>【提问-<B><%#Eval("AskTypeName")%></B>】 <%#Eval("QuestionContent")%></p>
                                        </div>
                                        <div class="bott"></div>
                                    </div>
                                </div>
                            </div>
                            <!-- 问 End -->
                            
                            <!-- 答 start -->
                            <div class="dvAnsw"  style='<%#GetDvAnswState(Eval("AnswerContent"))%>'>
                                <div class="deta clear">
                                    <div class="Sr">
                                        <div class="top"></div>
                                        <div class="txt">
                                                 <%#Eval("AnswerContent")%>
                                        </div>
                                        <div class="bott"></div>
                                    </div>
                                    <div class="Sl">
                                        <div class="arrow"></div>
                                        <div class="pic"><img src="upload/daren/<%#Eval("smartPersonHeaderImg")%>" alt=""  width="40px" /></div>
                                    </div>
                                </div>
                              </div>
                              <!-- 答 End -->
                              </ItemTemplate>
                          </asp:Repeater>
                            <div class="pageNum3">
                    	<ul>
                          <li>当前第<asp:label id="lblCurrentPage" runat="server" ForeColor="Maroon"></asp:label>页/总共 <asp:label id="lblTotalPage" runat="server" ForeColor="#993333"></asp:label>页</li><li>
                            <span>
                            <asp:LinkButton ID="LinkButtonFirst" runat="server" Font-Bold="True" onclick="LinkButtonFirst_Click" 
               >首页</asp:LinkButton></span></li><li><span> <asp:LinkButton ID="LinkButtonPrev" runat="server" Font-Bold="True" 
                onclick="LinkButtonPrev_Click">上页</asp:LinkButton></span></li>
                <li><asp:LinkButton ID="LinkButtonNext" runat="server" Font-Bold="True" 
                onclick="LinkButtonNext_Click">下页</asp:LinkButton></li><li><asp:LinkButton ID="LinkButtonLast" 
                                    runat="server" Font-Bold="True" onclick="LinkButtonLast_Click" 
               >末页</asp:LinkButton></li><li><label>跳转到第</label><asp:DropDownList  ID="ddlPageCount" AutoPostBack="true" 
                OnTextChanged="PageIndex" runat="server"></asp:DropDownList>页</li>
                        </ul>
                    </div>
                            
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
        <li><a href="register.html"><img src="images/btn_regnow.jpg" alt="立即注册" /></a></li>
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
    </form>
</body>
</html>
