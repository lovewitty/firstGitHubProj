<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Y_ArticleReply.ascx.cs" Inherits="Ascx_DarenArticleReply" %>
   <!--********** Begin *****************-->
                    <div class="share_reply">
                    	<dl>
                        	<dt>回复：</dt>
                            <dd>
                                <asp:TextBox ID="TextReply" runat="server" TextMode="MultiLine"  
                                    class="input_reply" Rows="5"></asp:TextBox>
                       </dd>
                            <dd class="btn_replay">
                                <asp:LinkButton ID="lnkSubmit" runat="server" onclick="lnkSubmit_Click"><img src="images/btn_submit.jpg" alt="提交" /></asp:LinkButton>
                      
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
                            	<div class="share_replylist_t"><%#Eval("replyContent")%><br />
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
                    <!--********** End*****************-->