<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar.ascx.cs" Inherits="Ascx_Calendar" %>
<%--<link href="/css/base.css" rel="stylesheet" type="text/css" />
    <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/page.css" rel="stylesheet" type="text/css" />
    <link href="/css/jquery.jcarousel.css" rel="stylesheet" type="text/css" />
    <link href="/css/skin3.css" rel="stylesheet" type="text/css" />
    <link href="/css/easydialog.css" rel="stylesheet" type="text/css" />--%>
<script language="javascript" type="text/javascript">
    $().ready(function () {
        var todayClass = "qa_list";
        var d = new Date();
        $('div .date .year').text('' + d.getFullYear() + '.' + (d.getMonth() + 1) + '.' + d.getDate());
        $('.days ul').empty();
        $('div .date .days ul').append(cldBldAll(d));
        $('div .date .days ul a').each(function () {
            if ($(this).text() == d.getDate())
                $(this).parent().attr('class', todayClass); //目前是应用在li上
        });
        $('div .date .days ul ' + ' a').click(function () {
            var d = new Date();
            var de = d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + $(this).text();            
            $.ajax({
                url: "GetNewActId.aspx?de=" + de,
                async: false
            }).done(function (data) {
                if (data <= 0)
                    //$('li.act').hide();
                    $('#actlnk').attr('href', 'activity-events.aspx');
                else
                    //$('li.act').show();
                $('#actlnk').attr('href', 'activity_detail.aspx?Idx=' + data);
            }).fail(function (data) {
                //alert(data + ' fail' + data);
            });
            easyDialog.open({
                container: 'newsBox',
                //autoClose : 2000,
                follow: $(this).attr('id'),
                followX: 40,
                followY: 20,
                fixed: false
            });
        });
    });

    //获取指定的年有第一天是星期几
    function weekOf1stMonth(datevar) {
        var day1st = new Date(datevar.getFullYear(), datevar.getMonth(), 1)
        var dayweek = day1st.getDay(); //当天星期几
        return dayweek;
    }

    //获取datevar指定的年月最后一天是几号
    function monthLastDay(datevar) {
        var MonthNextFirstDay = new Date(datevar.getFullYear(), datevar.getMonth() + 1, 1);
        var MonthLastDay = new Date(MonthNextFirstDay - 86400000);
        return MonthLastDay.getDate();
    }

    //参数 d1st:每月第一天是星期几
    function cldBldLine1(d1st, dycur) {
        var str = '';
        var lnary = new Array();
        for (var i = 0; i < 7; i++) lnary[i] = '';
        if (d1st <= 0) d1st = 0;
        var i = 0;
        while ((d1st + i) < 7) {
            lnary[d1st + i] = cldBldPerLine(i + 1, true, dycur >= (i + 1));
            ++i;
        }
        $('#perweek').text(i + 1);
        var k = 1;
        while ((d1st - k) >= 0) {
            lnary[d1st - k] = cldBldPerLine(k, false, true);
            ++k;
        }
        str = '';
        for (var i = 0; i < 7; i++)
            str += lnary[i];
        return str;
    }

    //逐行构造
    function cldBldPerLine(dy, enabled, canlinked) {
        if (enabled) {
//            if (canlinked)
                return '<li><a href="#" id=liid_' + dy + '>' + (dy) + '</a></li>';
//            else
//                return '<li><span id=liid_' + dy + '>' + (dy) + '</span></li>';
        }
        else
            return '<li><span></span></li>';
    }

    //构造剩余行
    function cldBldCnuLine(dy, datevar) {
        var str = '';
        var daycur = datevar.getDate();
        var mlast = monthLastDay(datevar);
        var i = 0;
        while (dy + i <= mlast) {
            str += cldBldPerLine(dy + (i), true, daycur >= (dy + i));
            i++;
        }
        return str;
    }

    function cldBldAll(datevar) {
        var str = cldBldLine1(weekOf1stMonth(datevar), datevar.getDate());
        str += cldBldCnuLine(parseInt($('#perweek').text()), datevar);
        return str;
    }
</script>
<div id="perweek" style="display: none">
</div>
<div class="date">
    <div class="year">
        XXXX.X</div>
    <div class="week">
        <ul>
            <li>日</li>
            <li>一</li>
            <li>二</li>
            <li>三</li>
            <li>四</li>
            <li>五</li>
            <li>六</li>
            <%--<br class="clr" />--%>
        </ul>
    </div>
    <div class="days">
        <ul>
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
        </ul>
    </div>
</div>
<div id="newsBox">
    <div class="close2">
        <a href="javascript:;" onclick="easyDialog.close();">
            <img src="images/icon_close2.gif" alt="关闭" /></a></div>
    <div class="title2">
        最新动态</div>
    <div class="box_a">
        <ul>
            <%--最新活动--%>
            <li class="act">
                <p>
                    <img src="images/eventpic_1.jpg" alt="" /></p>
                <p>
                    <a href="activity_detail.aspx?Idx=" id="actlnk">
                        <img src="images/btn_apply.gif" alt="立即申请" /></a></p>
            </li>
            <%--课件--%>
            <li>
                <p>
                    <img src="images/eventpic_2.jpg" alt="" /></p>
                <p>
                    <a href="sisley-academy.aspx">
                        <img src="images/btn_look.gif" alt="立即查看" /></a></p>
            </li>
            <%--最新创建的文章--%>
            <li>
                <p>
                    <img src="images/eventpic_1.jpg" alt="" /></p>
                <p>
                    <a href="ArticleSisleyDetail.aspx?Idx=<%=artId %>">
                        <img src="images/btn_apply.gif" alt="立即申请" /></a></p>
                </li>
            <%--贴身达人链接--%>
            <li>
                <p>
                    <img src="images/eventpic_2.jpg" alt="" /></p>
                <p>
                    <a href="sisley-service.aspx">
                        <img src="images/btn_look.gif" alt="立即查看" /></a></p>
            </li>
        </ul>
    </div>
</div>
