<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Ascx_header" %>

<div class="header">
        <div class="logo"><h1><a href="index.aspx" class="cmbtn" title="sisley PARIS 法国希思黎社区">sisley PARIS 法国希思黎社区</a></h1>
    	</div>
    </div>
    <div class="toplink">
      <ul>
        <% if(!HasLogined()){ %>
    	<li><a href="login.aspx?from=<%=fromUrl %>" >用户登录 <!--Loginbtn Loginbtn--></a></li>
    	<li><a href="register.aspx">新用户注册</a></li>
        
        <!--
        <li class="lg">使用</li>
        <li class="lg">
        <a href="mylogin.aspx?t=sina"><img src="images/icon_weibo3.jpg" alt="新浪微博" /></a>
         <a href="myLogin.aspx?t=qq"><img src="images/icon_tqq3.jpg" alt="腾讯微博" /></a> 
         <a href="myLogin.aspx?t=renren"><img src="images/icon_kaixin3.jpg" alt="开心网" /></a></li>
        <li class="lg" id="flBtn">帐号登录</li>
        -->
        <!--
        <li class="appstore"><a href="#"><img src="images/btn_appstore.jpg" alt="App Store" /></a></li>
        -->
        <%}else{ %>
        <li>欢迎进入希思黎社区，<B><%=Cmn.Cookies.Get("login_UserEmail")%></B> 
           <a  href="personalInfo.aspx"> 个人信息 </a>
            <a  href="logout.aspx"> <u>退出</u> </a>
        </li>
        <%} %>
    </ul>
    <br class="clr" />
    </div>
    <div class="topnav">
     	<div class="nav_1"><a href="sisley-academy.aspx" class="cmbtn" title="至臻学院">至臻学院</a></div>
    
    	<div class="nav_2"><a href="sisley-prestige-club.aspx" class="cmbtn"  title="<%=strVip %>" <%=strVipScript%>>至臻坊会员专享</a></div>
    	<div class="nav_3"><a href="sisley-beauty-garden.aspx" class="cmbtn" title="希粉会">希粉会</a></div>

    	<div class="nav_4"><a href="products_family.aspx" class="cmbtn" title="产品家族">产品家族</a></div>
    	<div class="nav_5"><a href="activity-events.aspx" class="cmbtn" title="活动导航">活动导航</a></div>
    	<div class="nav_6"><a href="KOL-share.aspx" class="cmbtn" title="达人分享">达人分享</a></div>
    	<div class="nav_7"><a href="trial_zone.aspx" class="cmbtn" title="试用中心">试用中心</a></div>
    	<div class="nav_8"><a href="http://www.sisley.com.cn/140000.html?from=homepage_kv1" target="_blank" class="cmbtn" title="最新资讯">最新资讯</a></div>
    	<div class="nav_9"><a href="http://www.sisley.com.cn" title="官方网上商城" target="_blank" class="cmbtn">官方网上商城</a></div>

    </div>



