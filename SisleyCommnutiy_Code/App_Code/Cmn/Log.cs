using System;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;


namespace Cmn
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class Log
    {

        #region Write
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logFileName">文件名 绝对目录</param>
        /// <param name="strings">消息</param>
        public static void Write(string logFileName,string strings)
        {
            string _path = logFileName;

            try {
                if (!System.IO.File.Exists(_path)) {
                    System.IO.FileStream f = System.IO.File.Create(_path);
                    f.Close();
                }

                System.IO.StreamWriter f2 = new System.IO.StreamWriter(_path, true, System.Text.Encoding.GetEncoding("gb2312"));//gb2312//UTF-8
                f2.WriteLine(strings);
                f2.Close();
                f2.Dispose();
            }
            catch{}
        }

        /// <summary>
        /// 写日志gb2312 UTF-8
        /// </summary>
        /// <param name="_fileName">文件</param>
        /// <param name="_string">消息</param>
        /// <param name="_encoding">编码gb2312 UTF-8</param>
        public static bool Write(string _fileName,string _string,string _encoding)
        {
            bool _isTrue = false;
            try {
                if (!System.IO.File.Exists(_fileName)) {
                    System.IO.FileStream f = System.IO.File.Create(_fileName); f.Close(); f.Dispose();
                }
                System.IO.StreamWriter f2 = new System.IO.StreamWriter(_fileName, true, System.Text.Encoding.GetEncoding(_encoding));
                f2.WriteLine(_string); f2.Close(); f2.Dispose();
                _isTrue = true;
            } catch { }
            return _isTrue;
        }
        #endregion

        /// <summary>
        /// 写日志，保存在执行文件当前目录的log目录下
        /// </summary>
        /// <param name="txt">消息内容</param>
        public static void Write(string txt)
        {
            string _fileName = AppConfig.GetAppPath();

            if(HttpContext.Current!=null) { //如果是网站
                _fileName += "/Log/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                Write(_fileName,"/*******************************************************************************************************");
                Write(_fileName, "* DateTime: " + DateTime.Now.ToString() + "		IP: " + Safe.GetIp() + "(" + Session.Get("7funAdminName") + Session.Get("7funAreaAdminName") + Session.Get("7funCityAdminName") + ")		Brower: " + Safe.GetOS() + "  " + Safe.GetBrowser());
                Write(_fileName, "* Url : " + Safe.GetUrl());
            }
            else { //是应用程序                                
                _fileName += "/Log";
                try { System.IO.Directory.CreateDirectory(_fileName); } catch{}
                _fileName += "/Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                _fileName  = _fileName.Replace("\\","/");
                Write(_fileName,"/*******************************************************************************************************");
                Write(_fileName,"DateTime: " + DateTime.Now.ToString());
            }
           
            Write(_fileName,txt);
            Write(_fileName,"*******************************************************************************************************/");
            Write(_fileName,"");        
        }
    }
}
