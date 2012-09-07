<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fexchange_record.aspx.cs" Inherits="exchange_record" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 用户注册</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script language="javascript" type="text/javascript" src="AdminManage/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    function GoPage() {
        var pgIdx = $('#tidx').val();
        if (isNaN(pgIdx)) return false;
        if (pgIdx <= 0) pgIdx = 1;
        $('#opPgIdx').val(pgIdx);
        $('#form1').submit();
    }
    $().ready(function () {
        $('.btnGo').click(function () { GoPage(); });
        $('#Button1').click(function () {
            $('#opPgIdx').val(1);
        });
        $('#totalPg').text($('#dtotal').text());
        $("#curPgidx").text($('#opPgIdx').val());
        if ($('#opPgIdx').val() == "")
            $("#curPgidx").text("1");

        $('.apg').click(function () {
            var txt = $(this).text();
            var curpg = $('#opPgIdx').val();
            if (txt == '末页') {
                $('#opPgIdx').val($('#dtotal').text());
            }
            else if (txt == '首页') {
                $('#opPgIdx').val(1);
            }
            else {
                pgIx = $(this).attr('pgIdx');

                $('#opPgIdx').val(parseInt(curpg, 10) + parseInt(pgIx, 10));

            }
            $('#form1').submit();
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
   <%-- <input name="opOrdDateBegin" type="hidden" id="opOrdDateBegin" runat="server" />
    <input name="opOrdDateEnd" type="hidden" id="opOrdDateEnd" runat="server" />
    <input name="opOrdStatus" type="hidden" id="opOrdStatus" runat="server" />
    <input name="opOrdNo" type="hidden" id="opOrdNo" runat="server" />
    --%>
        
    <input name="opPgIdx" type="hidden" id="opPgIdx" runat="server" value="1" />
    
    <div class="wrap">
 <!-- *************header Begin**********************-->
        <uc1:header ID="header1" runat="server" />
 <!-- ***********header End***************************-->
    
    <div class="content">
    	<div class="crumbs">当前位置：<a href="index.aspx">首页</a> &gt; <a href="#">希享会俱乐部</a> &gt; <a href="personalInfo.aspx">个人信息</a> &gt; <a href="#">社区动态</a> &gt; <a href="#">积分兑礼记录</a></div>
        <div class="titRecord"><h2>我的兑礼记录</h2></div>
        <div class="mainExch">
            <div class="recoSearch clear">
            	<div class="Sl">
                	<ul>
                    	<%--<li><select name="state"><option selected="selected">--选择定单状态--</option></select></li>--%>
                        <li><label for="corderId">定单号：</label>                        
                            <asp:TextBox ID="txtOrdNo" runat="server" class="inputs"></asp:TextBox>
                        </li>
                        <li><label for="from">从：</label>
                            
                            <asp:TextBox ID="txtDateBegin" runat="server" class="inputs" onclick="WdatePicker();"></asp:TextBox>
                        </li>
                        <li><label for="to">到：</label>
                        
                        <asp:TextBox ID="txtDateEnd" runat="server"  class="inputs" onclick="WdatePicker()"></asp:TextBox>
                        </li>
                        <li>
                        
                        <asp:Button ID="Button1" runat="server" value="查询定单" class="btnOrder" 
                            Text="查询定单" />
                        </li>
                        <li></li>
                    </ul>
                </div>
                <div class="Sr">
                	<a href="#" target="_blank">查看我的积分</a>
                </div>
            </div>
            <div class="recordList">
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="VerfiyAdmin" SelectMethod="GetOrds">
                <SelectParameters>
                    <asp:FormParameter Name="pgIdx" FormField="opPgIdx" DefaultValue="1" />
                    <asp:FormParameter Name="ordno" FormField="txtOrdNo" DefaultValue="" />
                    <asp:FormParameter Name="debegin" FormField="txtDateBegin" DefaultValue="2000-1-1 00:00:00" />
                    <asp:FormParameter Name="deEnd" FormField="txtDateEnd" DefaultValue="2200-1-1 00:00:00" />
                    <asp:Parameter Name="ordStatus" DefaultValue="" />
                    <asp:Parameter Name="pgSize" DefaultValue="10" />
                    
                </SelectParameters>
                </asp:ObjectDataSource>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" 
                    onitemdatabound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
            	<div class="titRecord">
                	<ul class="clear">
                    	<li><div class="n1">序号</div></li>
                        <li><div class="n2">时间</div></li>                        
                        <li><div class="n4">订单号</div></li>
                        <li><div class="n5">花费积分</div></li>
                        <li><div class="n6">订单状态</div></li>
                        <li><div class="n7"></div></li>
                    </ul>
                </div>
                <div class="details">
                </HeaderTemplate>
                <ItemTemplate>
                	<ul class="clear">
                    	<li><div class="n1"><%#Container.ItemIndex+1%></div><div id="dtotal" style="display:none"><%# DataBinder.Eval(Container.DataItem, "TotalPGCount")%></div></li>
                        <li><div class="n2">
                            <asp:Label ID="lblCreateDate" runat="server" Text=""></asp:Label></div></li>                        
                        <li><div class="n4"><%# DataBinder.Eval(Container.DataItem, "OrderNo")%></div></li>
                        <li><div class="n5"><%# DataBinder.Eval(Container.DataItem, "TotalPoints")%></div></li>
                        <li><div class="n6"><span>
                            <asp:Label ID="lblState" runat="server" Text=""></asp:Label></span></div></li>
                        <li><div class="n7"><a href="fexchange_view.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Idx")%>" target="_blank">查看详细</a></div></li>
                    </ul>                    
                    </ItemTemplate>
                    <FooterTemplate>
                </div>
                </FooterTemplate>
                </asp:Repeater>
                <div class="pageNum">
                    <ul>
                        <li>当前第<span id="curPgidx">1</span>页/总共<span id="totalPg">9</span>页</li><li><a href="javascript:void();" pgidx="1" class="apg">首页</a></li>
                        <li><a href="javascript:void();" pgidx="-1" class="apg">上一页</a></li>
                        <li><a href="javascript:void();"  pgidx="1" class="apg">下一页</a></li><li><a href="#" class="apg">末页</a></li>
                        <li><label>跳转到</label><input type="text" value="" class="nums" id="tidx" />
                        <input type="button" value="Go" class="btnGo" /></li>
                    </ul>
                </div>
                <div class="btnWrap">
                	<a href="#">返回</a>
                </div>
            </div>

        </div>
    </div>
<uc2:footer ID="footer1" runat="server" />
</div>
    </form>
</body>
</html>
