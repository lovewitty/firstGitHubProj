/* 首页 沙龙切换 */
function init_zzjs(strId) {
    var domRoot = document.getElementById('feature-slide');
    if (!domRoot) return;
    domRoot.list = [];
    var children = domRoot.childNodes;
    var offset = 0;
    for (var i in children) {
        var domItem = children[i];
        if (domItem && domItem.className == 'preview_item') {
            domRoot.list.push(domItem);
            domItem.offset = offset;
            offset++;
        }
}
    var domList = document.getElementById('feature-list');
    if (!domList) return;
    domList.innerHTML = '';
    domList.items = [];
    for (var i = 0; i < domRoot.list.length; i++) {
        var temp = domRoot.list[i];
        var domItem = document.createElement('a');
        domList.appendChild(domItem);
        domItem.href = '#';
        domItem.onclick = function(){
            return false;
        }
        domList.items.push(domItem);
        domItem.offset = i;
    }
    var domPreviousBtn = document.getElementById('previous_arrow');
    var domNextBtn = document.getElementById('next_arrow');
    domPreviousBtn.onclick = function(evt) {
        evt = evt || window.event;
        var target = evt.target || evt.srcElement;
        var offset = domList.current.offset;
        offset--;
        if (offset >= domList.items.length || offset < 0)
            offset = domList.items.length - 1;
        target.blur();
        doSlide(offset);
        return false;
    }
    domNextBtn.onclick = function(evt) {
        evt = evt || window.event;
        var target = evt.target || evt.srcElement;
        var offset = domList.current.offset;
        offset++;
        if (offset >= domList.items.length || offset < 0)
            offset = 0;
        target.blur();
        doSlide(offset);
        return false;
}
    domRoot.current = domRoot.list[0];
    domList.current = domList.items[0];
    domRoot.current.style.display = 'block';
    domList.current.className = 'current';
    function doSlide(offset, timeStamp) {
        if (
            timeStamp &&
            (
                domRoot.boolHover ||
                timeStamp != domRoot.timeStamp
                )
                ) return;
        if (typeof(offset) != 'number') {
            offset = domList.current.offset - (-1);
            if (offset >= domList.items.length || offset < 0)
                offset = 0;
        }
        domRoot.current.style.display = 'none';
        domList.current.className = '';
        domRoot.current = domRoot.list[offset];
        domList.current = domList.items[offset];
        domRoot.current.style.display = 'block';
        domList.current.className = 'current';
        if (domRoot.boolHover) return;
        var now = new Date();
        domRoot.timeStamp = now.valueOf();
        window.setTimeout(function() {
            doSlide(null, now.valueOf());
        }, 5000);
}
    domList.onmouseover = domList.onclick = function (evt) {
        evt = evt || window.event;
        var target = evt.target || evt.srcElement;
        while (target && target != domList) {
            if (target.tagName.toLowerCase() == 'a') {
                target.blur();
                doSlide(target.offset);
                return false;
            }
            target = target.parentNode;
        }
    }
    domRoot.onmouseover = domRoot.onmousemove = function() {
        domRoot.boolHover = true;
}
    domRoot.onmouseout = function(evt) {
        domRoot.boolHover = false;
        var now = new Date();
        domRoot.timeStamp = now.valueOf();
        window.setTimeout(function() {
            doSlide(null, now.valueOf());
        }, 5000);
    }
    var now = new Date();
    domRoot.timeStamp = now.valueOf();
    window.setTimeout(function() {
        doSlide(null, now.valueOf());
    }, 5000);
}