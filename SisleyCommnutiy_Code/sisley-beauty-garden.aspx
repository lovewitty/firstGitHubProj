<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sisley-beauty-garden.aspx.cs" Inherits="sisley_beauty_garden" %>
<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 希粉会</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
<link href="css/skin3.css" rel="stylesheet" type="text/css" />
<link href="css/easydialog.css" rel="stylesheet" type="text/css" />
<link href="css/waterwheel-carousel.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.jcarousel.pack.js"></script>
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
    //$(function(){
    //	$('#slides').slides({
    //		preload: true,
    //		generateNextPrev: false
    //	});
    //});
</script>
<script type="text/javascript" src="js/jquery.waterwheelCarousel.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $("#waterwheel-carousel-horizon").waterwheelCarousel({
            startingWaveSeparation: 0,
            centerOffset: 30,
            startingItemSeparation: 150,
            itemSeparationFactor: .7,
            itemDecreaseFactor: .75,
            opacityDecreaseFactor: 1,
            autoPlay: 10000000
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
  当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="sisley-beauty-garden.html">希粉会</a></div>
  		<div class="club">
   	    <div class="club_l">
        	<div class="box_c">
            	<div class="title_pic"><img src="images/title_calendar2.jpg" alt="calendar" /></div>
                <div class="calendar_out">
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
            </div>
   	    </div>
        	<div class="club_r">
            	<div class="box_d">
                	<div class="title_pic"><img src="images/title_personal.jpg" alt="个人信息" /></div>
                	<div class="personal">
                       <% 
                      if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
                      {
                          Cmn.Js.ShowAlert("请先登录，谢谢！");
                          Response.Redirect(string.Format("login.aspx?from={0}", Request.Url.ToString()));
                      }
                      DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
                      ent = ent.Get(int.Parse(Cmn.Cookies.Get("login_UserIdx")));
                      string headImg = "";
                      string strSorce = "90";


                      string uName = ent.RealName;
                      if (string.IsNullOrEmpty(uName))
                      {
                          uName = ent.UserEmail.Split('@')[0].ToString();
                      }
                                        
                    headImg = string.Format("upload/userHearderImg/{0}", ent.HeadPhoto);
                    if (!Cmn.FileFolder.CheckFileExist(Server.MapPath(headImg)))
                    {
                        headImg = string.Format("upload/userHearderImg/{0}", "default.jpg");
                    }                    
                  %>

                    	<div class="personal_pic"><img src="images/avatar_145_191.jpg" width="145" height="191" alt="" /><br />
