var xmlDoc = loadXmlDoc(xmlFile); 

var smthumb = '20';
var smilies_type = new Array();
smilies_type[1] = ['默认', 'default'];
smilies_type[2] = ['酷猴', 'monkey'];
smilies_type[3] = ['呆呆男', 'grapeman'];
var smilies_array = new Array();
smilies_array[1] = new Array();
smilies_array[2] = new Array();
smilies_array[3] = new Array();
smilies_array[1][1] = null;
smilies_array[2][1] = null;
smilies_array[3][1] = null;
var default_list="",monkey_list="",grapeman_list="";
//从XML读取表情
var borwser_type=1;
if(getOs()=="MSIE")
{
    //IE
	borwser_type=1;
	node = xmlDoc.documentElement.childNodes;
}
else
{
    //其他浏览器
	borwser_type=2;
	node = xmlDoc.getElementsByTagName(mode);	
}
for(var i=0;i<node.length;i++)
{
	var id="",code="",imgUrl="",type="";
	if(borwser_type==1)
	{
		id = Trim(node[i].childNodes[0].text);               
		code = Trim(node[i].childNodes[1].text);
		imgUrl = Trim(node[i].childNodes[2].text);
		type = Trim(node[i].childNodes[3].text);
	}
	else
	{
		var value = node[i].textContent.split('\n');
		id = Trim(value[1]);
		code = Trim(value[2]);
		imgUrl = Trim(value[3]);
		type = Trim(value[4]);
	}
	code = code.replace("\\","/").replace("'","\"");
	imgUrl = imgUrl.substring(imgUrl.lastIndexOf("/")+1);
	if(type=="默认")
	{
		default_list += "['"+id+"', '"+code+"','"+imgUrl+"','20','20','20'],";
	}
	else if(type=="酷猴")
	{
		monkey_list += "['"+id+"', '"+code+"','"+imgUrl+"','20','20','20'],";
	}
	else if(type=="呆呆男")
	{
		grapeman_list += "['"+id+"', '"+code+"','"+imgUrl+"','20','20','20'],";
	}
	else{
		//未定义的类别
	}
}
if(default_list.length>1)
{
    default_list = default_list.substr(0,default_list.length-1);
    smilies_array[1][1] = eval("(["+default_list+"])");
}
if(monkey_list.length>1)
{
    monkey_list = monkey_list.substr(0,monkey_list.length-1);
	smilies_array[2][1] = eval("(["+monkey_list+"])");
}
if(grapeman_list.length>1)
{
	grapeman_list = grapeman_list.substr(0,grapeman_list.length-1);
	smilies_array[3][1] = eval("(["+grapeman_list+"])");
}