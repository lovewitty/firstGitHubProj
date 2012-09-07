//设置cookies的值
function SetCookie(strCookieName, strCookieValue, strExpireDate) {
    var strExpires;
    if (strExpireDate == "session") {
        strExpires = "";
    }
    else {
        if (strExpireDate)
            strExpires = ";expires=" + strExpireDate;
        else
            strExpires = ";expires=" + (new Date((new Date()).getTime() + 1000 * 10 * 60 * 1)).toGMTString();
    }
    document.cookie = strCookieName + "=" + escape(strCookieValue) + strExpires + ";path=/";
}

//读取cookies的值
function ReadCookie(strCookieName) {
    var anyCookies = document.cookie;
    var pos = anyCookies.indexOf(strCookieName + "=");
    var value = "";
    if (pos != -1) {
        var start = pos + strCookieName.length + 1;
        var end = anyCookies.indexOf(";", start);
        if (end == -1) {
            end = anyCookies.length;
        }
        value = anyCookies.substring(start, end); value = unescape(value);
    }
    return value;
}

//== 如下业务逻辑部分=========

//001 点击发布文章，验证是否就是登陆
function doSendShare()
{
    var cookEmail = ReadCookie("login_UserEmail");
    //alert(cookEmail);
    if (cookEmail == "")
    {
        var isLogin = confirm("您还没有登录，想登录吗？");
        if (isLogin)
        {
            location.href = "login.aspx";
            return false;
        }
        else
        {
            return false;
        }
    }
    return true;
}    
