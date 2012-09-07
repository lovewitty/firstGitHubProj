<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fprod_detail.aspx.cs" Inherits="fprod_detail" %>
<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    function AddToGiftCart(gft) {

        $.ajax({
            url: "giftCart.aspx?GiftID=" + gft
        }).done(function (data) {
        }).fail(function () { alert('fail'); }).always(function () { window.location.href = 'fview_cart.aspx'; });
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
    <!-- *************header Begin**********************-->    
    <uc1:header ID="header1" runat="server" />
<!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <a href="fselect_prod.aspx">积分兑换</a> &gt; <a href="#">礼品详细信息</a> </div>
        <div class="titExch"><h2>兑礼流程</h2></div>
        <div class="mainExch">
        	<div class="titProd clear">
            	<div class="Sl">
                	<ul>
                    	<li>您可用积分：<span><%=UserAvaPoint %></span>分</li>
                    </ul>
                </div>
            </div>
            <div class="stepExch">
                <ul class="clear">
                    <li class="n1"><span class="curr">Step 1 选择礼品</span></li>
                    <li class="n2"><span>Step 2 查看兑礼车</span></li>
                    <li class="n3"><span>Step 3 核对信息</span></li>
                    <li class="n4"><span>Step 4 成功兑换</span></li>
                </ul>
            </div>
            <div class="tipExch">本次兑换的礼品</div>
            <div class="proDeta">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"  SelectMethod="GetGiftByIdx" TypeName="VerfiyAdmin">
                <SelectParameters>
                <asp:QueryStringParameter QueryStringField="Idx" DefaultValue="0" Name="gftId" />
                </SelectParameters>
                </asp:ObjectDataSource>
                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
                        <HeaderTemplate>
                        <div class="details clear">
                        </HeaderTemplate>
                        <ItemTemplate>
                	<div class="Sl">
                    	<div class="pic"><img src="upload/giftImg/<%# DataBinder.Eval(Container.DataItem, "GiftImgSmall") %>" alt="" /></div>
                    </div>
                    <div class="Sr">
                        <div class="txt">
                            <p><strong>【产品】：</strong><%# DataBinder.Eval(Container.DataItem, "GiftName")%><%#Eval("GiftSKU")%><br />
                            <strong>【规格】：</strong><%# DataBinder.Eval(Container.DataItem, "SkuProperty")%> <br />
                            <strong>【介绍】：</strong><%# DataBinder.Eval(Container.DataItem, "GiftDescription")%> 
                            <p><strong>【所需积分】：</strong><%# DataBinder.Eval(Container.DataItem, "NeedPoint")%></p>
                            
                        </div>
                    </div>   
                    
                </div>
                
                <div class="btnWrap clear">
                	<div class="btnLink">
                    	<a href="javascript:window.history.go(-1);" class="n1">返回</a>&nbsp;<a href="javascript:void();" onclick='AddToGiftCart(<%# DataBinder.Eval(Container.DataItem, "Idx")%>)' class="n2">放进兑礼车</a>
                    </div>
                </div> </ItemTemplate>
                        <FooterTemplate>        </FooterTemplate>
                    </asp:Repeater>        
            </div>

        </div>
    </div>
<uc2:footer ID="footer1" runat="server" /> 
</div>
    </form>
</body>
</html>
