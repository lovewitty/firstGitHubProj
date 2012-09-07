using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Cmn
{
    /// <summary>
    /// 字符串操作类
    /// </summary>
    public class Str
    {
        /// <summary>
        /// 截取字符串长度
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">字符串长度</param>
        /// <param name="flg">true:加...,flase:不加</param>
        /// <returns></returns>
        public static string GetStr(string str, int length, bool flg)
        {
            int i = 0, j = 0;
            foreach (char chr in str) {
                if ((int)chr > 127) {  i += 2; } else { i++; }
                if (i > length) {
                    str = str.Substring(0, j);
                    if (flg) str += "...";
                    break;
                }
                j++;
            }
            return str;
        }

        /// <summary>
        /// 去除Html标记，图片
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string GetNoHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring) == true)
            {
                return string.Empty;
            }
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<[^>]*>", "", RegexOptions.Compiled);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", " ", RegexOptions.Compiled);
            return Htmlstring.Replace("&nbsp;", " ");
        }

        /// <summary>
        /// 去除Html标记，图片
        /// </summary>
        /// <param name="Htmlstring">目标Html文本</param>
        /// <param name="maxLen">最大长度</param>
        /// <param name="flag">标记</param>
        /// <returns></returns>
        public static string GetNoHTML(string Htmlstring,int maxLen,bool flag)
        {
            return GetStr(GetNoHTML(Htmlstring), maxLen, flag);
        }

        /// <summary>
        /// 返回无图片的纯Html的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLen"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        public static string GetNoImgStr(string str, int maxLen, bool flg)
        {
            return Cmn.Str.GetStr(Regex.Replace(str, "<\\w+\\s[^>]*>", ""), maxLen, flg);
        }

        /// <summary>
        /// 返回中文字符的长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回中文字符的长度</returns>
        public static int cnLength(string str)
        { 
            int i = 0;
            foreach (char chr in str) {
                if ((int)chr > 127) {  i += 2; } else { i++; }
            }
            return i;
        }
        /// <summary>
        /// 截取字符串+…
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intlen"></param>
        /// <returns></returns>
        public static string CutStr(string strInput, int intlen)//截取字符串
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int intLength = 0;
            string strString = "";
            byte[] s = ascii.GetBytes(strInput);
            for (int i = 0; i < s.Length; i++) {
                if ((int)s[i] == 63) { intLength += 2; } else { intLength += 1; }
                try { strString += strInput.Substring(i, 1); } catch { break; }
                if (intLength > intlen) { break; }
            }
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(strInput);
            if (mybyte.Length > intlen) {strString += "…"; }//如果截过则加上半个省略号
            return strString;
        }

        /// <summary>
        /// 是否匹配正则表达式
        /// </summary>
        /// <param name="op">表达式</param>
        /// <param name="str">字符串</param>
        /// <returns>完全匹配返回真</returns>
        public static bool isMatch(string op, string str)
        {
            if (str.Equals(String.Empty) || str == null) return false;
            Regex re = new Regex(op, RegexOptions.IgnoreCase);
            return re.IsMatch(str);
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string UrlEncoding(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Text.Encoding.UTF8.GetString(bytes).ToString();
        }

        /// <summary>
        /// HTML Encode
        /// </summary>
        /// <param name="strInput">HTML代码</param>
        /// <returns>HtmlEncode</returns>
        public static string HtmlEncode(string strInput)
        {
            return HttpContext.Current.Server.HtmlEncode(strInput);
        }

        /// <summary>
        /// HTML Decode
        /// </summary>
        /// <param name="strInput">HTML代码</param>
        /// <returns>HtmlDecode</returns>
        public static string HtmlDecode(string strInput)
        {
            return HttpContext.Current.Server.HtmlDecode(strInput);
        }

        /// <summary>
        /// 取文件扩展名
        /// </summary>
        /// <param name="fileName">文件URL</param>
        /// <returns>文件扩展名</returns>
        public static string GetFileExtends(string fileName)
        {
            string ext = null;
            if (fileName.IndexOf('.') > 0) {
                string[] fs = fileName.Split('.');
                ext = fs[fs.Length - 1];
            }
            return ext;
        }

        /// <summary>
        /// 执行正则提取出值 GetregValue("<title>.+?</title>",htmlCode)
        /// </summary>
        /// <param name="regexString">正则表达式</param>
        /// <param name="htmlCode">HTML代码</param>
        /// <returns></returns>
        public static string GetRegexValue(string regexString, string htmlCode)
        {
            foreach (Match m in Regex.Matches(htmlCode, regexString, RegexOptions.IgnoreCase)) { return m.Value; }

            return "";
        }
        //----------------------------------------------------------
        /// <summary>
        /// 用正则替换字符串中的子串
        /// </summary>
        /// <param name="sourceStr">原字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="replaceStr">要将替换成的字符串</param>
        /// <returns></returns>
        public static string Replace(string sourceStr,string regex,string replaceStr)
        {
            string _retValue = sourceStr;

            foreach (Match m in Regex.Matches(sourceStr, regex, RegexOptions.IgnoreCase)) {
                _retValue = _retValue.Replace(m.Value,replaceStr);             
            }

            return _retValue;
        }
        //-----------------------------------------------------------
        /// <summary>
        /// 替换HTML源代码
        /// </summary>
        /// <param name="htmlCode">html源代码</param>
        /// <returns></returns>
        public static string RemoveHTML(string htmlCode)
        {
            string MatchVale = htmlCode;
            MatchVale = new Regex("<br>", RegexOptions.IgnoreCase).Replace(MatchVale, "\n");
            foreach (Match s in Regex.Matches(htmlCode, "<[^{><}]*>")) { MatchVale = MatchVale.Replace(s.Value, ""); }//"(<[^{><}]*>)"//@"<[\s\S-! ]*?>"//"<.+?>"//<[^\>]+\>
            MatchVale = new Regex("\n", RegexOptions.IgnoreCase).Replace(MatchVale, "<br>");
            return MatchVale;
        }

        /// <summary>
        /// 获取页面的链接正则 GetHref(htmlCode);
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <returns></returns>
        public static string GetHref(string htmlCode)
        {
            string MatchVale = "";
            string Reg = @"(h|H)(r|R)(e|E)(f|F) *= *('|"")?((\w|\\|\/|\.|:|-|_)+)('|""| *|>)?";
            foreach (Match m in Regex.Matches(htmlCode, Reg)) {
                MatchVale += (m.Value).ToLower().Replace("href=", "").Trim() + "||";
            }
            return MatchVale;
        }

        /// <summary>
        /// 匹配页面的图片地址 GetImgSrc(htmlCode,"http://www.baidu.com/");当比如:&lt;img src="bb/x.gif">则要补充http://www.baidu.com/,当包含http信息时,则可以为空
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <param name="imgHttp">要补充的http://路径信息</param>
        /// <returns></returns>
        public static string GetImgSrc(string htmlCode, string imgHttp)
        {
            string MatchVale = "";
            string Reg = @"<img.+?>";
            foreach (Match m in Regex.Matches(htmlCode, Reg)) {
                MatchVale += GetImg((m.Value).ToLower().Trim(), imgHttp) + "||";
            }
            return MatchVale;
        }
        /// <summary>
        /// 匹配<img src="" />中的图片路径实际链接
        /// </summary>
        /// <param name="imgString"><img src="" />字符串</param>
        /// <param name="imgHttp">前面URL</param>
        /// <returns></returns>
        public static string GetImg(string imgString, string imgHttp)
        {
            string MatchVale = "";
            string Reg = @"src=.+\.(bmp|jpg|gif|png|)";
            foreach (Match m in Regex.Matches(imgString.ToLower(), Reg)) {
                MatchVale += (m.Value).ToLower().Trim().Replace("src=", "");
            }
            return (imgHttp + MatchVale);
        }

        /// <summary>
        /// 替换通过正则获取字符串所带的正则首尾匹配字符串
        /// </summary>
        /// <param name="regValue">要替换的值</param>
        /// <param name="regStart">正则匹配的首字符串</param>
        /// <param name="regEnd">正则匹配的尾字符串</param>
        /// <returns></returns>
        public static string RegReplace(string regValue, string regStart, string regEnd)
        {
            string s = regValue;
            if (regValue != "" && regValue != null) {
                if (regStart != "" && regStart != null) { s = s.Replace(regStart, ""); }
                if (regEnd != "" && regEnd != null) { s = s.Replace(regEnd, ""); }
            }
            return s;
        }

        /// <summary>
        /// 替换网页中的换行和引号
        /// </summary>
        /// <param name="htmlCode">HTML源代码</param>
        /// <returns></returns>
        public static string ReplaceEnter(string htmlCode)
        {
            string s = "";
            if (htmlCode == null || htmlCode == "") s = ""; else s = htmlCode.Replace("\"", "");
            s = s.Replace("\r\n", "");
            return s;
        }

        /// <summary>
		/// string型转换为int型
		/// </summary>
		/// <param name="strValue">要转换的字符串</param>
		/// <param name="defValue">缺省值</param>
		/// <returns>转换后的int类型结果</returns>
		public static int ToInt(object strValue, int defValue)
		{
			if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
				return defValue;
			string val = strValue.ToString();
			string firstletter = val[0].ToString();
			if(val.Length == 10 && Valid.isNumber(firstletter) && int.Parse(firstletter) > 1)
				return defValue;
			else if (val.Length == 10 && !Valid.isNumber(firstletter))
				return defValue;
			int intValue = defValue;
			if (strValue != null) {
				bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
				if (IsInt) intValue = Convert.ToInt32(strValue);
			}
			return intValue;
        }

        /// <summary>
		/// 字符串如果操过指定长度则将超出的部分用指定字符串代替
		/// </summary>
		/// <param name="p_SrcString">要检查的字符串</param>
		/// <param name="p_Length">指定长度</param>
		/// <param name="p_TailString">用于替换的字符串</param>
		/// <returns>截取后的字符串</returns>
		public static string GetSubString(string p_SrcString, int p_Length, string p_TailString) 
		{ 
			string myResult = p_SrcString; 
			if (p_Length >= 0)  { 
				byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString); 
				if (bsSrcString.Length > p_Length) { 
					int nRealLength = p_Length; 
					int[] anResultFlag = new int[p_Length]; 
					byte[] bsResult = null; 

					int nFlag = 0; 
					for (int i = 0; i < p_Length; i++)  { 
						if (bsSrcString[i] > 127)  { 
							nFlag++; 
							if (nFlag == 3) nFlag = 1; 
						} else nFlag = 0; 
						anResultFlag[i] = nFlag; 
					} 
					if ((bsSrcString[p_Length - 1] > 127) && (anResultFlag[p_Length - 1] == 1)) 
						nRealLength = p_Length + 1; 
					bsResult = new byte[nRealLength]; 
					Array.Copy(bsSrcString, bsResult, nRealLength); 
					myResult = Encoding.Default.GetString(bsResult); 
					myResult = myResult + p_TailString; 
				} 
			} 
			return myResult;
        }
    }
}
