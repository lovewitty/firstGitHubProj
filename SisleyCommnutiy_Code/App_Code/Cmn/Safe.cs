using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// ��ȫ������
    /// </summary>
    public class Safe
    {
        /// <summary>
        /// ����SQL�ַ���
        /// </summary>
        /// <param name="str">Դ�ַ���</param>
        /// <returns>���˵����ź���ַ���</returns>
        static public String sqlStr(String str)
        {
            str = str.Replace("'", "''");
            return str;
        }

        /// <summary>
        /// ����ʽ���ַ���
        /// </summary>
        /// <param name="htmlStr">Ҫ����ʽ�����ַ���</param>
        /// <returns>����ʽ����ɵ��ַ���</returns>
        public static String unHtml(string htmlStr)
        {
            string str = htmlStr.Replace("''", "'").Replace("\n", "<br />").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace(" ", "&nbsp;").Replace("\0", "");
            return str;
        }

        /// <summary>
        /// ����ʽ���ַ���
        /// </summary>
        /// <param name="htmlStr">Ҫ����ʽ�����ַ���</param>
        /// <returns>����ʽ����ɵ��ַ���</returns>
        public static string showHtml(string htmlStr)
        {
            string str = htmlStr.Replace("''", "'").Replace("\n", "<br />");
            str = str.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            str = str.Replace("\0", "");
            str = new Regex("<script", RegexOptions.IgnoreCase).Replace(str, "<_script");
            str = new Regex("<object", RegexOptions.IgnoreCase).Replace(str, "<_object");
            str = new Regex("javascript:", RegexOptions.IgnoreCase).Replace(str, "_javascript:");
            str = new Regex("vbscript:", RegexOptions.IgnoreCase).Replace(str, "_vbscript:");
            str = new Regex("expression", RegexOptions.IgnoreCase).Replace(str, "_expression");
            str = new Regex("@import", RegexOptions.IgnoreCase).Replace(str, "_@import");
            str = new Regex("<iframe", RegexOptions.IgnoreCase).Replace(str, "<_iframe");
            str = new Regex("<frameset", RegexOptions.IgnoreCase).Replace(str, "<_frameset");
            str = new Regex(@" (on[a-zA-Z ]+)=", RegexOptions.IgnoreCase).Replace(str, " _$1=");
            return str;
        }


        /// <summary>
        /// �������ڱ����ύ����
        /// </summary>
        /// <remarks>�����Ƿ��ǰ�ȫURL</remarks>
        /// <param name="doMain">����</param>
        public static bool isSafeUrl(string doMain)
        {
            string[] _splictDoMain = doMain.Split(new char[] { '|' });

            foreach(string _doMain in _splictDoMain)
            {
                if (HttpContext.Current.Request.UrlReferrer == null) { return false; }
                else {
                    //string _url = HttpContext.Current.Request.UrlReferrer.ToString();
                    string _url = HttpContext.Current.Request.UrlReferrer.Host;
                    //_url = _url.Substring(0, doMain.Length);
                    if (_url.ToLower().Trim() == _doMain.ToLower().Trim()) { return true;}
                }
            }

            return false;
        }

        /// <summary>
        /// ȡMD5�ַ���
        /// </summary>
        /// <param name="str">Դ�ַ���</param>
        /// <returns>MD5�ַ���</returns>
        public static String getMd5(string str)
        {
            string cl1 = str;
            string pwd = "";
            MD5 md5 = MD5.Create();// ���ܺ���һ���ֽ����͵����� 
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl1));
            for (int i = 0; i < s.Length; i++) {// ͨ��ʹ��ѭ�������ֽ����͵�����ת��Ϊ�ַ��������ַ����ǳ����ַ���ʽ������ 
                pwd = pwd + s[i].ToString("x");// ���õ����ַ���ʹ��ʮ���������͸�ʽ����ʽ����ַ���Сд����ĸ�����ʹ�ô�д��X�����ʽ����ַ��Ǵ�д�ַ� 
            }
            return pwd;
        }

        /// <summary>
        /// ȡIP
        /// </summary>
        /// <returns>����IP</returns>
        public static string GetIp()
        {
            //string str = "";//�������������ȡԶ���û���ʵIP��ַ
            //if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            //    str = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            //else
            //    str = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            //return str;

            string result = String.Empty;
			result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (null == result || result == String.Empty)
				result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			if (null == result || result == String.Empty)
				result = HttpContext.Current.Request.UserHostAddress;
			if (null == result || result == String.Empty || !Valid.isIP(result))
				return "0.0.0.0";
			return result;
        }

        /// <summary>
        /// ȡ����ϵͳ
        /// </summary>
        /// <returns>���ز���ϵͳ</returns>
        public static string GetOS() {
            HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
            bc = System.Web.HttpContext.Current.Request.Browser;
            return bc.Platform;
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <returns>����������</returns>
        public static string GetBrowser()
        {
            HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
            bc = System.Web.HttpContext.Current.Request.Browser;
            return bc.Type;
        }

        /// <summary>
        /// ȡ��ǰURL
        /// </summary>
        /// <returns>���ص�ǰURL</returns>
        public static string GetUrl() {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// ������һҳ��URL
        /// </summary>
        /// <returns></returns>
        public static string getLastUrl() {
            return HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
        }
        /// <summary>
        /// ���ô�ҳ���ʱ��
        /// </summary>
        public static void setDateTime() {
            Cookies.Set("__sysTime", DateTime.Now.ToString());
        }
        /// <summary>
        /// �ж��Ƿ���ָ�����������ύ���ݣ����ﵽ�ж��Ƿ�ˢ��ҳ���Ŀ��
        /// </summary>
        /// <param name="seconds">��������</param>
        /// <returns>��/��</returns>
        public static bool isRefresh(int seconds) {
            string _sysTime = Cookies.Get("__sysTime");
            if (_sysTime.Trim()=="") return true;
            if (!Valid.isDateTime(_sysTime)) return true;
            DateTime _startTime = DateTime.Parse(_sysTime);
            DateTime _endTime = DateTime.Now;
            TimeSpan _value = Date.GetTimeSpan(_startTime, _endTime);
            if (_value.Seconds >= seconds) return false;
            else {
                Js.Alert("������ˢ�£�������ύ���ݣ���" + seconds.ToString() + "����ύ���ݡ�");
                return true;
            }
        }
        /// <summary>
        /// ɱ������
        /// </summary>
        /// <param name="processName">������</param>
        public static void doKill(string processName)
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(processName);// '�õ����д򿪵Ľ���
            try {
                foreach (System.Diagnostics.Process proc in procs) {
                    if (!proc.CloseMainWindow()) { proc.Kill(); }
                }
            } catch { }
        }
    }
}
