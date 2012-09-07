﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register src="Ascx/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="Ascx/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 首页</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
<link href="css/skin.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.jcarousel.pack.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<!--
<script type="text/javascript" src="js/MSClass.js"></script>
-->
<script src="js/jsStringFormat.js" type="text/javascript"></script>
<script type="text/javascript">

    jQuery(document).ready(function () {
        jQuery('#mycarousel').jcarousel({
            vertical: true,
            auto: 5,
            wrap: 'last',
            /*initCallback: mycarousel_initCallback,*/
            scroll: 1
        });
    });


    function GoSearchProduct() {
        var keyword = $("#txtKeywords").val();
        var urlSearch = String.format("http://www.sisley.com.cn/products/search/?keyWords={0}", keyword);
        window.open(urlSearch, "_blank");
        return;
    }

    function GetImgCode() {
        var getimagecode = document.getElementById("imgViladCode");
        var myDate = new Date();
        var rdn = myDate.getMilliseconds();
        getimagecode.src = "Ascx/VerifyCode.aspx?rdn=" + rdn;
    }

    function AddViewLog(cmIdx, cmName) {
        var url = "data2flash/APICourse.aspx?rep=courselog&cmIdx=" + cmIdx + "&cmName=" + cmName;
        $.post(url);
    }


    function GoLogin() {
        var UserEmail = $("#UserEmail").val();
        var Password = $("#Password").val();
        var ViladCode = $("#ViladCode").val();

        if (UserEmail == "") {
            alert("请输入会员号");
            $("#UserEmail").focus();
            return false;
        }

        if (Password == "") {
            alert("请输入您的密码");
            $("#Password").focus();
            return false;
        }

        /*
        $.ajax(
            {
                type: "POST",
                url: "Ascx/DealAjax.aspx",
                data: String.format("rep=homeLogin&UserEmail={0}&Password={1}&viladCode={2}", UserEmail, Password, viladCode),
                success: function (msg) {
                    alert(msg);
                    //location.href = "rLogin.aspx?t=sina";
                }
            });
     */
    }
