using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Cmn
{
    /// <summary>
    /// 安全操作类
    /// </summary>
    public class Safe
    {
        /// <summary>
        /// 过滤SQL字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>过滤单引号后的字符串</returns>
        static public String sqlStr(String str)
        {
            str = str.Replace("'", "''");
            return str;
        }

        /// <summary>
        /// 反格式化字符串
        /// </summary>
        /// <param name="htmlStr">要反格式化的字符串</param>
        /// <returns>反格式化完成的字符串</returns>
        public static String unHtml(string htmlStr)
        {
            string str = htmlStr.Replace("''", "'").Replace("\n", "<br />").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace(" ", "&nbsp;").Replace("\0", "");
            return str;
        }

        /// <summary>
        /// 反格式化字符串
        /// </summary>
        /// <param name="htmlStr">要反格式化的字符串</param>
        /// <returns>反格式化完成的字符串</returns>
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
        /// 不允许在本地提交数据
        /// </summary>
        /// <remarks>返回是否是安全URL</remarks>
        /// <param name="doMain">域名</param>
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
        /// 取MD5字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <returns>MD5字符串</returns>
        public static String getMd5(string str)
        {
            string cl1 = str;
            string pwd = "";
            MD5 md5 = MD5.Create();// 加密后是一个字节类型的数组 
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl1));
            for (int i = 0; i < s.Length; i++) {// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得 
                pwd = pwd + s[i].ToString("x");// 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
            }
            return pwd;
        }

        /// <summary>
        /// 取IP
        /// </summary>
        /// <returns>返回IP</returns>
        public static string GetIp()
        {
            //string str = "";//穿过代理服务器取远程用户真实IP地址
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
        /// 取操作系统
        /// </summary>
        /// <returns>返回操作系统</returns>
        public static string GetOS() {
            HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
            bc = System.Web.HttpContext.Current.Request.Browser;
            return bc.Platform;
        }

        /// <summary>
        /// 取游览器
        /// </summary>
        /// <returns>返回游览器</returns>
        public static string GetBrowser()
        {
            HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
            bc = System.Web.HttpContext.Current.Request.Browser;
            return bc.Type;
        }

        /// <summary>
        /// 取当前URL
        /// </summary>
        /// <returns>返回当前URL</returns>
        public static string GetUrl() {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 返回上一页的URL
        /// </summary>
        /// <returns></returns>
        public static string getLastUrl() {
            return HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
        }
        /// <summary>
        /// 设置打开页面的时间
        /// </summary>
        public static void setDateTime() {
            Cookies.Set("__sysTime", DateTime.Now.ToString());
        }
        /// <summary>
        /// 判断是否在指定多少秒内提交数据，来达到判断是否刷新页面的目的
        /// </summary>
        /// <param name="seconds">多少秒内</param>
        /// <returns>是/否</returns>
        public static bool isRefresh(int seconds) {
            string _sysTime = Cookies.Get("__sysTime");
            if (_sysTime.Trim()=="") return true;
            if (!Valid.isDateTime(_sysTime)) return true;
            DateTime _startTime = DateTime.Parse(_sysTime);
            DateTime _endTime = DateTime.Now;
            TimeSpan _value = Date.GetTimeSpan(_startTime, _endTime);
            if (_value.Seconds >= seconds) return false;
            else {
                Js.Alert("不允许刷新，或快速提交数据，请" + seconds.ToString() + "秒后提交数据。");
                return true;
            }
        }
        /// <summary>
        /// 杀死进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void doKill(string processName)
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(processName);// '得到所有打开的进程
            try {
                foreach (System.Diagnostics.Process proc in procs) {
                    if (!proc.CloseMainWindow()) { proc.Kill(); }
                }
            } catch { }
        }
    }
}