<%=uName%></div>
						<div class="personal_info">

        

                        <ul>
                        <!--<li><span>我的积分：</span>58643</li>-->
                        <li><span>我的勋章：</span><img src="images/badge_1.jpg" height="21" width="21" alt="" align="absmiddle" /> <img src="images/badge_2.jpg" height="21" width="21" alt="" align="absmiddle" /> <img src="images/badge_3.jpg" height="21" width="21" alt="" align="absmiddle" /> </li>
                        <li><span>我的学院进度：</span>15%</li>
                        <li><span>我的考试成绩：</span>100</li>
                        <li><span>我浏览过的文章：</span><a href="#">法国人的鸿久馆</a></li>
                        <li><span>我参与过的活动：</span><a href="#">我最爱的枕边书</a></li>
                        <li><span>我的分享：</span><a href="#">希思黎明星产品--全能乳液使用感受</a></li>
                        <li class="lookmore"><a href="personalInfo.aspx"><img src="images/btn_lookmore.jpg" alt="查看更多" /></a></li>
                        </ul>
                        </div>
                    </div>
                </div>
        	</div>
            <div class="clr"></div>
       </div>
     <div class="club2">
           <div class="title_pic"><img src="images/title_exp.jpg" alt="新片体验和分享" /></div>
           <div class="newpros"><%--<div id="waterwheel-carousel-horizon">
      <div class="carousel-controls">
      	<div class="carousel-prev"><a href="#"><img src="images/arrow_left.png" alt="" /></a></div>
      	<div class="carousel-next"><a href="#"><img src="images/arrow_right.png" alt="" /></a></div>
      </div>
      <div class="carousel-images">
        <a href="#"><img src="images/testImage1.png" alt="" /></a>
        <a href="#"><img src="images/testImage2.png" alt="" /></a>
        <a href="#"><img src="images/testImage3.png" alt="" /></a>
        <a href="#"><img src="images/testImage4.png" alt="" /></a>
        <a href="#"><img src="images/testImage5.png" alt="" /></a>
        <a href="#"><img src="images/testImage6.png" alt="" /></a>
        <a href="#"><img src="images/testImage7.png" alt="" /></a>
      </div>
    </div>--%>
    
     <!-- <img src="images/scrollpic.jpg" width="959" height="301" /> -->
                       <!--flash -->
           <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"  width="959" height="301">
    <param name="movie" value="sisley_userPart0827.swf" />
    <param name="quality" value="high" />
    <param name="wmode" value="transparent" />
    <param name="FlashVars" value="path=http://wlin.sisleycommnutiy.com/data2flash/xwFlash.aspx?rep=getImageList&typeName=userPart" /> 
    <embed src="sisley_userPart0827.swf"  width="959" height="301" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" wmode="transparent"></embed>
  </object>
    
    </div>
     </div>
       <div class="club3">
       		<div class="club3_l">
            	<ul class="club_banner_1">
                	<li><a href="http://b.showone.com.cn/medal_rule.aspx"><img src="images/banner_01.jpg" alt="" /></a></li>
                </ul>
                <div class="title_pic"><img src="images/title_promotion.jpg" alt="活动介绍" /></div>
                <div id="picBox2">
                    <ul id="show_pic2" style="left:0;">
                        <li>
            
                        <div class="promo_intro border1">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令1</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                      
                        <div class="promo_intro">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令1</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="activity-mine.aspx">More..</a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        
                        </li>
                        <li>
                        <div class="promo_intro border1">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令2</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
              
                        <div class="promo_intro">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令2</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        </li>
                        <li>
                        <div class="promo_intro border1">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令3</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        <div class="promo_intro">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令3</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        </li>
                        <li>
                        <div class="promo_intro border1">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令4</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        <div class="promo_intro">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令4</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        </li>
                        <li>
                        <div class="promo_intro">
                        	<div class="promo_intro_l"><img src="images/pic_177_142.jpg" width="177" height="142" alt="" /></div>
                            <div class="promo_intro_r">
                            <dl>
                            	<dt><span>闺蜜征集令5</span><br />
                                时间：2012-12-31<br />
                                规则：邀请微博好友一起参加<br />
                                平台：微博、社区<br />
                                <span style="color:#c8b772; font-size:12px;">奖品：希思黎小样</span></dt>
                                <dd><a href="#"><img src="images/btn_detail2.gif" alt="查看详情" /></a></dd>
                                <dd class="share2"><a href="#"><img src="images/icon_weibo2.jpg" alt="新浪微博" /></a> <a href="#"><img src="images/icon_kaixin2.jpg" alt="开心网" /></a> <a href="#"><img src="images/icon_renren2.jpg" alt="人人网" /></a>
                            	</dd>
                            </dl>
                            </div>
                            <br class="clr" />
                        </div>
                        </li>
                    </ul>
                    <!--
                    <ul id="icon_num2">
                        <li class="active">1</li>
                        <li>2</li>
                        <li>3</li>
                        <li>4</li>
                        <li>5</li>
                    </ul>
                    -->
                </div>
                
                
            </div>
      <div class="club3_m">
            	<div class="title_pic"><img src="images/title_darenshare.jpg" alt="达人分享" /></div>
                <ul class="darens1">
                <asp:Repeater ID="Repeater1" runat="server">
                   <ItemTemplate>
                   <li>
                            <p class="ava">
                                <a href='<%#Cmn.SisleyHelper.GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>'><img src='upload/userHearderImg/<%#Eval("HeadPhoto")%>' width="66" height="66" alt="" /></a>
                                <br /><%#Cmn.Str.GetStr(Eval("RealName").ToString(),8,false)%></p>
                            <p><a href="<%#Cmn.SisleyHelper.GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>"><span><%#Cmn.Str.GetNoImgStr(Eval("Title").ToString(),25,true)%></span><br /> <%#Cmn.Str.GetNoImgStr(Eval("Content").ToString(),60,true)%></a></p>
                            </li>
                </ItemTemplate>
                 </asp:Repeater>
                </ul>
         </div>
         <div class="club3_r">
         	<div class="club_banner_1"><a href="beautifulPlan.aspx"><img src="images/home_banner_1.jpg" width="213" height="208" alt="" /></a></div>
            <div class="title_pic"><img src="images/title_survice.jpg" alt="贴身服务" /></div>
            <div class="club_banner_2">
            <a href="sisley-service.aspx">
            <img src="images/club_banner.jpg" width="209" height="211" /><span>美容达人一对一<br />