</script>
<script type="text/javascript">
    var JQY = function (id) {
        return "string" == typeof id ? document.getElementById(id) : id;
    };

    var Extend = function (destination, source) {
        for (var property in source) {
            destination[property] = source[property];
        }
        return destination;
    }

    var CurrentStyle = function (element) {
        return element.currentStyle || document.defaultView.getComputedStyle(element, null);
    }

    var Bind = function (object, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function () {
            return fun.apply(object, args.concat(Array.prototype.slice.call(arguments)));
        }
    }

    var Tween = {
        Quart: {
            easeOut: function (t, b, c, d) {
                return -c * ((t = t / d - 1) * t * t * t - 1) + b;
            }
        },
        Back: {
            easeOut: function (t, b, c, d, s) {
                if (s == undefined) s = 1.70158;
                return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
            }
        },
        Bounce: {
            easeOut: function (t, b, c, d) {
                if ((t /= d) < (1 / 2.75)) {
                    return c * (7.5625 * t * t) + b;
                } else if (t < (2 / 2.75)) {
                    return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b;
                } else if (t < (2.5 / 2.75)) {
                    return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b;
                } else {
                    return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b;
                }
            }
        }
    }


    //容器对象,滑动对象,切换数量
    var SlideTrans = function (container, slider, count, options) {
        this._slider = JQY(slider);
        this._container = JQY(container); //容器对象
        this._timer = null; //定时器
        this._count = Math.abs(count); //切换数量
        this._target = 0; //目标值
        this._t = this._b = this._c = 0; //tween参数

        this.Index = 0; //当前索引

        this.SetOptions(options);

        this.Auto = !!this.options.Auto;
        this.Duration = Math.abs(this.options.Duration);
        this.Time = Math.abs(this.options.Time);
        this.Pause = Math.abs(this.options.Pause);
        this.Tween = this.options.Tween;
        this.onStart = this.options.onStart;
        this.onFinish = this.options.onFinish;

        var bVertical = !!this.options.Vertical;
        this._css = bVertical ? "top" : "left"; //方向

        //样式设置
        var p = CurrentStyle(this._container).position;
        p == "relative" || p == "absolute" || (this._container.style.position = "relative");
        this._container.style.overflow = "hidden";
        this._slider.style.position = "absolute";

        this.Change = this.options.Change ? this.options.Change :
		this._slider[bVertical ? "offsetHeight" : "offsetWidth"] / this._count;
    };
    SlideTrans.prototype = {
        //设置默认属性
        SetOptions: function (options) {
            this.options = {//默认值
                Vertical: true, //是否垂直方向（方向不能改）
                Auto: true, //是否自动
                Change: 0, //改变量
                Duration: 50, //滑动持续时间
                Time: 10, //滑动延时
                Pause: 4000, //停顿时间(Auto为true时有效)
                onStart: function () { }, //开始转换时执行
                onFinish: function () { }, //完成转换时执行
                Tween: Tween.Quart.easeOut//tween算子
            };
            Extend(this.options, options || {});
        },
        //开始切换
        Run: function (index) {
            //修正index
            index == undefined && (index = this.Index);
            index < 0 && (index = this._count - 1) || index >= this._count && (index = 0);
            //设置参数
            this._target = -Math.abs(this.Change) * (this.Index = index);
            this._t = 0;
            this._b = parseInt(CurrentStyle(this._slider)[this.options.Vertical ? "top" : "left"]);
            this._c = this._target - this._b;

            this.onStart();
            this.Move();
        },
        //移动
        Move: function () {
            clearTimeout(this._timer);
            //未到达目标继续移动否则进行下一次滑动
            if (this._c && this._t < this.Duration) {
                this.MoveTo(Math.round(this.Tween(this._t++, this._b, this._c, this.Duration)));
                this._timer = setTimeout(Bind(this, this.Move), this.Time);
            } else {
                this.MoveTo(this._target);
                this.Auto && (this._timer = setTimeout(Bind(this, this.Next), this.Pause));
            }
        },
        //移动到
        MoveTo: function (i) {
            this._slider.style[this._css] = i + "px";
        },
        //下一个
        Next: function () {
            this.Run(++this.Index);
        },
        //上一个
        Previous: function () {
            this.Run(--this.Index);
        },
        //停止
        Stop: function () {
            clearTimeout(this._timer); this.MoveTo(this._target);
        }
    };
</script>
</head>

<body>
<form runat="server" id="myForm1">
<div id="bg"></div>
<div class="wrap">
 <!-- *************header Begin**********************-->    
    <uc1:header ID="header1" runat="server" />
<!-- ***********header End***************************-->
    <div class="kv_index">
    	 	<div class="link_board">
        <ul>
        	<li><a href="hotboard.aspx" >热议排行榜</a></li>
        	<li><a href="famous_prod-temp1.aspx" >希思黎全能乳液</a></li>
        	<li><a href="famous_prod.aspx" >玫瑰焕采紧致面膜</a></li>
        	<li><a href="http://www.sisley.com.cn/box.html?utm_source=navi&utm_medium=website&utm_campaign=2012%2DAbtesting&utm_nooverride=1" target="_blank" >官网特享活动</a></li>
        </ul>
        </div>
    	<div class="search">
        	<ul>
	            <li class="ipt"><input name="" id="txtKeywords" type="text" class="input_search" value="全能乳液" /></li>
                <li class="ico_search"><a href="#" onclick="GoSearchProduct();"><img src="images/icon_search.jpg" /></a></li>            </ul>
        </div>
    	
<!-- 新KV 开始 -->
<DIV id="idContainer2" class="container">
<TABLE id="idSlider2" border="0" cellSpacing="0" cellPadding="0">
  <TBODY>
  <TR>
    <TD><A href="trial_zone.aspx" target="_blank"><IMG border=0 src="images/index_kv_1.jpg" width=982 height=334></A></TD>
	<TD><A href="famous_prod-temp2.aspx" target="_blank"><IMG border=0 src="images/index_kv_2.jpg" width=982 height=334></A></TD>
	<TD><A href="fselect_prod.aspx" target="_blank"><IMG border=0 src="images/index_kv_3.jpg" width=982 height=334></A></TD>
   </TR></TBODY></TABLE>
