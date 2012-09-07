<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trial_tab2.aspx.cs" Inherits="trial_tab2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 试用中心</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/exchange.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="aa" runat ="server">
<div class="trialTab2">
           <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>    
	<div class="deta clear">
        <div class="Sl">
            <div class="pic" title="点击查看详细..."><a target="_blank" href='<%# Cmn.SisleyHelper.GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>'><img src="upload/userHearderImg/<%#Eval("headphoto")%>" width="50" height="50" alt="" /></a></div>
            <div class="nickName"><%#Eval("RealName")%></div>
        </div>
        <div class="Sr">
            <div class="txt">
                <ul class="clear">
                    <li>总评分：<em><%#GetTotalFen(Eval("pingFenTotal"))%></em>/5分</li>
                    <li><%#GetStarsStyle(Eval("pingFenTotal").ToString())%></li>
                    <li><%#GetOtherMarks(Eval("Idx").ToString())%></li>
                </ul>
                <p><%#Cmn.Str.GetNoHTML(Eval("articleContent").ToString(),300,true)%></p>
            </div>
        </div>
    </div>
          </ItemTemplate>
                        </asp:Repeater>              

    <div class="pageNum">
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
</form>
</body>
</html>
