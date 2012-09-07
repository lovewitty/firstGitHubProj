<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personalInfo.aspx.cs" Inherits="personalInfo" %>

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
<script type="text/javascript" src="js/common.js"></script>
<script type="text/javascript">

    function upgradeShow() {
        $(".dvUpgrade").show();
        var xx = (($(window).width() - $(".dvUpgrade").width()) / 2) + $(document).scrollLeft() + 'px';
        $(".dvUpgrade").css("top", 440);
        $(".dvUpgrade").css("left", xx);
        return false;
    }
    $(document).ready(function () {
        showUp();
        $(".btnUpgrade").click(function () {
            upgradeShow();
        });
        $(".btnClose").click(function () {
            $(".dvUpgrade").hide();
            return false;
        });
    });
</script>
    <style type="text/css">
        #Text5
        {
            width: 315px;
        }
        #Text6
        {
            width: 136px;
        }
    </style>
</head>

<body>
<form id="myForm" runat="server">
<div class="wrap">
<div class="flower" style="bottom:180px;"><img src="images/flower.jpg" /></div>
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server">
    </uc1:header>
    <!-- ***********header End***************************-->
<%    
    if (string.IsNullOrEmpty(Cmn.Cookies.Get("login_UserIdx")))
    {
        Response.Redirect("login.aspx?from=" + Request.Url.ToString());
    }
    int uIdx = int.Parse(Cmn.Cookies.Get("login_UserIdx"));
    DBEntity.Tab_UserCommunity ent = new DBEntity.Tab_UserCommunity();
    ent = ent.Get(uIdx);

    string strVip = "普通会员  <input type='button' value='升级VIP' class='btnUpgrade' />";
    string strPosion = "希思黎俱乐部";
    string strTopClass = "subTit commTit";
    if (ent.VipBool == "yes")
    {
        strVip = "VIP 会员";
        strPosion = "至臻坊会员专享";
        strTopClass = "subTit vipTit";
    }

    string strSiteMsgNumber = "6";
    
 %>
    <div class="content">
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <%=strPosion%> &gt; <a href="personalInfo.aspx">个人信息</a></div>
        <div class="titExch titPersonal"><h2>用户个人信息</h2></div>
        <div class="mainExch infoPad">
            <div class="persTit">
            	<ul>
                	<li class="first"><a href="#">基本信息</a></li>
                    <li><a href="personalfootmark.aspx">希享足迹</a></li>
                </ul>
            </div>
            <div class="persList">
            	<div class="<%=strTopClass %>"><a href="message.aspx">站内信<em>(<%=strSiteMsgNumber %>)</em></a><span>普通会员</span></div>
                <div class="details clear">
                    <div class="Sl">
                        <div class="member">
                            <ul>
                                <li>会员级别：<%=strVip%></li>
                <li> 电子邮箱：<%=ent.UserEmail %></li>
                                <li>姓　　名：<%=ent.RealName %></li>
                                <li>手机号码：<%=ent.MobilePhone %></li>
                                <li>所在省份：<%=ent.Province %></li>
                                <li>所在城市：<%=ent.City %></li> 
                                  <li>地　　址：<%=ent.Address%></li> 
                                  <li>邮　　编：<%=ent.ZipCode%></li> 



                            </ul>
                            <div class="btnMember"><a href="personalInfoEdit.aspx">修改基本信息</a></div>
                        </div>
                        
                    </div>
                    <div class="Sr">
                    	<div class="picWrap">
                        	<div class="pic">
								<img width="140px" height="190px" src="upload/userHearderImg/<%=ent.HeadPhoto %>" alt="<%=ent.Idx %>" />
                        	</div>
                        </div>
                        <div class="btnShow"><a href="###">更改头像</a></div>
                        <div class="showUp">  <!--class="showUp"-->
                        	<asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<div class="tips">图片尺寸大于150x200像素将被自动等比例缩减。</div>
                            <asp:Button ID="btnUpload"  runat="server"  class="btnUp"  Text="上传图片" 
                                onclick="btnUpload_Click" />
&nbsp;</div>
                    </div>
                </div>
                <div class="state">
                    <div class="titState">希享状态</div>
                    <ul>
                        <li>我的积分：1000</li>
                        <li>我的勋章：<span><img src="images/medal_1.jpg" alt="" align="absmiddle" />x2</span><span><img src="images/medal_2.jpg" alt="" align="absmiddle" />x3</span><span><img src="images/medal_3.jpg" alt="" align="absmiddle" />x5</span></li>
                        <li>我的学院进度：30%</li>
                        <li>我的考试成绩：100</li>
                    </ul>
                    
                    <% if (ent.VipBool == "yes")
                       { %>
                    <div class="btnState clear"><a href="fselect_prod.aspx" class="n3">我要兑礼</a><a href="fexchange_record.aspx" class="n4">查看积分兑礼记录</a><a href="medal_rule.aspx" class="n1">勋章机制</a><a href="#" class="n2">查看勋章兑礼记录</a></div>
                        <%}
                       else
                       { %>
                    <div class="btnState"><a href="rule.aspx" class="n1">勋章机制</a><a href="#" class="n2">查看勋章兑礼记录</a></div>
               <%} %>
                </div>
            </div>

        </div>
    </div>
    <uc2:footer ID="footer1" runat="server" />
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

<div class="dvUpgrade">
	<div class="upBg"></div>
    <div class="details">
    	<a href="###" title="关闭" class="btnClose">关闭</a>
        <ul>
        	<li><label for="uCard">会员卡号</label><input type="text" name="uCard" class="inputs" id="uCard" runat="server"/></li>
            <li><label for="uMobile">手机号码</label><input type="text" name="uMobile" class="inputs" id="uMobile"  runat="server"/></li>
            <li><label></label>
                <asp:Button ID="btnChekVipCardNo" runat="server" Text="立即提交" class="btnSubmit" 
                    onclick="btnChekVipCardNo_Click"  /></li>
        </ul>
    </div>
</div>

</form>


</body>
</html>
