<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="activity_detail.aspx.cs" Inherits="activity_detail" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 活动导航</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
<link href="css/skin3.css" rel="stylesheet" type="text/css" />
<link href="css/easydialog.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.jcarousel.pack.js"></script>
<script type="text/javascript" src="js/main.js"></script>
    <script src="js/jsStringFormat.js" type="text/javascript"></script>
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

    function goApply(aId_uId) {
        //alert(aId_uId);
        var arrObj = aId_uId.split('|');
        var activityId = arrObj[0];
        if (uIdx == "") {
            alert("请登录后再申请");
            return false;
        }

        $.post("data2flash/AjaxSubmit.aspx", { rep: "applyActivity", activityId: activityId, uIdx: uIdx },
   function (data) {
       alert(data);
       //alert("已经提出申请，请等待审核！");
   });


//        $.post("data2flash/AjaxSubmit.aspx"
//            , {     rep: "applyActivity"
//                    , activityId: activityId
//                    , uIdx: uIdx 
//               }
//            ,   function (data) {
//               alert("Data Loaded: " + data);
//           });


        //=========
//        $.ajax(
//            {
//                type: "POST",
//                url: "data2flash/AjaxSubmit.aspx",
//                data: String.format("rep=applyActivity&activityId={0}&uIdx={1}", activityId, uIdx),
//                success: function (msg) {
//                    alert(msg);
//                    //location.href = "rLogin.aspx?t=sina";
//                }
//            });      
    }
</script>
</head>

<body>
<div class="wrap">
<form id="myForm" runat="server">
    <!-- *************header Begin**********************-->
    <uc1:header id="header1" runat="server">
</uc1:header>
    <!-- ***********header End***************************-->
    
    <div class="content" style="padding-top:7px;">
        <div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="activity-events.aspx">活动导航</a></div>
  		<div class="KOLshare">
   	    <div class="KOLshare_l">
        	<div class="box_c">
            	<div class="title_pic" style="margin-top:3px;"><img src="images/title_calendar.jpg" alt="calendar" /></div>
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
                <div class="btn_gethelp"><a href="javascript:;" id="gethelp"><img src="images/btn_gethelp.jpg" alt="寻求帮助" /></a>
                	<div id="helpBox">
                        <div class="close_box2"><a href="javascript:;" id="helpclose"><img src="images/icon_close2.gif" alt="关闭" /></a></div>
                      <div class="askcontent"><textarea runat="server" id="txtQuestion" name="aa" cols="5" rows="8" class="input_help" text=""></textarea>
                      </div>
                        <div class="btn_apply">
                            <asp:LinkButton ID="lnkAskQuestion" runat="server" 
                                onclick="lnkAskQuestion_Click"><img src="images/btn_apply.jpg" alt="立即申请" /></asp:LinkButton>
                      
                        </div>
                    </div>
                </div>
                
            </div>
            <div class="box_c">
           	  <div class="title_pic"><img src="images/title_newevent.jpg" alt="最新活动" /></div>
           	  <div class="newevent">
                	<ul>
                        <asp:Literal ID="ltlActivitesNewest" runat="server">
                    	<li style="margin-bottom:12px;"> <a href="#"><img src="images/pic_85_85.jpg" alt="" /></a>
                            <p><span>打造柔焦底妆</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位</p>
							<br class="clr" />
                      </li>
                   	  <li> <a href="#"><img src="images/pic_85_85.jpg" alt="" /></a>
                        <p><span>打造柔焦底妆</span><br />
植物洁面摩丝，摩丝质地，清洁卸妆一步到位</p>
							<br class="clr" />
                      </li>
                      </asp:Literal>
                    </ul>
                </div>
                
            </div>
   	    </div>
        	<div class="KOLshare_r">
                <asp:Literal ID="ltlActivity_detail" runat="server">
            	<div class="activity_detail">

                	<div class="icon_end"><img src="images/icon_end.jpg" alt="活动已结束" /></div>
            	  	<div class="activity_detail_title">寻找黑玫瑰</div>
                  <div class="activity_detail_con">活动机制
                    </div>
                    <div class="activity_detail_txt">1.会员可在任何活动入口参与此活动，活动形式为&quot;对对碰&quot;，5分钟内完成游戏即可获得活动奖品<br />
                      2.参与活动并完成即可获得限定黑玫瑰勋章，完成活动抽奖即有机会获得特别礼品<br />
                      3.会员可在任何活动入口参与此活动，活动形式为&quot;对对碰&quot;并完成即可获得限定黑玫瑰勋章，5分钟内完成游戏即可获得活动奖品<br />
                    4.参与活动并完成即可获得限定黑玫瑰勋章完成活动抽奖即有机会获得特别礼品，完成活动抽奖即有机会获得特别礼品完成活动抽奖即有机会获得特</div>
                    <div class="activity_detail_pic"><img src="images/activity_pic.jpg" alt="" /></div>
                    <div class="activity_detail_btn"><!--<a href="#"><img src="images/btn_apply.jpg" alt="立即申请" /></a>--></div>
                  <div class="activity_detail_con">活动时间：<span>2012年7月1日-2012年8月1日</span>
                    </div>
                  <div class="activity_detail_con">中奖名单
                    </div>
                    <div class="activity_detail_txt2">
               	  <ul>
                        	<li>豆豆霓虹剪影</li>
                            <li>被爱的高童童_Sina</li>
                            <li>洛之塵_Sina</li>
                   	<li>豆豆霓虹剪影</li>
                    <li>被爱的高童童_Sina</li>
                    <li>洛之塵_Sina</li>
                   	<li>豆豆霓虹剪影</li>
                    <li>被爱的高童童_Sina</li>
                    <li>洛之塵_Sina</li>
                        <br class="clr" />
                        </ul>
                    </div>
                  <div class="activity_tips">*本次活动最终解释权归希思黎所有</div>

            	</div>
                </asp:Literal>

                <div class="share_ctrl" style="margin-top:40px;">
                  <div class="share_ctrl_r">分享至：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a>
                    </div>
                        <br class="clr" />
              </div>
              <div class="share_reply">
                    	<dl>
                        	<dt>回复：</dt>
                            <dd>
                                <asp:TextBox ID="txtReplyText"  runat="server" class="input_reply" TextMode="MultiLine"></asp:TextBox>
                            </textarea></dd>
                            <dd class="btn_replay">
                                <asp:LinkButton ID="lnkReply" runat="server" onclick="lnkReply_Click" ><img src="images/btn_submit.jpg" alt="提交" /></asp:LinkButton>
                         
                            </dd>
                           
                              
                            <br class="clr" />
                        </dl>
                    </div>
                    <div class="share_replylist">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                            
                    	<dl>
                        	<dt><img src="upload/userHearderImg/<%#Eval("headphoto")%>" width="39" height="39" alt="" /></dt>
                            <dd>
                            	<div class="share_replylist_t"><%#Eval("replyText")%><br />
                                <br />
                               <%#Cmn.Date.ToDateTimeStr(DateTime.Parse(Eval("replyDatetime").ToString()))%></div>
                            	<div class="share_replylist_b"></div>
                            </dd>
                            <br class="clr" />
                        </dl>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
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
            <div class="clr"></div>
       </div>
	  <br class="clr" />
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
<script>
    $(document).ready(function () {
        $("#gethelp").click(function () {
            $("#helpBox").show();
            //$("#bg").show().height($(document).height());
        });
        $("#helpclose").click(function () {
            $("#helpBox").hide();
            //$("#bg").hide();
        });
    });
</script>
</form>
</body>
</html>
