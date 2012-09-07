<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fview_cart.aspx.cs" Inherits="fview_cart" %>
<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta   HTTP-EQUIV="Cache-Control"   CONTENT="no-cache,   must-revalidate"> 
    <meta name="description" content="索尼（Sony）在中国网站，全面介绍Sony公司的各项业务.提供丰富的产品信息，包括数码相机，摄像机，笔记本电脑，电视系列，影音产品等以及售后服务和购买服务" />
    <meta name="keywords" content="数码摄像机, 数码相机,Sony数码相机,MP3,sony mp3,记忆棒,vaio,walkman,随身听,液晶电视,Sony彩电,汽车音响,投影机,等离子屏,服务支持,sony中国 ,索尼中国 ,电影,笔记本电脑, 家用电器,影音 产品" />
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
        $().ready(function () {
            //alert('xx');
            $('.opbtndel').click(function () {
                var atr = $(this).attr('gft');
                AddToGiftCart(atr, -9999999, true);
            });
            $('.opimgm').click(function () {

                var gft = $(this).attr("gft");
                if (!getMinus(gft)) return false;
                var atr = ($('#text_box_' + gft).val());
                if (atr >= 1) {
                    AddToGiftCart(gft, -1, false);
                }
            });
            $('.opimgp').click(function () {
                var gft = $(this).attr("gft");
                var atr = ($('#text_box_' + gft).val());
                if (atr > 1) {
                    AddToGiftCart(gft, 1, false);
                }
            });
        });

        function AddToGiftCart(gft,gftc,breload) {

            $.ajax({
                url: "giftCart.aspx?GiftID=" + gft + "&GiftCount=" + gftc
            }).done(function (data) {
            }).fail(function () {  }).always(function () { if(breload)window.location.href = 'fview_cart.aspx'; });
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
            <div class="crumbs">
                当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="#">个人信息</a>
                &gt; <a href="#">社区动态</a> &gt; <a href="fselect_prod.aspx">我要兑礼</a></div>
            <div class="titExch">
                <h2>
                    兑礼流程</h2>
            </div>
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
                        <li class="n2"><span class="curr">Step 2 查看兑礼车</span></li>
                        <li class="n3"><span>Step 3 核对信息</span></li>
                        <li class="n4"><span>Step 4 成功兑换</span></li>
                    </ul>
                </div>
                <div class="tipExch">
                    本次兑换的礼品</div>
                <div class="cartList">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="GetGiftCart" TypeName="VerfiyAdmin">
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
                            <li>
                                <div class="n6">
                                    删除</div>
                            </li>
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
                                    <img class="opimgm" 
                                    gft=<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>
                                    src="images/minus.gif" alt="-"  />
                                    <input type="text" id="text_box_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>"
                                        name="count" value="<%# DataBinder.Eval(Container.DataItem, "GiftCount")%>" />
                                        <img class="opimgp" 
                                        gft=<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>
                                        src="images/plus.gif" alt="+" onclick="getPlus(<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>);" /></div>
                            </li>
                            <li>
                                <div id="price_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" class="n4">
                                    <%# DataBinder.Eval(Container.DataItem, "PerGiftData.NeedPoint")%></div>
                            </li>
                            <li>
                                <div id="total_<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" class="n5">
                                    <%# DataBinder.Eval(Container.DataItem, "TotalNeedPoint")%></div>
                            </li>
                            <li>
                                <div class="n6">
                                    <input class="opbtndel" type="button" value="删除" 

                                    Gft="<%# DataBinder.Eval(Container.DataItem, "PerGiftData.Idx")%>" /></div>
                            </li>
                        </ul>
                        <%--<ul class="clear">
                            <li>
                                <div class="n1">
                                    <img src="images/prod/m_1.jpg" width="112" height="112" alt="" /></div>
                            </li>
                            <li>
                                <div class="n2">
                                    <a href="#" target="_blank">调理化妆水调理化妆水调理化妆水</a></div>
                            </li>
                            <li>
                                <div class="n3">
                                    <img src="images/minus.gif" alt="-" onclick="getMinus(2);" /><input type="text" id="text_box_2"
                                        name="count" value="1" /><img src="images/plus.gif" alt="+" onclick="getPlus(2);" /></div>
                            </li>
                            <li>
                                <div id="price_2" class="n4">
                                    7440</div>
                            </li>
                            <li>
                                <div id="total_2" class="n5">
                                    7440</div>
                            </li>
                            <li>
                                <div class="n6">
                                    <input type="button" value="删除" /></div>
                            </li>
                        </ul>
                        <ul class="noLine clear">
                            <li>
                                <div class="n1">
                                    <img src="images/prod/m_1.jpg" width="112" height="112" alt="" /></div>
                            </li>
                            <li>
                                <div class="n2">
                                    <a href="#" target="_blank">调理化妆水调理化妆水调理化妆水</a></div>
                            </li>
                            <li>
                                <div class="n3">
                                    <img src="images/minus.gif" alt="-" onclick="getMinus(3);" /><input type="text" id="text_box_3"
                                        name="count" value="1" /><img src="images/plus.gif" alt="+" onclick="getPlus(3);" /></div>
                            </li>
                            <li>
                                <div id="price_3" class="n4">
                                    7440</div>
                            </li>
                            <li>
                                <div id="total_3" class="n5">
                                    7440</div>
                            </li>
                            <li>
                                <div class="n6">
                                    <input type="button" value="删除" /></div>
                            </li>
                        </ul>--%>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                    </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="totalCart">
                        <ul>
                            <li>
                                <div>
                                    共<span id="totalProd">1</span>个产品 总计<span id="totalPrice"></span>分积分</div>
                            </li>
                        </ul>
                    </div>
                    <div class="btnWrap clear">
                        <a href="fselect_prod.aspx">继续选择兑礼</a> 
                        <input type="button" value="下一步" class="btnNext" onclick="location.href='fcheck_info.aspx'" />
                    </div>
                </div>
            </div>
        </div>
        <uc2:footer ID="footer1" runat="server" />  
    </form>
</body>
</html>
