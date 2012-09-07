/*
	[Discuz!] (C)2001-2007 Comsenz Inc.
	This is NOT a freeware, use is subject to license terms
	Download by http://www.codefans.net
	$RCSfile: post.js,v $
	$Revision: 1.27 $
	$Date: 2007/08/06 08:27:23 $
*/

var postSubmited = false;
var smdiv = new Array();
var codecount = '-1';
var codehtml = new Array();

function AddText(txt) {
	obj = $('postform').message;
	selection = document.selection;
	checkFocus();
	if(!isUndefined(obj.selectionStart)) {
		var opn = obj.selectionStart + 0;
		obj.value = obj.value.substr(0, obj.selectionStart) + txt + obj.value.substr(obj.selectionEnd);
	} else if(selection && selection.createRange) {
		var sel = selection.createRange();
		sel.text = txt;
		sel.moveStart('character', -strlen(txt));
	} else {
		obj.value += txt;
	}
}

function checkFocus() {
	var obj = typeof wysiwyg == 'undefined' || !wysiwyg ? $('postform').message : editwin;
	if(!obj.hasfocus) {
		obj.focus();
	}
}

function validate(theform) {
	var message = wysiwyg ? html2bbcode(getEditorContents()) : parseurl(theform.message.value);
	theform.message.value = message;
	return true;
}

//ctrl+enter 提交
function ctlent(event) {
	if(postSubmited == false && (event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83) && $('postsubmit')) {
		if(in_array($('postsubmit').name, ['topicsubmit', 'replysubmit', 'editsubmit'])) {
			doane(event);
			return;
		}		
		postSubmited = true;
		$('postsubmit').disabled = true;
		$('postform').submit();
	}
}

