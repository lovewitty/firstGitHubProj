<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="Ascx_footer" %>
    <div class="footer">
    	<div class="footer_1" style="display:<%=Bool_footer_1%>">
        <ul>
               <asp:Literal ID="ltlHome_UserCommunityHeaderImg" runat="server">
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
        	<li><img src="images/avatar_50_50.jpg" width="50" height="50" alt="" /></li>
            </asp:Literal>
            <br class="clr" />
        </ul>
        </div>
        <div class="footer_2" style="display:<%=Bool_footer_2%>">
        <ul>
        	<li class="txt1">法国希思黎至臻坊社区和TA们在一起</li>
            <li class="weibogz"><a href="<%=WeiboUrl %>" target="_blank"><img src="images/btn_guanzhu.gif" alt="加关注" /></a></li>
            <li class="num4">
                <asp:Literal ID="ltlAddWeiboCount" runat="server">12,910,091</asp:Literal></li>
            <li class="s0">
            	<ul class="share">
                	<li><a href="#" title="Qzone"><img src="images/icon_qzone.gif" alt="Qzone" /></a></li>
                	<li><a href="#" title="新浪微博"><img src="images/icon_weibo.gif" alt="新浪微博" /></a></li>
                	<li><a href="#" title="腾讯微博"><img src="images/icon_tqq.gif" alt="腾讯微博" /></a></li>
                	<li><a href="#" title="人人网"><img src="images/icon_renren.gif" alt="人人网" /></a></li>
                	<li><a href="#" title="开心网"><img src="images/icon_kaixin.gif" alt="开心网" /></a></li>
                </ul>
            </li>
            <li class="txt2">分享到：</li>
            <br class="clr" />
        </ul>
        </div>
        <div class="footer_3">
<ul>
            	<li class="fl"><a href="sisley-academy.aspx">至臻学院</a></li>
            	<li><a href="sisley-prestige-club.aspx">希享会俱乐部</a></li>
            	<li><a href="sisley-beauty-garden.aspx">希粉会</a></li>
            	<li><a href="star-products.aspx">明星产品</a></li>
             	<li><a href="sisley-events.aspx">至臻沙龙</a></li>
            	<li><a href="KOL-share.aspx">达人分享</a></li>
            	<li><a href="trial-zone.aspx">试用中心</a></li>
            	<li><a href="e-magazine.aspx">至臻e杂志</a></li>
            	<li class="fr"><a href="http://www.sisley.com.cn/" target="_blank">官方网上商城</a></li>
                <li class="copyright">All rights reserved by sisley,  希思黎 2012 </li>
                <br class="clr" />
           </ul>
        </div>
    </div>