using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Cmn
{
    /// <summary>
    /// �ַ���������
    /// </summary>
    public class Str
    {
        /// <summary>
        /// ��ȡ�ַ�������
        /// </summary>
        /// <param name="str">Ҫ��ȡ���ַ���</param>
        /// <param name="length">�ַ�������</param>
        /// <param name="flg">true:��...,flase:����</param>
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
        /// ȥ��Html��ǣ�ͼƬ
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
        /// ȥ��Html��ǣ�ͼƬ
        /// </summary>
        /// <param name="Htmlstring">Ŀ��Html�ı�</param>
        /// <param name="maxLen">��󳤶�</param>
        /// <param name="flag">���</param>
        /// <returns></returns>
        public static string GetNoHTML(string Htmlstring,int maxLen,bool flag)
        {
            return GetStr(GetNoHTML(Htmlstring), maxLen, flag);
        }

        /// <summary>
        /// ������ͼƬ�Ĵ�Html���ַ���
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
        /// ���������ַ��ĳ���
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>���������ַ��ĳ���</returns>
        public static int cnLength(string str)
        { 
            int i = 0;
            foreach (char chr in str) {
                if ((int)chr > 127) {  i += 2; } else { i++; }
            }
            return i;
        }
        /// <summary>
        /// ��ȡ�ַ���+��
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intlen"></param>
        /// <returns></returns>
        public static string CutStr(string strInput, int intlen)//��ȡ�ַ���
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
            if (mybyte.Length > intlen) {strString += "��"; }//����ع�����ϰ��ʡ�Ժ�
            return strString;
        }

        /// <summary>
        /// �Ƿ�ƥ��������ʽ
        /// </summary>
        /// <param name="op">���ʽ</param>
        /// <param name="str">�ַ���</param>
        /// <returns>��ȫƥ�䷵����</returns>
        public static bool isMatch(string op, string str)
        {
            if (str.Equals(String.Empty) || str == null) return false;
            Regex re = new Regex(op, RegexOptions.IgnoreCase);
            return re.IsMatch(str);
        }

        /// <summary>
        /// URL����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns></returns>
        public static string UrlEncoding(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Text.Encoding.UTF8.GetString(bytes).ToString();
        }

        /// <summary>
        /// HTML Encode
        /// </summary>
        /// <param name="strInput">HTML����</param>
        /// <returns>HtmlEncode</returns>
        public static string HtmlEncode(string strInput)
        {
            return HttpContext.Current.Server.HtmlEncode(strInput);
        }

        /// <summary>
        /// HTML Decode
        /// </summary>
        /// <param name="strInput">HTML����</param>
        /// <returns>HtmlDecode</returns>
        public static string HtmlDecode(string strInput)
        {
            return HttpContext.Current.Server.HtmlDecode(strInput);
        }

        /// <summary>
        /// ȡ�ļ���չ��
        /// </summary>
        /// <param name="fileName">�ļ�URL</param>
        /// <returns>�ļ���չ��</returns>
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
        /// ִ��������ȡ��ֵ GetregValue("<title>.+?</title>",htmlCode)
        /// </summary>
        /// <param name="regexString">������ʽ</param>
        /// <param name="htmlCode">HTML����</param>
        /// <returns></returns>
        public static string GetRegexValue(string regexString, string htmlCode)
        {
            foreach (Match m in Regex.Matches(htmlCode, regexString, RegexOptions.IgnoreCase)) { return m.Value; }

            return "";
        }
        //----------------------------------------------------------
        /// <summary>
        /// �������滻�ַ����е��Ӵ�
        /// </summary>
        /// <param name="sourceStr">ԭ�ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <param name="replaceStr">Ҫ���滻�ɵ��ַ���</param>
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
        /// �滻HTMLԴ����
        /// </summary>
        /// <param name="htmlCode">htmlԴ����</param>
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
        /// ��ȡҳ����������� GetHref(htmlCode);
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
        /// ƥ��ҳ���ͼƬ��ַ GetImgSrc(htmlCode,"http://www.baidu.com/");������:&lt;img src="bb/x.gif">��Ҫ����http://www.baidu.com/,������http��Ϣʱ,�����Ϊ��
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <param name="imgHttp">Ҫ�����http://·����Ϣ</param>
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
        /// ƥ��<img src="" />�е�ͼƬ·��ʵ������
        /// </summary>
        /// <param name="imgString"><img src="" />�ַ���</param>
        /// <param name="imgHttp">ǰ��URL</param>
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
        /// �滻ͨ�������ȡ�ַ���������������βƥ���ַ���
        /// </summary>
        /// <param name="regValue">Ҫ�滻��ֵ</param>
        /// <param name="regStart">����ƥ������ַ���</param>
        /// <param name="regEnd">����ƥ���β�ַ���</param>
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
        /// �滻��ҳ�еĻ��к�����
        /// </summary>
        /// <param name="htmlCode">HTMLԴ����</param>
        /// <returns></returns>
        public static string ReplaceEnter(string htmlCode)
        {
            string s = "";
            if (htmlCode == null || htmlCode == "") s = ""; else s = htmlCode.Replace("\"", "");
            s = s.Replace("\r\n", "");
            return s;
        }

        /// <summary>
		/// string��ת��Ϊint��
		/// </summary>
		/// <param name="strValue">Ҫת�����ַ���</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>ת�����int���ͽ��</returns>
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
		/// �ַ�������ٹ�ָ�������򽫳����Ĳ�����ָ���ַ�������
		/// </summary>
		/// <param name="p_SrcString">Ҫ�����ַ���</param>
		/// <param name="p_Length">ָ������</param>
		/// <param name="p_TailString">�����滻���ַ���</param>
		/// <returns>��ȡ����ַ���</returns>
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