<UL id="idNum" class="num"></UL>
</DIV>
<!-- 新KV 结束 -->
    

      <SCRIPT type="text/javascript">
          new Marquee(
			{
			    MSClass: ["MSClassBox", "ContentID", "TabID", "", 200],
			    Direction: 5,
			    Step: [0.45, 15],
			    Width: 982,
			    Height: 334,
			    DelayTime: 3,
			    WaitTime: 3,
			    ScrollStep: 982,
			    SwitchType: 0,
			    AutoStart: 1
			})
			</SCRIPT>
  </div>


  <!---->
    <div class="content">
    	<div class="homepage">
        <div class="homeline"><img src="images/line.gif" /></div>
    	<div class="home_l">
        	<div class="home_l_1">
            	<div><img src="images/home_l_1_pic.jpg"  width="387" height="290" /></div>
                <div class="num3">
                    <asp:Literal ID="ltlCount_UserCommunity" runat="server">110,908</asp:Literal>人学员</div>
            </div>
        	<div class="home_l_2">
            <ul>
            <!--  课程列表 -->
                <asp:Literal ID="ltlCourseList" runat="server">
       	    <li>
            		<div class="num1">123,50</div>
                	<div class="pic"><a href="#"><img src="images/home_l_2_pic.jpg" width="133" height="75" /></a></div>
                    <div class="text">
                    <span>玫瑰焕彩紧致面膜 - 新品培训</span><br />
源自希思黎瞬间提升青春活力与美貌度，融合三种功效，只需15分钟...                    </div>
              </li>
       	    <li>
                	<div class="num1">123,50</div>
                    <div class="pic"><a href="#"><img src="images/home_l_2_pic.jpg" width="133" height="75" /></a></div>
                    <div class="text">
                    <span>玫瑰焕彩紧致面膜 - 新品培训</span><br />
源自希思黎瞬间提升青春活力与美貌度，融合三种功效，只需15分钟...                    </div>
              </li>
       	    <li>
                	<div class="num1">123,50</div>
                    <div class="pic"><a href="#"><img src="images/home_l_2_pic.jpg" width="133" height="75" /></a></div>
                    <div class="text">
                    <span>玫瑰焕彩紧致面膜 - 新品培训</span><br />
