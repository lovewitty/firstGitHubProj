<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Daren.ascx.cs" Inherits="Ascx_Daren" %>
<script type="text/javascript" language="javascript">
    $().ready(function () {
        $('#mycarousel').jcarousel({
            vertical: false,
            auto: 5,
            wrap: 'last',
            /*initCallback: mycarousel_initCallback,*/
            scroll: 1
        });
    });
</script>
<div class="persons">
    <ul id="mycarousel" class="jcarousel jcarousel-skin-persons">
        <li>
                   <p><a href="#"><img src="images/avatar_46_46.jpg" width="46" height="46" alt="" /></a></p>
                   <p>美肌专家</p>
        </li>
      <%--<asp:ObjectDataSource ID="objDaren" runat="server" SelectMethod="GetServicer" 
            TypeName="VerfiyAdmin"></asp:ObjectDataSource>
        <asp:Repeater ID="rptDaren" runat="server" DataSourceID="objDaren">
        <ItemTemplate>
        <li>
            <p><a href="javascript:void();"><img src='upload/Daren/<%#Eval("HeaderImg")%>' width="46" height="46" alt="" /></a></p>
            <p><%#Eval("DarenName")%></p>
        </li>            
        </ItemTemplate>
        </asp:Repeater>--%>
    </ul>
</div>
