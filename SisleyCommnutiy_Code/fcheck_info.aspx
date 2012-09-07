<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fcheck_info.aspx.cs" Inherits="fcheck_info" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="索尼（Sony）在中国网站，全面介绍Sony公司的各项业务.提供丰富的产品信息，包括数码相机，摄像机，笔记本电脑，电视系列，影音产品等以及售后服务和购买服务" />
    <meta name="keywords" content="数码摄像机, 数码相机,Sony数码相机,MP3,sony mp3,记忆棒,vaio,walkman,随身听,液晶电视,Sony彩电,汽车音响,投影机,等离子屏,服务支持,sony中国 ,索尼中国 ,电影,笔记本电脑, 家用电器,影音 产品" />
    <title>法国希思黎至臻坊社区 sisley PARIS | 用户注册</title>
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/exchange.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
    <script type="text/javascript" src="js/common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.divselect("#dvCity", "#inputCity");

            $("#dvCity ul li a").click(function () {
                var selectedcity = $("#dvCity cite").text();
                if (selectedcity == "其他") {
                    $("#dvCounter").hide();
                    $("#inputOther").show();
                } else {
                    $("#dvCounter").show();
                    $("#inputOther").hide();
                }

                $("#dvCounter cite").html("--请选择柜台--");
                $('#counterIdx').val('-1');
                $("#inputCounter").val($("#dvCounter cite").html());
                $("#dvCounter .deta ul").html("");
                //                                $.getJSON("json/city.js?=" + Math.random(), function (data_c) {
                
                $.getJSON("json/GetCounterAddr.aspx?city=" + encodeURIComponent(selectedcity), function (data_c) {
                    
                    for (var i = 0; i < data_c.city.length; i++) {
                        if (data_c.city[i].name == selectedcity) {
                            //alert("match");
                            for (var j = 0; j < data_c.city[i].address.length; j++) {
                                $("#dvCounter .deta ul").append("<li><a Idx=" + "'" + data_c.city[i].address[j].Idx + "'" + " href='javascript:;'>" + data_c.city[i].address[j].name + "</a></li>");
                            }
                        }
                    }
                });
                $("#dvCounter cite").click(function () {
                    $("#dvCounter .deta").slideDown("fast");
                    $("#dvCounter .deta ul li a").click(function () {
                        var _result = $(this).text();
                        $("#dvCounter cite").html(_result);
                        $("#dvCounter .deta").slideUp("fast");
                        $("#inputCounter").val(_result);
                        var _idx = $(this).attr('Idx');
                        $('#counterIdx').val(_idx);
                    })
                });
            });
            $(document).mouseup(function (event) {
                if ($(event.target).parents(".deta").length == 0) {
                    $(".deta").hide();
                }
            })
        });
    </script>
    <script type="text/javascript" src="js/easydialog.js"></script>
    <script type="text/javascript">
        
        function submitOrd() 
        {        
                var c = $("#dvCity cite").text();
                var ct = $("#inputCounter").val();
                
                if (c == "" || (ct == ""||ct=="--请选择柜台--")) {
                    alert('请选择柜台所在城市'); return false;
                }
                var upt = $('#usrpt').text();
                var ppt = $('#totalPrice').text();
                var upt = upt - ppt;
                if (upt < 0) {
                    alert('您的积分不足以兑换全部礼品!');return false;
                }
                $('#form1').submit();
        }

        $().ready(function () {
     
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

        function AddToGiftCart(gft, gftc, breload) {

            $.ajax({
                url: "giftCart.aspx?GiftID=" + gft + "&GiftCount=" + gftc
            }).done(function (data) {
            }).fail(function () { }).always(function () { if (breload) window.location.href = 'fview_cart.aspx'; });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" value="-1" name="counterIdx" id="counterIdx" runat="server"/>
    <div class="wrap">
        <!-- *************header Begin**********************-->
        <uc1:header ID="header1" runat="server" />
        <!-- ***********header End***************************-->
        <div class="content">
            <div class="crumbs">
                当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="personalInfo.aspx">
                    个人信息</a> &gt; <a href="#">社区动态</a> &gt; <a href="fselect_prod.aspx">我要兑礼</a></div>
            <div class="titExch">
                <h2>
                    兑礼流程</h2>
            </div>
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
                                    <a href="#" target="_blank"><%# DataBinder.Eval(Container.DataItem, "PerGiftData.GiftName")%></a></div>
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
                </div>
                <div class="counterList">
                    <h2>
                        请选择您所在的城市对应的柜台兑换礼品</h2>
                    <div class="details clear">
                        <div class="Sl">
                            <div id="dvCity">
                                <cite>--请选择城市--</cite>
                                <div class="deta">
                                    <ul class="clear">
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="VerfiyAdmin" SelectMethod="GetCounterCity">
                                        </asp:ObjectDataSource>
                                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource2">
                                            <ItemTemplate>
                                            <li><a href="javascript:;"><%# DataBinder.Eval(Container.DataItem, "CounterCity")%></a></li>
                                        </ItemTemplate>
                                        </asp:Repeater>                                        
                                    </ul>
                                    <div class="other">
                                        <ul>
                                            <li><a href="javascript:;" selectid="其他">其他</a></li></ul>
                                    </div>
                                </div>
                            </div>
                            <input name="city" type="hidden" value="北京" id="inputCity" />
                        </div>
                        <div class="Sr">
                            <div id="dvCounter">
                                <cite>--请选择柜台--</cite>
                                <div class="deta">
                                    <ul class="clear">
                                    </ul>
                                </div>
                            </div>
                            <input name="counter" type="hidden" value="" id="inputCounter" />
                            <input name="other" type="text" value="" id="inputOther" />
                        </div>
                    </div>
                </div>
                <div class="personal">
                    <h2>
                        您的信息</h2>
                    <div class="txt">
                        <p>
                            姓名：<asp:Label ID="lblRealName" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            手机号码：<asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            电子邮箱：<asp:Label ID="lblMail" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            所在省份：<asp:Label ID="lblProv" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            所在城市：<asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            地址：<asp:Label ID="lblAddr" runat="server" Text="Label"></asp:Label></p>
                        <p>
                            邮编：<asp:Label ID="lblPostCode" runat="server" Text="Label"></asp:Label></p>
                    </div>
                </div>
                <div class="btnCheck clear">
                    <a href="javascript:history.go(-1);">上一步</a> 
                    <input type="button" value="提交订单" onclick="submitOrd();"  class="btnSubmit"/>
                    <%--onclick="location.href='fexchange_success.aspx'"--%>
                  <%--  <a id="submitOrd" onclick="submitOrd();" href="javascript:void();">
                    <img src="images/btn_next01.gif" alt="下一步" />
                    </a> <!--提交订单-->--%>
                     
                    
                </div>
            </div>
        </div>
        <uc2:footer ID="footer1" runat="server" />
    </div>

    <div id="LoginBox">
        <div class="close_box">
            <a href="javascript:;" onclick="easyDialog.close();">
                <img src="images/icon_close.gif" alt="关闭" /></a></div>
        <ul class="login_l">
            <li>
                <label for="textfield">
                    会员名：</label>
                <input type="text" name="textfield" id="textfield" class="input_login" />
            </li>
            <li>
                <label for="textfield2">
                    密码：</label>
                <input type="password" name="textfield2" id="textfield2" class="input_login" />
            </li>
            <li>
                <label for="textfield3">
                    验证码：</label>
                <input type="text" name="textfield3" id="textfield3" class="input_login2" />
            </li>
            <li class="ver">
                <img src="images/code.jpg" />
                <span>看不清？<a href="#">换一张</a></span> </li>
            <li class="ver">
                <input name="" type="checkbox" value="" />
                记住登录状态&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">忘记密码?</a></li>
            <li class="ver"><a href="#">
                <img src="images/btn_login.jpg" alt="登录" /></a></li>
        </ul>
        <ul class="login_r">
            <li>您是第一次进入希思黎官方网站？</li>
            <li><a href="register.aspx">
                <img src="images/btn_regnow.jpg" alt="立即注册" /></a></li>
            <li>使用其他网站帐号登录：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a>
                <a href="#">
                    <img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#">
                        <img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a></li>
        </ul>
    </div>
    </form>
</body>
</html>
