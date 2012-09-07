<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRili2.aspx.cs" Inherits="TestRili2" %>


<html  >
<head id="Head1" runat="server">
    <title>日历控件</title>
<script type="text/javascript" src="calendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <input id="Text1" type="text"  onFocus=calendar() />
       </div>
    </form>
</body>
</html>
