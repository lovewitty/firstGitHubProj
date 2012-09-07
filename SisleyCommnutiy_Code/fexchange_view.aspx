<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fexchange_view.aspx.cs" Inherits="fexchange_view" %>

<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="索尼（Sony）在中国网站，全面介绍Sony公司的各项业务.提供丰富的产品信息，包括数码相机，摄像机，笔记本电脑，电视系列，影音产品等以及售后服务和购买服务" />
<meta name="keywords" Content="数码摄像机, 数码相机,Sony数码相机,MP3,sony mp3,记忆棒,vaio,walkman,随身听,液晶电视,Sony彩电,汽车音响,投影机,等离子屏,服务支持,sony中国 ,索尼中国 ,电影,笔记本电脑, 家用电器,影音 产品" />
<title>法国希思黎至臻坊社区 sisley PARIS | 用户注册</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript" src="js/common.js"></script>
<script type="text/javascript" src="js/easydialog.js"></script>
<script type="text/javascript">
    $().ready(function () {
        $.ajax({
            url: "GetCounterAddr.aspx?clr=clr"
        })
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrap">
 <!-- *************header Begin**********************-->    
    <uc1:header ID="header1" runat="server" />
<!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="personalInfo.aspx">个人信息</a> &gt; <a href="#">社区动态</a> &gt; <a href="fselect_prod.aspx">我要兑礼</a></div>
        <div class="titExch"><h2>兑礼流程</h2></div>
        <div class="mainExch">
        	<div class="titProd clear">
            	<div class="Sl">
                	<ul>
                    	<li>您可用积分：<span id="usrpt"><%=UserAvaPoint %></span>分</li>
                    </ul>
                </div>
            </div>
            <div class="stepExch">
                <ul class="clear">
                    <li class="n1"><span class="curr">Step 1 选择礼品</span></li>
                    <li class="n2"><span class="curr">Step 2 查看兑礼车</span></li>
                    <li class="n3"><span class="curr">Step 3 核对信息</span></li>
                    <li class="n4"><span class="curr">Step 4 成功兑换</span></li>
                </ul>
            </div>
            <div class="successExch">
            	<div class="txt n1">
                	<%--<h2>提交成功</h2>--%>
                    <p>兑礼订单号：<asp:Label ID="lblOrdNo" runat="server" Text="Label"></asp:Label></p>
                </div>
                <div class="txt n2">
                	<p>我们已将此次订单的信息发至您的邮箱：<asp:Label ID="lblMail" runat="server" Text="Label"></asp:Label></p>
                    <p>更多希思黎植物美颜奥秘，请点击 <a href="http://www.sisley.com.cn/" target="_blank">http://www.sisley.com.cn/</a></p>
                </div>
                <div class="txt n3">
                	<h3>兑礼柜台信息</h3>
                    <p>柜台所在处：<asp:Label ID="lblCounterName" runat="server" Text=""></asp:Label></p>
                    <p>柜台地址：<asp:Label ID="lblAddr" runat="server" Text=""></asp:Label></p>
                    <p>联系电话：<asp:Label ID="lblCounterPhone" runat="server" Text=""></asp:Label></p>
                </div>
            </div>
            <div class="cartList">
            	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="GetGiftCart" TypeName="VerfiyAdmin">
                        <SelectParameters>
                        <asp:QueryStringParameter Name="ordIdx" QueryStringField="Id" />
                        </SelectParameters>
                        </asp:ObjectDataSource>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                        <HeaderTemplate>
                    <div class="titCart">
                        <ul class="clear">
                            <li>
                                <div class="n1">
                                    礼品图片</div>
                            </li>
                            <li>
                                <div class="n2">
                                    礼品名称</div>
                            </li>
                            <li>
                                <div class="n3">
                                    数量</div>
                            </li>
                            <li>
                                <div class="n4">
                                    所需积分</div>
                            </li>
                            <li>
                                <div class="n5">
                                    合计积分</div>
                            </li>
                            <%--<li>
                                <div class="n6">
                                    删除</div>
                            </li>--%>
                        </ul>
                    </div>
                    <div class="details">                    
                        </HeaderTemplate>
                        <ItemTemplate>
                    
                        <ul class="clear">
                            <li>
                                <div class="n1">
                                    <img src="upload/giftImg/<%# DataBinder.Eval(Container.DataItem, "PerGiftData.GiftImgBig") %>" width="112" height="112" alt="" /></div>
                            </li>
                            <li>
                                <div class="n2">
                                    <a href="#" target="_blank"><%# DataBinder.Eval(Container.DataItem, "PerGiftData.GiftName")%><%#Eval("PerGiftData.GiftSKU")%></a></div>
                            </li>
                            <li>
                                <div class="n3">
                                    <%--<img class="opimgm" 
                                    gft=<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>
                                    src="images/minus.gif" alt="-"  />--%>
                                    <input type="text" id="text_box_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>"
                                        name="count" value="<%# DataBinder.Eval(Container.DataItem, "GiftCount")%>" readonly="readonly" />
                                        <%--<img class="opimgp" 
                                        gft=<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>
                                        src="images/plus.gif" alt="+" onclick="getPlus(<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>);" />--%>
                                        </div>
                            </li>
                            <li>
                                <div id="price_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" class="n4">
                                    <%# DataBinder.Eval(Container.DataItem, "PerGiftData.NeedPoint")%></div>
                            </li>
                            <li>
                                <div id="total_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" class="n5">
                                    <%# DataBinder.Eval(Container.DataItem, "TotalNeedPoint")%></div>
                            </li>
                            <%--<li>
                                <div class="n6">
                                    <input class="opbtndel" type="button" value="删除" 

                                    Gft="<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" /></div>
                            </li>--%>
                        </ul>                                                
                        </ItemTemplate>
                        <FooterTemplate>
                    </div>
                        </FooterTemplate>
                    </asp:Repeater>
                <div class="totalCart">
                	<ul>
                    	<li><div>共<span id="totalProd">1</span>个产品 总计<span id="totalPrice"></span>分积分</div></li>
                    </ul>
                </div>
                <%--<div class="btnSucc clear">
                	<a href="#" class="n1" onclick="javascript:window.print();">打印定单</a>
               
                 
                </div>--%>
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

    </form>
</body>
</html>

