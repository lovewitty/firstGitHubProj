//V1 method
String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
    }

//V2 static
String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

//==========================
function GetImgCode(ImgId) {
    var getimagecode = document.getElementById(ImgId);
    var myDate = new Date();
    var rdn = myDate.getMilliseconds();
    getimagecode.src = "Ascx/VerifyCode.aspx?rdn=" + rdn;
}