// 解析URL
function parseurl(str, mode, parsecode) {
	if(!parsecode) str= str.replace(/\s*\[code\]([\s\S]+?)\[\/code\]\s*/ig, function($1, $2) {return codetag($2);});
	str = str.replace(/([^>=\]"'\/]|^)((((https?|ftp):\/\/)|www\.)([\w\-]+\.)*[\w\-\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!]*)+\.(jpg|gif|png|bmp))/ig, mode == 'html' ? '$1<img src="$2" border="0">' : '$1[img]$2[/img]');
	str = str.replace(/([^>=\]"'\/@]|^)((((https?|ftp|gopher|news|telnet|rtsp|mms|callto|bctp|ed2k|thunder|synacast):\/\/))([\w\-]+\.)*[:\.@\-\w\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!#]*)*)/ig, mode == 'html' ? '$1<a href="$2" target="_blank">$2</a>' : '$1[url]$2[/url]');
	str = str.replace(/([^\w>=\]"'\/@]|^)((www\.)([\w\-]+\.)*[:\.@\-\w\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!#]*)*)/ig, mode == 'html' ? '$1<a href="$2" target="_blank">$2</a>' : '$1[url]$2[/url]');
	str = str.replace(/([^\w->=\]:"'\.\/]|^)(([\-\.\w]+@[\.\-\w]+(\.\w+)+))/ig, mode == 'html' ? '$1<a href="mailto:$2">$2</a>' : '$1[email]$2[/email]');
	if(!parsecode) {
		for(var i = 0; i <= codecount; i++) {
			str = str.replace("[\tDISCUZ_CODE_" + i + "\t]", codehtml[i]);
		}
	}
	return str;
}

// 处理[CODE] 将[code][/code] 间的数据填入 codehtml 返回 codecount
function codetag(text) {
	codecount++;
	if(typeof wysiwyg != 'undefined' && wysiwyg) text = text.replace(/<br[^\>]*>/ig, '\n').replace(/<(\/|)[A-Za-z].*?>/ig, '');
	codehtml[codecount] = '[code]' + text + '[/code]';
	return '[\tDISCUZ_CODE_' + codecount + '\t]';
}

// 验证内容长度
function checklength(theform) {
	var message = wysiwyg ? html2bbcode(getEditorContents()) : (!theform.parseurloff.checked ? parseurl(theform.message.value) : theform.message.value);
	var showmessage = postmaxchars != 0 ? '系统限制: ' + postminchars + ' 到 ' + postmaxchars + ' 字节' : '';
	alert('\n当前长度: ' + mb_strlen(message) + ' 字节\n\n' + showmessage);
}

// 恢复保存的编辑器数据
function loadData(quiet) {
	var message = '';
	if(is_ie) {
		try {
			textobj.load('Discuz!');
			var oXMLDoc = textobj.XMLDocument;
			var nodes = oXMLDoc.documentElement.childNodes;
			message = nodes.item(nodes.length - 1).getAttribute('message');
		} catch(e) {}
	} else if(window.sessionStorage) {
		try {
			message = sessionStorage.getItem('Discuz!');
		} catch(e) {}
	}
	message = message.toString();

	if(in_array((message = trim(message)), ['', 'null', 'false', null, false])) {
		if(!quiet) {
			alert('没有可以恢复的数据！');
		}
		return;
	}

	if(!quiet && !confirm('此操作将覆盖当前帖子内容，确定要恢复数据吗？')) {
		return;
	}

	var formdata = message.split(/\x09\x09/);
	for(var i = 0; i < $('postform').elements.length; i++) {
		var el = $('postform').elements[i];
		if(el.name != '' && (el.tagName == 'TEXTAREA' || el.tagName == 'INPUT' && (el.type == 'text' || el.type == 'checkbox' || el.type == 'radio'))) {
			for(var j = 0; j < formdata.length; j++) {
				var ele = formdata[j].split(/\x09/);
				if(ele[0] == el.name) {
					elvalue = !isUndefined(ele[3]) ? ele[3] : '';
					if(ele[1] == 'INPUT') {
						if(ele[2] == 'text') {
							el.value = elvalue;
						} else if((ele[2] == 'checkbox' || ele[2] == 'radio') && ele[3] == el.value) {
							el.checked = true;
							evalevent(el);
						}
					} else if(ele[1] == 'TEXTAREA') {
						if(ele[0] == 'message') {
							if(typeof wysiwyg == 'undefined' || !wysiwyg) {
								textobj.value = elvalue;
							} else {
								editdoc.body.innerHTML = bbcode2html(elvalue);
							}
						} else {
							el.value = elvalue;
						}
					}
					break
				}
			}
		}
	}
}

// 自动保存编辑器数据
var autosaveDatai, autosaveDatatime;
function autosaveData(op) {
	var autosaveInterval = 60;
	obj = $(editorid + '_cmd_autosave');
	if(op) {
		if(op == 2) {
			saveData(wysiwyg ? editdoc.body.innerHTML : textobj.value);
		} else {
			setcookie('disableautosave', '', -2592000);
		}
		autosaveDatatime = autosaveInterval;
		autosaveDatai = setInterval(function() {
			autosaveDatatime--;
			if(autosaveDatatime == 0) {
				saveData(wysiwyg ? editdoc.body.innerHTML : textobj.value);
				autosaveDatatime = autosaveInterval;
			}
			if($('autsavet')) {
				$('autsavet').innerHTML = '(' + autosaveDatatime + '秒' + ')';
			}
		}, 1000);
		obj.onclick = function() { autosaveData(0); }
	} else {
		setcookie('disableautosave', 1, 2592000);
		clearInterval(autosaveDatai);
		$('autsavet').innerHTML = '(已停止)';
		obj.onclick = function() { autosaveData(1); }
	}
}

// 执行指定对象的 onclik 事件
function evalevent(obj) {
	var script = obj.parentNode.innerHTML;
	var re = /onclick="(.+?)["|>]/ig;
	var matches = re.exec(script);
	if(matches != null) {
		matches[1] = matches[1].replace(/this\./ig, 'obj.');
		eval(matches[1]);
	}
}

// 保存编辑器数据
function saveData(data, del) {
	if(!data && isUndefined(del)) {
		return;
	}
	if(typeof wysiwyg != 'undefined' && typeof editorid != 'undefined' && $(editorid + '_mode') && $(editorid + '_mode').value == 1) {
		data = html2bbcode(data);
	}
	var formdata = '';
	if(isUndefined(del)) {
		for(var i = 0; i < $('postform').elements.length; i++) {
			var el = $('postform').elements[i];
			if(el.name != '' && (el.tagName == 'TEXTAREA' || el.tagName == 'INPUT' && (el.type == 'text' || el.type == 'checkbox' || el.type == 'radio')) && el.name.substr(0, 6) != 'attach') {
				var elvalue = el.name == 'message' ? data : el.value;
				if((el.type == 'checkbox' || el.type == 'radio') && !el.checked) {
					continue;
				}
				formdata += el.name + String.fromCharCode(9) + el.tagName + String.fromCharCode(9) + el.type + String.fromCharCode(9) + elvalue + String.fromCharCode(9, 9);
			}
		}
	}
	if(is_ie) {
		try {
			var oXMLDoc = textobj.XMLDocument;
			var root = oXMLDoc.firstChild;
			if(root.childNodes.length > 0) {
				root.removeChild(root.firstChild);
			}
			var node = oXMLDoc.createNode(1, 'POST', '');
			var oTimeNow = new Date();
			oTimeNow.setHours(oTimeNow.getHours() + 24);
			textobj.expires = oTimeNow.toUTCString();
			node.setAttribute('message', formdata);
			oXMLDoc.documentElement.appendChild(node);
			textobj.save('Discuz!');
		} catch(e) {}
	} else if(window.sessionStorage) {
		try {
			sessionStorage.setItem('Discuz!', formdata);
		} catch(e) {}
	}
}

// 删除保存的编辑器数据
function deleteData() {
	if(is_ie) {
		saveData('', 'delete');
	} else if(window.sessionStorage) {
		try {
			sessionStorage.removeItem('Discuz!');
		} catch(e) {}
	}
}

function setCaretAtEnd() {
	if(typeof wysiwyg != 'undefined' && wysiwyg) {
		editdoc.body.innerHTML += '';
	} else {
		editdoc.value += '';
	}
}

// 主题图标选择
function switchicon(iconid, obj) {
	$('iconid').value = iconid;
	$('icon_img').src = obj.src;
	hideMenu();
}


var Editorwin = 0;
var editbox = editwin = editdoc = editcss = null;
var cursor = -1;
var stack = new Array();
var initialized = false;

function newEditor(mode, initialtext) {
	wysiwyg = parseInt(mode);
	if(!(is_ie || is_moz || (is_opera >= 9))) {
		allowswitcheditor = wysiwyg = 0;
	}
	if(!allowswitcheditor) {
		$(editorid + '_switcher').style.display = 'none';
	}

	$(editorid + '_cmd_table').style.display = wysiwyg ? '' : 'none';

	if(wysiwyg) {
		if($(editorid + '_iframe')) {
			editbox = $(editorid + '_iframe');
		} else {
			var iframe = document.createElement('iframe');
			editbox = textobj.parentNode.appendChild(iframe);
			editbox.id = editorid + '_iframe';
		}

		editwin = editbox.contentWindow;
		editdoc = editwin.document;
		writeEditorContents(isUndefined(initialtext) ?  textobj.value : initialtext);
	} else {
		editbox = editwin = editdoc = textobj;
		if(!isUndefined(initialtext)) {
			writeEditorContents(initialtext);
		}
		addSnapshot(textobj.value);
	}
	setEditorEvents();
	initEditor();
}

function initEditor() {
	var buttons = $(editorid + '_controls').getElementsByTagName('a');
	for(var i = 0; i < buttons.length; i++) {
		if(buttons[i].id.indexOf(editorid + '_cmd_') != -1) {
			buttons[i].href = 'javascript:;';
			buttons[i].onclick = function(e) {discuzcode(this.id.substr(this.id.lastIndexOf('_cmd_') + 5))};
		} else if(buttons[i].id.indexOf(editorid + '_popup_') != -1) {
			buttons[i].href = 'javascript:;';
			if(!$(buttons[i].id + '_menu') || !$(buttons[i].id + '_menu').getAttribute('clickshow')) {
				buttons[i].onmouseover = function(e) {InFloat = InFloat_Editor;showMenu(this.id, true, 0, 2)};
			} else {
				buttons[i].onclick = function(e) {InFloat = InFloat_Editor;showMenu(this.id, true, 0, 2)};
			}
		}
	}
	setUnselectable($(editorid + '_controls'));
	textobj.onkeydown = function(e) {ctlent(e ? e : event)};
}

function setUnselectable(obj) {
	if(is_ie && is_ie > 4 && typeof obj.tagName != 'undefined') {
		if(obj.hasChildNodes()) {
			for(var i = 0; i < obj.childNodes.length; i++) {
				setUnselectable(obj.childNodes[i]);
			}
		}
		obj.unselectable = 'on';
	}
}

function writeEditorContents(text) {
	if(wysiwyg) {
		if(text == '' && is_moz) {
			text = '<br />';
		}
		if(initialized && !(is_moz && is_moz >= 3)) {
			editdoc.body.innerHTML = text;
		} else {
			editdoc.designMode = 'on';
			editdoc = editwin.document;
			editdoc.open('text/html', 'replace');
			editdoc.write(text);
			editdoc.close();
			editdoc.body.contentEditable = true;
			initialized = true;
		}
	} else {
		textobj.value = text;
	}

	setEditorStyle();

}

function getEditorContents() {
	return wysiwyg ? editdoc.body.innerHTML : editdoc.value;
}

function setEditorStyle() {
	if(wysiwyg) {
		textobj.style.display = 'none';
		editbox.style.display = '';
		editbox.className = textobj.className;

		if(editcss == null) {
			var cssarray = [editorcss, editorcss_editor];
			for(var i = 0; i < 2; i++) {
				editcss = editdoc.createElement('link');
				editcss.type = 'text/css';
				editcss.rel = 'stylesheet';
				editcss.href = cssarray[i];
				var headNode = editdoc.getElementsByTagName("head")[0];
				headNode.appendChild(editcss);
			}
		}

		if(is_moz || is_opera) {
			editbox.style.border = '0px';
		} else if(is_ie) {
			editdoc.body.style.border = '0px';
			editdoc.body.addBehavior('#default#userData');
		}
		editbox.style.width = textobj.style.width;
		editbox.style.height = textobj.style.height;
		editdoc.body.style.backgroundColor = TABLEBG;
		editdoc.body.style.textAlign = 'left';
		editdoc.body.id = 'wysiwyg';

	} else {
		var iframe = textobj.parentNode.getElementsByTagName('iframe')[0];
		if(iframe) {
			textobj.style.display = '';
			textobj.style.width = iframe.style.width;
			textobj.style.height = iframe.style.height;
			iframe.style.display = 'none';
		}
	}
}

function setEditorEvents() {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			editwin.addEventListener('focus', function(e) {this.hasfocus = true;}, true);
			editwin.addEventListener('blur', function(e) {this.hasfocus = false;}, true);
			editwin.addEventListener('keydown', function(e) {ctlent(e);}, true);
		} else {
			if(editdoc.attachEvent) {
				editdoc.body.attachEvent("onkeydown", ctlent);
			}
		}
	}
	editwin.onfocus = function(e) {this.hasfocus = true;};
	editwin.onblur = function(e) {this.hasfocus = false;};
}

function wrapTags(tagname, useoption, selection) {

	if(isUndefined(selection)) {
		var selection = getSel();
		if(selection === false) {
			selection = '';
		} else {
			selection += '';
		}
	}

	if(useoption !== false) {
		var opentag = '[' + tagname + '=' + useoption + ']';
	} else {
		var opentag = '[' + tagname + ']';
	}

	var closetag = '[/' + tagname + ']';
	var text = opentag + selection + closetag;

	insertText(text, strlen(opentag), strlen(closetag), in_array(tagname, ['code', 'quote', 'free', 'hide']) ? true : false);

}

function applyFormat(cmd, dialog, argument) {
	if(wysiwyg) {
		editdoc.execCommand(cmd, (isUndefined(dialog) ? false : dialog), (isUndefined(argument) ? true : argument));
		return;
	}
	switch(cmd) {
		case 'bold':
		case 'italic':
		case 'underline':
			wrapTags(cmd.substr(0, 1), false);
			break;
		case 'justifyleft':
		case 'justifycenter':
		case 'justifyright':
			wrapTags('align', cmd.substr(7));
			break;
		case 'floatleft':
		case 'floatright':
			wrapTags('float', cmd.substr(5));
			break;
		case 'indent':
			wrapTags(cmd, false);
			break;
		case 'fontname':
			wrapTags('font', argument);
			break;
		case 'fontsize':
			wrapTags('size', argument);
			break;
		case 'forecolor':
			wrapTags('color', argument);
			break;
		case 'createlink':
			var sel = getSel();
			if(sel) {
				wrapTags('url', argument);
			} else {
				wrapTags('url', argument, argument);
			}
			break;
		case 'insertimage':
			wrapTags('img', false, argument);
			break;
	}
}

function getCaret() {
	if(wysiwyg) {
		var obj = editdoc.body;
		var s = document.selection.createRange();
		s.setEndPoint("StartToStart", obj.createTextRange());
		return s.text.replace(/\r?\n/g, ' ').length;
	} else {
		var obj = editbox;
		var wR = document.selection.createRange();
		obj.select();
		var aR = document.selection.createRange();
		wR.setEndPoint("StartToStart", aR);
		var len = wR.text.replace(/\r?\n/g, ' ').length;
		wR.collapse(false);
		wR.select();
		return len;
	}
}

function setCaret(pos) {
	var obj = wysiwyg ? editdoc.body : editbox;
	var r = obj.createTextRange();
	r.moveStart('character', pos);
	r.collapse(true);
	r.select();
}

// 插入连接
function insertlink(cmd) {
	var sel;
	if(is_ie) {
		sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();
		var pos = getCaret();
	}
	var selection = sel ? (wysiwyg ? sel.htmlText : sel.text) : getSel();
	var ctrlid = editorid + '_cmd_' + cmd;
	var tag = cmd == 'insertimage' ? 'img' : (cmd == 'createlink' ? 'url' : 'email');
	var str = (tag == 'img' ? '请输入图片链接地址:' : (tag == 'url' ? '请输入链接的地址:' : '请输入此链接的邮箱地址:')) + '<br /><input type="text" id="' + ctrlid + '_param_1" style="width: 98%" value="" class="txt" />';
	var div = editorMenu(ctrlid, str);
	$(ctrlid + '_param_1').focus();
	$(ctrlid + '_param_1').onkeydown = editorMenuEvent_onkeydown;
	$(ctrlid + '_submit').onclick = function() {
		checkFocus();
		if(is_ie) {
			setCaret(pos);
		}
		var input = $(ctrlid + '_param_1').value;
		if(input != '') {
			var v = selection ? selection : input;
			var href = tag != 'email' && /^(www\.)/.test(input) ? 'http://' + input : input;
			var text = wysiwyg ? (tag == 'img' ? '<img src="' + input + '" border="0">' : '<a href="' + (tag == 'email' ? 'mailto:' : '') + href + '">' + v + '</a>') : (tag == 'img' ? '[' + tag + ']' + input + '[/' + tag + ']' : '[' + tag + '=' + href + ']' + v + '[/' + tag + ']');
			var closetaglen = tag == 'email' ? 8 : 6;
			if(wysiwyg) insertText(text, text.length - v.length, 0, (selection ? true : false), sel);
			else insertText(text, text.length - v.length - closetaglen, closetaglen, (selection ? true : false), sel);
		}
		hideMenu();
		div.parentNode.removeChild(div);
	}
}

// 插入表情
function insertSmiley(smilieid) {
	checkFocus();
	var src = $('smilie_' + smilieid).src;
	var code = $('smilie_' + smilieid).alt;
	if(typeof wysiwyg != 'undefined' && wysiwyg && allowsmilies && (!$('smileyoff') || $('smileyoff').checked == false)) {
		if(is_moz) {
			applyFormat('InsertImage', false, src);
			var smilies = editdoc.body.getElementsByTagName('img');
			for(var i = 0; i < smilies.length; i++) {
				if(smilies[i].src == src && smilies[i].getAttribute('smilieid') < 1) {
					smilies[i].setAttribute('smilieid', smilieid);
					smilies[i].setAttribute('border', "0");
				}
			}
		} else {
			insertText('<img src="' + src + '" border="0" smilieid="' + smilieid + '" alt="" /> ', false);
		}
	} else {
		code += ' ';
		AddText(code);
	}
	hideMenu();
}

function editorMenuEvent_onkeydown(e) {
	e = e ? e : event;
	var ctrlid = this.id.substr(0, this.id.lastIndexOf('_param_'));
	if((this.type == 'text' && e.keyCode == 13) || (this.type == 'textarea' && e.ctrlKey && e.keyCode == 13)) {
		$(ctrlid + '_submit').click();
		doane(e);
	} else if(e.keyCode == 27) {
		hideMenu();
		$(ctrlid + '_menu').parentNode.removeChild($(ctrlid + '_menu'));
	}
}
// 自定义ubb标签
function customTags(tagname, params) {
	var sel;
	if(is_ie) {
		sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();
		var pos = getCaret();
	}
	var selection = sel ? (wysiwyg ? sel.htmlText : sel.text) : getSel();
	var opentag = '[' + tagname + ']';
	var closetag = '[/' + tagname + ']';
	var haveSel = selection == null || selection == false || in_array(trim(selection), ['', 'null', 'undefined', 'false']) ? 0 : 1;
	if(params == 1 && haveSel) {
		return insertText((opentag + selection + closetag), strlen(opentag), strlen(closetag), true, sel);
	}
	var ctrlid = editorid + '_cmd_custom' + params + '_' + tagname;
	var ordinal = {1 : 'first', 2 : 'second', 3 : 'third'}
	var promptlang = custombbcodes[tagname]['prompt'].split("\t");
	var str = '';
	for(var i = 1; i <= params; i++) {
		if(i != params || !haveSel) {
			str += (promptlang[i - 1] ? promptlang[i - 1] : 'Please input the ' + ordinal[i] + ' parameter:') + '<br /><input type="text" id="' + ctrlid + '_param_' + i + '" style="width: 98%" value="" class="txt" />' + (i < params ? '<br />' : '');
		}
	}
	var div = editorMenu(ctrlid, str);
	$(ctrlid + '_param_1').focus();
	for(var i = 1; i <= params; i++) {if(i != params || !haveSel) $(ctrlid + '_param_' + i).onkeydown = editorMenuEvent_onkeydown;}
	$(ctrlid + '_submit').onclick = function() {
		var first = $(ctrlid + '_param_1').value;
		if($(ctrlid + '_param_2')) var second = $(ctrlid + '_param_2').value;
		if($(ctrlid + '_param_3')) var third = $(ctrlid + '_param_3').value;
		checkFocus();
		if(is_ie) {
			setCaret(pos);
		}
		if((params == 1 && first) || (params == 2 && first && (haveSel || second)) || (params == 3 && first && second && (haveSel || third))) {
			var text;
			if(params == 1) {
				text = first;
			} else if(params == 2) {
				text = haveSel ? selection : second;
				opentag = '[' + tagname + '=' + first + ']';
			} else {
				text = haveSel ? selection : third;
				opentag = '[' + tagname + '=' + first + ',' + second + ']';
			}
			insertText((opentag + text + closetag), strlen(opentag), strlen(closetag), true, sel);
		}
		hideMenu();
		div.parentNode.removeChild(div);
	};
}

function editorMenu(ctrlid, str) {
	var div = document.createElement('div');
	div.id = ctrlid + '_menu';
	div.style.display = 'none';
	div.className = 'popupmenu_popup popupfix';
	div.style.width = '230px';
	$(editorid + '_controls').appendChild(div);
	div.innerHTML = '<div class="popupmenu_option" unselectable="on">' + str + '<br /><center><input type="button" id="' + ctrlid + '_submit" value="提交" /> &nbsp; <input type="button" onClick="hideMenu();try{div.parentNode.removeChild(' + div.id + ')}catch(e){}" value="取消" /></center></div>';
	InFloat = InFloat_Editor;
	showMenu(ctrlid, true, 0, 3);
	return div;
}

function discuzcode(cmd, arg) {
	if(cmd != 'redo') {
		addSnapshot(getEditorContents());
	}

	checkFocus();

	if(in_array(cmd, ['quote', 'code', 'free', 'hide'])) {
		var sel;
		if(is_ie) {
			sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();
			var pos = getCaret();
		}
		var selection = sel ? (wysiwyg ? sel.htmlText : sel.text) : getSel();
		var opentag = '[' + cmd + ']';
		var closetag = '[/' + cmd + ']';
		if(cmd != 'hide' && selection) {
			return insertText((opentag + selection + closetag), strlen(opentag), strlen(closetag), true, sel);
		}
		var ctrlid = editorid + '_cmd_' + cmd;
		var str = '';
		lang['e_quote'] = '请输入要插入的引用';
		lang['e_code'] = '请输入要插入的代码';
		lang['e_free'] = '请输入要插入的免费信息';
		lang['e_hide'] = '请输入要插入的隐藏内容';
		if(cmd != 'hide' || !selection) {
			str += lang['e_' + cmd] + ':<br /><textarea id="' + ctrlid + '_param_1" style="width: 98%" cols="50" rows="5"></textarea>';
		}
		str += cmd == 'hide' && selection ? '' : '<br />';
		str += cmd == 'hide' ? '<input type="radio" name="' + ctrlid + '_radio" id="' + ctrlid + '_radio_1" class="txt" checked="checked" />只有当浏览者回复本帖时才显示<br /><input type="radio" name="' + ctrlid + '_radio" id="' + ctrlid + '_radio_2" class="txt" />只有当浏览者积分高于 <input type="text" size="3" id="' + ctrlid + '_param_2" class="txt" /> 时才显示' : '';
		var div = editorMenu(ctrlid, str);
		$(ctrlid + '_param_' + (cmd == 'hide' && selection ? 2 : 1)).focus();
		$(ctrlid + '_param_' + (cmd == 'hide' && selection ? 2 : 1)).onkeydown = editorMenuEvent_onkeydown;
		$(ctrlid + '_submit').onclick = function() {
			checkFocus();
			if(is_ie) {
				setCaret(pos);
			}
			if(cmd == 'hide' && $(ctrlid + '_radio_2').checked) {
				var mincredits = parseInt($(ctrlid + '_param_2').value);
				opentag = mincredits > 0 ? '[hide=' + mincredits + ']' : '[hide]';
			}
			var text = selection ? selection : $(ctrlid + '_param_1').value;
			if(wysiwyg) {
				if(cmd == 'code') {
					text = preg_replace(['<', '>'], ['&lt;', '&gt;'], text);
				}
				text = text.replace(/\r?\n/g, '<br />');
			}
			text = opentag + text + closetag;
			insertText(text, strlen(opentag), strlen(closetag), false, sel);
			hideMenu();
			div.parentNode.removeChild(div);
		}
		return;
	} else if(cmd.substr(0, 6) == 'custom') {
		var ret = customTags(cmd.substr(8), cmd.substr(6, 1));
	} else if(!wysiwyg && cmd == 'removeformat') {
		var simplestrip = new Array('b', 'i', 'u');
		var complexstrip = new Array('font', 'color', 'size');

		var str = getSel();
		if(str === false) {
			return;
		}
		for(var tag in simplestrip) {
			str = stripSimple(simplestrip[tag], str);
		}
		for(var tag in complexstrip) {
			str = stripComplex(complexstrip[tag], str);
		}
		insertText(str);
	} else if(!wysiwyg && cmd == 'undo') {
		addSnapshot(getEditorContents());
		moveCursor(-1);
		if((str = getSnapshot()) !== false) {
			editdoc.value = str;
		}
	} else if(!wysiwyg && cmd == 'redo') {
		moveCursor(1);
		if((str = getSnapshot()) !== false) {
			editdoc.value = str;
		}
	} else if(!wysiwyg && in_array(cmd, ['insertorderedlist', 'insertunorderedlist'])) {
		var listtype = cmd == 'insertorderedlist' ? '1' : '';
		var opentag = '[list' + (listtype ? ('=' + listtype) : '') + ']\n';
		var closetag = '[/list]';

		if(txt = getSel()) {
			var regex = new RegExp('([\r\n]+|^[\r\n]*)(?!\\[\\*\\]|\\[\\/?list)(?=[^\r\n])', 'gi');
			txt = opentag + trim(txt).replace(regex, '$1[*]') + '\n' + closetag;
			insertText(txt, strlen(txt), 0);
		} else {
			insertText(opentag + closetag, opentag.length, closetag.length);

			while(listvalue = prompt('输入一个列表项目.\r\n留空或者点击取消完成此列表.', '')) {
				if(is_opera > 8) {
					listvalue = '\n' + '[*]' + listvalue;
					insertText(listvalue, strlen(listvalue) + 1, 0);
				} else {
					listvalue = '[*]' + listvalue + '\n';
					insertText(listvalue, strlen(listvalue), 0);
				}
			}
		}
	} else if(!wysiwyg && cmd == 'outdent') {
		var sel = getSel();
		sel = stripSimple('indent', sel, 1);
		insertText(sel);
	} else if(cmd == 'createlink') {
		insertlink('createlink');
	} else if(!wysiwyg && cmd == 'unlink') {
		var sel = getSel();
		sel = stripSimple('url', sel);
		sel = stripComplex('url', sel);
		insertText(sel);
	} else if(cmd == 'email') {
		insertlink('email');
	} else if(cmd == 'insertimage') {
		insertlink('insertimage');
	} else if(cmd == 'table') {
		if(wysiwyg) {
			var selection = getSel();
			if(is_ie) {
				var pos = getCaret();
			}
			var ctrlid = editorid + '_cmd_table';
			var str = '<p>表格行数: <input type="text" id="' + ctrlid + '_param_rows" size="2" value="2" class="txt" /> &nbsp; 表格列数: <input type="text" id="' + ctrlid + '_param_columns" size="2" value="2" class="txt" /></p><p>表格宽度: <input type="text" id="' + ctrlid + '_param_width" size="2" value="" class="txt" /> &nbsp; 背景颜色: <input type="text" id="' + ctrlid + '_param_bgcolor" size="2" class="txt" /></p>';
			var div = editorMenu(ctrlid, str);
			$(ctrlid + '_param_rows').focus();
			var params = ['rows', 'columns', 'width', 'bgcolor'];
			for(var i = 0; i < 4; i++) {$(ctrlid + '_param_' + params[i]).onkeydown = editorMenuEvent_onkeydown;}
			$(ctrlid + '_submit').onclick = function() {
				var rows = $(ctrlid + '_param_rows').value;
				var columns = $(ctrlid + '_param_columns').value;
				var width = $(ctrlid + '_param_width').value;
				var bgcolor = $(ctrlid + '_param_bgcolor').value;
				rows = /^[-\+]?\d+$/.test(rows) && rows > 0 && rows <= 30 ? rows : 2;
				columns = /^[-\+]?\d+$/.test(columns) && columns > 0 && columns <= 30 ? columns : 2;
				width = width.substr(width.length - 1, width.length) == '%' ? (width.substr(0, width.length - 1) <= 98 ? width : '98%') : (width <= 560 ? width : '98%');
				bgcolor = /[\(\)%,#\w]+/.test(bgcolor) ? bgcolor : '';
				var html = '<table cellspacing="0" cellpadding="0" width="' + (width ? width : '50%') + '" class="t_table"' + (bgcolor ? ' bgcolor="' + bgcolor + '"' : '') + '>';
				for (var row = 0; row < rows; row++) {
					html += '<tr>\n';
					for (col = 0; col < columns; col++) {
						html += '<td>&nbsp;</td>\n';
					}
					html+= '</tr>\n';
				}
				html += '</table>\n';
				insertText(html);
				hideMenu();
				div.parentNode.removeChild(div);
			}
		}
		return false;
	} else if(cmd == 'floatleft' || cmd == 'floatright') {
		if(wysiwyg) {
			var selection = getSel();
			if(selection) {
				var ret = insertText('<br style="clear: both"><span style="float: ' + cmd.substr(5) + '">' + selection + '</span>', true);
			}
		} else {
			var ret = applyFormat(cmd, false);
		}
	} else if(cmd == 'loadData') {
		loadData();hideMenu();
	} else if(cmd == 'saveData') {
		autosaveData(2);hideMenu();
	} else if(cmd == 'autosave') {
		if(getcookie('disableautosave')) {
			autosaveData(1);
		} else {
			autosaveData(0);
		}
	} else if(cmd == 'checklength') {
		checklength($('postform'));hideMenu();
	} else if(cmd == 'clearcontent') {
		clearcontent();hideMenu();
	} else {
		try {
			var ret = applyFormat(cmd, false, (isUndefined(arg) ? true : arg));
		} catch(e) {
			var ret = false;
		}
	}

	if(cmd != 'undo') {
		addSnapshot(getEditorContents());
	}
	if(in_array(cmd, ['bold', 'italic', 'underline', 'fontname', 'fontsize', 'forecolor', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'floatleft', 'floatright', 'removeformat', 'unlink', 'undo', 'redo'])) {
		hideMenu();
	}
	return ret;
}

// 文本选择区域
function getSel() {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			selection = editwin.getSelection();
			checkFocus();
			range = selection ? selection.getRangeAt(0) : editdoc.createRange();
			return readNodes(range.cloneContents(), false);
		} else {
			var range = editdoc.selection.createRange();
			if(range.htmlText && range.text) {
				return range.htmlText;
			} else {
				var htmltext = '';
				for(var i = 0; i < range.length; i++) {
					htmltext += range.item(i).outerHTML;
				}
				return htmltext;
			}
		}
	} else {
		if(!isUndefined(editdoc.selectionStart)) {
			return editdoc.value.substr(editdoc.selectionStart, editdoc.selectionEnd - editdoc.selectionStart);
		} else if(document.selection && document.selection.createRange) {
			return document.selection.createRange().text;
		} else if(window.getSelection) {
			return window.getSelection() + '';
		} else {
			return false;
		}
	}
}

function insertText(text, movestart, moveend, select, sel) {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			applyFormat('removeformat');
			var fragment = editdoc.createDocumentFragment();
			var holder = editdoc.createElement('span');
			holder.innerHTML = text;

			while(holder.firstChild) {
				fragment.appendChild(holder.firstChild);
			}
			insertNodeAtSelection(fragment);
		} else {
			checkFocus();
			if(!isUndefined(editdoc.selection) && editdoc.selection.type != 'Text' && editdoc.selection.type != 'None') {
				movestart = false;
				editdoc.selection.clear();
			}

			if(isUndefined(sel)) {
				sel = editdoc.selection.createRange();
			}

			sel.pasteHTML(text);

			if(text.indexOf('\n') == -1) {
				if(!isUndefined(movestart)) {
					sel.moveStart('character', -strlen(text) + movestart);
					sel.moveEnd('character', -moveend);
				} else if(movestart != false) {
					sel.moveStart('character', -strlen(text));
				}
				if(!isUndefined(select) && select) {
					sel.select();
				}
			}
		}
	} else {
		checkFocus();
		if(!isUndefined(editdoc.selectionStart)) {
			var opn = editdoc.selectionStart + 0;
			editdoc.value = editdoc.value.substr(0, editdoc.selectionStart) + text + editdoc.value.substr(editdoc.selectionEnd);

			if(!isUndefined(movestart)) {
				editdoc.selectionStart = opn + movestart;
				editdoc.selectionEnd = opn + strlen(text) - moveend;
			} else if(movestart !== false) {
				editdoc.selectionStart = opn;
				editdoc.selectionEnd = opn + strlen(text);
			}
		} else if(document.selection && document.selection.createRange) {
			if(isUndefined(sel)) {
				sel = document.selection.createRange();
			}
			sel.text = text.replace(/\r?\n/g, '\r\n');
			if(!isUndefined(movestart)) {
				sel.moveStart('character', -strlen(text) +movestart);
				sel.moveEnd('character', -moveend);
			} else if(movestart !== false) {
				sel.moveStart('character', -strlen(text));
			}
			sel.select();
		} else {
			editdoc.value += text;
		}
	}
}

function stripSimple(tag, str, iterations) {
	var opentag = '[' + tag + ']';
	var closetag = '[/' + tag + ']';

	if(isUndefined(iterations)) {
		iterations = -1;
	}
	while((startindex = stripos(str, opentag)) !== false && iterations != 0) {
		iterations --;
		if((stopindex = stripos(str, closetag)) !== false) {
			var text = str.substr(startindex + opentag.length, stopindex - startindex - opentag.length);
			str = str.substr(0, startindex) + text + str.substr(stopindex + closetag.length);
		} else {
			break;
		}
	}
	return str;
}

function stripComplex(tag, str, iterations) {
	var opentag = '[' + tag + '=';
	var closetag = '[/' + tag + ']';

	if(isUndefined(iterations)) {
		iterations = -1;
	}
	while((startindex = stripos(str, opentag)) !== false && iterations != 0) {
		iterations --;
		if((stopindex = stripos(str, closetag)) !== false) {
			var openend = stripos(str, ']', startindex);
			if(openend !== false && openend > startindex && openend < stopindex) {
				var text = str.substr(openend + 1, stopindex - openend - 1);
				str = str.substr(0, startindex) + text + str.substr(stopindex + closetag.length);
			} else {
				break;
			}
		} else {
			break;
		}
	}
	return str;
}

function stripos(haystack, needle, offset) {
	if(isUndefined(offset)) {
		offset = 0;
	}
	var index = haystack.toLowerCase().indexOf(needle.toLowerCase(), offset);

	return (index == -1 ? false : index);
}

// 切换编辑器模式
function switchEditor(mode) {
	mode = parseInt(mode);
	if(mode == wysiwyg || !allowswitcheditor)  {
		return;
	}
	
	if(!mode) {
		var controlbar = $(editorid + '_controls');
		var controls = new Array();
		var buttons = controlbar.getElementsByTagName('a');
		var buttonslength = buttons.length;
		for(var i = 0; i < buttonslength; i++) {
			if(buttons[i].id) {
				controls[controls.length] = buttons[i].id;
			}
		}
		var controlslength = controls.length;
		for(var i = 0; i < controlslength; i++) {
			var control = $(controls[i]);

			if(control.id.indexOf(editorid + '_cmd_') != -1) {
				control.className = control.id.indexOf(editorid + '_cmd_custom') == -1 ? '' : 'plugeditor';
				control.state = false;
				control.mode = 'normal';
			} else if(control.id.indexOf(editorid + '_popup_') != -1) {
				control.state = false;
			}
		}
	}
	cursor = -1;
	stack = new Array();
	var parsedtext = getEditorContents();
	parsedtext = mode ? bbcode2html(parsedtext) : html2bbcode(parsedtext);
	wysiwyg = mode;
	$(editorid + '_mode').value = mode;
	newEditor(mode, parsedtext);
	editwin.focus();
	setCaretAtEnd();
}

function insertNodeAtSelection(text) {
	checkFocus();

	var sel = editwin.getSelection();
	var range = sel ? sel.getRangeAt(0) : editdoc.createRange();
	sel.removeAllRanges();
	range.deleteContents();

	var node = range.startContainer;
	var pos = range.startOffset;

	switch(node.nodeType) {
		case Node.ELEMENT_NODE:
			if(text.nodeType == Node.DOCUMENT_FRAGMENT_NODE) {
				selNode = text.firstChild;
			} else {
				selNode = text;
			}
			node.insertBefore(text, node.childNodes[pos]);
			add_range(selNode);
			break;

		case Node.TEXT_NODE:
			if(text.nodeType == Node.TEXT_NODE) {
				var text_length = pos + text.length;
				node.insertData(pos, text.data);
				range = editdoc.createRange();
				range.setEnd(node, text_length);
				range.setStart(node, text_length);
				sel.addRange(range);
			} else {
				node = node.splitText(pos);
				var selNode;
				if(text.nodeType == Node.DOCUMENT_FRAGMENT_NODE) {
					selNode = text.firstChild;
				} else {
					selNode = text;
				}
				node.parentNode.insertBefore(text, node);
				add_range(selNode);
			}
			break;
	}
}

function add_range(node) {
	checkFocus();
	var sel = editwin.getSelection();
	var range = editdoc.createRange();
	range.selectNodeContents(node);
	sel.removeAllRanges();
	sel.addRange(range);
}

function readNodes(root, toptag) {
	var html = "";
	var moz_check = /_moz/i;

	switch(root.nodeType) {
		case Node.ELEMENT_NODE:
		case Node.DOCUMENT_FRAGMENT_NODE:
			var closed;
			if(toptag) {
				closed = !root.hasChildNodes();
				html = '<' + root.tagName.toLowerCase();
				var attr = root.attributes;
				for(var i = 0; i < attr.length; ++i) {
					var a = attr.item(i);
					if(!a.specified || a.name.match(moz_check) || a.value.match(moz_check)) {
						continue;
					}
					html += " " + a.name.toLowerCase() + '="' + a.value + '"';
				}
				html += closed ? " />" : ">";
			}
			for(var i = root.firstChild; i; i = i.nextSibling) {
				html += readNodes(i, true);
			}
			if(toptag && !closed) {
				html += "</" + root.tagName.toLowerCase() + ">";
			}
			break;

		case Node.TEXT_NODE:
			html = htmlspecialchars(root.data);
			break;
	}
	return html;
}

function moveCursor(increment) {
	var test = cursor + increment;
	if(test >= 0 && stack[test] != null && !isUndefined(stack[test])) {
		cursor += increment;
	}
}

function addSnapshot(str) {
	if(stack[cursor] == str) {
		return;
	} else {
		cursor++;
		stack[cursor] = str;

		if(!isUndefined(stack[cursor + 1])) {
			stack[cursor + 1] = null;
		}
	}
}

function getSnapshot() {
	if(!isUndefined(stack[cursor]) && stack[cursor] != null) {
		return stack[cursor];
	} else {
		return false;
	}
}
// 插入media类型标签
function setmediacode(editorid) {
	insertText('[media='+$(editorid + '_mediatype').value+
		','+$(editorid + '_mediawidth').value+
		','+$(editorid + '_mediaheight').value+
		','+$(editorid + '_mediaautostart').value+']'+
		$(editorid + '_mediaurl').value+'[/media]');
	hideMenu();
}
// 自动判断URL中media类型
function setmediatype(editorid) {
	var ext = $(editorid + '_mediaurl').value.lastIndexOf('.') == -1 ? '' : $(editorid + '_mediaurl').value.substr($(editorid + '_mediaurl').value.lastIndexOf('.') + 1, $(editorid + '_mediaurl').value.length).toLowerCase();
	if(ext == 'rmvb') {
		ext = 'rm';
	}
	if($(editorid + '_mediatyperadio_' + ext)) {
		$(editorid + '_mediatyperadio_' + ext).checked = true;
		$(editorid + '_mediatype').value = ext;
	}
}
// 清空编辑器内容
function clearcontent() {
	if(wysiwyg) {
		editdoc.body.innerHTML = is_moz ? '<br />' : '';
	} else {
		textobj.value = '';
	}
}
openEditor();