<%@ Control Language="C#" AutoEventWireup="true" CodeFile="productTry3List.ascx.cs" Inherits="Ascx_productTry3List" %>
<ul>
                        <asp:Repeater ID="Repeater_productTryChk" runat="server">
                       <ItemTemplate>
                    	<li style="margin-bottom:12px;"> <a href='<%#GetUrl_ByBoardName(Eval("BoardName").ToString()) %>?Idx=<%#Eval("Idx")%>'><img src="upload/userHearderImg/<%#Eval("headphoto")%>" alt="" /></a>
                            <p><span><%#Cmn.Str.GetStr(Eval("articleTitle").ToString(), 20, true)%></span><br />
                               <%#Cmn.Str.GetNoHTML(Eval("articleContent").ToString(), 50, true)%></p>
							<br class="clr" />
                        </li></ItemTemplate>
                         </asp:Repeater>
                    </ul>