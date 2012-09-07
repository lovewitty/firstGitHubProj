<%@ Page Language="C#" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="message" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="索尼（Sony）在中国网站，全面介绍Sony公司的各项业务.提供丰富的产品信息，包括数码相机，摄像机，笔记本电脑，电视系列，影音产品等以及售后服务和购买服务" />
<meta name="keywords" Content="数码摄像机, 数码相机,Sony数码相机,MP3,sony mp3,记忆棒,vaio,walkman,随身听,液晶电视,Sony彩电,汽车音响,投影机,等离子屏,服务支持,sony中国 ,索尼中国 ,电影,笔记本电脑, 家用电器,影音 产品" />
<title>法国希思黎至臻坊社区 sisley PARIS | 用户注册</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    $().ready(function () {
        $('#delall').click(function () {
            if (!confirm('确定要删除吗?')) return false;
            var i = $(":checkbox:checked");
            if (i.length <= 0) {
                $('#delids').val(""); return false;
            }
            $('#delids').val('0');
            for (var h = 0; h < i.length; h++) {
                $('#delids').val(
               $('#delids').val() + "," + (i[h].value));
            }
            $('#form1').submit();
        });
        $('#chkall').click(function () {
            $('.chkdel').attr('checked', 'checked');
        });
    });
    function showmes(num) {

        for (var id = 1; id <= 3; id++) {
            if (id == num) {
                document.getElementById("m" + id).style.display = "block";
            }
            else {
                document.getElementById("m" + id).style.display = "none";
            }
        }
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<asp:HiddenField ID="delids" runat="server" />
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header id="header1" runat="server">
</uc1:header>
    <!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">
   	当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="sisley-prestige-club.html">希享会俱乐部</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="message.html">个人信息</a></div>
    	<div class="message">
            <div class="titExch titPersonal"><h2>用户个人信息</h2></div>
            <div class="mainExch infoPad">
            <div class="persTit">
            	<ul>
                	<li class="first"><a href="#">基本信息</a></li>
                    <li><a href="#">希享足迹</a></li>
                </ul>
            </div>
            <div class="messagelist">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="VerfiyAdmin" 
                SelectMethod="GetSiteMail" EnablePaging="true" 
                    onselecting="ObjectDataSource1_Selecting" 
                    SelectCountMethod="GetSiteMailTotalCount">
            <SelectParameters>
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="StartRecordIndex" DefaultValue="1"
                    Name="startRowIndex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10"
                    Name="maximumRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
           	  <div class="subTit2"><a href="#">站内信<em>(<asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>)</em></a></div>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" 
                    onitemdatabound="Repeater1_ItemDataBound">
                <ItemTemplate>
                <dl class="message_line">
                	<dt><img src="images/avatar_28_28.jpg" width="28" height="28" alt="" /></dt>
                    <dd class="ms_name">希思黎系统</dd>
                    <dd class="ms_tit"><a href="javascript:showmes(<%#(Container.ItemIndex)+1%>)">
                        <asp:Label ID="litsubject" runat="server"></asp:Label>
                    <%# Eval("MailSubject") %></a>
                    </dd>
                    <dd class="ms_time">2012年7月16日 11:50</dd>
                    <dd class="ms_select"><input name="" type="checkbox" value="<%#Eval("Idx") %>" class="chkdel" /></dd>
                    <br class="clr" />
                </dl>
                <div class="ms_detail" id="m<%#(Container.ItemIndex)+1%>" style="display:none;">
                    <asp:Label ID="litcontent" runat="server"></asp:Label>   <%#Eval("MailContent") %>
                </div>      
                </ItemTemplate>
                </asp:Repeater>         
            </div>
            <div class="ms_opr"><a href="javascript:void();" id="chkall">全选</a> <a href="javascript:void();" id="delall">删除</a> < </div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                    CurrentPageButtonPosition="End" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Right" PageSize="10">
                </webdiyer:AspNetPager>
          </div>
        </div>
    </div>
    <uc2:footer id="footer1" runat="server">
</uc2:footer>
</div>

</form>
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

</body>
</html>
