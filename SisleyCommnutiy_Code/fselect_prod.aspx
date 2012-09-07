<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fselect_prod.aspx.cs" Inherits="fselect_prod" %>
<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>

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
    <script type="text/javascript" src="js/easydialog.js"></script>
    <script type="text/javascript">

       
        var JQRY = function () {
            return document.getElementById(arguments[0]);
        };

//        JQRY('Loginbtn').onclick = function () {
//            easyDialog.open({
//                container: 'LoginBox',
//                overlay: true,
//                fixed: false
//            });
//        };
        function GoPage() {
            var pgIdx=$('#txtPg').val();
            if (isNaN(pgIdx)) return false;
            if (pgIdx <= 0) pgIdx = 1;
            $('#PG').val(pgIdx);
            $('#form1').submit();
        }

        function AddToGiftCart(gft) {

            $.ajax({
                url: "giftCart.aspx?GiftID=" + gft
            }).done(function (data) {
                //alert(data + ' ok '+gft);
            }).fail(function (data) {
                //alert(data + ' fail' + gft);
            }).always(function () { window.location.href = 'fview_cart.aspx'; });
        }


        $().ready(function () {
            $('.apg').attr('href', 'javascript:void();');
            $('.apg').click(function () {
                $('#PG').val($(this).attr('PG'));
                $('#form1').submit();
            });

            $('#btnSearch').click(function () {
                $('#PG').val('1');
                $('#oparg').val($('#ByGiftName').val());
                $('#optype').val("ByGiftName");
                $('#form1').submit();
            });
            $('#ByAvaPt').click(function () {
                $('#PG').val('1');
                $('#oparg').val("");
                $('#optype').val("ByAvaPt");
                $('#form1').submit();
            });
            $('#ByPt').click(function () {
                $('.curr').click();
                $('#form1').submit();
            });
            $('.aser').each(function () {
                if ($(this).text() == $('#oparg').val()) {

                    $(this).attr('background-image', 'images/category_abg.gif');
                }
            });
            $('.curr').click(function () { $('#oparg').val(""); $('#optype').val(""); });
            $('.aser').click(function () {
                $('#PG').val('1');
                $('#oparg').val($(this).text());
                $('#optype').val("BySer");
                $('#form1').submit();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="optype" name="optype" value="" runat="server"/>
    <input type="hidden" id="oparg" name="oparg" value="" runat="server"/>
    <input type="hidden" id="PG" name="PG" value="1" runat="server" />
    <div class="wrap">
         <!-- *************header Begin**********************-->    
    <uc1:header ID="header1" runat="server" />
<!-- ***********header End***************************-->
        <div class="content">
            <div class="crumbs">
                当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="personalInfo.aspx">
                    个人信息</a> &gt; <a href="#">社区动态</a> &gt; <a href="#">我要兑礼</a></div>
            <div class="titExch">
                <h2>
                    兑礼流程</h2>
            </div>
            <div class="mainExch">
                <div class="titProd clear">
                    <div class="Sl">
                        <ul>
                            <li>您可用积分：<span><%=UserAvaPoint %></span>分</li>
                            <li><a href="javascript:void();" id='ByPt'>按积分值查看</a></li>
                            <li><a href="javascript:void();">在线兑礼示范</a></li>
                            <li><a href="javascript:void();" id='ByAvaPt'>可用积分兑换</a></li>
                        </ul>
                    </div>
                    <div class="Sr">
                        <ul>
                            <li>产品名称：</li>
                            <li>
                                <input type="text" value="" class="keyWord" runat="server" name="ByGiftName" id="ByGiftName" /></li>
                            <li>
                                <input type="button" value="搜索" class="btnSearch" id="btnSearch" /></li>
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
                <div class="prodList clear">
                    <div class="Sl">
                        <ul>
                            <li><a href="fselect_prod.aspx" class="curr">全部礼品</a></li>
                            <li><a href="#" class="aser">护肤系列</a></li>
                            <li><a href="#" class="aser">彩妆系列</a></li>
                            <li class="last"><a href="#" class="aser">香水系列</a></li>
                        </ul>
                    </div>
                    <div class="Sr">
                        <div class="deta">

                            <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <ul class="clear">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    <li>
                                        <div class="pic">
                                        <a href="#" target="_blank"><img src="upload/giftImg/<%#Eval("GiftImgSmall")%>" alt="<%#Eval("GiftName")%>" /></a>
                                    </div>
                                        <h3>所需积分：<span><%#Eval("NeedPoint")%></span></h3>
                                        <h4><a href="#" target="_blank"><%#Eval("GiftName")%><%#Eval("GiftSKU")%></a></h4>
                                        <div class="btn clear">
                                            <a href="fprod_detail.aspx?Idx=<%#Eval("Idx") %>" target="_blank" class="n1">详细</a>
                                            <a href="javascript:void();" class="n2" onclick="AddToGiftCart(<%#Eval("Idx") %>)">放进兑礼车</a>
                                        </div>
                                    </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                            <%--<ul class="clear">
                                
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank"><img src="images/prod/1.jpg" alt="" /></a>
                                    </div>
                                    <h3>所需积分：<span>6720</span></h3>
                                    <h4><a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a>
                                        <a href="fview_cart.html" class="n2">放进兑礼车</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/2.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/3.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/4.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/5.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/6.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/7.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/8.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                                <li>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="images/prod/9.jpg" alt="" /></a></div>
                                    <h3>
                                        所需积分：<span>6720</span></h3>
                                    <h4>
                                        <a href="#" target="_blank">植物平衡化妆水</a></h4>
                                    <div class="btn clear">
                                        <a href="#" target="_blank" class="n1">详细</a><a href="fview_cart.html" class="n2">放进兑礼车</a></div>
                                </li>
                            </ul>--%>
                        </div>
                        <div class="pageNum">
                            <ul>
                                <li>当前第<%=PageIdx %>页/总共<%=PageTotalCount%>页</li><li><a class="apg" href="" PG="1">首页</a></li><li><a href="" class="apg" PG="<%=(PageIdx-1)<=1?1:PageIdx-1 %>">上一页</a>
                                </li><li><a class="apg" PG="<%=(PageIdx+1)>=PageTotalCount?PageTotalCount:PageIdx+1 %>">
                                    下一页</a></li><li><a class="apg" PG="<%=PageTotalCount%>">末页</a></li><li>
                                        <label>
                                            跳转到</label><input type="text" value="" class="nums" id='txtPg' />
                                            <input type="button" value="Go" class="btnGo" onclick="GoPage();" />
                                        
                                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        		 <uc2:footer ID="footer1" runat="server" />   
    </form>
</body>
</html>