源自希思黎瞬间提升青春活力与美貌度，融合三种功效，只需15分钟...                    </div>
              </li>
              </asp:Literal>
            </ul>
            </div>
            <div class="more"><a href="sisley-academy.aspx?cmIdx=1"><img src="images/btn_more.jpg" alt="more" /></a></div>
        </div>
    	<div class="home_m">
        	<div class="home_m_1"><a href="activity-events.aspx"><img src="images/home_m_1_pic.jpg" runat="server" id="Ad_Home_middle" width="300" height="159" alt="" /></a></div>
          <div class="home_m_2">
                 <div id="feature-slide">
                  <asp:Literal ID="ltl_ActivityHomeList" runat="server">
                  <div class="preview_item" style="display: none;">
                    	<div class="preview_item_left">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙1</div>
                    </div>
                  	<div class="preview_item_right">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙</div>
                    </div>
                    <br class="clr" />
                  </div>

                  <div class="preview_item" style="display: none;">
                  	<div class="preview_item_left">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙AA</div>
                    </div>
                  	<div class="preview_item_right">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙abc</div>
                    </div>
                    <br class="clr" />
                  </div>

                  <div class="preview_item" style="display: none;">
                  	<div class="preview_item_left">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_1_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙3bb</div>
                    </div>
                  	<div class="preview_item_right">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙ccc</div>
                    </div>
                    <br class="clr" />
                  </div>

                  <div class="preview_item" style="display: none;">
                  	<div class="preview_item_left">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙4aa</div>
                    </div>
                  	<div class="preview_item_right">
                    	<div style="padding:0 0 0 1px;"><img src="images/home_m_2_pic.jpg" width="147" height="81" /></div>
                        <div class="preview_item_text"><span>07/01-07/02 2012</span><br />
						希思黎美肤沙龙cdef</div>
                    </div>
                    <br class="clr" />
                  </div>
                  </asp:Literal>

                  <div class="feature-slide-list">
                   <a href="#" id="previous_arrow" class="previous_arrow"></a>
                   <div id="feature-list" class="feature-list">                   </div>
                   <a href="#" id="next_arrow" class="next_arrow"></a>                  </div>
                 </div>
                 <script type="text/javascript">
                     init_zzjs();
                 </script>
          </div>
            <div class="home_m_3">
            	<ul id="mycarousel" class="jcarousel jcarousel-skin-tango">
                    <asp:Literal ID="ltl_weiboHome" runat="server">
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>1潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>2潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>3潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>4潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>5潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>6潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    <li>
                    	<dl>
                        	<dt><img src="images/avatar_50_50.jpg" width="50" height="50" /></dt>
                            <dd><span>7潇潇de妈咪：</span>哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈</dd>
                            <br class="clr" />
                        </dl>
                    </li>
                    </asp:Literal>
                </ul>
                <div class="more"><a href="KOL-share.aspx"><img src="images/btn_more.jpg" alt="more" /></a></div>
            </div>
        </div>
    	<div class="home_r">
        	<div class="home_banner_1"><a href="#" id="Ad_Home_RightHref" target="_blank" runat="server"><img src="images/home_banner_1.jpg" runat="server" id="Ad_Home_Right" width="213" height="208" alt="" /></a></div>
        	<div class="home_banner_2">
            	<div class="home_banner_2_pic"><img src="images/home_banner_2_pic.jpg" width="197" height="174" runat="server" id="AdPosition_Left2" alt="玫瑰焕采紧致面膜" /></div>
           	  <div class="banner_2_num1">1212</div>
           	  <div class="banner_2_num2">121212</div>;
                <div class="btn_trail"><a href="product2.aspx"><img src="images/btn_trail.jpg" alt="即刻试用" /></a></div>
        </div>
        	<div class="home_banner_3" style="display:none">
            	<div class="link_emag_online"><a href="#" class="cmbtn" title="在线观看" runat="server" id="MagazineAd_BrowserUrl">在线观看</a></div>
            	<div class="link_emag_download"><a href="#" class="cmbtn" title="下载收藏" runat="server" id="MagazineAd_DownlowdRarPath">下载收藏</a></div>
          	</div>
        </div>
    	<div class="clr"></div>
        </div>
  </div>
    <uc2:footer ID="footer1" runat="server" />
    
</div>




<script src="js/easydialog.js"></script>
<script>
    var JQRY = function () {
        return document.getElementById(arguments[0]);
    };

//    JQRY('Loginbtn').onclick = function () {
//        easyDialog.open({
//            container: 'LoginBox',
//            overlay: true,
//            fixed: false
//        });
//    };


/*
    $(document).ready(function () {
        easyDialog.open({
            container: 'TaskBox',
            follow: 'flBtn',
            followX: -148,
            followY: 22
        });
    });
    */


    $(document).ready(function () {
        $("#Loginbtn").click(function () {
            $("#LoginBox").show();
            $("#bg").show().height($(document).height());
        });
        $("#loginclose").click(function () {
            $("#LoginBox").hide();
            $("#bg").hide();    
        });
    });

</script>
<script>
    var forEach = function (array, callback, thisObject) {
        if (array.forEach) {
            array.forEach(callback, thisObject);
        } else {
            for (var i = 0, len = array.length; i < len; i++) { callback.call(thisObject, array[i], i, array); }
        }
    }

    var st = new SlideTrans("idContainer2", "idSlider2", 3, { Vertical: false });

    var nums = [];
    //插入数字
    for (var i = 0, n = st._count - 1; i <= n; ) {
        (nums[i] = JQY("idNum").appendChild(document.createElement("li"))).innerHTML = ++i;
    }

    forEach(nums, function (o, i) {
        o.onmouseover = function () { o.className = "on"; st.Auto = false; st.Run(i); }
        o.onmouseout = function () { o.className = ""; st.Auto = true; st.Run(); }
    })

    //设置按钮样式
    st.onStart = function () {
        forEach(nums, function (o, i) { o.className = st.Index == i ? "on" : ""; })
    }
    st.Run();
</script>
</form>
</body>

</html>