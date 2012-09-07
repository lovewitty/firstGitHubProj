<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qa.aspx.cs" Inherits="qa" %>

<%@ Register Src="Ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="Ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="description" Content="源自法国的植物美容学先驱希思黎，是享誉全球高端奢侈护肤品领域的经典品牌。逾30年植物研发经验，成就安全、自然、有效的承诺。从护肤系列，到植物彩妆，全方位美容产品和专业美肤方案" />
<meta name="keywords" Content="全能明星套,全能乳液,玫瑰焕采紧致面膜,城市防护隔离,夏日保湿套,SPF30防晒隔离,花香保湿面膜,旅游防晒隔离,口碑美白套,全日呵护精华	焕白亮采面膜,SOS晒后修复,盛夏防晒套,赋活水润保湿霜,瞬间紧致眼膜,夏季补水保湿" />
<title>sisley 法国希思黎S社区 | 至臻学院</title>
<link href="css/base.css" rel="stylesheet" type="text/css" />
<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/page.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/main.js"></script>
<script type="text/javascript">
    function showqa(num) {

        for (var id = 1; id <= 10; id++) {
            if (id == num) {
                document.getElementById("a" + id).style.display = "block";
            }
            else {
                document.getElementById("a" + id).style.display = "none";
            }
        }
    }
</script>
</head>

<body>
<form runat="server" id="formId1">
<div class="wrap">
    <!-- *************header Begin**********************-->
    <uc1:header ID="header1" runat="server" />
    <!-- ***********header End***************************-->
    
<div class="content">
    <div class="crumbs">
        当前位置：<a href="index.aspx">首页</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="sisley-academy.html">至臻学院</a> <img src="images/arrow_01.gif" align="absmiddle" alt="" /> <a href="qa.html">Q&amp;A</a></div>
        <div class="academy">
        	<div class="academy_3">
            	<div class="title_pic"><img src="images/title_qa2.jpg" alt="希思黎Q&amp;A" /></div>
              <div class="subtitle_rule">选择你的问题类型</div>
                <div class="qa_content">
               	  <div class="qa_nav">
                  <ul>
                      <asp:Literal ID="ltlQaType" runat="server">
                  	<li><a href="#">护肤</a></li>
                    <li><a href="#">彩妆</a></li>
                    <li><a href="#">香水</a></li>
                    <li class="thison"  ><span><a href="#">护肤基本常识</a></span></li>
                    <li class="ri"><a href="#">植物美容学</a></li>
                    </asp:Literal>
                    <br class="clr" />
                  </ul>
                  </div>
                    <div class="qa_box">
                    	<div class="qa_subnav">
                          <ul>
                              <asp:Literal ID="ltlQaSubType" runat="server">
                            <li><a href="#">面部肌肤保养</a></li>
                            <li><a href="#">眼唇护理</a></li>
                            <li><a href="#">身体护理</a></li>
                            <li><a href="#">头发护理</a></li>
                            <li><a href="#">防晒护理</a></li>
                            </asp:Literal>
                            <br class="clr" />
                          </ul>
                          </div>
                          <div class="qa_list">
                          <!--- Begin -->
    <asp:Repeater ID="DataList1" runat="server" >   
      <HeaderTemplate>

        </HeaderTemplate>     
        <ItemTemplate>
        <dl class="qa_q">
                <dt class="q1">Q</dt>
                <dd class="q0"><a href="javascript:showqa(<%#Container.ItemIndex+1%>)"><%#Eval("ContentQuestion")%></a></dd>
                <br class="clr" />
       </dl>
                            <dl class="qa_a" id="a<%#Container.ItemIndex+1%>" style="display:none;">
                                <dt class="a1">A</dt>
                                <dd class="a0"><%#Eval("ContentAnswer")%></dd>
                                  <dd class="qa_share">分享至：<a href="#"><img src="images/icon_weibo3.jpg" alt="新浪微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_tqq3.jpg" alt="腾讯微博" align="absmiddle" /></a> <a href="#"><img src="images/icon_kaixin3.jpg" alt="开心网" align="absmiddle" /></a></dd>
                                <br class="clr" />
                            </dl>
     
        </ItemTemplate>
        </asp:Repeater>
                          </div>
                    </div>
                    <div class="qa_page">
                    <div class="pageNum2">
                    	
                          
                        
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
                </div>
            </div>
    </div>
</div>
    <uc2:footer ID="footer1" runat="server" />
</div>


</form>

</body>
</html>