解答您的护肤问题</span><br />
<img src="images/btn_lookmore.jpg" alt="查看更多" /></a>

</div>
         </div>
            <div class="clr"></div>
       </div>
    </div>
        <uc2:footer ID="footer1" runat="server" />
</div>
<script type="text/javascript">
    /**
    *glide.layerGlide((oEventCont,oSlider,sSingleSize,sec,fSpeed,point);
    *@param auto type:bolean 是否自动滑动 当值是true的时候 为自动滑动
    *@param oEventCont type:object 包含事件点击对象的容器
    *@param oSlider type:object 滑动对象
    *@param sSingleSize type:number 滑动对象里单个元素的尺寸（width或者height）  尺寸是有point 决定
    *@param second type:number 自动滑动的延迟时间  单位/秒
    *@param fSpeed type:float   速率 取值在0.05--1之间 当取值是1时  没有滑动效果
    *@param point type:string   left or top
    */
    var glide = new function () {
        function $id(id) { return document.getElementById(id); };
        this.layerGlide = function (auto, oEventCont, oSlider, sSingleSize, second, fSpeed, point) {
            var oSubLi = $id(oEventCont).getElementsByTagName('li');
            var interval, timeout, oslideRange;
            var time = 1;
            var speed = fSpeed
            var sum = oSubLi.length;
            var a = 0;
            var delay = second * 1000;
            var setValLeft = function (s) {
                return function () {
                    oslideRange = Math.abs(parseInt($id(oSlider).style[point]));
                    $id(oSlider).style[point] = -Math.floor(oslideRange + (parseInt(s * sSingleSize) - oslideRange) * speed) + 'px';
                    if (oslideRange == [(sSingleSize * s)]) {
                        clearInterval(interval);
                        a = s;
                    }
                }
            };
            var setValRight = function (s) {
                return function () {
                    oslideRange = Math.abs(parseInt($id(oSlider).style[point]));
                    $id(oSlider).style[point] = -Math.ceil(oslideRange + (parseInt(s * sSingleSize) - oslideRange) * speed) + 'px';
                    if (oslideRange == [(sSingleSize * s)]) {
                        clearInterval(interval);
                        a = s;
                    }
                }
            }

            function autoGlide() {
                for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                clearTimeout(interval);
                if (a == (parseInt(sum) - 1)) {
                    for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                    a = 0;
                    oSubLi[a].className = "active";
                    interval = setInterval(setValLeft(a), time);
                    timeout = setTimeout(autoGlide, delay);
                } else {
                    a++;
                    oSubLi[a].className = "active";
                    interval = setInterval(setValRight(a), time);
                    timeout = setTimeout(autoGlide, delay);
                }
            }

            if (auto) { timeout = setTimeout(autoGlide, delay); };
            for (var i = 0; i < sum; i++) {
                oSubLi[i].onmouseover = (function (i) {
                    return function () {
                        for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                        clearTimeout(timeout);
                        clearInterval(interval);
                        oSubLi[i].className = "active";
                        if (Math.abs(parseInt($id(oSlider).style[point])) > [(sSingleSize * i)]) {
                            interval = setInterval(setValLeft(i), time);
                            this.onmouseout = function () { if (auto) { timeout = setTimeout(autoGlide, delay); }; };
                        } else if (Math.abs(parseInt($id(oSlider).style[point])) < [(sSingleSize * i)]) {
                            interval = setInterval(setValRight(i), time);
                            this.onmouseout = function () { if (auto) { timeout = setTimeout(autoGlide, delay); }; };
                        }
                    }
                })(i)
            }
        }
    }
    glide.layerGlide(true, 'icon_num2', 'show_pic2', 427, 5, 0.1, 'left');
</script>
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

