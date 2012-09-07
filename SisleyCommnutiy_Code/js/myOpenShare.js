//分享按钮
//, shareLink('kaixinShare') ,shareLink('qqShare') ,shareLink('doubanShare') ,
function shareLink(target) {
    alert("testOk_" + target);
    try {
        $.post("data2flash/API_AddWeiboShare.aspx", { rep: "shareWeibo", target: target, remark: location.href });
    } catch (e) {

    }

    var vTitle = document.title; //"中银理财风向标”，规划自己人生财务；百年中行，全球服务; //
    var shareLink = location.href;
    //alert(target);
    var link = "";
    var pic = escape("http://boc.msn.com.cn/images/jiaodian.jpg");
    switch (target) {
        case "msnShare":
            link = "http://profile.live.com/badge/?url=" + escape(shareLink) + "&title=" + escape(vTitle) + "&msg=" + escape(vTitle) + "&screenshot=" + pic + "&description=" + escape(vTitle);
            break;
        case "sinaShare":  //
            link = "http://v.t.sina.com.cn/share/share.php?title=" + encodeURIComponent(vTitle) + "&searchPic=false&url=" + encodeURIComponent(shareLink) + "&source=bookmark&pic=" + pic;
            break;
        case "kaixinShare":
            link = "http://www.kaixin001.com//repaste//share.php?rtitle=" + encodeURIComponent(vTitle) + "&rurl=" + encodeURIComponent(shareLink) + "&rcontent="; // +encodeURIComponent(vTitle);
            break;
        case "doubanShare":
            link = "http://shuo.douban.com/%21service/share?image=" + pic + "&href=" + encodeURIComponent(shareLink) + "&name=" + encodeURIComponent(vTitle);
            break;
        case "qqShare":
            var _t = encodeURI(vTitle);
            var _url = encodeURIComponent(document.location);
            var _appkey = encodeURI("appkey");
            var _pic = pic;
            var _site = "";
            link = 'http://v.t.qq.com/share/share.php?title=' + _t + '&url=' + _url + '&appkey=' + _appkey + '&site=' + _site + '&pic=' + _pic;
            break;
    }

    window.open(link, "_blank");
}

  

    //人人分享，现在分享页面中加入 
    //<script type="text/javascript" src="http://widget.renren.com/js/rrshare.js"></script>
    //人人分享点击
function shareRenRenClick() {
    try {//写入数据库中
        $.post("data2flash/API_AddWeiboShare.aspx", { rep: "shareWeibo", target: "renren", remark: location.href });
    }
    catch (e) {

    }
        var vTitle = document.title;
        var shareLink = location.href;
        var rrShareParam = {
            resourceUrl: shareLink, //分享的资源Url
            pic: 'http://boc.msn.com.cn/images/jiaodian.jpg',  //分享的主题图片Url
            title: vTitle,  //分享的标题
            description: vTitle //分享的详细描述
        };
        rrShareOnclick(rrShareParam);
    }

 



