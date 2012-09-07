<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personalInfoEdit.aspx.cs" Inherits="personalInfoEdit" %>

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
<script src="js/jsStringFormat.js" type="text/javascript"></script>
<script type="text/javascript" src="js/common.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var arr = ['安徽', '澳门', '北京', '福建', '甘肃', '广东', '广西', '贵州', '海南', '河北', '河南', '黑龙江', '湖北', '湖南', '吉林', '江苏', '江西', '辽宁', '内蒙古', '宁夏', '青海', '山东', '山西', '陕西', '上海', '四川', '台湾', '天津', '西藏', '香港', '新疆', '云南', '浙江', '重庆', '海外'];
        ddl = $("#Province");
        ddl.children().remove();
        ddl.append($("<option value=''>请选择省份</option>"));
        for (var i = 0; i < arr.length - 1; i++) {
            //var arrTemp = arr[i];
            var dd = " "
            if (document.getElementById("Hidden1").value == arr[i]) {
                dd = " selected "
            }
            ddl.append($("<option " + dd  + " title=" + arr[i] + " value=" + arr[i] + " >" + arr[i] + "</option>"));
        }
    });

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

    function checkForm() {
        var RealName = $("#RealName").val();
        var Province = $("#Province").val();
        var MobilePhone = $("#MobilePhone").val();
        var City = $("#City").val();
        var Address = $("#Address").val();
        var ZipCode = $("#ZipCode").val();

        if (RealName == "") {
            alert("请输入您的姓名");
            $("#RealName").focus();
            return false;
        }

        if (MobilePhone == "") {
            alert("请输入您的手机号码");
            $("#MobilePhone").focus();
            return false;
        }
        else {
            if (MobilePhone.length != 11) {
                alert("手机格式不正确！请重新输入");
                $("#MobilePhone").focus();
                return false;
            }
        }

        if (Province == "") {
            alert("请选择省");
            $("#Province").focus();
            return false;
        }

        if (City == "") {
            alert("请输入城市");
            $("#City").focus();
            return false;
        }

        //        $.ajax(
        //        {
        //          var parms =  String.format("rep=changeInfo&RealName={0}&MobilePhone={1}&Province={2}&City={3}&Address={4}&ZipCode={5}"
        //                                                , RealName, MobilePhone, Province, City, Address,ZipCode);
        //                        alert(parms);
        //            type: "POST",
        //            url: "data2flash/AjaxSubmit.aspx",
        //            data: parms,
        //            success: function (msg) {
        //                location.href = "personalInfo.aspx";
        //            }
        //        });
        //    }
    }

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
<form runat="server" id="myForm1">
<div class="wrap">
<div class="flower" style="bottom:180px;"><img src="images/flower.jpg" /></div>
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server"></uc1:header>
    <!-- ***********header End***************************-->

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
            	<div class="<%=strTopClass %>"><a href="#">站内信<em>(<%=strSiteMsgNumber %>)</em></a><span>普通会员</span></div>
                <div class="details clear">
                    <div class="Sl">
                        <div class="member">
                            <ul>
                                <li>会员级别：<%=strVip%></li>
                                <li>电子邮箱：<%=ent.UserEmail %></li>
                                <li>姓　　名：<input type="text" name="RealName" id="RealName" runat="server" /></li>
                                <li>手机号码：<input type="text" name="MobilePhone" id="MobilePhone"  runat="server" /></li>
                                <li>所在省份：<input id="Hidden1" type="hidden" runat="server" />
                                    <select id="Province" runat="server" onchange="this.form.Hidden1.value=this.value"></select>
                                </li>
                                <li>所在城市：<input type="text" name="City" id="City" runat="server" /></li> 
                                  <li>地　　址：<input type="text" name="Address" id="Address" runat="server" /></li> 
                                  <li>邮　　编：<input type="text" name="ZipCode" id="ZipCode" runat="server" /></li> 
                            </ul>    
                              <style>
							.btnMember2 {margin:10px 0 0 0;width:425px;overflow:hidden;}
							.btnMember2 a {display:block;width:100px;height:33px;overflow:hidden;text-indent:-999999px;background:url("images/btn_modify.jpg") no-repeat;}
							      #Address
                                  {
                                      width: 327px;
                                  }
							</style>
                            
                              <div class="btnMember2">
                                  <asp:LinkButton ID="ltnEditPersonInfo" runat="server" 
                                      OnClientClick="return checkForm()" onclick="ltnEditPersonInfo_Click">立即修改</asp:LinkButton>
                             </div>
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
                    <div class="btnState clear"><a href="fselect_prod.aspx" class="n3">我要兑礼</a><a href="fexchange_record.html" class="n4">查看积分兑礼记录</a><a href="medal_rule.aspx" class="n1">勋章机制</a><a href="#" class="n2">查看勋章兑礼记录</a></div>
                        <%}
                       else
                       { %>
                    <div class="btnState"><a href="#" class="n1">勋章机制</a><a href="#" class="n2">查看勋章兑礼记录</a></div>
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
</form>
<div class="dvUpgrade">
<div class="upBg"></div>
    <div class="details">
    	<a href="###" title="关闭" class="btnClose">关闭</a>
        <ul>
        	<li><label for="uCard">会员卡号</label><input type="text" name="uCard" class="inputs" id="uCard"/></li>
<%--            <li><label for="uName">姓名</label><input type="text" name="uName" class="inputs" id="uName"/></li>
--%>            <li><label for="uMobile">手机号码</label><input type="text" name="uMobile" class="inputs" id="uMobile"/></li>
            <li><label></label><input type="button" value="立即提交" class="btnSubmit" /></li>
        </ul>
    </div>
    
</div>






</body>
</html>
