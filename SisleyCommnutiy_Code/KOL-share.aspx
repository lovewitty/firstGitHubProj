<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KOL-share.aspx.cs" Inherits="KOL_share" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register src="Ascx/productTry3List.ascx" tagname="productTry3List" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="description" content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
    <meta name="keywords" content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
    <title>sisley 法国希思黎S社区 | 达人分享</title>
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/page.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
    <link href="css/skin3.css" rel="stylesheet" type="text/css" />
    <link href="css/easydialog.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script src="js/mySetCookies.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.jcarousel.pack.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
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

      


        

    </script>
</head>
<body>
    <form runat="server" id="myForm1">
    <div class="wrap">
        <!-- *************header Begin**********************-->
        <uc1:header ID="header1" runat="server" />
        <!-- ***********header End***************************-->
        <div class="content" style="padding-top: 7px;">
            <div class="crumbs">
                当前位置：<a href="index.aspx">首页</a>
                <img src="images/arrow_01.gif" align="absmiddle" alt="" />
                <a href="KOL-share.aspx">达人分享</a></div>
            <div class="KOLshare">
                <div class="KOLshare_l">
                    <div class="box_c">
                        <div class="title_pic">
                            <img src="images/title_calendar.jpg" alt="calendar" /></div>
                        <div class="calendar">
                            <div class="date">
                                <div class="year">
                                    2012.08</div>
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
                                        <p>
                                            <a href="#">
                                                <img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                                        <p>
                                            美肌专家</p>
                                    </li>                                
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="btn_publ">

                        <a href="Daren-express-1.aspx" onclick="return doSendShare()">
                            <img src="images/btn_publish.jpg" alt="发表分享" /></a></div>
                    <div class="box_c">
                        <div class="title_pic">
                            <img src="images/title_protest.jpg" alt="产品测评" /></div>
                        <div class="protest">
                        <uc3:productTry3List ID="productTry3List2" runat="server" />

                       <%--     <ul>
                                <li style="margin-bottom: 12px;"><a href="#">
                                    <img src="images/aaa1.jpg" alt="" /></a>
                                    <p>
                                        <span>24k24k</span><br />
                                        年初才用的小金瓶，不到个把月就剩不多了，害的本宫怨自个儿脸实在太大</p>
                                    <br class="clr" />
                                </li>
                                <li><a href="#">
                                    <img src="images/bbb1.jpg" alt="" /></a>
                                    <p>
                                        <span>玫瑰mm</span><br />
                                        冬天是个需要投资面霜的季节。 我发现身边的很多朋友都.....</p>
                                    <br class="clr" />
                                </li>
                                <li><a href="#">
                                    <img src="images/ccc1.jpg" alt="" /></a>
                                    <p>
                                        <span>久久妹妹</span><br />
                                        曾参加使用sisley的致臻夜间修复精华露，感觉很棒哦~ 所以当Sisley推出这款紧致精华时</p>
                                    <br class="clr" />
                                </li>
                            </ul>--%>
                        </div>
                        <div class="more1">
                            <a href="#">查看更多&gt;&gt;</a></div>
                    </div>
                    <div class="box_c">
                        <div class="title_pic">
                            <img src="images/title_newtrail.jpg" alt="最新试用" /></div>
                        <div class="newtrail">
                            <ul>
                                <li><a href="#">
                                    <img src="images/pic_100_100.jpg" alt="" /></a>
                                    <p>
                                        <span>焕白亮泽保湿乳</span><br />
                                        植物洁面摩丝，摩丝质地，清洁卸妆一步到位<br />
                                        <span style="color: #a96397; font-size: 12px;">人气：235 剩余：20</span></p>
                                    <p style="padding-top: 0;">
                                        <a href="#">
                                            <img src="images/btn_trail4.jpg" alt="申请试用" class="btn_trail1" /></a></p>
                                    <br class="clr" />
                                </li>
                            </ul>
                        </div>
                        <div class="more1">
                            <a href="#">查看更多&gt;&gt;</a></div>
                    </div>
                </div>
                <div class="KOLshare_r">
                    <div class="box_d">
                        <div class="title_pic">
                            <img src="images/title_life.jpg" alt="至臻生活" /></div>
                        <div class="zzlife">
                            <asp:Literal ID="ltlAritcleHome1" runat="server">
                    	<div class="zzlife_l"><a href="#"><img src="images/pic_288_204.jpg" width="288" height="204" alt="" /></a></div>
                        <div class="zzlife_m">
                        	<p class="m1">浪漫的金色海岸线</p>
                        	<p class="m2">浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线浪漫的金色海岸线</p>
                             <p style="text-align:right; padding:10px 0 0 0;"><a href="#"><img src="images/btn_more.gif" alt="查看更多" class="btn_more1" /></a></p>
                        </div>
                      
                            </asp:Literal>
                            <div class="zzlife_r">
                                <p class="r1">
                                    下期预告</p>
                                <p>
                                    <asp:Literal ID="ltlKol_Share" runat="server">
                            <a href="#"><img src="images/pic_108_147.jpg" width="108" height="157" alt="" /></a>
                                    </asp:Literal>
                                </p>
                                <!--<p><a href="#"><img src="images/btn_more.gif" alt="查看更多" class="btn_more1" /></a></p>-->
                                <!-- <p> <a href="#"><img src="images/btn_more.gif" alt="查看更多" class="btn_more1" /></a></p> -->
                            </div>
                            <div class="clr">
                            </div>
                        </div>
                    </div>
                    <div class="box_b">
                        <div class="title_txt">
                            达人分享</div>
                        <div class="darenshare">
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <dl>
                                                <dt><a href='<%# Cmn.SisleyHelper.GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>'>
                                                    <img src="upload/userHearderImg/<%#Eval("headphoto")%>" width="136" height="136"
                                                        alt="" />
                                                </a></dt>
                                                <dd>
                                                    <p class="s1">
                                                        <a href='<%#Cmn.SisleyHelper.GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>'>
                                                            <%#Eval("Title")%></a></p>
                                                    <p class="s2">
                                                        发表于<%#Cmn.Date.ToDateTimeStr(DateTime.Parse(Eval("CreateDate").ToString()))%></p>
                                                    <p class="s3">
                                                        <%#Cmn.Str.GetNoHTML(Eval("Content").ToString(),200,true)%></p>
                                                    <ul class="s4">
                                                        <li class="o1">已有<span><%#GetReadCount(Eval("Idx").ToString())%></span>人阅读过本人</li>
                                                        <li class="o2">目前<span><%#GetReplyCount(Eval("Idx").ToString())%></span>人回复</li>
                                                        <li class="o3">分享至 <a href="#">
                                                            <img src="images/icon_weibo2.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#">
                                                                <img src="images/icon_renren2.jpg" alt="人人网" align="absmiddle" /></a> <a href="#">
                                                                    <img src="images/icon_kaixin2.jpg" alt="开心网" align="absmiddle" /></a>
                                                        </li>
                                                        <br class="clr" />
                                                    </ul>
                                                </dd>
                                            </dl>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- <br class="clr" /> -->
                            </ul>
                            <div class="darenpage">
                                当前第<asp:Label ID="lblCurrentPage" runat="server" ForeColor="Maroon"></asp:Label>页/总共
                                <asp:Label ID="lblTotalPage" runat="server" ForeColor="#993333"></asp:Label>页
                                <asp:LinkButton Visible="false" ID="LinkButtonFirst" runat="server" Font-Bold="True"
                                    OnClick="LinkButtonFirst_Click">首页</asp:LinkButton>
                                <asp:LinkButton Visible="false" ID="LinkButtonPrev" runat="server" Font-Bold="True"
                                    OnClick="LinkButtonPrev_Click">上页</asp:LinkButton>
                                <asp:LinkButton ID="LinkButtonNext" runat="server" Font-Bold="True" Visible="false"
                                    OnClick="LinkButtonNext_Click">下页</asp:LinkButton><asp:LinkButton ID="LinkButtonLast"
                                        runat="server" Font-Bold="True" Visible="false" OnClick="LinkButtonLast_Click">末页</asp:LinkButton><label>跳转到第</label><asp:DropDownList
                                            ID="ddlPageCount" AutoPostBack="true" OnTextChanged="PageIndex" runat="server">
                                        </asp:DropDownList>
                                页
                            </div>
                        </div>
                    </div>
                    <div class="clr">
                    </div>
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



        </script>
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
        <div id="newsBox">
            <div class="close2">
                <a href="javascript:;" onclick="easyDialog.close();">
                    <img src="images/icon_close2.gif" alt="关闭" /></a></div>
            <div class="title2">
                最新动态</div>
            <div class="box_a">
                <ul>
                    <li>
                        <p>
                            <img src="images/eventpic_1.jpg" alt="" /></p>
                        <p>
                            <a href="#">
                                <img src="images/btn_apply.gif" alt="立即申请" /></a></p>
                    </li>
                    <li>
                        <p>
                            <img src="images/eventpic_2.jpg" alt="" /></p>
                        <p>
                            <a href="#">
                                <img src="images/btn_look.gif" alt="立即查看" /></a></p>
                    </li>
                    <li>
                        <p>
                            <img src="images/eventpic_1.jpg" alt="" /></p>
                        <p>
                            <a href="#">
                                <img src="images/btn_apply.gif" alt="立即申请" /></a></p>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
